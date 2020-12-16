using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TFProjectAPI.Helper;
using TFProjectAPI.Models.API;
using TFProjectAPI.Models.API.Country;
using S = TFProjectAPI.Client.Services;
using SM = TFProjectAPI.Client.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFProjectAPI.Controllers
{
    /// <summary>
    /// User Controller Give List of Countries + and manage Ctry for Admin
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private string where = "ACTRY";
        /// <summary>
        /// Get a List of All Countries registred in the Database
        /// </summary>
        /// <returns>Countries data Registred</returns>
        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<SM.Country> ctry = S.ServiceLocator.Instance.CountryService.Get();
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.Country>(HttpStatusCode.OK, null, ctry), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);

            }
        }

        /// <summary>
        /// Get data of one specified Country registred in the Database according to Country ISO code pass in parameter
        /// </summary>
        /// <param name="iso">Country Code ISO (2 Characters)</param>
        /// <returns>Country data Registred</returns>
        [HttpGet("{iso}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Get([FromRoute] String iso)
        {
            try
            {
                if (iso.Length != 2) throw new IndexOutOfRangeException("Country must be 2 digits (" + where + ") (GET)");

                SM.Country ctry = S.ServiceLocator.Instance.CountryService.Get(iso);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.Country>(HttpStatusCode.OK, null, ctry), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Add country into table for Admin User(s)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Add
        ///     {
        ///        "ISO": "BE",
        ///        "Ctry": "BELGIUM",
        ///        IsEU : false
        ///     }
        ///
        /// </remarks>
        /// <param name="ctry">Ctry Object (ISO,Ctry,IsEU)</param>
        [HttpPost]
        [Authorize(Roles = "0")]
        public IActionResult Add([FromBody] Country ctry)
        {
            try
            {
                if (ctry is null) throw new ArgumentNullException("Currency Exchange Object Empty (" + where + ") (ADD)");
                if (ctry.ISO.Length != 2) throw new IndexOutOfRangeException("Country must be 2 digits (" + where + ") (ADD)");

                SM.Country ctryo = new SM.Country(ctry.ISO, ctry.Ctry, ctry.IsEU);
                S.ServiceLocator.Instance.CountryService.Add(ctryo);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.Country>(HttpStatusCode.OK, null, ctryo), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Update country into table for Admin User(s)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PUT / Upd
        ///     {
        ///        "ISO": "BE",
        ///        "Ctry": "BELGIUM",
        ///        IsEU : false
        ///     }
        ///
        /// </remarks>
        /// <param name="ctry">Ctry Object (ISO,Ctry,IsEU)</param>
        [HttpPut]
        [Authorize(Roles = "0")]
        public IActionResult Upd([FromBody] Country ctry)
        {
            try
            {
                if (ctry is null) throw new ArgumentNullException("Currency Exchange Object Empty (" + where + ") (UPD)");
                if (ctry.ISO.Length != 2) throw new IndexOutOfRangeException("Country must be 2 digits (" + where + ") (UPD)");

                SM.Country ctryo = new SM.Country(ctry.ISO, ctry.Ctry, ctry.IsEU);
                bool UpdOk = S.ServiceLocator.Instance.CountryService.Upd(ctryo);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, UpdOk), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Delete Country record into table for Admin User(s)
        /// </summary>
        /// <param name="iso">ISO Country Code to Delete</param>
        [HttpDelete("{iso}")]
        [Authorize(Roles = "0")]
        public IActionResult Del([FromRoute] string iso)
        {
            try
            {
                if (iso.Length != 2) throw new IndexOutOfRangeException("Country must be 2 digits (" + where + ") (GET)");
                bool DelOk = S.ServiceLocator.Instance.CountryService.Del(iso);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, DelOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }
        
        [HttpGet("{iso}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Used([FromRoute] string iso)
        {
            try
            {
                if (iso.Length != 2) throw new IndexOutOfRangeException("Country must be 2 digits (" + where + ") (GET)");
                int CtryCnt = S.ServiceLocator.Instance.CountryService.IsUsed(iso);
                return ApiControllerHelper.SendOk(this, new ApiResult<int>(HttpStatusCode.OK, null, CtryCnt), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

    }
}
