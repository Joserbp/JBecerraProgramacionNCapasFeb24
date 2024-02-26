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
            var result = BL.Usuario.GetAllEF();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = result;
            return View(usuario);
        }
        [HttpGet] // Mostrar el form vacio
        public ActionResult Form()
        {
            //CONDICIONAL //VACIO //LLENO
                //IDUSUARIO = 0 ADD ID =! 0 //UPDATE
            ML.Usuario usuario = new ML.Usuario();  //
           // usuario.Rol = new ML.Rol();
           //GETBYID
           //REMPLAZAR Usuario vacio por lo que recupere de la BD
            return View(usuario);
        }

        [HttpPost]  //Capturar datos
        public ActionResult Form(ML.Usuario usuario)
        {
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
    }
}