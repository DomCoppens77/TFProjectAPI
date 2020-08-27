using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TFProjectAPI.Helper;
using TFProjectAPI.Models.API;
using TFProjectAPI.Models.API.shop;
using S = TFProjectAPI.Client.Services;
using SM = TFProjectAPI.Client.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFProjectAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        /// <summary>
        /// Get a List of All Shops registred in the Database
        /// </summary>
        /// <returns>List of Shop Data</returns>
        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<SM.Shop> s = S.ServiceLocator.Instance.shopService.Get();
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.Shop>(HttpStatusCode.OK, null, s), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Get data of one Shop record in the Database according to ID pass in parameter
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <returns>A Shop Data</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Get(int id)
        {
            try
            {
                SM.Shop s = S.ServiceLocator.Instance.shopService.Get(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.Shop>(HttpStatusCode.OK, null, s), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Add Shop into table for Admin User(s)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Add
        ///     {
        ///        "name": "Rock Away Beat",
        ///        "address1": "Boulevard Aanspack",
        ///        "address2": "",
        ///        "zip": "1000",
        ///        "city": "Bruxelles",
        ///        "country": "BE",
        ///        "phone": "",
        ///        "email": "",
        ///        "webSite": "",
        ///        "localisationURL": "",
        ///        "closed": true
        ///      }
        /// </remarks>
        /// 
        /// <param name="sadd">Shop Data Object</param>
        /// <returns>Id of the record created</returns>
        [HttpPost]
        [Authorize(Roles = "0")]
        public IActionResult Add([FromBody] Shop_upd sadd)
        {
            try
            {
                if (!ModelState.IsValid) throw new ValidationException("Model is not meeting requirement");
                SM.Shop s = new SM.Shop(0, sadd.Name, sadd.Address1, sadd.Address2, sadd.ZIP, sadd.City, sadd.Country, sadd.Phone, sadd.Email, sadd.WebSite, sadd.LocalisationURL, sadd.Closed);
                s = S.ServiceLocator.Instance.shopService.Add(s);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.Shop>(HttpStatusCode.OK, null, s), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Update Shop into table for Admin User(s)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PUT / Upd
        ///     {
        ///        "name": "Rock Away Beat",
        ///        "address1": "Boulevard Aanspack",
        ///        "address2": "",
        ///        "zip": "1000",
        ///        "city": "Bruxelles",
        ///        "country": "BE",
        ///        "phone": "",
        ///        "email": "",
        ///        "webSite": "",
        ///        "localisationURL": "",
        ///        "closed": true
        ///      }
        /// </remarks>
        /// <param name="id">Id of the Shop to Update</param>
        /// <param name="supd">Shop Data Object</param>
        /// 
        /// <returns>Bollean for Update</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult Upd(int id, [FromBody] Shop_upd supd)
        {
            try
            {
                if (!ModelState.IsValid) throw new ValidationException("Model is not meeting requirement");
                SM.Shop s = new SM.Shop(id, supd.Name, supd.Address1, supd.Address2, supd.ZIP, supd.City, supd.Country, supd.Phone, supd.Email, supd.WebSite, supd.LocalisationURL, supd.Closed);
                bool UpdOk = S.ServiceLocator.Instance.shopService.Upd(s);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, UpdOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Delete Shop into table for Admin User(s)
        /// </summary>
        /// <param name="id">Id of the record</param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult Del(int id)
        {
            try
            {
                bool DelOk = S.ServiceLocator.Instance.shopService.Del(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, DelOk), HttpStatusCode.OK);
            }

            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Check on how many record(s) Shop Is Used
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <returns>Number of Record(s) where is used</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Used(int id)
        {
            try
            {
                int shopcnt = S.ServiceLocator.Instance.shopService.ShopIsUsed(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<int>(HttpStatusCode.OK, null, shopcnt), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }
    }
}
