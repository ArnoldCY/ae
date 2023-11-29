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
    public class bdEmpleado:conexion
    {

        // Método para insertar un empleado
        public int Insertar(cEmpleado empleado)
        {
            int resultado = 0;
            try
            {
                Conectado();
                comand = new SqlCommand("InsertarEmpleado");
                comand.CommandType = CommandType.StoredProcedure;
                comand.Connection = conex;
                comand.Parameters.AddWithValue("@CI", empleado.CI1);
                comand.Parameters.AddWithValue("@Usuario", empleado.Usuario1);
                comand.Parameters.AddWithValue("@Contraseña", empleado.Contraseña1);
                comand.Parameters.AddWithValue("@Nombre", empleado.Nombre1);
                comand.Parameters.AddWithValue("@ApPaterno", empleado.ApPaterno1);
                comand.Parameters.AddWithValue("@ApMaterno", empleado.ApMaterno1);
                comand.Parameters.AddWithValue("@CargoID", empleado.CargoID1);
                comand.Parameters.AddWithValue("@Telefono", empleado.Telefono1);
                comand.Parameters.AddWithValue("@Correo", empleado.Correo1);
                comand.Parameters.AddWithValue("@Direccion", empleado.Direccion1);

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

        // Método para mostrar todos los empleados
        public DataTable Mostrar()
        {
            DataTable dt = new DataTable();
            try
            {
                Conectado();
                comand = new SqlCommand("MostrarEmpleado");
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

        // Método para actualizar un empleado
        public int Actualizar(cEmpleado empleado)
        {
            int resultado = 0;
            try
            {
                Conectado();
                comand = new SqlCommand("ActualizarEmpleado"); // Asumiendo que tienes este procedimiento almacenado
                comand.CommandType = CommandType.StoredProcedure;
                comand.Connection = conex;
                comand.Parameters.AddWithValue("@CI", empleado.CI1);
                comand.Parameters.AddWithValue("@Usuario", empleado.Usuario1);
                comand.Parameters.AddWithValue("@Contraseña", empleado.Contraseña1);
                comand.Parameters.AddWithValue("@Nombre", empleado.Nombre1);
                comand.Parameters.AddWithValue("@ApPaterno", empleado.ApPaterno1);
                comand.Parameters.AddWithValue("@ApMaterno", empleado.ApMaterno1);
                comand.Parameters.AddWithValue("@CargoID", empleado.CargoID1);
                comand.Parameters.AddWithValue("@Telefono", empleado.Telefono1);
                comand.Parameters.AddWithValue("@Correo", empleado.Correo1);
                comand.Parameters.AddWithValue("@Direccion", empleado.Direccion1);

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

        // Método para eliminar un empleado
        public int Eliminar(int CI)
        {
            int resultado = 0;
            try
            {
                Conectado();
                comand = new SqlCommand("EliminarEmpleado"); // Asumiendo que tienes este procedimiento almacenado
                comand.CommandType = CommandType.StoredProcedure;
                comand.Connection = conex;
                comand.Parameters.AddWithValue("@CI", CI);

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
