using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class OperacionesController : ApiController
    {
        //Investigacion
        //Que es WebServices
        //Que es REST
        //       SOAP
        // Como se consumen
        //DataContract, DataMember, OperationCOntract y ServiceContract
        //Verbos HTTP
        //Status Code Http
        //Endpoint
        //En un word con capturas del codigo + capturas de postman como se consumio
        //WPS o drive
        //Se manda personal
        //Endpoint -- Rutas
        [Route("api/Saludo")]
        [HttpGet]
        public IHttpActionResult Saludar(string Nombre)
        {
            string saludo = "Hola " + Nombre;
            //Tipo de retorno JSON, HTTP Status Code 100,200,300 Grupos
            return Content(HttpStatusCode.OK,saludo);
        }
        [Route("api/Suma")]
        [HttpGet]
        public IHttpActionResult Suma(int numero1 , int numero2)
        {
            string saludo = "Hola ";
            //Tipo de retorno JSON, HTTP Status Code 100,200,300 Grupos
            return Content(HttpStatusCode.OK, saludo);
        }
    }
}
