using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
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
            catch(Exception ex)
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

                    if(tablaUsuario != null)  //Trae datos
                    {
                       
                        foreach (DataRow row in tablaUsuario.Rows)  //Tipodedato que almacena la lista : Lista
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();

                            //Recuperar los demas datos

                            usuarios.Add(usuario); // equivalente a datos.push(1)
                        }
                    }
                    else //La tabla esta vacia
                    {
                        
                    }
                    

                }
            }catch(Exception ex) { 
                
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
    }
}
