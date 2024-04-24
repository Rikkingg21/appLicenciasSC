using appLicenciasSC.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace appLicenciasSC.Presentacion
{
    public partial class FrmIngresoPersonalSubsidiado : Form
    {
        public FrmIngresoPersonalSubsidiado()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si los campos obligatorios están vacíos
                if (string.IsNullOrEmpty(txtApeNom.Text) || string.IsNullOrEmpty(txtDNI.Text) || string.IsNullOrEmpty(txtCargo.Text) || string.IsNullOrEmpty(txtCTrabajo.Text) || cBoxTipoServidor.SelectedItem == null || string.IsNullOrEmpty(txtAutogenerado.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                    return; // Salir del método para evitar la inserción con campos vacíos
                }

                // Crear una instancia de la clase Conexion
                Conexion conexion = Conexion.getInstancia();

                // Crear la consulta SQL para insertar datos
                string query = "INSERT INTO PERSONAL ([APELLIDOS Y NOMBRES], DNI, CARGO, C_TRABAJO, TIPO_SERVIDOR, AUTOGENERADO) " +
                               "VALUES (@ApeNom, @DNI, @Cargo, @CTrabajo, @TipoServidor, @Autogenerado)";

                // Crear un array de parámetros
                SQLiteParameter[] parametros = new SQLiteParameter[]
                {
                    new SQLiteParameter("@ApeNom", txtApeNom.Text),
                    new SQLiteParameter("@DNI", txtDNI.Text),
                    new SQLiteParameter("@Cargo", txtCargo.Text),
                    new SQLiteParameter("@CTrabajo", txtCTrabajo.Text),
                    new SQLiteParameter("@TipoServidor", cBoxTipoServidor.SelectedItem.ToString()),
                    new SQLiteParameter("@Autogenerado", txtAutogenerado.Text)
                };

                // Ejecutar la consulta usando la clase Conexion
                DataTable dataTable = conexion.EjecutarConsulta(query, parametros);

                MessageBox.Show("Datos guardados exitosamente.");
                FrmInicio frmInicio = Application.OpenForms.OfType<FrmInicio>().FirstOrDefault();
                if (frmInicio != null)
                {
                    frmInicio.ActualizarTabla1();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message);
            }
        }
        #region Parametros para Rellenar Campos
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApeNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        private void txtCTrabajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtAutogenerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtCargo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        private void cBoxTipoServidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool mouseDown;
        private Point lastLocation;
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int deltaX = e.Location.X - lastLocation.X;
                int deltaY = e.Location.Y - lastLocation.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
