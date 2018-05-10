using CoreAPI;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class FraseController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GetTop100 api/frase/GetMostPopular
        [HttpGet]
        [Route("api/frase/GetMostPopular")]
        public IHttpActionResult GetMostPopular()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new FraseManager();
                apiResp.Data = mng.RetrieveByPopularity();
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        [HttpGet]
        [Route("api/frase/Get")]
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new FraseManager();

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
