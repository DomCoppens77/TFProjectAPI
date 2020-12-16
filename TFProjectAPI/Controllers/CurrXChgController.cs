using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net;
using TFProjectAPI.Helper;
using TFProjectAPI.Models.API;
using TFProjectAPI.Models.API.CurrX;
using S = TFProjectAPI.Client.Services;
using SM = TFProjectAPI.Client.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFProjectAPI.Controllers
{
    /// <summary>
    /// User Controller Give List of Curriencies XREF + and manage Curr XREF for Admin
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CurrXChgController : ControllerBase
    {
        private string where = "ACX";
        /// <summary>
        /// Get a List of All Currency Exchange record(s) in the Database
        /// </summary>
        /// <returns>List of Currency Exchange Data</returns>
        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<SM.Currency_Exchange> curx = S.ServiceLocator.Instance.Currency_ExchangeService.Get();
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.Currency_Exchange>(HttpStatusCode.OK, null, curx), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Get data of one Currency Exchange record in the Database
        /// </summary>
        /// <param name="id">Id of the record desired</param>
        /// <returns>Currency Exchange Data</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id < 1) throw new IndexOutOfRangeException("ID must be greater than 0 (" + where + ") (GET)");
                SM.Currency_Exchange curx = S.ServiceLocator.Instance.Currency_ExchangeService.Get(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.Currency_Exchange>(HttpStatusCode.OK, null, curx), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Add Currency Exchange for Admin  User(s)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Add
        ///     {
        ///       "dateFrom": "2020-08-26",
        ///       "dateTo": "2020-08-26",
        ///       "currFrom": "EUR",
        ///       "currTo": "USD",
        ///       "rate": 0.87
        ///     }
        /// </remarks>
        /// <param name="x">Currency Exchange Object Without ID</param>
        [HttpPost]
        [Authorize(Roles = "0")]
        public IActionResult Add([FromBody] Currency_Exchange x)
        {
            try
            {
                if (x is null) throw new ArgumentNullException("Currency Exchange Object Empty (" + where + ") (ADD)");
                if (x.CurrFrom.Length != 3) throw new DataException("Currency From must be 3 digits (" + where + ") (ADD)");
                if (x.CurrTo.Length != 3) throw new DataException("Currency To must be 3 digits (" + where + ") (ADD)");
                if (x.DateFrom > x.DateTo) throw new DataException("Date From Bigger than Date To (" + where + ") (ADD)");

                S.ServiceLocator.Instance.Currency_ExchangeService.Add(new SM.Currency_Exchange(0, x.CurrFrom, x.CurrTo, x.DateFrom, x.DateTo, x.Rate));
                return ApiControllerHelper.SendOk(this);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Update Currency Exchange for Admin  User(s)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PUT / Upd
        ///     {
        ///       "dateFrom": "2020-08-26",
        ///       "dateTo": "2020-08-26",
        ///       "currFrom": "EUR",
        ///       "currTo": "USD",
        ///       "rate": 0.87
        ///     }
        /// </remarks>
        /// <param name="id">ID  to update</param>
        /// <param name="x">Currency Exchange Data</param>
        /// <returns>Boolean for update </returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult Upd(int id, [FromBody] Currency_Exchange x)
        {
            try
            {
                if (id < 1) throw new IndexOutOfRangeException("ID must be greater than 0 (" + where + ") (UPD)");
                if (x is null) throw new ArgumentNullException("Currency Exchange Object Empty (" + where + ") (UPD)");
                if (x.CurrFrom.Length != 3) throw new DataException("Currency From must be 3 digits (" + where + ") (UPD)");
                if (x.CurrTo.Length != 3) throw new DataException("Currency To must be 3 digits (" + where + ") (UPD)");
                if (x.DateFrom > x.DateTo) throw new DataException("Date From Bigger than Date To (" + where + ") (UPD)");

                bool UpdOk = S.ServiceLocator.Instance.Currency_ExchangeService.Upd(new SM.Currency_Exchange(id, x.CurrFrom, x.CurrTo, x.DateFrom, x.DateTo, x.Rate));
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, UpdOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Delete Currency Exchange for Admin  User(s)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean for deletion</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult Del(int id)
        {
            try
            {
                if (id < 1) throw new IndexOutOfRangeException("ID must be greater than 0 (" + where + ") (DEL)");
                bool DelOk = S.ServiceLocator.Instance.Currency_ExchangeService.Del(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, DelOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Check Date From for new Currency Excange Record
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     Get / ChkCurrXDtF
        ///     {
        ///       "dateFrom": "2020-08-26",
        ///       "dateTo": "2020-08-26",
        ///       "currFrom": "EUR",
        ///       "currTo": "USD",
        ///       "rate": 0.87
        ///     }
        /// </remarks>
        /// <param name="x">Currency Exchange Object Without ID</param>
        /// <returns>Counter of record(s) found</returns>
        [HttpPost]
        [Authorize(Roles = "0,1")]
        public IActionResult ChkCurrXDtF([FromBody] Currency_Exchange x)
        {
            try
            {
                if (x is null) throw new ArgumentNullException("Currency Exchange Object Empty (" + where + ") (CF)");
                if (x.CurrFrom.Length == 3) throw new DataException("Currency From must be 3 digits (" + where + ") (CF)");
                if (x.CurrTo.Length == 3) throw new DataException("Currency To must be 3 digits (" + where + ") (CF)");

                int RcdCntFrom = S.ServiceLocator.Instance.Currency_ExchangeService.Check_DateF(new SM.Currency_Exchange(0, x.CurrFrom, x.CurrTo, x.DateFrom, x.DateTo, x.Rate));
                return ApiControllerHelper.SendOk(this, new ApiResult<int>(HttpStatusCode.OK, null, RcdCntFrom), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Check Date To for new Currency Excange Record
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     Get / ChkCurrXDtT
        ///     {
        ///       "dateFrom": "2020-08-26",
        ///       "dateTo": "2020-08-26",
        ///       "currFrom": "EUR",
        ///       "currTo": "USD",
        ///       "rate": 0.87
        ///     }
        /// </remarks>
        /// <param name="x">Currency Exchange Object Without ID</param>
        /// <returns>Counter of record(s) found</returns>
        [HttpPost]
        [Authorize(Roles = "0,1")]
        public IActionResult ChkCurrXDtT([FromBody] SM.Currency_Exchange x)
        {
            try
            {
                if (x is null) throw new ArgumentNullException("Currency Exchange Object Empty (" + where + ") (CT)");
                if (x.CurrFrom.Length == 3) throw new DataException("Currency From must be 3 digits (" + where + ") (CT)");
                if (x.CurrTo.Length == 3) throw new DataException("Currency To must be 3 digits (" + where + ") (CT)");

                int RcdCntTo = S.ServiceLocator.Instance.Currency_ExchangeService.Check_DateT(new SM.Currency_Exchange(0, x.CurrFrom, x.CurrTo, x.DateFrom, x.DateTo, x.Rate));
                return ApiControllerHelper.SendOk(this, new ApiResult<int>(HttpStatusCode.OK, null, RcdCntTo), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }
    }
}
