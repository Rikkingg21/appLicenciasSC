using appLicenciasSC.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace appLicenciasSC.Presentacion
{
    public partial class FrmEditarNuevoCIT : Form
    {
        public FrmEditarNuevoCIT()
        {
            InitializeComponent();
        }
       
        public FrmEditarNuevoCIT(string IDseleccionado, string 
            ApellidoNombreSeleccionado, string DNIseleccionado, string TPrestacionSeleccionado, string CITseleccionado,
            string ColMedicoSeleccionado, string dtp_InicioSeleccionado, string dtp_FinSeleccionado, string DiasLicSeleccionado,
            string ExpedienteSeleccionado, string InformeSeleccionado)
        {
            InitializeComponent();

            // Establece el valor del txtApellidosNombres
            lblID.Text = IDseleccionado;
            txtApellidosNombres.Text = ApellidoNombreSeleccionado;
            txtDNI.Text = DNIseleccionado;
            cboxTPrestacion.Text = TPrestacionSeleccionado;
            txtCIT.Text = CITseleccionado;
            txtColMedico.Text = ColMedicoSeleccionado;
            txtInicio.Text = dtp_InicioSeleccionado;
            txtFin.Text = dtp_FinSeleccionado;
            txtDiasLic.Text = DiasLicSeleccionado;
            txtExpediente.Text = ExpedienteSeleccionado;
            cboxInforme.Text = InformeSeleccionado;
        }
        public string ID
        {
            get { return lblID.Text; }
            set { lblID.Text = value; }
        }

        public string ApellidosNombres
        {
            get { return txtApellidosNombres.Text; }
            set { txtApellidosNombres.Text = value; }
        }

        public string DNI
        {
            get { return txtDNI.Text; }
            set { txtDNI.Text = value; }
        }

        public string TPrestacion
        {
            get { return cboxTPrestacion.Text; }
            set { cboxTPrestacion.Text = value; }
        }

        public string CIT
        {
            get { return txtCIT.Text; }
            set { txtCIT.Text = value; }
        }

        public string ColMedico
        {
            get { return txtColMedico.Text; }
            set { txtColMedico.Text = value; }
        }

        public string F_Inicio
        {
            get { return txtInicio.Text; }
            set { txtInicio.Text = value; }
        }
        public string F_Fin
        {
            get { return txtFin.Text; }
            set { txtFin.Text = value; }
        }
        public string DiasLic
        {
            get { return txtDiasLic.Text; }
            set { txtDiasLic.Text = value; }
        }
        public string Expediente
        {
            get { return txtExpediente.Text; }
            set { txtExpediente.Text = value;}
        }
        public string Informe
        {
            get { return cboxInforme.Text; }
            set { cboxInforme.Text = value; }
        }
        private void btnActualizarCIT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas actualizar los datos?", "Confirmar Actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Conexion conexion = Conexion.getInstancia();

                    // Obtener los valores modificados del formulario FrmEditarNuevoCIT
                    string ID = lblID.Text;
                    string ApellidoNombre = txtApellidosNombres.Text;
                    string DNI = txtDNI.Text;
                    string TPrestacion = cboxTPrestacion.Text;
                    string CIT = txtCIT.Text;
                    string ColMedico = txtColMedico.Text;
                    string F_Inicio = txtInicio.Text;
                    string F_Fin = txtFin.Text;
                    string DiasLic = txtDiasLic.Text;
                    string Expediente = txtExpediente.Text;
                    string Informe = cboxInforme.Text;

                    // Consulta SQL de actualización
                    string query = @"UPDATE PERSONAL_CIT 
                         SET APENOM = @ApellidoNombre, 
                             DNI = @DNI, 
                             T_P_ECONOMICA = @TPrestacion, 
                             CIT = @CIT, 
                             COL_MED = @ColMedico, 
                             F_INICIO = @F_Inicio, 
                             F_FIN = @F_Fin, 
                             DIAS = @DiasLic, 
                             EXPEDIENTE = @Expediente,
                             INFORME = @Informe
                         WHERE ID_CIT = @ID";

                    // Crear los parámetros para la consulta SQL de actualización
                    SQLiteParameter[] parametros = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@ApellidoNombre", ApellidoNombre),
                        new SQLiteParameter("@DNI", DNI),
                        new SQLiteParameter("@TPrestacion", TPrestacion),
                        new SQLiteParameter("@CIT", CIT),
                        new SQLiteParameter("@ColMedico", ColMedico),
                        new SQLiteParameter("@F_Inicio", F_Inicio),
                        new SQLiteParameter("@F_Fin", F_Fin),
                        new SQLiteParameter("@DiasLic", DiasLic),
                        new SQLiteParameter("@Expediente", Expediente),
                        new SQLiteParameter("@Informe", Informe),
                        new SQLiteParameter("@ID", ID)
                    };

                    // Ejecutar la consulta SQL de actualización
                    conexion.EjecutarConsulta(query, parametros);

                    MessageBox.Show("Datos registrados correctamente en la tabla PERSONAL_CIT.");

                    FrmInicio frmInicio = Application.OpenForms.OfType<FrmInicio>().FirstOrDefault();
                    if (frmInicio != null)
                    {
                        frmInicio.ActualizarFilaTabla1();
                        frmInicio.ActualizarTabla2();
                    }

                    MessageBox.Show("Registro actualizado correctamente.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboxTPrestacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtCIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtColMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtExpediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
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
