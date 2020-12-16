using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
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
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private string where = "US";
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
                if (id < 1) throw new IndexOutOfRangeException("ID must be greater than 0 (" + where + ") (GET)");
                SM.User u = S.ServiceLocator.Instance.usersService.Get(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.User>(HttpStatusCode.OK, null, u), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// 
        /// Add Users into table for Admin User(s)
        /// </summary>
        /// <remarks>
        ///     POST / Add
        ///     {
        ///        "Firstname": "Coppens",
        ///        "LastName": "Domnique"
        ///        "Email": "zecoop@gmail.com"
        ///        "Passwd": "QUJDMTIz"  (Coded in base 64)
        ///        "SecretAnswer" : "TVVIQURJQg==" (Coded in base 64)
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
                    throw new ValidationException("The last name cannot be the same as the first name. (" + where + ") (RESET)");

                if (uadd.Email.Length == 0) throw new ValidationException("Email empty");

                // checkif email is not taken
                bool EmailOK = S.ServiceLocator.Instance.usersService.EmailIsUsed(uadd.Email);
                if (EmailOK) throw new ValidationException("Email already used :" + uadd.Email);

                SM.User u = new SM.User();
                u.FirstName = uadd.FirstName;
                u.LastName = uadd.LastName;
                u.Email = uadd.Email;
                u.Passwd = Base64.Base64Decode(uadd.Passwd);
                u.SecretAnswer = Base64.Base64Decode(uadd.SecretAnswer);
                u.Avatar = uadd.Avatar;

                u = S.ServiceLocator.Instance.usersService.Add(u);
                u.Passwd = "";        /* put passwd BLANK */
                u.SecretAnswer = "";  /* put Secret BLANK */

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
        ///        "Status"  : 1 or 0
        ///        "Avatar"  : Image in BASE64 or ''
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

                if (id < 1) throw new IndexOutOfRangeException("ID must be greater than 0 (" + where + ") (UPD)");

                if (uupd.FirstName == uupd.LastName)
                {
                    ModelState.AddModelError("LastName", "The last name cannot be the same as the first name.");
                }

                //if (uupd.Status > 1) throw new DataException("Wrong USer Status");

                // get user to get all dtata enad mod only need dtat to update and pass user object
                SM.User u = S.ServiceLocator.Instance.usersService.Get(id);

                if (u is null) throw new AuthenticationException("Record not found for update (" + id.ToString() + ") (" + where + ") (RESET)");


                // if email orign VS emailupd <> then check email unique
                //if (u.Email != uupd.Email)
                //{
                //    bool EmailOK = S.ServiceLocator.Instance.usersService.EmailIsUsed(uupd.Email);
                //    if (EmailOK) throw new ValidationException("Email already used :" + uupd.Email);
                //}

                u.Id = id;
                u.FirstName = uupd.FirstName;
                u.LastName = uupd.LastName;
                u.Status = uupd.Status;
                u.Avatar = uupd.Avatar;

                bool UpdOk = S.ServiceLocator.Instance.usersService.Upd(id, u); ;

                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, UpdOk), HttpStatusCode.OK);
            }

            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Delete User into table for Admin User(s) (It's a soft deleted, user can be reactivate by Admin with ReactivateUser method
        /// </summary>
        /// <param name="id">Id of the record</param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult Del(int id)
        {
            try
            {
                if (id < 1) throw new IndexOutOfRangeException("ID must be greater than 0 (" + where + ") (GET)");
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

                if (u is null) throw new AuthenticationException("Wrong Login/passwd (" + where + ") (LOGIN)");

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
                if (UCP.Email.Length == 0) throw new ValidationException("Email empty (" + where + ") (CHG)");
                if (UCP.OldPasswd.Length == 0) throw new ValidationException("Old Password empty (" + where + ") (CHG)");
                if (UCP.Passwd.Length == 0) throw new ValidationException("Password empty (" + where + ") (CHG)");

                bool EmailOK = S.ServiceLocator.Instance.usersService.EmailIsUsed(UCP.Email);
                if (!EmailOK) throw new ValidationException("Email Not Found :" + UCP.Email);

                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, S.ServiceLocator.Instance.usersService.ChangePasswd(UCP.Email, Base64.Base64Decode(UCP.OldPasswd), Base64.Base64Decode(UCP.Passwd))), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Reset Password o a user using a secret Answer
        /// Secret Answer could be anything, the name o your mother, your firsdt pet Name, you favorite band, your choice
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Login
        ///     {
        ///        "Email": "zecoop@gmail.com",
        ///        "Secret Answer": "TVVIQURJQg=="
        ///        "Passwd": "REVGNDU2"
        ///     }
        /// </remarks>
        /// <param name="URP">Object with Email , Secret Answer in BASE64, New Password in BASE 64</param>
        /// <returns></returns>
        [HttpPut]
        [AllowAnonymous]
        public IActionResult ResetPasswd([FromBody] ResetPassword URP)
        {
            try
            {
                if (URP.Email.Length == 0) throw new ValidationException("Email empty (" + where + ") (RESET)");
                if (URP.Passwd.Length == 0) throw new ValidationException("password empty (" + where + ") (RESET)");
                if (URP.SecretAnswer.Length == 0) throw new ValidationException("Secret Answer empty (" + where + ") (RESET");

                bool EmailOK = S.ServiceLocator.Instance.usersService.EmailIsUsed(URP.Email);
                if (!EmailOK) throw new ValidationException("Email Not Found :" + URP.Email);

                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, S.ServiceLocator.Instance.usersService.ResetPasswd(URP.Email, Base64.Base64Decode(URP.SecretAnswer), Base64.Base64Decode(URP.Passwd))), true);

            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        ///   Reactivate a 'Soft' Deleted USer, when U are admin
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult ReactivateUser(int id)
        {
            try
            {
                if (id < 1) throw new IndexOutOfRangeException("ID must be greater than 0 (" + where + ") (REACT)");
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, S.ServiceLocator.Instance.usersService.ReactivateUser(id)), true);
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
        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult RenewToken()
        {
            try
            {
                // check if claimtype Exist in the Token
                bool hasUsernamer = HttpContext.User.HasClaim(c => c.Type == ClaimTypes.NameIdentifier);
                if (!hasUsernamer) throw new SecurityTokenException("Issue with Token (no ClaimTypes.NameIdentifier (" + where + ") (RENEW)");

                // get back value ID from the Token & tryto Parse into Int
                string valueUsername = HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                int id2w;
                bool ParseSuccess = int.TryParse(valueUsername, out id2w);

                if (!ParseSuccess) throw new SecurityTokenException("Issue with Token (TryParse)" + valueUsername + " (" + where + ") (RENEW)"); 

                // Get back user data
                SM.User u = S.ServiceLocator.Instance.usersService.Get(id2w);
                if (u is null) throw new AuthenticationException("Record not found for Renew Token (" + id2w.ToString() + ") (" + where + ") (RENEW)");

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
                JWTB.ExpirationDateTime = DateTime.Now.AddMinutes(double.Parse(_config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value));
                JWTB.BearerJWT = jwt.GenerateSecurityToken(u.Email, u.Status.ToString(), u.Id.
                    ToString()); ;
            }
            return JWTB;
        }
    }
}
