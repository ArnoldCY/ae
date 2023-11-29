using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class bdCategoria:conexion
    {

        // Método para insertar una categoría
        public int Insertar(cCategoria categoria)
        {
            int resultado = 0;
            try
            {
                Conectado();
                comand = new SqlCommand("InsertarCategoria", conex);
                comand.CommandType = CommandType.StoredProcedure;

                comand.Parameters.AddWithValue("@Nombre", categoria.Nombre1);
                comand.Parameters.AddWithValue("@Descripcion", categoria.Descripcion1);

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

        // Método para mostrar todas las categorías
        public DataTable Mostrar()
        {
            DataTable dt = new DataTable();
            try
            {
                Conectado();
                comand = new SqlCommand("MostrarCategoria", conex);
                comand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(comand);
                da.Fill(dt);
            }
            catch (SqlException me)
            {
                Console.Write(me.Message);
                dt = null;
            }
            finally
            {
                Desconectado();
            }
            return dt;
        }

        // Método para actualizar una categoría
        public int Actualizar(cCategoria categoria)
        {
            int resultado = 0;
            try
            {
                Conectado();
                comand = new SqlCommand("ActualizarCategoria", conex); // Asumiendo que tienes este procedimiento almacenado
                comand.CommandType = CommandType.StoredProcedure;

                comand.Parameters.AddWithValue("@idCategoria", categoria.Codigo1);
                comand.Parameters.AddWithValue("@Nombre", categoria.Nombre1);
                comand.Parameters.AddWithValue("@Descripcion", categoria.Descripcion1);

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

        // Método para eliminar una categoría
        public int Eliminar(int idCategoria)
        {
            int resultado = 0;
            try
            {
                Conectado();
                comand = new SqlCommand("EliminarCategoria", conex); // Asumiendo que tienes este procedimiento almacenado
                comand.CommandType = CommandType.StoredProcedure;

                comand.Parameters.AddWithValue("@idCategoria", idCategoria);

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
