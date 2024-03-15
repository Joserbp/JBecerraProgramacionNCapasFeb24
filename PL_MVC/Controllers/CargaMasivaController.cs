using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        public ActionResult Get()
        {
            ML.ErrorExcel errorExcel = new ML.ErrorExcel();
            return View(errorExcel);
        }

        [HttpPost]
        public ActionResult Get(int? dato)
        {
            //Validar la extension del archivo
            if (Session["PathArchivo"] == null)
            {
                HttpPostedFileBase file = Request.Files["ArchivoExcel"];
                string pathFolder = ConfigurationManager.AppSettings["pathFolder"].ToString();

                if (file.ContentLength > 0)
                {
                    string extensionArchivo = Path.GetExtension(file.FileName).ToLower();
                    string extensionModulo = ConfigurationManager.AppSettings["TipoExcel"].ToString();

                    if (extensionArchivo == extensionModulo)
                    {
                        string pathArchivo = Server.MapPath(pathFolder) + Path.GetFileNameWithoutExtension(file.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                        if (!System.IO.File.Exists(pathArchivo))
                        {
                            file.SaveAs(pathArchivo);
                            string connectionString = ConfigurationManager.AppSettings["ConnectionStringExcel"].ToString() + pathArchivo; ;
                            var resultUsuarios = BL.Usuario.GetAllByExcel(connectionString);

                            if (resultUsuarios.Item1)
                            {
                                var resultValidacion = BL.Usuario.Validacion(resultUsuarios.Item3);
                                if (resultValidacion.Item2.Errores.Count == 0)
                                {
                                    Session["PathArchivo"] = pathArchivo;
                                    return View();
                                }

                                return View(resultValidacion);
                            }
                            else
                            {
                                ViewBag.Mensaje = "El excel no contiene registros";
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Mensaje = "Favor de seleccionar un archivo .xlsx, Verifique su archivo";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "No selecciono ningun archivo, Seleccione uno correctamente";
                }
                return View();
            }
            else
            {
                string pathArchivo = Session["PathArchivo"].ToString();
                string connectionString = ConfigurationManager.AppSettings["ConnectionStringExcel"].ToString() + pathArchivo;
                //Proceso de lectura

                var datos = BL.Usuario.GetAllByExcel(connectionString);

                if( datos.Item1)
                {
                    foreach(ML.Usuario usuario in datos.Item3 )
                    {
                        BL.Usuario.Add(usuario);
                    }
                }
                ViewBag.Mensaje = "Se realizo la carga de manera correcta";
                Session["PathArchivo"] = null;
                return PartialView("Modal");
            }
        }
    }
}