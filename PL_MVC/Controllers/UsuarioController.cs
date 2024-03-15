using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Usuario usuarioBusqueda = new ML.Usuario();
            usuarioBusqueda.Nombre = "";
            usuarioBusqueda.ApellidoPaterno = "";
            usuarioBusqueda.ApellidoMaterno = "";
            var result = BL.Usuario.GetAllEF(usuarioBusqueda);
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = result;
            return View(usuario);
        }
        [HttpGet] // Mostrar el form vacio
        public ActionResult Form()
        {
            ML.Usuario usuario = new ML.Usuario();
            var listPaises = BL.Pais.GetAll();
            if (listPaises.Item1)
            {
                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Estado= new ML.Estado();
                usuario.Direccion.Estado.Pais = new ML.Pais();
                usuario.Direccion.Estado.Pais.Paises = listPaises.Item3.Paises;
                return View(usuario);
            }
            else
            {
                //MODAL
                return View(usuario);
            }
            
        }

        [HttpPost]  //Capturar datos
        public ActionResult Form(ML.Usuario usuario)
        {
            HttpPostedFileBase file = Request.Files["Imagen"];
            
            //if (file.ContentLength > 0)
            //{
            //    usuario.Imagen = Convert(file);
            //}

            //LIKE SQL
            //Comodines 
            //Operadores logicos SQL

            var result = BL.Usuario.Add(usuario);
            if(result == true)
            {
                //investigar como mostrar mensaje de la tarea
            } else
            {
                //pagina, saber 
            }

            return View();
        }

        [HttpPost]
        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);
            if (result.Item1)
            {
                return Json(result.Item3.Estados, JsonRequestBehavior.AllowGet);
            }
            else{
                return Json(result.Item2, JsonRequestBehavior.AllowGet);
            }
         
        }
    }
}