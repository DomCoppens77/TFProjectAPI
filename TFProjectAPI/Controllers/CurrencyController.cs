using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TFProjectAPI.Helper;
using TFProjectAPI.Models.API;
using TFProjectAPI.Models.API.Currency;
using S = TFProjectAPI.Client.Services;
using SM = TFProjectAPI.Client.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFProjectAPI.Controllers
{
    /// <summary>
    /// User Controller Give List of Curriencies + and manage Currency for Admin
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private string where = "ACURR";
        /// <summary>
        ///  Get a List of All Currencies record(s) in the Database
        /// </summary>
        /// <returns>List of Currencies Data</returns>
        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<SM.Currency> cur = S.ServiceLocator.Instance.CurrencyService.Get();
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.Currency>(HttpStatusCode.OK, null, cur), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        ///  Get data of one specified Currency record in the Database according to Currency ISO code pass in parameter
        /// </summary>
        /// <param name="curr">Currency Code ISO (3 Characters)</param>
        /// <returns>A Currency Data</returns>
        [HttpGet("{curr}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Get([FromRoute] string curr)
        {

            try
            {
                if (curr.Length != 3) throw new IndexOutOfRangeException("Currency must be 3 digits (" + where + ") (GET)");
                SM.Currency cur = S.ServiceLocator.Instance.CurrencyService.Get(curr);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.Currency>(HttpStatusCode.OK, null, cur), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Add currency for Admin  User(s)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Add
        ///     {
        ///        "Curr": "EUR",
        ///        "Desc": "Euro",
        ///     }
        /// </remarks>
        /// <param name="cur">Currency Object (Curr,Desc)</param>
        [HttpPost]
        [Authorize(Roles = "0")]
        public IActionResult Add([FromBody] Currency cur)
        {
            try
            {
                if (cur is null) throw new ArgumentNullException("Currency Object Empty (" + where + ") (ADD)");
                if (cur.Curr is null) throw new ArgumentNullException("Currency Curr Empty (" + where + ") (ADD)");
                if (cur.Curr.Length != 3) throw new IndexOutOfRangeException("Currency must be 3 digits (" + where + ") (ADD)");
                SM.Currency curo = new SM.Currency(cur.Curr, cur.Desc);
                S.ServiceLocator.Instance.CurrencyService.Add(curo);
                return ApiControllerHelper.SendOk(this);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Update currency for Admin  User(s)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PUT / Upd
        ///     {
        ///        "Curr": "EUR",
        ///        "Desc": "Euro",
        ///     }
        /// </remarks>/// 
        /// <param name="cur">Currency Object (Curr,Desc)</param>
        [HttpPut]
        [Authorize(Roles = "0")]
        public IActionResult Upd([FromBody] SM.Currency cur)
        {
            try
            {
                if (cur is null) throw new ArgumentNullException("Currency Object Empty (" + where + ") (UPD)");
                if (cur.Curr is null) throw new ArgumentNullException("Currency Curr Empty (" + where + ") (UPD)");
                if (cur.Curr.Length != 3) throw new IndexOutOfRangeException("Currency must be 3 digits (" + where + ") (UPD)");
                SM.Currency curo = new SM.Currency(cur.Curr, cur.Desc);
                bool UpdOk = S.ServiceLocator.Instance.CurrencyService.Upd(curo);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, UpdOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Delete Currency record into table for Admin User(s)
        /// </summary>
        /// <param name="curr">Currency Code ISO (3 Characters)(</param>
        [HttpDelete("{curr}")]
        [Authorize(Roles = "0")]
        public IActionResult Del([FromRoute] string curr)
        {
            try
            {
                if (curr.Length != 3) throw new IndexOutOfRangeException("Currency must be 3 digits (" + where + ") (DEL)");
                bool DelOk = S.ServiceLocator.Instance.CurrencyService.Del(curr);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, DelOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Is Currency used in the database (Object)
        /// </summary>
        /// <param name="curr">Currency Code ISO (3 Characters)</param>
        /// <returns>Nbr Record(s) that use that choosen currency</returns>
        [HttpGet("{curr}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Used([FromRoute] string curr)
        {
            try
            {
                if (curr.Length != 3) throw new IndexOutOfRangeException("Currency must be 3 digits (" + where + ") (USED)");
                int CurrCnt = S.ServiceLocator.Instance.CurrencyService.CurrencyIsUsed(curr);
                return ApiControllerHelper.SendOk(this, new ApiResult<int>(HttpStatusCode.OK, null, CurrCnt), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

    }
}
