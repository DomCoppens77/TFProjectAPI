using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net;
using TFProjectAPI.Helper;
using TFProjectAPI.Models.API;
using TFProjectAPI.Models.API.MusicType;
using S = TFProjectAPI.Client.Services;
using SM = TFProjectAPI.Client.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFProjectAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MusicTypeController : ControllerBase
    {

        private string where = "AMT";

        /// <summary>
        /// Get a List of All Music Type registred in the Database
        /// </summary>
        /// <returns>List of Music Type Data</returns>
        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<SM.MusicType> mt = S.ServiceLocator.Instance.MusicTypeService.Get();
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.MusicType>(HttpStatusCode.OK, null, mt), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Get data of one Music Type record in the Database according to ID pass in parameter
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <returns>A Music Type Data</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id < 1) throw new IndexOutOfRangeException("ID must be greater than 0 (" + where + ") (GET)");
                SM.MusicType mt = S.ServiceLocator.Instance.MusicTypeService.Get(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.MusicType>(HttpStatusCode.OK, null, mt), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Add Music Type into table for Admin User(s)
        /// </summary>
        /// <remarks>
        ///     POST / Add
        ///     {
        ///        "name": "D",
        ///     }
        /// </remarks>
        /// <param name="mt"></param>
        /// <returns>id of the record created</returns>
        [HttpPost]
        [Authorize(Roles = "0")]
        public IActionResult Add([FromBody] MusicType mt)
        {
            try
            {
                if (mt is null) throw new ArgumentNullException("Music Type Object Empty (" + where + ") (ADD)");
                if (mt.Name.Length == 0) throw new DataException("Music Type NAme can't be BLANK (" + where + ") (ADD)");
                SM.MusicType mto = new SM.MusicType(0,mt.Name);
                mto = S.ServiceLocator.Instance.MusicTypeService.Add(mto);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.MusicType>(HttpStatusCode.OK, null, mto), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Update Music Type into table for Admin User(s)
        /// </summary>
        /// <remarks>
        ///     PUT / Upd
        ///     {
        ///        "name": "D",
        ///     }
        /// </remarks>
        /// <param name="id">Id of Record to Upd</param>
        /// <param name="mt"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult Upd(int id, [FromBody] MusicType mt)
        {
            try
            {
                if (id < 1) throw new IndexOutOfRangeException("ID must be greater than 0 (" + where + ") (UPD)");
                if (mt is null) throw new ArgumentNullException("Music Type Object Empty (" + where + ") (UPD)");
                if (mt.Name.Length == 0) throw new DataException("Music Type NAme can't be BLANK (" + where + ") (UPD)");

                SM.MusicType mto = new SM.MusicType(id, mt.Name);
                bool UpdOk = S.ServiceLocator.Instance.MusicTypeService.Upd(mto);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, UpdOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Delete Music Type into table for Admin User(s)
        /// </summary>
        /// <param name="id">Id of the record</param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult Del(int id)
        {
            try
            {
                if (id < 1) throw new IndexOutOfRangeException("ID must be greater than 0 (" + where + ") (DEL)");
                bool DelOk = S.ServiceLocator.Instance.MusicTypeService.Del(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, DelOk), HttpStatusCode.OK);
            }

            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Check on how many record(s) Music Type Is Used
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <returns>Number of Record(s) where is used</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Used(int id)
        {
            try
            {
                if (id < 1) throw new IndexOutOfRangeException("ID must be greater than 0 (" + where + ") (USED)");
                int MTCount = S.ServiceLocator.Instance.MusicTypeService.MusicTypeIsUsed(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<int>(HttpStatusCode.OK, null, MTCount) , HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

    }
}
