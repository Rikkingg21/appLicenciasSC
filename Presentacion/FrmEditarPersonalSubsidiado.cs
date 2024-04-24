using appLicenciasSC.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message);
            }
        }
    }
}
