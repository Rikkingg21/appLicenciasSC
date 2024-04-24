using appLicenciasSC.Logica;
using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Drawing;
using System.Net;
using iTextSharp.tool.xml.html;
using Org.BouncyCastle.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Globalization;


namespace appLicenciasSC.Presentacion
{
    public partial class FrmInicio : Form
    {
        private Conexion conexion;
        public FrmInicio()
        {
            InitializeComponent();
            conexion = Conexion.getInstancia();
            menuStrip4.Renderer = new MiRenderizador();
        }
        private void FrmInicio_Load(object sender, EventArgs e) //RB
        {
            CargarAniosComboBox();
            cboxAnio.SelectedIndex = 0;
            AplicarPintadoFilas();

        }
        private void CargarAniosComboBox()
        {
            try
            {
                // Consulta SQL para obtener los años distintos de la columna F_INICIO
                string query = "SELECT DISTINCT SUBSTR(F_INICIO, -4) AS Anio FROM PERSONAL_CIT ORDER BY Anio DESC";

                // Ejecutar la consulta y obtener un DataTable
                DataTable dataTable = conexion.EjecutarConsulta(query);

                // Limpiar ComboBox antes de cargar los nuevos años
                cboxAnio.Items.Clear();

                // Agregar los años al ComboBox
                foreach (DataRow row in dataTable.Rows)
                {
                    string anio = row["Anio"].ToString();
                    cboxAnio.Items.Add(anio);
                }

                // Seleccionar el primer año por defecto si hay elementos en el ComboBox
                if (cboxAnio.Items.Count > 0)
                {
                    cboxAnio.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los años: " + ex.Message);
            }
        }

        public void ActualizarTabla1() {
            CargarDatosEnDataGridViewTabla1(cboxAnio.Text);
            AplicarPintadoFilas();
            SeleccionarUltimaFiladgvTabla2();
        }
        private void SeleccionarUltimaFiladgvTabla2()
        {
            if (dgvTabla2.Rows.Count > 0)
            {
                dgvTabla2.ClearSelection(); // Limpiar la selección actual
                int ultimaFilaIndex = dgvTabla2.Rows.Count - 1;
                dgvTabla2.Rows[ultimaFilaIndex].Selected = true;
                dgvTabla2.FirstDisplayedScrollingRowIndex = ultimaFilaIndex; // Desplazar la vista para que la última fila sea visible
            }
        }
        public void ActualizarFilaTabla1()
        {
            CargarActualizarFilaTabla1(cboxAnio.Text);
            SeleccionarUltimaFiladgvTabla2();
            
        }

        private void CargarActualizarFilaTabla1(string anio)
        {
            try
            {
                // Verifica si hay una fila seleccionada en el DataGridView
                if (dgvTabla1.SelectedRows.Count > 0)
                {
                    // Obtiene la fila seleccionada
                    DataGridViewRow filaSeleccionada = dgvTabla1.SelectedRows[0];

                    // Obtener el índice de la fila seleccionada
                    int indiceFilaSeleccionada = filaSeleccionada.Index;

                    // Consulta SQL para obtener los datos del personal
                    string dni = filaSeleccionada.Cells["DNI"].Value.ToString();
                    int totalDias = CalcularTotalDias(dni, anio); // Calcular la suma de los días totales

                    // Asignar el total de días a la columna "Dias Totales" de la fila seleccionada
                    filaSeleccionada.Cells["Dias Totales"].Value = totalDias;
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para actualizar.");
                }
                CalcularFechaInicioEsSalud(anio);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }
        private void cboxAnio_SelectedIndexChanged(object sender, EventArgs e) {
            string anio = cboxAnio.Text;
            ActualizarTabla1();
            AplicarPintadoFilas();
            CalcularFechaInicioEsSalud(anio);
        }
        private void CargarDatosEnDataGridViewTabla1(string anio)
        {
            try
            {
                // Consulta SQL para obtener todos los registros de la tabla PERSONAL
                string query = "SELECT * FROM PERSONAL";

                // Ejecutar la consulta y obtener un DataTable
                DataTable dataTable = conexion.EjecutarConsulta(query);

                // Agregar columnas adicionales al DataTable
                dataTable.Columns.Add("Fecha Inicio EsSalud", typeof(DateTime)); // Agregar columna Fecha Inicio de tipo DateTime
                dataTable.Columns.Add("Dias Totales", typeof(int)); // Agregar columna Dias de tipo entero

                // Calcular la suma de los días totales de la tabla PERSONAL_CIT
                foreach (DataRow row in dataTable.Rows)
                {
                    string dni = row["DNI"].ToString();
                    int totalDias = CalcularTotalDias(dni, anio); // Calcular la suma de los días totales

                    row["Dias Totales"] = totalDias; // Asignar el total de días a la columna Dias Totales

                }
                // Asignar el DataTable al DataGridView
                dgvTabla1.DataSource = dataTable;
                dgvTabla1.Columns[0].Width = 100;
                dgvTabla1.Columns[1].Width = 100;
                //Para que no se ordene
                foreach (DataGridViewColumn column in dgvTabla1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void AplicarPintadoFilas()
        {
            try
            {
                // Consulta SQL para obtener los registros de PERSONAL_CIT que cumplen con las condiciones
                string query = @"SELECT DNI, SUM(EsSalud) AS TotalDias
                 FROM PERSONAL_CIT
                 WHERE SUBSTR(F_INICIO, -4) = '2024' AND INFORME = 'CANJE'
                 GROUP BY DNI
                 HAVING SUM(EsSalud) > 20";

                // Ejecutar la consulta y obtener un DataTable
                DataTable dataTable = conexion.EjecutarConsulta(query);

                // Iterar sobre las filas del DataGridView
                foreach (DataGridViewRow row in dgvTabla1.Rows)
                {
                    // Obtener el DNI de la fila actual
                    string dni = row.Cells["DNI"].Value.ToString();

                    // Verificar si el DNI existe en los resultados de la consulta
                    DataRow[] resultados = dataTable.Select("DNI = '" + dni + "'");
                    if (resultados.Length > 0)
                    {
                        // Si el DNI existe y cumple con las condiciones, pintar la fila de rojo
                        //row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(236, 112, 99);


                        // Verificar si la fila actual es la fila seleccionada
                        if (dgvTabla1.CurrentRow != null && dgvTabla1.CurrentRow.Index == row.Index)
                        {
                            // Si la fila actual es la fila seleccionada, cambiar su color a rosa
                            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(236, 112, 99);
                            row.DefaultCellStyle.ForeColor = Color.White;
                        }

                    }
                    else
                    {
                        //row.DefaultCellStyle.BackColor = Color.Cyan;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 134, 193);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar el pintado de filas en dgvTabla1: " + ex.Message);
            }
        }

        private int CalcularTotalDias(string dni, string anio)
        {
            int totalDias = 0;
            try
            {
                // Consulta SQL para obtener la suma de los días totales para un DNI específico
                string query = "SELECT SUM(DIAS) FROM PERSONAL_CIT WHERE DNI = @DNI and SUBSTR(F_INICIO, -4)=@anio";

                // Crear un array de parámetros para el DNI
                SQLiteParameter[] parametros = new SQLiteParameter[]
                {
                    new SQLiteParameter("@DNI", dni),
                    new SQLiteParameter("@anio", anio)
                };

                // Ejecutar la consulta y obtener el total de días
                DataTable result = conexion.EjecutarConsulta(query, parametros);

                // Verificar si hay filas en el resultado
                if (result.Rows.Count > 0 && result.Rows[0][0] != DBNull.Value)
                {
                    totalDias = Convert.ToInt32(result.Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular los días totales: " + ex.Message);
            }
            return totalDias;
        }
       
        

        #region AGREGAR PERSONAL
        //agregar personal
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            FrmIngresoPersonalSubsidiado frmIngresoPersonalSubsidiado = new FrmIngresoPersonalSubsidiado();
            frmIngresoPersonalSubsidiado.Show();
        }
        #endregion

        #region AGREGAR PERSONAL CIT
        //Agregar CIT personal
        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado al menos una fila en el DataGridView
            if (dgvTabla1.SelectedRows.Count > 0)
            {
                // Obtener el valor de la celda "APELLIDOS Y NOMBRES" de la fila seleccionada
                string nombreSeleccionado = dgvTabla1.SelectedRows[0].Cells["APELLIDOS Y NOMBRES"].Value.ToString();
                string DNIseleccionado = dgvTabla1.SelectedRows[0].Cells["DNI"].Value.ToString();

                // Abrir el formulario FrmIngresarNuevoCIT con el valor del nombre seleccionado
                FrmIngresarNuevoCIT frmIngresarNuevoCIT = new FrmIngresarNuevoCIT(nombreSeleccionado,DNIseleccionado);
                frmIngresarNuevoCIT.Show();
            }
            else
            {
                MessageBox.Show("Selecciona una fila antes de abrir el formulario.");
            }
        }
        #endregion

        #region EDITAR PERSONAL
        //editar personal
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado al menos una fila en el DataGridView dgvTabla1
                if (dgvTabla1.SelectedRows.Count > 0)
                {
                    // Obtener los datos de la fila seleccionada en dgvTabla1
                    string nombreSeleccionado = dgvTabla1.SelectedRows[0].Cells["APELLIDOS Y NOMBRES"].Value.ToString();
                    string DNIseleccionado = dgvTabla1.SelectedRows[0].Cells["DNI"].Value.ToString();
                    string C_TrabajoSelec = dgvTabla1.SelectedRows[0].Cells["C_TRABAJO"].Value.ToString();
                    string CargoSelect = dgvTabla1.SelectedRows[0].Cells["CARGO"].Value.ToString();
                    string AutogeneradoSelec = dgvTabla1.SelectedRows[0].Cells["AUTOGENERADO"].Value.ToString();
                    string T_ServidorSelec = dgvTabla1.SelectedRows[0].Cells["TIPO_SERVIDOR"].Value.ToString();

                    // Abrir el formulario FrmEditarPersonal con los datos de la fila seleccionada
                    FrmEditarPersonalSubcidiado frmEditarPersonalSubcidiado = new FrmEditarPersonalSubcidiado(nombreSeleccionado, DNIseleccionado, C_TrabajoSelec, CargoSelect, AutogeneradoSelec, T_ServidorSelec);
                    frmEditarPersonalSubcidiado.Show();
                }
                else
                {
                    MessageBox.Show("Selecciona una fila en dgvTabla1 antes de abrir el formulario de edición.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de edición: " + ex.Message);
            }
        }
        #endregion

        #region ELIMINAR PERSONAL
        //ELIMINAR REGISTRO DEL PERSONAL
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay al menos una fila seleccionada en dgvTabla1
                if (dgvTabla1.SelectedRows.Count > 0)
                {
                    // Obtener el DNI del personal seleccionado
                    string dni = dgvTabla1.SelectedRows[0].Cells["DNI"].Value.ToString();

                    // Confirmar la eliminación con un cuadro de diálogo
                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro para el DNI " + dni + "?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    // Si el usuario confirma la eliminación
                    if (result == DialogResult.Yes)
                    {
                        // Consulta SQL para eliminar el registro de PERSONAL
                        string queryEliminarPersonal = "DELETE FROM PERSONAL WHERE DNI = @DNI";

                        // Consulta SQL para eliminar el historial relacionado en PERSONAL_CIT
                        string queryEliminarHistorial = "DELETE FROM PERSONAL_CIT WHERE DNI = @DNI";

                        // Crear un array de parámetros para el DNI
                        SQLiteParameter[] parametros = new SQLiteParameter[]
                        {
                    new SQLiteParameter("@DNI", dni)
                        };

                        // Ejecutar el comando de eliminación de PERSONAL
                        conexion.EjecutarComando(queryEliminarPersonal, parametros);

                        // Ejecutar el comando de eliminación de historial en PERSONAL_CIT
                        conexion.EjecutarComando(queryEliminarHistorial, parametros);

                        // Actualizar la visualización de dgvTabla1 y dgvTabla2
                        ActualizarTabla1();
                        ActualizarTabla2();

                        MessageBox.Show("Registro eliminado correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona una fila en dgvTabla1 antes de eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        //FILTRO DE BUSQUEDA
        #region FILTRO
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Obtener el texto del filtro
                string filtro = txtFiltro.Text.Trim();

                // Consulta SQL para obtener los registros filtrados de la tabla PERSONAL
                string query = @"SELECT *, 
                                CAST(NULL AS DATETIME) AS [Fecha Inicio EsSalud], 
                                CAST(NULL AS INT) AS [Dias Totales] 
                         FROM PERSONAL 
                         WHERE [APELLIDOS Y NOMBRES] LIKE '%" + filtro + @"%' 
                         OR DNI LIKE '%" + filtro + @"%'";
                

                // Ejecutar la consulta y obtener un DataTable
                DataTable dataTable = conexion.EjecutarConsulta(query);
                foreach (DataRow row in dataTable.Rows)
                {
                    string dni = row["DNI"].ToString();
                    string anio = cboxAnio.Text; // Obtener el año seleccionado en el ComboBox
                    int totalDias = CalcularTotalDias(dni, anio); // Calcular la suma de los días totales

                    // Asignar los valores calculados a las columnas adicionales
                    //row["Fecha Inicio EsSalud"] = ObtenerFechaInicioEsSalud(dni, anio);
                    row["Dias Totales"] = totalDias;
                    
                }

                // Asignar el DataTable al DataGridView
                dgvTabla1.DataSource = dataTable;
                AplicarPintadoFilas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar el filtro: " + ex.Message);
            }
        }
        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        #endregion

        public void ActualizarTabla2()
        {
            string anio = cboxAnio.Text;
            CargarDatosEnDataGridViewTabla2(anio);
            CalcularFechaInicioEsSalud(anio);
            AplicarPintadoFilas();
        }
        
        private void CargarDatosEnDataGridViewTabla2(string anio)
        {
            try
            {
                if (dgvTabla1.SelectedRows.Count > 0)
                {
                    string DNIseleccionado = dgvTabla1.SelectedRows[0].Cells["DNI"].Value.ToString();
                    string APENOMseleccionado = dgvTabla1.SelectedRows[0].Cells["APELLIDOS Y NOMBRES"].Value.ToString();

                    lblNom.Text = APENOMseleccionado;
                    lblDNI.Text = DNIseleccionado;

                    string query = @"SELECT [ID_CIT] AS 'ID', [CIT] AS 'N° C.I.T.', [F_INICIO] AS 'Fecha Inicio', [F_FIN] AS 'Fecha Fin', 
                    [COL_MED] AS 'Col Medico', [T_P_ECONOMICA] AS 'Tipo',
                    [DIAS] AS 'Dias', [Empleador] AS 'Empleador', [EsSalud] AS 'EsSalud',
                    [EXPEDIENTE] AS 'Expediente', [INFORME] AS 'Informe'
                    FROM PERSONAL_CIT WHERE DNI = @DNI and SUBSTR(F_INICIO, -4)=@anio";

                    SQLiteParameter[] parametros = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@DNI", DNIseleccionado),
                        new SQLiteParameter("@anio", anio)
                    };

                    DataTable dataTable = conexion.EjecutarConsulta(query, parametros);

                    dgvTabla2.DataSource = dataTable;
                    SeleccionarUltimaFiladgvTabla2();
                }
                else
                {
                    dgvTabla2.DataSource = null;
                    lblNom.Text = "";
                    lblDNI.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en dgvTabla2: " + ex.Message);
            }
        }
        private void CalcularFechaInicioEsSalud(string anio)
        {
            try
            {
                foreach (DataGridViewRow row in dgvTabla1.Rows)
                {
                    string dni = row.Cells["DNI"].Value.ToString();

                    // Consulta SQL para obtener la fecha de inicio de EsSalud y EsSalud para un DNI específico
                    string query = @"SELECT F_FIN, EsSalud FROM PERSONAL_CIT
                             WHERE DNI = @DNI AND EsSalud != 0 AND SUBSTR(F_INICIO, -4)=@anio
                             ORDER BY F_FIN ASC
                             LIMIT 1";

                    SQLiteParameter[] parametros = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@DNI", dni),
                        new SQLiteParameter("@anio", anio)
                    };

                    // Ejecutar la consulta
                    DataTable resultado = conexion.EjecutarConsulta(query, parametros);

                    // Verificar si se encontraron resultados
                    if (resultado.Rows.Count > 0)
                    {
                        DateTime fechaFin = Convert.ToDateTime(resultado.Rows[0]["F_FIN"]);
                        int esSalud = Convert.ToInt32(resultado.Rows[0]["EsSalud"]);

                        // Restar EsSalud de F_FIN
                        DateTime fechaInicioEsSalud = fechaFin.AddDays(-esSalud);

                        // Asignar el valor calculado a la celda "Fecha Inicio EsSalud"
                        row.Cells["Fecha Inicio EsSalud"].Value = fechaInicioEsSalud;
                    }
                    //else
                    //{
                    //    row.Cells["Fecha Inicio EsSalud"].Value = DateTime.MinValue;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular la fecha de inicio para EsSalud: " + ex.Message);
            }
        }



        private void dgvTabla1_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarTabla2();
            
        }
        #region ELIMINAR PERSONAL CIT
        private void eliminarCITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay al menos una fila seleccionada en dgvTabla2
                if (dgvTabla2.SelectedRows.Count > 0)
                {
                    string cit = dgvTabla2.SelectedRows[0].Cells["ID"].Value.ToString();

                    // Confirmar la eliminación con un cuadro de diálogo
                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro con el N° C.I.T. " + cit + "?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    // Si el usuario confirma la eliminación
                    if (result == DialogResult.Yes)
                    {
                        string query = "DELETE FROM PERSONAL_CIT WHERE ID_CIT = @ID_CIT";

                        // Crear un array de parámetros para el N° C.I.T.
                        SQLiteParameter[] parametros = new SQLiteParameter[]
                        {
                            new SQLiteParameter("@ID_CIT", cit)
                        };

                        // Ejecutar el comando de eliminación
                        conexion.EjecutarComando(query, parametros);

                        ActualizarFilaTabla1();

                        ActualizarTabla2();
                        SeleccionarUltimaFiladgvTabla2();

                        MessageBox.Show("Registro eliminado correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona una fila en dgvTabla2 antes de eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region EDITAR PERSONAL CIT
        private void editarCITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado al menos una fila en el DataGridView dgvTabla2
                if (dgvTabla2.SelectedRows.Count > 0)
                {
                    // Obtener los datos de la fila seleccionada en dgvTabla2
                    string IDseleccionado = dgvTabla2.SelectedRows[0].Cells["ID"].Value.ToString();
                    string ApellidoNombreSeleccionado = lblNom.Text;
                    string DNIseleccionado = lblDNI.Text;
                    string TPrestacionSeleccionado = dgvTabla2.SelectedRows[0].Cells["Tipo"].Value.ToString();
                    string CITseleccionado = dgvTabla2.SelectedRows[0].Cells["N° C.I.T."].Value.ToString();
                    string ColMedicoSeleccionado = dgvTabla2.SelectedRows[0].Cells["Col Medico"].Value.ToString();
                    string dtp_InicioSeleccionado = dgvTabla2.SelectedRows[0].Cells["Fecha Inicio"].Value.ToString();
                    string dtp_FinSeleccionado = dgvTabla2.SelectedRows[0].Cells["Fecha Fin"].Value.ToString();
                    
                   
                    string DiasLicSeleccionado = dgvTabla2.SelectedRows[0].Cells["Dias"].Value.ToString();
                    string ExpedienteSeleccionado = dgvTabla2.SelectedRows[0].Cells["Expediente"].Value.ToString();
                    string informeSeleccionado = dgvTabla2.SelectedRows[0].Cells["Informe"].Value.ToString();
                    
                    // Abrir el formulario FrmEditarPersonal con los datos de la fila seleccionada
                    FrmEditarNuevoCIT frmEditarNuevoCIT = new FrmEditarNuevoCIT(IDseleccionado,ApellidoNombreSeleccionado, DNIseleccionado, TPrestacionSeleccionado, CITseleccionado,
                        ColMedicoSeleccionado, dtp_InicioSeleccionado, dtp_FinSeleccionado, DiasLicSeleccionado, ExpedienteSeleccionado, informeSeleccionado);
                    frmEditarNuevoCIT.Show();
                }
                else
                {
                    MessageBox.Show("Selecciona una fila en dgvTabla2 antes de abrir el formulario de edición.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de edición: " + ex.Message);
            }
        }
        #endregion

        #region IMPRIMIR
        //IMPRIMIR
        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            string nombreArchivo = "pdfchancado.pdf";
            string rutaCarpeta = @"C:\Documents\prueba";
            string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

            // Verificar si el archivo existe y está en uso
            if (!Directory.Exists(rutaCarpeta))
            {
                try
                {
                    Directory.CreateDirectory(rutaCarpeta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al crear la carpeta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                try
                {
                    // Crear el archivo en la ruta especificada
                    using (File.Create(rutaCompleta)) { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al crear el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            try
            {
                string paginahtml_texto = Properties.Resources.plantilla.ToString();
                string APENOMseleccionado = dgvTabla1.SelectedRows[0].Cells["APELLIDOS Y NOMBRES"].Value.ToString();
                string DNIseleccionado = dgvTabla1.SelectedRows[0].Cells["DNI"].Value.ToString();
                string T_ServidorSeleccionado = dgvTabla1.SelectedRows[0].Cells["TIPO_SERVIDOR"].Value.ToString();
                string c_trabajoSeleccionado = dgvTabla1.SelectedRows[0].Cells["C_TRABAJO"].Value.ToString();
                string DiasSeleccionado = dgvTabla1.SelectedRows[0].Cells["DIAS TOTALES"].Value.ToString();


                paginahtml_texto = paginahtml_texto.Replace("@ApeNom", APENOMseleccionado);
                paginahtml_texto = paginahtml_texto.Replace("@DNI", DNIseleccionado);
                paginahtml_texto = paginahtml_texto.Replace("@Fecha", DateTime.Now.ToString("dd/MM/yyyy"));
                paginahtml_texto = paginahtml_texto.Replace("@T_Servicio", T_ServidorSeleccionado);
                paginahtml_texto = paginahtml_texto.Replace("@C_Trabajo", c_trabajoSeleccionado);
                paginahtml_texto = paginahtml_texto.Replace("@Total", DiasSeleccionado);

                string filas = string.Empty;

                foreach (DataGridViewRow row in dgvTabla2.Rows)
                {
                    filas += "<tr>";
                    //filas += "<td>" + dgvTabla2.Rows[0].Cells["Fecha Inicio"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Fecha Inicio"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Fecha Fin"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Dias"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Tipo"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["N° C.I.T."].Value.ToString() + " </td>";
                    filas += "<td>" + row.Cells["Col Medico"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Expediente"].Value.ToString() + "</td>";
                    filas += "<td>" + "Empleador: " + row.Cells["Empleador"].Value.ToString() + " / EsSalud: " + row.Cells["EsSalud"].Value.ToString() + "</td>";
                    //filas += "<td>" + row.Cells["EsSalud"].Value.ToString() + "</td>";
                    filas += "</tr>";
                }
                paginahtml_texto = paginahtml_texto.Replace("@Filas", filas);

                using (FileStream stream = new FileStream(rutaCompleta, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));
                    using (StringReader sr = new StringReader(paginahtml_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                }
                FrmVistaPDF frmVistaPDF = new FrmVistaPDF();
                frmVistaPDF.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para verificar si el archivo está en uso
        private bool IsFileInUse(string filePath)
        {
            try
            {
                using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }
            return false;
        }
        #endregion



        

        

        private void descargarPersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = new XSSFWorkbook();

            // Crear una hoja de Excel
            ISheet sheet = workbook.CreateSheet("Datos");

            // Obtener la fila seleccionada en dgvTabla1
            DataGridViewRow filaSeleccionada = dgvTabla1.SelectedRows[0];

            // Crear la estructura de la tabla en el archivo Excel
            IRow rowHeader = sheet.CreateRow(0);
            rowHeader.CreateCell(0).SetCellValue("Apellidos y Nombre:");
            rowHeader.CreateCell(1).SetCellValue("DNI:");
            rowHeader.CreateCell(2).SetCellValue("Cargo:");
            rowHeader.CreateCell(3).SetCellValue("Centro de Trabajo:");
            rowHeader.CreateCell(4).SetCellValue("Tipo Servidor:");
            rowHeader.CreateCell(5).SetCellValue("Autogenerado:");
            rowHeader.CreateCell(6).SetCellValue("Fecha Inicio EsSalud:");
            rowHeader.CreateCell(7).SetCellValue("Días Totales:");

            // Escribir los datos de la fila seleccionada en dgvTabla1 en el archivo de Excel
            IRow rowSelectedData = sheet.CreateRow(1);
            for (int i = 0; i < dgvTabla1.Columns.Count; i++)
            {
                rowSelectedData.CreateCell(i).SetCellValue(Convert.ToString(filaSeleccionada.Cells[i].Value));
            }

            // Agregar las cabeceras de las columnas del dgvTabla2
            IRow rowColumnHeaders = sheet.CreateRow(3);
            string[] columnasAMostrar = { "N° C.I.T.", "Fecha Inicio", "Fecha Fin", "Col Medico", "Tipo", "Dias", "Empleador", "EsSalud", "Expediente" };
            for (int i = 0; i < columnasAMostrar.Length; i++)
            {
                rowColumnHeaders.CreateCell(i).SetCellValue(columnasAMostrar[i]);
            }

            // Escribir los datos de dgvTabla2 en el archivo de Excel
            for (int i = 0; i < dgvTabla2.Rows.Count; i++)
            {
                IRow rowData = sheet.CreateRow(i + 4);
                for (int j = 0; j < columnasAMostrar.Length; j++)
                {
                    rowData.CreateCell(j).SetCellValue(Convert.ToString(dgvTabla2.Rows[i].Cells[columnasAMostrar[j]].Value));
                }
            }
            for (int i = 0; i < columnasAMostrar.Length; i++)
            {
                sheet.AutoSizeColumn(i);
            }

            // Mostrar el diálogo para seleccionar la ubicación y nombre del archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "datos.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Guardar el libro de Excel en la ubicación seleccionada
                using (var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fileStream);
                }
                MessageBox.Show("Los datos se han exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void descargarPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private class MiRenderizador : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected)
                {
                    base.OnRenderMenuItemBackground(e); // Si el elemento del menú no está seleccionado, dibuja el fondo por defecto
                }
                else
                {
                    // Si el elemento del menú está seleccionado, dibuja un fondo de color SkyBlue
                    System.Drawing.Rectangle rc = new System.Drawing.Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(Brushes.SkyBlue, rc); // Puedes elegir el color que desees aquí
                    e.Graphics.DrawRectangle(Pens.Black, 1, 0, rc.Width - 2, rc.Height - 1);
                }
            }
        }
        private void toolStripMenuItem15_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem15_MouseLeave(object sender, EventArgs e)
        {
            //toolStripMenuItem15.BackColor = Color.FromArgb(31, 97, 141);
        }

        private void descargarPersonaToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            descargarPersonaToolStripMenuItem.BackColor = Color.FromArgb(31, 97, 141);
        }

        private void descargarPersonaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            descargarPersonaToolStripMenuItem.BackColor = SystemColors.Control;
        }
    }
}
