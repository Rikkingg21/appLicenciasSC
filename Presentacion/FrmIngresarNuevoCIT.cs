using appLicenciasSC.Logica;
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

namespace appLicenciasSC.Presentacion
{
    public partial class FrmIngresarNuevoCIT : Form
    {
        private Conexion conexion;
        public FrmIngresarNuevoCIT()
        {
            InitializeComponent();
            ConfigurarDateTimePickers();
            conexion = Conexion.getInstancia();
        }
        private void FrmIngresarNuevoCIT_Load_1(object sender, EventArgs e)
        {
            CargarAniolbl();
            ActualizarTablaMuestra();
        }
        public void ActualizarTablaMuestra()
        {
            string anio = lblAnio.Text;
            string dni = txtDNI.Text;
            CargarDatosEndgvMuestra(dni, anio);

        }

        // Constructor que acepta el nombre seleccionado como argumento
        public FrmIngresarNuevoCIT(string nombreSeleccionado, string DNIseleccionado)
        {
            InitializeComponent();
            ConfigurarDateTimePickers();

            txtApellidosNombres.Text = nombreSeleccionado;
            txtDNI.Text = DNIseleccionado;
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

        private void ConfigurarDateTimePickers()
        {
            dtp_Inicio.Format = DateTimePickerFormat.Custom;
            dtp_Inicio.CustomFormat = "dd/MM/yyyy";
            dtp_Inicio.ValueChanged += CalcularDiferenciaEnDias;

            dtp_Fin.Format = DateTimePickerFormat.Custom;
            dtp_Fin.CustomFormat = "dd/MM/yyyy";
            dtp_Fin.ValueChanged += CalcularDiferenciaEnDias;
        }
        private void CargarAniolbl()
        {
            // Obtener el año de la fecha seleccionada en el DateTimePicker
            int anio = dtp_Inicio.Value.Year;

            // Mostrar el año en el Label
            lblAnio.Text = anio.ToString();
        }
        private void CalcularDiferenciaEnDias(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas de los DateTimePickers
            DateTime fechaInicio = dtp_Inicio.Value;
            DateTime fechaFin = dtp_Fin.Value;

            // Calcular la diferencia en días
            int diferenciaEnDias = (int)(fechaFin - fechaInicio).TotalDays;
            diferenciaEnDias += 1;

            // Validar que la diferencia sea positiva y mayor que 0
            if (cboxTPrestacion.Text == "")
            {
                MessageBox.Show("Por favor seleccionar el tipo de prestacion primero");
            }
            else
            {
                if (diferenciaEnDias > 0)
                {
                    // Mostrar la diferencia en el TextBox
                    txtDiasLic.Text = diferenciaEnDias.ToString();
                    if (cboxTPrestacion.Text == "MATERNIDAD")
                    {
                        lblDiasES.Text = diferenciaEnDias.ToString();
                        lblDiasEmpleador.Text = "0";
                    }
                    else    //si es diferente a maternidad en cboxTipo
                    {
                        ActualizarTablaMuestra();

                        if (dgvMuestra.Rows.Count == 0) // Si no hay filas en el DataGridView
                        {
                            if (diferenciaEnDias < 20)
                            {
                                lblDiasEmpleador.Text = diferenciaEnDias.ToString();
                                lblDiasES.Text = "0";
                            }
                            else
                            {
                                int diasLicenciaEmpleador = 20;
                                int diasLicenciaEsSalud = diferenciaEnDias - diasLicenciaEmpleador;

                                lblDiasEmpleador.Text = diasLicenciaEmpleador.ToString();
                                lblDiasES.Text = diasLicenciaEsSalud.ToString();
                            }
                        }
                        if (dgvMuestra.Rows.Count != 0) //Si hay filas en dgvMuestra
                        {
                            int sumaDiasEmpleador = 0;
                            foreach (DataGridViewRow row in dgvMuestra.Rows)
                            {
                                if (row.Cells["Empleador"].Value != null && row.Cells["Empleador"].Value != DBNull.Value)
                                {
                                    sumaDiasEmpleador += Convert.ToInt32(row.Cells["Empleador"].Value);
                                }
                            }
                            if (dgvMuestra.Rows[0].Cells["TIPO"].Value != null && dgvMuestra.Rows[0].Cells["TIPO"].Value.ToString() == "MATERNIDAD")
                            {

                                if (sumaDiasEmpleador < 20)
                                {
                                    int diasRestantesEmpleador = 20 - sumaDiasEmpleador;
                                    lblDiasEmpleador.Text = diasRestantesEmpleador.ToString();

                                    int diasRestantesEmpleado = diferenciaEnDias - diasRestantesEmpleador;
                                    lblDiasES.Text = (diasRestantesEmpleado < 0) ? "0" : diasRestantesEmpleado.ToString(); // Asegurar que los días del empleado no sean negativos
                                }
                                else
                                {
                                    lblDiasEmpleador.Text = "0";
                                    lblDiasES.Text = diferenciaEnDias.ToString();
                                }
                            }

                            else
                            {
                                // Si no es la primera fila "MATERNIDAD", continuar con el procesamiento

                                // Calcular la suma de días de licencia para el empleador
                                //int sumaDiasEmpleador = 0;
                                

                                // Calcular los días restantes de licencia para el empleador y el empleado
                                if (sumaDiasEmpleador < 20)
                                {
                                    int diasRestantesEmpleador = 20 - sumaDiasEmpleador;
                                    lblDiasEmpleador.Text = diasRestantesEmpleador.ToString();

                                    int diasRestantesEmpleado = diferenciaEnDias - diasRestantesEmpleador;
                                    lblDiasES.Text = (diasRestantesEmpleado < 0) ? "0" : diasRestantesEmpleado.ToString(); // Asegurar que los días del empleado no sean negativos
                                }
                                else
                                {
                                    lblDiasEmpleador.Text = "0";
                                    lblDiasES.Text = diferenciaEnDias.ToString();
                                }
                            }
                        }
                    }
                }
                else
                {
                    txtDiasLic.Text = "";
                }
            }
            
            CargarAniolbl();
        }

        private void btnRegistrarCIT_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia de la clase Conexion
                Conexion conexion = Conexion.getInstancia();


                // Crear la consulta SQL para insertar datos en la tabla PERSONAL_CIT
                string query = @"INSERT INTO PERSONAL_CIT 
                                (APENOM, T_P_ECONOMICA, CIT, F_INICIO, F_FIN, DIAS, COL_MED, EXPEDIENTE, DNI, INFORME, Empleador, EsSalud) 
                                VALUES (@ApellidosNombres, @TipoEconomica, @CIT, @FechaInicio, @FechaFin,@Dias, @ColMedico,
                                @Expediente, @DNI, @Informe, @Empleador, @EsSalud)";

                // Crear un array de parámetros
                SQLiteParameter[] parametros = new SQLiteParameter[]
                {
                    new SQLiteParameter("@ApellidosNombres", txtApellidosNombres.Text),
                    new SQLiteParameter("@TipoEconomica", cboxTPrestacion.Text),
                    new SQLiteParameter("@CIT", txtCIT.Text),
                    new SQLiteParameter("@FechaInicio", dtp_Inicio.Value.ToString("dd/MM/yyyy")),
                    new SQLiteParameter("@FechaFin", dtp_Fin.Value.ToString("dd/MM/yyyy")),
                    new SQLiteParameter("@Dias", txtDiasLic.Text),
                    new SQLiteParameter("@ColMedico", txtColMedico.Text),
                    new SQLiteParameter("@Expediente", txtExpediente.Text),
                    new SQLiteParameter("@DNI", txtDNI.Text),
                    new SQLiteParameter("@Informe", cboxInforme.Text),
                    new SQLiteParameter("@Empleador", lblDiasEmpleador.Text),
                    new SQLiteParameter("@EsSalud", lblDiasES.Text),
                };

                // Ejecutar la consulta de inserción
                conexion.EjecutarConsulta(query, parametros);

                MessageBox.Show("Datos registrados correctamente en la tabla PERSONAL_CIT.");

                FrmInicio frmInicio = Application.OpenForms.OfType<FrmInicio>().FirstOrDefault();
                if (frmInicio != null)
                {
                    frmInicio.ActualizarFilaTabla1();
                    //frmInicio.ActualizarTabla1();
                    frmInicio.ActualizarTabla2();
                    ActualizarTablaMuestra();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar los datos: " + ex.Message);
            }
        }

        private void CargarDatosEndgvMuestra(string dni, string anio)
        {
            try
            {
                if (lblAnio.Text != null)
                {
                    string query = @"SELECT [ID_CIT] AS 'ID', [CIT] AS 'N° C.I.T.', [F_INICIO] AS 'Fecha Inicio', [F_FIN] AS 'Fecha Fin', 
                        [COL_MED] AS 'Col Medico', [T_P_ECONOMICA] AS 'Tipo',
                        [DIAS] AS 'Dias', [Empleador] AS 'Empleador', [EsSalud] AS 'EsSalud',
                        [EXPEDIENTE] AS 'Expediente', [INFORME] AS 'Informe'
                        FROM PERSONAL_CIT WHERE DNI = @DNI and SUBSTR(F_INICIO, -4)=@Anio";

                    SQLiteParameter[] parameters =
                    {
                    new SQLiteParameter("@DNI", dni),
                    new SQLiteParameter("@Anio", anio)
                    };

                    Conexion conexion = Conexion.getInstancia();
                    DataTable dataTable = conexion.EjecutarConsulta(query, parameters);
                    int totalDias = 0;

                    foreach (DataRow row in dataTable.Rows)
                    {
                        totalDias += Convert.ToInt32(row["Dias"]);
                    }

                    // Asignar los días a las columnas Empleador y EsSalud en el DataTable
                    int diasEmpleador = 20;
                    int diasEsSalud = totalDias - diasEmpleador;

                    dgvMuestra.DataSource = dataTable;
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow lastRow = dataTable.Rows[dataTable.Rows.Count - 1];
                        lblDiasEmpleador.Text = lastRow["Empleador"].ToString();
                        lblDiasES.Text = lastRow["EsSalud"].ToString();
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }
        #region parametros
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
        private void cboxInforme_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        #endregion

        private void cboxTPrestacion_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private bool mouseDown;
        private Point lastLocation;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int deltaX = e.Location.X - lastLocation.X;
                int deltaY = e.Location.Y - lastLocation.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
