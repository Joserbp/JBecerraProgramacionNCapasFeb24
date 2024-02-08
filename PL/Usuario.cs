using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }


        //CRUD ABC
        //Add Update Delete GetAll GetById
        public static bool Add(string Nombre, string ApellidoPaterno, string ApellidoMaterno)
        {
            SqlConnection context = new SqlConnection(Conexion.Get());
            string query = "INSERT INTO [Usuario] ([Nombre] ,[ApellidoPaterno] ,[ApellidoMaterno]) VALUES (@Nombre ,@ApellidoPaterno,@ApellidoMaterno)";
            SqlCommand cmd = new SqlCommand(query, context);

            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
            parameters[0].Value = Nombre;
            parameters[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
            parameters[1].Value = ApellidoPaterno;
            parameters[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
            parameters[2].Value = ApellidoMaterno;

            cmd.Parameters.AddRange(parameters);

            cmd.Connection.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            if(rowAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


            //Cadena de conexion (1)
            //Open Database
            //Close
        }
    }
}
