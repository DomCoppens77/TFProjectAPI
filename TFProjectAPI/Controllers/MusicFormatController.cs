using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TFProjectAPI.Helper;
using TFProjectAPI.Models.API;
using TFProjectAPI.Models.API.MusicFormat;
using S = TFProjectAPI.Client.Services;
using SM = TFProjectAPI.Client.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFProjectAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MusicFormatController : ControllerBase
    {
        /// <summary>
        /// Get a List of All Music Format registred in the Database
        /// </summary>
        /// <returns>List of Music Format Data</returns>
        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<SM.MusicFormat> mf = S.ServiceLocator.Instance.MusicFormatService.Get();
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.MusicFormat>(HttpStatusCode.OK, null, mf), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Get data of one Music Format record in the Database according to ID pass in parameter
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <returns>A Music Format Data</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Get(int id)
        {
            try
            {
                SM.MusicFormat mf = S.ServiceLocator.Instance.MusicFormatService.Get(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.MusicFormat>(HttpStatusCode.OK, null, mf), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Add Music Format into table for Admin User(s)
        /// </summary>
        /// <remarks>
        ///     POST / Add
        ///     {
        ///        "name": "D",
        ///     }
        /// </remarks>
        /// <param name="mf"></param>
        /// <returns>id of the record created</returns>
        [HttpPost]
        [Authorize(Roles = "0")]
        public IActionResult Add([FromBody] MusicFormat mf)
        {
            try 
            { 
                if (!ModelState.IsValid) throw new ValidationException("Model is not meeting requirement");
                SM.MusicFormat mfo = new SM.MusicFormat(0, mf.Name);
                mfo = S.ServiceLocator.Instance.MusicFormatService.Add(mfo);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.MusicFormat>(HttpStatusCode.OK, null, mfo), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Update Music Format into table for Admin User(s)
        /// </summary>
        /// <remarks>
        ///     PUT / Upd
        ///     {
        ///        "name": "D",
        ///     }
        /// </remarks>
        /// <param name="id">Id of Record to Upd</param>
        /// <param name="mf"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult Upd(int id,[FromBody] MusicFormat mf)
        {
            try
            {
                if (!ModelState.IsValid) throw new ValidationException("Model is not meeting requirement");
                SM.MusicFormat mfo = new SM.MusicFormat(id, mf.Name);
                bool UpdOk = S.ServiceLocator.Instance.MusicFormatService.Upd(mfo);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, UpdOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Delete Music Format into table for Admin User(s)
        /// </summary>
        /// <param name="id">Id of the record</param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult Del(int id)
        {
            try
            {
                bool DelOk = S.ServiceLocator.Instance.MusicFormatService.Del(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, DelOk), HttpStatusCode.OK);
            }

            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }
        /// <summary>
        /// Check on how many record(s) Music Format Is Used
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <returns>Number of Record(s) where is used</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Used(int id)
        {
            try
            {
                int MFCount = S.ServiceLocator.Instance.MusicFormatService.MusicFormatIsUsed(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<int>(HttpStatusCode.OK, null, MFCount), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }
    }
}
