using appLicenciasSC.Logica;
using appLicenciasSC.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appLicenciasSC
{
    public partial class Form1 : Form
    {
        private Conexion conexion;

        public Form1()
        {
            InitializeComponent();
            conexion = Conexion.getInstancia();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            if (ValidarCredenciales(usuario, password))
            {
                //MessageBox.Show("Acceso correcto");
                FrmInicio frmInicio = new FrmInicio();
                frmInicio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Por favor, inténtelo de nuevo.");
            }
        }
        private bool ValidarCredenciales(string usuario, string password)
        {
            bool credencialesCorrectas = false;

            try
            {
                using (var connection = conexion.CrearConexion())
                {
                    connection.Open();

                    // Consulta SQL para validar credenciales en la tabla USERS
                    string query = "SELECT COUNT(*) FROM USERS WHERE DNI = @DNI AND PASSWORD = @PASSWORD";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DNI", usuario);
                        command.Parameters.AddWithValue("@PASSWORD", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        credencialesCorrectas = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }

            return credencialesCorrectas;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool mouseDown;
        private Point lastLocation;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int deltaX = e.Location.X - lastLocation.X;
                int deltaY = e.Location.Y - lastLocation.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

       //RBH**
    }
}
