using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Security.Claims;
using TFProjectAPI.Helper;
using TFProjectAPI.Models;
using TFProjectAPI.Models.API;
using TFProjectAPI.Models.API.user;
using TFProjectAPI.ToolBox.Security;
using TFProjectAPI.ToolBox.Security.JWTBearerService;
using S = TFProjectAPI.Client.Services;
using SM = TFProjectAPI.Client.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFProjectAPI.Controllers
{
    /// <summary>
    /// User Controller :let's you identify yourself + Change Password + and manage Users for Admin
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Get a List of All Users registred in the Database
        /// </summary>
        /// <returns>All Users registred</returns>
        [HttpGet]
        [Authorize(Roles = "0,1")]

        //public string GetAll()
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<SM.User> u = S.ServiceLocator.Instance.usersService.Get();
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.User>(HttpStatusCode.OK, null, u), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Get Data from a specific User
        /// </summary>
        /// <param name="id">Id of the desired User</param>
        /// <returns>All data related to the choosen user</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Get(int id)
        {
            try
            {
                SM.User u = S.ServiceLocator.Instance.usersService.Get(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.User>(HttpStatusCode.OK, null, u), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Add Users into table for Admin User(s)
        /// </summary>
        /// <remarks>
        ///     POST / Add
        ///     {
        ///        "Firstname": "Coppens",
        ///        "LastName": "Domnique"
        ///        "Email": "zecoop@gmail.com"
        ///        "Passwd": "QUJDMTIz"
        ///     }
        /// </remarks>
        /// 
        /// <param name="uadd">User Data to be Added</param>
        /// <returns>User Object Created</returns>
        [HttpPost]
        [Authorize(Roles = "0")]
        public IActionResult Add([FromBody] user_add uadd)
        {
            try
            {
                if (uadd.FirstName == uadd.LastName)
                {
                    ModelState.AddModelError("LastName", "The last name cannot be the same as the first name.");
                }

                if (!ModelState.IsValid) throw new ValidationException("Model is not meeting requirement");

                // checkif email is not taken
                bool EmailOK = S.ServiceLocator.Instance.usersService.EmailIsUsed(uadd.Email);
                if (EmailOK) throw new ValidationException("Email already used :" + uadd.Email);

                SM.User u = new SM.User();
                u.FirstName = uadd.FirstName;
                u.LastName = uadd.LastName;
                u.Email = uadd.Email;
                u.Passwd = Base64.Base64Decode(uadd.Passwd);

                u = S.ServiceLocator.Instance.usersService.Add(u);

                return ApiControllerHelper.SendOk(this, new ApiResult<SM.User>(HttpStatusCode.OK, null, u), true);
            }

            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Update User into table for Admin User(s)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PUT / Upd
        ///     {
        ///        "Firstname": "Coppens",
        ///        "LastName": "Domnique"
        ///        "Email": "zecoop@gmail.com"
        ///     }
        /// </remarks>
        /// 
        /// <param name="id">Id of the desired User to update</param>
        /// <param name="uupd">User Data To Be Updated</param>
        /// <returns>Boolean for the update</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Upd(int id, [FromBody] user_upd uupd)
        {
            try
            {
                if (uupd.FirstName == uupd.LastName)
                {
                    ModelState.AddModelError("LastName", "The last name cannot be the same as the first name.");
                }

                if (!ModelState.IsValid) throw new ValidationException("Model is not meeting requirement");

                // get user to get all dtata enad mod only need dtat to update and pass user object
                SM.User u = S.ServiceLocator.Instance.usersService.Get(id);

                if (u is null) throw new AuthenticationException("Record not found for update (" + id.ToString() + ")");

                // if email orign VS emailupd <> then check email unique
                if (u.Email != uupd.Email)
                {
                    bool EmailOK = S.ServiceLocator.Instance.usersService.EmailIsUsed(uupd.Email);
                    if (EmailOK) throw new ValidationException("Email already used :" + uupd.Email);
                }

                u.Id = id;
                u.FirstName = uupd.FirstName;
                u.LastName = uupd.LastName;
                u.Email = uupd.Email;

                bool UpdOk = S.ServiceLocator.Instance.usersService.Upd(id, u); ;

                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, UpdOk), HttpStatusCode.OK);
            }

            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Delete User into table for Admin User(s)
        /// </summary>
        /// <param name="id">Id of the record</param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult Del(int id)
        {
            try
            {
                bool DelOk = S.ServiceLocator.Instance.usersService.Del(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, DelOk), HttpStatusCode.OK);
            }

            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }
    

        /// <summary>
        /// Login function allow to access Datas
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Login
        ///     {
        ///        "Email": "zecoop@gmail.com",
        ///        "Password": "QUJDMTIz"
        ///     }
        ///
        /// </remarks>
        /// <param name="l">Login Credencial With Password in BASE64 Coding to not transfert Password in clear from Client to API</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Login l)
        {
            try
            {
                SM.User u = S.ServiceLocator.Instance.usersService.Login(l.Email, Base64.Base64Decode(l.Passwd));

                if (u is null) throw new AuthenticationException("Wrong Login/passwd");

                //return Ok(new ApiResult<JWT_Bearer>(HttpStatusCode.OK, null, GenToken(u)));
                return ApiControllerHelper.SendOk(this, new ApiResult<JWT_Bearer>(HttpStatusCode.OK, null, GenToken(u)), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }


        /// <summary>
        /// Check if EMail is aleady Used
        /// </summary>
        /// <returns>True or False</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult EmailIsUsed([FromBody] Email_API em)
        {
            try
            {
                bool EmailOK = S.ServiceLocator.Instance.usersService.EmailIsUsed(em.Email);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, EmailOK), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Login
        ///     {
        ///        "Email": "zecoop@gmail.com",
        ///        "OldPasswd": "QUJDMTIz"
        ///        "Passwd": "REVGNDU2"
        ///     }
        /// </remarks>
        /// <param name="UCP">Oject with Email , Old Password in BASE64, New Password in BASE 64</param>
        [HttpPut]
        [Authorize(Roles = "0,1")]
        public IActionResult ChangePasswd([FromBody] ChangePasswd UCP)
        {

            try
            {
                bool EmailOK = S.ServiceLocator.Instance.usersService.EmailIsUsed(UCP.Email);
                if (!EmailOK) throw new ValidationException("Email Not Found :" + UCP.Email);

                S.ServiceLocator.Instance.usersService.ChangePasswd(UCP.Email, Base64.Base64Decode(UCP.OldPasswd), Base64.Base64Decode(UCP.Passwd));

                return ApiControllerHelper.SendOk(this);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Generate New Token for an already exit token
        /// </summary>
        /// <returns>New Token for the user</returns>
        [HttpPost]
        [Authorize(Roles = "0,1")]
        public IActionResult RenewToken()
        {
            try
            {
                // check if claimtype Exist in the Token
                bool hasUsernamer = HttpContext.User.HasClaim(c => c.Type == ClaimTypes.NameIdentifier);
                if (!hasUsernamer) throw new SecurityTokenException("Issue with Token (no ClaimTypes.NameIdentifier)");

                // get back value ID from the Token & tryto Parse into Int
                string valueUsername = HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                int id2w;
                bool ParseSuccess = int.TryParse(valueUsername, out id2w);

                if (!ParseSuccess) throw new SecurityTokenException("Issue with Token (TryParse)" + valueUsername);

                // Get back user data
                SM.User u = S.ServiceLocator.Instance.usersService.Get(id2w);
                if (u is null) throw new AuthenticationException("Record not found for Renew Token (" + id2w.ToString() + ")");

                return ApiControllerHelper.SendOk(this, new ApiResult<JWT_Bearer>(HttpStatusCode.OK, null, GenToken(u)), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Generate Token according to User information
        /// </summary>
        /// <param name="u">User Object, to user ID,EMail,Status </param>
        /// <returns>New Token</returns>
        private JWT_Bearer GenToken(SM.User u)
        {
            JWT_Bearer JWTB = new JWT_Bearer();
            if (u != null)
            {
                JwtService jwt = new JwtService(_config);
                JWTB.id = u.Id;
                JWTB.ExpirationDateTime = DateTime.UtcNow.AddMinutes(double.Parse(_config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value));
                JWTB.BearerJWT = jwt.GenerateSecurityToken(u.Email, u.Status.ToString(), u.Id.ToString()); ;
            }
            return JWTB;
        }
    }
}
