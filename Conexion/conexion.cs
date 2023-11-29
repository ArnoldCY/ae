using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Conexion
{
    public class conexion
    {
        public SqlConnection conex = new SqlConnection();
        public SqlCommand comand = new SqlCommand();
        public string sqlconex;
        public conexion()
        {
            //sqlconex = ConfigurationManager.ConnectionStrings["dbproy"].ConnectionString;
            sqlconex = "Data Source=DESKTOP-N9N2LTB\\SQLEXPRESS;Initial Catalog=pernova;Integrated Security=True";
        }
        public bool Conectado()
        {
            try
            {
                conex = new SqlConnection(sqlconex);

                // ABRE LA CONEXION
                conex.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Desconectado()
        {
            try
            {
                if (conex.State == ConnectionState.Open)
                {
                    // CIERRA LA CONEXION
                    conex.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
