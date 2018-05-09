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

        // GetTop100 api/fraseTraducida/GetByPalabra/<palabra>
        [Route("api/fraseTraducida/GetByPalabra")]
        public IHttpActionResult GetByPalabra(string palabra)
        {
            try
            {
                var mng = new TraduccionManager();
            var traduccion = new Traduccion();
            traduccion.FraseEspannol = palabra;

            apiResp = new ApiResponse();
            apiResp.Data = mng.RetrieveAllByPalabra(traduccion);
            return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
