using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PracticaNetBrandonCanux.Data
{
    public class DBConexion
    {
        private string cadenaConexion;
        private SqlConnection conexion;

        /// <summary>
        /// Obtiene la cadena de conexión.
        /// </summary>
        public DBConexion()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        }

        // Método para abrir una conexión a la base de datos
        private SqlConnection AbrirConexion()
        {
            conexion = new SqlConnection(cadenaConexion);
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            return conexion;
        }

        /// <summary>
        /// Cierra la conexión a báse de datos. 
        /// </summary>
        private void CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Ejecuta una consulta SQL
        /// </summary>
        /// <param name="consulta">Query de consulta SQL</param>
        /// <returns>Retorna DataTable con datos consultados.</returns>
        public DataTable EjecutarConsultaSQL(string consulta)
        {
            DataTable dtResultado = new DataTable();
            try
            {
                AbrirConexion();
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
            return dtResultado;
        }

        /// <summary>
        /// Método que ejecutará UPDATE, INSERT, DELETE
        /// </summary>
        /// <param name="sentencia">String con la consulta a ejecutar</param>
        /// <returns>Retorna número de filas afectadas.</returns>
        public int EjecutarSentenciaSQL(string sentencia)
        {
            int filasAfectadas = 0;
            try
            {
                AbrirConexion();
                SqlCommand comando = new SqlCommand(sentencia, conexion);
                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
            return filasAfectadas;
        }

        public int ContarFilasConsulta(string query)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, conexion);
                AbrirConexion();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int rowCount = 0;
                    while (reader.Read())
                    {
                        rowCount++;
                    }
                    return rowCount;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
            return 0;
        }
    }
}