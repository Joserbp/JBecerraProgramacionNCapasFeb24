using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static (bool, string, List<ML.Usuario>, Exception) GetAllByExcel(string connectionString)
        {
            try
            {
                using (OleDbConnection context = new OleDbConnection(connectionString))
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.Connection.Open();

                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                        DataTable tablaUsuario = new DataTable();
                        da.Fill(tablaUsuario);

                        if (tablaUsuario.Rows.Count > 0)
                        {
                            List<ML.Usuario>  usuarios =new List<ML.Usuario>();
                            foreach (DataRow row in tablaUsuario.Rows) //
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.Nombre = row[0].ToString();
                                usuario.ApellidoPaterno = row[1].ToString();
                                usuario.ApellidoMaterno = row[2].ToString();


                                usuarios.Add(usuario);
                            }
                            return (true, null, usuarios, null);
                        }
                        else
                        {
                            return (false,"", null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
        public static (bool, ML.ErrorExcel, Exception) Validacion(List<ML.Usuario> Object)
        {
            ML.ErrorExcel result = new ML.ErrorExcel();

            result.Errores = new List<ML.ErrorExcel>();
            string errorMessage;
            int contador = 2;
            foreach (ML.Usuario usuario in Object) //
            {
                errorMessage = "";
                errorMessage += (usuario.Nombre == "") ? "Falta Nombre " : "";
                errorMessage += (usuario.ApellidoPaterno == "") ? "Falta ApellidoPaterno " : "";
                errorMessage += (usuario.ApellidoMaterno == "") ? "Falta ApellidoMaterno " : "";

                if (errorMessage != "")
                {
                    ML.ErrorExcel error = new ML.ErrorExcel();
                    error.IdRegistro = contador;
                    error.Message = errorMessage;
                    result.Errores.Add(error);
                }

                contador++;
            }
            return (true, result, null);
        }



        public static bool CargaMasivaTxt()
        {
            string path = @"C:\Users\digis\OneDrive\Escritorio\CargaMasivaFeb24.txt";
            try
            {
                if (File.Exists(path))
                {
                    StreamReader reader = new StreamReader(path);
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        string[] datos = linea.Split('|');
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Nombre = datos[0];
                        usuario.ApellidoPaterno = datos[1];
                        usuario.ApellidoMaterno = datos[2];

                        // BL.Usuario.Add(usuario);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }



            //RUTA
            //Funcion txt
            //Regresar una tupla
            //Guardar datos leido
        }
        public static bool Add(ML.Usuario usuario)
        {
            try
            {
                SqlConnection context = new SqlConnection(DL.Conexion.Get());
                string query = "INSERT INTO [Usuario] ([Nombre] ,[ApellidoPaterno] ,[ApellidoMaterno]) VALUES (@Nombre ,@ApellidoPaterno,@ApellidoMaterno)";
                SqlCommand cmd = new SqlCommand(query, context);

                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                parameters[0].Value = usuario.Nombre;
                parameters[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                parameters[1].Value = usuario.ApellidoPaterno;
                parameters[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                parameters[2].Value = usuario.ApellidoMaterno;

                cmd.Parameters.AddRange(parameters);

                cmd.Connection.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if (rowAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public static List<ML.Usuario> GetAll()
        {
            List<ML.Usuario> usuarios = new List<ML.Usuario>();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "SELECT [IdUsuario] ,[Nombre] ,[ApellidoPaterno] ,[ApellidoMaterno] FROM [Usuario]";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = query;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable tablaUsuario = new DataTable();

                    da.Fill(tablaUsuario);

                    if (tablaUsuario != null)  //Trae datos
                    {

                        foreach (DataRow row in tablaUsuario.Rows)  //Tipodedato que almacena la lista : Lista
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();

                            //Recuperar los demas datos

                            usuarios.Add(usuario); // equivalente a datos.push(1)
                        }
                    }
                    else //La tabla esta vacia
                    {

                    }


                }
            }
            catch (Exception ex)
            {

            }
            return usuarios;
        }


        public static bool AddSP(ML.Usuario usuario)
        {
            try
            {
                SqlConnection context = new SqlConnection(DL.Conexion.Get());
                string query = "UsuarioAdd";
                SqlCommand cmd = new SqlCommand(query, context);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                parameters[0].Value = usuario.Nombre;
                parameters[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                parameters[1].Value = usuario.ApellidoPaterno;
                parameters[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                parameters[2].Value = usuario.ApellidoMaterno;



                cmd.Parameters.AddRange(parameters);

                cmd.Connection.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if (rowAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public static ML.Usuario GetByIdSP(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioGetById";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] parameters = new SqlParameter[1];
                    parameters[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                    parameters[0].Value = IdUsuario;

                    cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable tablaUsuario = new DataTable();

                    da.Fill(tablaUsuario);

                    if (tablaUsuario != null)  //Trae datos
                    {

                        DataRow row = tablaUsuario.Rows[0];

                        usuario.IdUsuario = int.Parse(row[0].ToString());
                        usuario.Nombre = row[1].ToString();
                        usuario.ApellidoPaterno = row[2].ToString();

                    }
                    else //La tabla esta vacia
                    {

                    }


                }
            }
            catch (Exception ex)
            {

            }
            return usuario;
        }

        public static List<ML.Usuario> GetAllEF(ML.Usuario usuarioBusqueda)
        {
            List<ML.Usuario> usuarios = new List<ML.Usuario>();
            try
            {
                using (DL_EF.JBecerraProgramacionNCapasFeb24Entities context = new DL_EF.JBecerraProgramacionNCapasFeb24Entities())
                {
                    var ObjUsuarios = context.UsuarioGetAll(usuarioBusqueda.Nombre, usuarioBusqueda.ApellidoPaterno, usuarioBusqueda.ApellidoMaterno).ToList();

                    foreach (var objUsuario in ObjUsuarios)  //Tipodedato que almacena la lista : Lista
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Nombre = objUsuario.NombreUsuario;
                        usuario.Direccion = new ML.Direccion();

                        usuarios.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return usuarios;
        }
    }
}
