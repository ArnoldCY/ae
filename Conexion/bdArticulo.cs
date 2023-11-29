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
    public class bdArticulo:conexion
    {

        // Método para insertar un artículo
        public int Insertar(cArticulo articulo)
        {
            int resultado = 0;
            try
            {
                Conectado();
                comand = new SqlCommand("InsertarArticulo");
                comand.CommandType = CommandType.StoredProcedure;
                comand.Connection = conex;
                comand.Parameters.AddWithValue("@idArticulo", articulo.IdArticulo);
                comand.Parameters.AddWithValue("@Nombre", articulo.Nombre1);
                comand.Parameters.AddWithValue("@Descripcion", articulo.Descripcion1);
                comand.Parameters.AddWithValue("@Precio", articulo.Precio1);
                comand.Parameters.AddWithValue("@Stock", articulo.Stock1);
                comand.Parameters.AddWithValue("@idCategoria", articulo.IdCategoria);

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

        // Método para mostrar todos los artículos
        public DataTable Mostrar()
        {
            DataTable dt = new DataTable();
            try
            {
                Conectado();
                comand = new SqlCommand("MostrarArticulo");
                comand.CommandType = CommandType.StoredProcedure;
                comand.Connection = conex;
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

        // Método para actualizar un artículo
        public int Actualizar(cArticulo articulo)
        {
            int resultado = 0;
            try
            {
                Conectado();
                comand = new SqlCommand("ActualizarArticulo"); // Asumiendo que tienes este procedimiento almacenado
                comand.CommandType = CommandType.StoredProcedure;
                comand.Connection = conex;
                comand.Parameters.AddWithValue("@idArticulo", articulo.IdArticulo);
                comand.Parameters.AddWithValue("@Nombre", articulo.Nombre1);
                comand.Parameters.AddWithValue("@Descripcion", articulo.Descripcion1);
                comand.Parameters.AddWithValue("@Precio", articulo.Precio1);
                comand.Parameters.AddWithValue("@Stock", articulo.Stock1);
                comand.Parameters.AddWithValue("@idCategoria", articulo.IdCategoria);

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
        public int Eliminar(string idArticulo)
        {
            int resultado = 0;
            try
            {
                Conectado();
                comand = new SqlCommand("EliminarArticulo"); // Asumiendo que tienes este procedimiento almacenado
                comand.CommandType = CommandType.StoredProcedure;
                comand.Connection = conex;
                comand.Parameters.AddWithValue("@idArticulo", idArticulo);

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
