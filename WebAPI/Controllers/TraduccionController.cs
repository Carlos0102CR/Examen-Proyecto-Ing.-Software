using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TraduccionController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // Get api/fraseTraducida/Get
        [HttpGet]
        [Route("api/traducciones/Get/{palabra}")]
        public IHttpActionResult Get(string palabra)
        {
            try
            {
                var mng = new TraduccionManager();
                var traduccion = new Traduccion(){FraseEspannol = palabra };
                apiResp = new ApiResponse { Data = mng.RetrieveAllByPalabra(traduccion) };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // Get api/fraseTraducida/Get
        [HttpGet]
        [Route("api/traducciones/Get")]
        public IHttpActionResult Get()
        {
            try
            {
                var mng = new TraduccionManager();

                apiResp = new ApiResponse {Data = mng.RetrieveAll()};
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
