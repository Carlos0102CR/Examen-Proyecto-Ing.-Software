using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class UsuarioController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GetMostTraduccionUsuario api/usuario/GetMostTraduccionUsuario
        [Route("api/usuario/GetMostTraduccionUsuario")]
        public IHttpActionResult GetMostTraduccionUsuario(string nombre, string contrasenna)
        {
            try
            { 
                var mng = new UsuarioManager();
                var usuario = new Usuario();
                usuario = mng.RetrieveByTraduccion();
                apiResp = new ApiResponse();
                apiResp.Data = usuario;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
