using appLicenciasSC.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appLicenciasSC.Presentacion
{
    public partial class FrmEditarPersonalSubcidiado : Form
    {
        public FrmEditarPersonalSubcidiado()
        {
            InitializeComponent();
        }
        public FrmEditarPersonalSubcidiado(string nombreSeleccionado, string DNIseleccionado, string C_TrabajoSelec, string CargoSelec, string AutogeneradoSelec, string T_ServidorSelec)
        {
            InitializeComponent();

            // Establece el valor del txtApellidosNombres
            txtApeNom.Text = nombreSeleccionado;
            txtDNI.Text = DNIseleccionado;
            txtCTrabajo.Text = C_TrabajoSelec;
            txtCargo.Text = CargoSelec;
            txtAutogenerado.Text = AutogeneradoSelec;
            cBoxTipoServidor.SelectedItem = T_ServidorSelec;
        }

        public string ApellidosNombres
        {
            get { return txtApeNom.Text; }
            set { txtApeNom.Text = value; }
        }

        public string DNI
        {
            get { return txtDNI.Text; }
            set { txtDNI.Text = value; }
        }

        public string CTrabajo
        {
            get { return txtCTrabajo.Text; }
            set { txtCTrabajo.Text = value; }
        }

        public string Cargo
        {
            get { return txtCargo.Text; }
            set { txtCargo.Text = value; }
        }

        public string Autogenerado
        {
            get { return txtAutogenerado.Text; }
            set { txtAutogenerado.Text = value; }
        }

        public string TipoServidor
        {
            get { return cBoxTipoServidor.Text; }
            set { cBoxTipoServidor.Text = value; }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia de la clase Conexion
                Conexion conexion = Conexion.getInstancia();

                // Crear la consulta SQL para actualizar los datos del personal
                string query = @"UPDATE PERSONAL 
                         SET ""APELLIDOS Y NOMBRES"" = @ApeNom, 
                             CARGO = @Cargo, 
                             C_TRABAJO = @CTrabajo, 
                             TIPO_SERVIDOR = @TipoServidor, 
                             AUTOGENERADO = @Autogenerado 
                         WHERE DNI = @DNI";

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

                // Ejecutar la consulta de actualización
                conexion.EjecutarConsulta(query, parametros);

                FrmInicio frmInicio = Application.OpenForms.OfType<FrmInicio>().FirstOrDefault();
                if (frmInicio != null)
                {
                    frmInicio.ActualizarTabla1();
                }

                MessageBox.Show("Datos actualizados correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message);
            }
        }
        #region PARAMETOS PARA INGRESAR CAMPOS
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

        private void cBoxTipoServidor_KeyPress(object sender, KeyPressEventArgs e)
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
        #endregion
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
