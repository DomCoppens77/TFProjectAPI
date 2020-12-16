using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Helper;
using TFProjectAPI.Models.API;
using TFProjectAPI.Models.API.ObjectDOM;
using S = TFProjectAPI.Client.Services;
using SM = TFProjectAPI.Client.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFProjectAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class GeneralTypeController : ControllerBase
    {
        private string where = "AGT";

        /// <summary>
        /// Get a List of All General Type record(s) in the Database
        /// </summary>
        /// <returns>List of General Type Data</returns>
        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult GetAll()
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
                if (id < 1) throw new IndexOutOfRangeException("ID must be greater than 0 (" + where + ") (GET)");
                SM.GeneralType gt = S.ServiceLocator.Instance.GeneralTypeService.Get(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.GeneralType>(HttpStatusCode.OK, null, gt), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult GetYP()
        {
            try
            {
                IEnumerable<SM.GenYearPurch> yp = S.ServiceLocator.Instance.GeneralTypeService.GetYP();
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.GenYearPurch>(HttpStatusCode.OK, null, yp), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        //[HttpGet("{page,search}")]
        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult SearchODesc([FromQuery] int page, [FromQuery] string search)
        {
            try
            {
                if (page < 1) throw new DataException("Page Number must be at least 1 (" + where + ") (ST)");
                if (search.Length == 0) throw new DataException("Search String can't be BLANK (" + where + ") (ST)");

                int jump, records, maxpages = 1;
                Code_Mstr cdm = S.ServiceLocator.Instance.CodeMstrService.Get(new Code_Mstr("CONFIGURATION", "JUMP_OBJECT", ""));
                if (!int.TryParse(cdm.Code_Desc, out jump)) jump = 50;

                records = S.ServiceLocator.Instance.GeneralTypeService.SearchTextCnt(search);
                IEnumerable<GenObjectSearch> objs = null;
                if (records > 0)
                {
                    if (records > jump)
                    {
                        maxpages = records / jump;
                        if (records % jump > 0) maxpages += 1;
                    }

                    if (page <= maxpages)
                    {
                        objs = S.ServiceLocator.Instance.GeneralTypeService.SearchText(page, jump, search);
                    }
                    if (objs != null && objs.OfType<GenObjectSearch>().Count() == 0) objs = null;
                }
                ObjectDTO odto = new ObjectDTO(records, maxpages, page, jump, objs);

                return ApiControllerHelper.SendOk(this, new ApiResult<ObjectDTO>(HttpStatusCode.OK, null, odto), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult SearchOEAN([FromQuery] int page, [FromQuery] string search)
        {
            try
            {
                if (page < 1) throw new DataException("Page Number must be at least 1 (" + where + ") (ST)");
                if (search.Length == 0) throw new DataException("Search String can't be BLANK (" + where + ") (ST)");

                int jump, records, maxpages = 1;
                Code_Mstr cdm = S.ServiceLocator.Instance.CodeMstrService.Get(new Code_Mstr("CONFIGURATION", "JUMP_OBJECT", ""));
                if (cdm is null) jump = 50;
                else if (!int.TryParse(cdm.Code_Desc, out jump)) jump = 50;

                records = S.ServiceLocator.Instance.GeneralTypeService.SearchEANcnt(search);
                IEnumerable<GenObjectSearch> objs = null;
                if (records > 0)
                {
                    if (records > jump)
                    {
                        maxpages = records / jump;
                        if (records % jump > 0) maxpages += 1;
                    }

                    if (page <= maxpages)
                    {
                        objs = S.ServiceLocator.Instance.GeneralTypeService.SearchEAN(page, jump, search);
                    }
                    if (objs != null && objs.OfType<GenObjectSearch>().Count() == 0) objs = null;
                }

                ObjectDTO odto = new ObjectDTO(records, maxpages, page, jump, objs);

                return ApiControllerHelper.SendOk(this, new ApiResult<ObjectDTO>(HttpStatusCode.OK, null, odto), true);
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
                if (id < 1) throw new IndexOutOfRangeException("ID must be greater than 0 (" + where + ") (USED)");
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
