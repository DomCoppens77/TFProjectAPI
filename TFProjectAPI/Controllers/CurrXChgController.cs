using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                if (!ModelState.IsValid) throw new ValidationException("Model is not meeting requirement");
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
                if (!ModelState.IsValid) throw new ValidationException("Model is not meeting requirement");
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
        ///     Get / ChkCurrXchgDtF
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
        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult ChkCurrXchgDtF([FromBody] Currency_Exchange x)
        {
            try
            {
                if (!ModelState.IsValid) throw new ValidationException("Model is not meeting requirement");
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
        ///     Get / ChkCurrXchgDtT
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
        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult ChkCurrXchgDtT([FromBody] SM.Currency_Exchange x)
        {
            try
            {
                if (!ModelState.IsValid) throw new ValidationException("Model is not meeting requirement");
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
