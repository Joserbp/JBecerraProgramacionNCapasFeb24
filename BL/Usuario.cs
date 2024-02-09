using System;
using System.Collections.Generic;
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
    }
}
