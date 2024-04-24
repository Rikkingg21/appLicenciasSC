using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace appLicenciasSC.Logica
{
    public class Conexion
    {
        private string Basedatos;
        private static Conexion Con = null;

        private Conexion()
        {
            this.Basedatos = "./LIC_SALUD_DB.db";
        }

        public SQLiteConnection CrearConexion()
        {
            SQLiteConnection Cadena = new SQLiteConnection();
            try
            {
                Cadena.ConnectionString = "Data Source=" + this.Basedatos;
            }
            catch(Exception ex) 
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }
        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
        public DataTable EjecutarConsulta(string query, SQLiteParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (var connection = CrearConexion())
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }

            return dataTable;
        }
        public void EjecutarComando(string query, SQLiteParameter[] parameters = null)
        {
            try
            {
                using (var connection = CrearConexion())
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar comando: " + ex.Message);
            }
        }
    }
}
