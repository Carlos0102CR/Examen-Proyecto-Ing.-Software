using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class FraseTraducidaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GetTop100 api/fraseTraducida/GetByPalabra/<palabra>
        [HttpGet]
        [Route("api/fraseTraducida/GetByPalabra/{palabra}")]
        public IHttpActionResult GetByPalabra(string palabra)
        {
            try
            {
                var mng = new FraseTraducidaManager();
            var fraseTraducida = new FraseTraducida();
            fraseTraducida.Palabra = palabra;

            apiResp = new ApiResponse();
            apiResp.Data = mng.RetrieveAllByPalabra(fraseTraducida);
            return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // GetTop100 api/fraseTraducida/GetByIdioma/<idioma>
        [HttpGet]
        [Route("api/fraseTraducida/GetByIdioma/{idioma}")]
        public IHttpActionResult GetByIdioma(string idioma)
        {
            try
            {
                var mng = new FraseTraducidaManager();
            var fraseTraducida = new FraseTraducida();
            fraseTraducida.NombreIdioma = idioma;

            apiResp = new ApiResponse();
            apiResp.Data = mng.RetrieveAllByIdioma(fraseTraducida);
            return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
