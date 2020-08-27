﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TFProjectAPI.Helper;
using TFProjectAPI.Models.API;
using TFProjectAPI.Models.API.Music;
using S = TFProjectAPI.Client.Services;
using SM = TFProjectAPI.Client.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TFProjectAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        /// <summary>
        /// Get a List of All Music record(s) in the Database
        /// </summary>
        /// <returns>List Of Music Data</returns>
        [HttpGet]
        [Authorize(Roles = "0,1")]
        public IActionResult GetAll()
        {
            
            try
            {
                IEnumerable<SM.Music> mus = S.ServiceLocator.Instance.MusicService.Get();
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.Music>(HttpStatusCode.OK, null, mus), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Get data of one specified Music record in the Database according to ID pass in parameter
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <returns>A Music Data</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "0,1")]
        public IActionResult Get(int id)
        {
            try
            {
                SM.Music mus = S.ServiceLocator.Instance.MusicService.Get(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<SM.Music>(HttpStatusCode.OK, null, mus), true);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Add Music record into table for Admin User(s)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST / Add
        ///     {
        ///        "price": 400,
        ///        "curr": "BEF",
        ///        "shopId": 25,
        ///        "date": "1993-07-26",
        ///        "typeId": 1,
        ///        "signed": false,
        ///        "signedBy": "",
        ///        "ean": "'731451002229",
        ///        "eaN_EXT": "",
        ///        "comment1": "",
        ///        "comment2": "",
        ///        "onwed": true,
        ///        "band": "Metallica",
        ///        "title": "Black Album",
        ///        "year": 1991,
        ///        "tracks": "12",
        ///        "nbCDs": 1,
        ///        "nbDvds": 0,
        ///        "nbLps": 0,
        ///        "mTypeId": 0,
        ///        "formatId": 0,
        ///        "serialNbr": "510 022-2",
        ///        "typeStr": "3",
        ///        "formatStr": "3",
        ///        "ctry": "BE"
        ///     }
        ///
        /// </remarks>
        /// <param name="mus">Music Object (NO NEED to Enter the Id )</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "0")]
        public IActionResult Add([FromBody] Music mus)
        {
            try
            {
                if (!ModelState.IsValid) throw new ValidationException("Model is not meeting requirement");
                SM.GeneralType G = S.ServiceLocator.Instance.GeneralTypeService.Get(1);
                if (G is null) throw new ValidationException("Music Model don't exist in General List");

                SM.Music musa = new SM.Music(0
                    , mus.Band, mus.Title, mus.YEAR, mus.TRACKS, mus.NbCDs, mus.NbDvds, mus.NbLps, mus.MTypeId, mus.FormatId, mus.SerialNbr, mus.Ctry,
                    "","",
                    mus.Price, mus.Curr, mus.ShopId, mus.Date,1, mus.Signed, mus.SignedBy, mus.EAN, mus.EAN_EXT, mus.Comment1, mus.Comment2, mus.Onwed
                    );

                musa = S.ServiceLocator.Instance.MusicService.Add(musa);

                return ApiControllerHelper.SendOk(this, new ApiResult<SM.Music>(HttpStatusCode.OK, null, musa), true);

            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }

        /// <summary>
        /// Update Music record into table for Admin User(s)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PUT / Upd
        ///     {
        ///        "price": 400,
        ///        "curr": "BEF",
        ///        "shopId": 25,
        ///        "date": "1993-07-26",
        ///        "typeId": 1,
        ///        "signed": false,
        ///        "signedBy": "",
        ///        "ean": "'731451002229",
        ///        "eaN_EXT": "",
        ///        "comment1": "",
        ///        "comment2": "",
        ///        "onwed": true,
        ///        "band": "Metallica",
        ///        "title": "Black Album",
        ///        "year": 1991,
        ///        "tracks": "12",
        ///        "nbCDs": 1,
        ///        "nbDvds": 0,
        ///        "nbLps": 0,
        ///        "mTypeId": 0,
        ///        "formatId": 0,
        ///        "serialNbr": "510 022-2",
        ///        "typeStr": "3",
        ///        "formatStr": "3",
        ///        "ctry": "BE"
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="mus">Music Object (Enter the Id also)</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult Upd(int id, [FromBody] Music mus)
        {
            //return S.ServiceLocator.Instance.MusicService.Upd(muso);
            try
            {
                if (!ModelState.IsValid) throw new ValidationException("Model is not meeting requirement");
                SM.GeneralType G = S.ServiceLocator.Instance.GeneralTypeService.Get(1);
                if (G is null) throw new ValidationException("Music Model don't exist in General List");

                SM.Music musa = new SM.Music(id
                    , mus.Band, mus.Title, mus.YEAR, mus.TRACKS, mus.NbCDs, mus.NbDvds, mus.NbLps, mus.MTypeId, mus.FormatId, mus.SerialNbr, mus.Ctry,
                    "", "",
                    mus.Price, mus.Curr, mus.ShopId, mus.Date, 1, mus.Signed, mus.SignedBy, mus.EAN, mus.EAN_EXT, mus.Comment1, mus.Comment2, mus.Onwed
                    );

                bool UpdOk = S.ServiceLocator.Instance.MusicService.Upd(musa);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, UpdOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }
        /// <summary>
        /// Delete Music record into table for Admin User(s)
        /// </summary>
        /// <param name="id">Id of the record</param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult Del(int id)
        {
            try
            {
                bool DelOk = S.ServiceLocator.Instance.MusicService.Del(id);
                return ApiControllerHelper.SendOk(this, new ApiResult<bool>(HttpStatusCode.OK, null, DelOk), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ApiControllerHelper.SendError(this, ex);
            }
        }
    }
}