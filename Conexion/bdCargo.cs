using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Conexion
{
    public class bdCargo:conexion
    {
        public DataTable Cargar()
        {
            try
            {
                SqlDataAdapter da;
                DataTable dt = new DataTable();
                Conectado();
                comand = new SqlCommand("MostrarCargo");
                comand.CommandType = CommandType.StoredProcedure;
                comand.Connection = conex;
                comand.ExecuteNonQuery();
                da = new SqlDataAdapter(comand);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException me)
            {
                Console.Write(me.Message);
                return null;
            }
            finally
            {
                Desconectado();
            }
        }
        public int Insertar(cCargo dts)
        {
            try
            {
                int sqlok = 0;
                Conectado();
                comand = new SqlCommand("InsertarCargo");
                comand.CommandType = CommandType.StoredProcedure;
                comand.Connection = conex;
                comand.Parameters.AddWithValue("@Nombre", dts.Nombre1);
                comand.Parameters.AddWithValue("@Descripcion", dts.Descripcion1);
                sqlok = comand.ExecuteNonQuery();
                if (sqlok > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException me)
            {
                Console.Write(me.Message);
                return 0;
            }
            finally
            {
                Desconectado();
            }
        }
        public int Actualizar(cCargo cargo)
        {
            int resultado = 0;
            try
            {
                Conectado();
                comand = new SqlCommand("ActualizarCargo"); // Asumiendo que tienes este procedimiento almacenado
                comand.CommandType = CommandType.StoredProcedure;
                comand.Connection = conex;
                comand.Parameters.AddWithValue("@idCargo", cargo.IdCargo1);
                comand.Parameters.AddWithValue("@Nombre", cargo.Nombre1);
                comand.Parameters.AddWithValue("@Descripcion", cargo.Descripcion1);

                resultado = comand.ExecuteNonQuery();
                return resultado > 0 ? 1 : 0;
            }
            catch (SqlException me)
            {
                Console.Write(me.Message);
                return 0;
            }
            finally
            {
                Desconectado();
            }
        }

        // Método para eliminar un artículo
        public int Eliminar(string idCargo)
        {
            int resultado = 0;
            try
            {
                Conectado();
                comand = new SqlCommand("EliminarCaego"); // Asumiendo que tienes este procedimiento almacenado
                comand.CommandType = CommandType.StoredProcedure;
                comand.Connection = conex;
                comand.Parameters.AddWithValue("@idCargo", idCargo);

                resultado = comand.ExecuteNonQuery();
                return resultado > 0 ? 1 : 0;
            }
            catch (SqlException me)
            {
                Console.Write(me.Message);
                return 0;
            }
            finally
            {
                Desconectado();
            }
        }
    }
}
