﻿using CoreAPI;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class IdiomaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GetTop100 api/usuario/GetMostTraduccionUsuario
        [Route("api/idioma/GetMostPopular")]
        public IHttpActionResult GetMostPopular()
        {
            try
            {
                var mng = new IdiomaManager();
                apiResp.Data = mng.RetrieveMostPopular();
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // GetTop100 api/usuario/GetMostTraduccionUsuario
        [Route("api/idioma/Get")]
        public IHttpActionResult Get()
        {
            try
            {
                var mng = new IdiomaManager();
                apiResp.Data = mng.RetrieveAll();
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
