using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using TFProjectAPI.Helper;
using TFProjectAPI.Models.API;
using S = TFProjectAPI.Client.Services;
using SM = TFProjectAPI.Client.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFProjectAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class GeneralTypeController : ControllerBase
    {
        /// <summary>
        /// Get a List of All General Type record(s) in the Database
        /// </summary>
        /// <returns>List of General Type Data</returns>
        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<SM.GeneralType> gt = S.ServiceLocator.Instance.GeneralTypeService.Get();
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.GeneralType>(HttpStatusCode.OK, null, gt), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        ///  Get data of one General Type record in the Database according to ID pass in parameter
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <returns>A General Type Data</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Get(int id)
        {
            try
            {
                SM.GeneralType gt = S.ServiceLocator.Instance.GeneralTypeService.Get(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.GeneralType>(HttpStatusCode.OK, null, gt), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Count the number of object that have the requested type
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <returns>Number of Records having this particular type</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Used(int id)
        {
            try
            {
                int GenTypeCnt = S.ServiceLocator.Instance.GeneralTypeService.IsUsed(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<int>(HttpStatusCode.OK, null, GenTypeCnt), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }
    }
}
