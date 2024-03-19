using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        //HTTP STATUS CODE
        // 100 - 199 = Informativas
        // 200 - 299 = Aceptacion
        // 300 - 399 = Redirecciones
        // 400 - 499 = Errores Clientes
        //404 --- Not Found
        // 500 - 599 = Errores en Servidor 

        //Cliente --- //Navegador //Apk // dmg 
        //Servidor  --- //Sistema que contiene los WS  (SL)


        //Get -- Obtener
        //Post -- Agregar
        //Put -- Actualizar  //Si encuentra el recurso ---> Actualiza , No ----> Error
        //Patch --- Actualizar //Si encuentra el recurso ---> Actualiza , No ----> Crea   Post+Put
        //Delete --- Eliminar

        //Endpoint ----> URL Para una solicitud //Como se le envia informacion (Header, Body)

        //Serializar ---> objeto a un flujo de datos (JSON,XML)
        //Deserializar  ---> flujo de datos a un objeto

        //Programar 5 metodos de Producto/Paquete 


        //Investigar como consumir una api con C# (.NET Framework)

        //WORD CODIGO + POSTMAN

        [HttpPost]
        [Route("api/Usuario/Add")]
        public IHttpActionResult Add([FromBody]ML.Usuario usuario)
        {
            var resultado = BL.Usuario.AddSP(usuario);
            if (resultado)
            {
                return Content(HttpStatusCode.OK, resultado);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, resultado);
            }
        }

        [HttpDelete]
        [Route("api/Usuario/Delete")]
        public IHttpActionResult Delete(int IdUsuario)  //Header
        {
            var resultado = BL.Usuario.Delete(IdUsuario);
            if (resultado)
            {
                return Content(HttpStatusCode.OK, resultado);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, resultado);
            }
        }


    }
}
