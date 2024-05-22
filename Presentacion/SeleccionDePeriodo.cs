using appLicenciasSC.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace appLicenciasSC.Presentacion
{
    public partial class SeleccionDePeriodo : Form
    {
        private Conexion conexion;

        public SeleccionDePeriodo()
        {
            InitializeComponent();
            conexion = Conexion.getInstancia();
        }

        private void SeleccionDePeriodo_Load(object sender, EventArgs e)
        {
            CargarAniosComboBox();
        }

        private void CargarAniosComboBox()
        {
            try
            {
                string query = "SELECT DISTINCT SUBSTR(F_INICIO, -4) AS Anio FROM PERSONAL_CIT ORDER BY Anio DESC";
                DataTable dataTable = conexion.EjecutarConsulta(query);
                cboxAnio.Items.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    string anio = row["Anio"].ToString();
                    cboxAnio.Items.Add(anio);
                }

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

        private void CargarMesesComboBox(string anioSeleccionado)
        {
            cboxMes.Items.Clear();
            cboxMes.Items.AddRange(new string[] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" });
        }

        private void cboxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string anio = cboxAnio.Text;
            CargarMesesComboBox(anio);
        }

        private void cboxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreMesSeleccionado = cboxMes.SelectedItem.ToString();
            string valorMesSeleccionado = ObtenerValorMes(nombreMesSeleccionado);
            string anioSeleccionado = cboxAnio.Text;
            CalcularDiasMesSeleccionado(anioSeleccionado, valorMesSeleccionado);
        }

        private string ObtenerValorMes(string nombreMes)
        {
            Dictionary<string, string> meses = new Dictionary<string, string>
            {
                {"Enero", "01"},
                {"Febrero", "02"},
                {"Marzo", "03"},
                {"Abril", "04"},
                {"Mayo", "05"},
                {"Junio", "06"},
                {"Julio", "07"},
                {"Agosto", "08"},
                {"Septiembre", "09"},
                {"Octubre", "10"},
                {"Noviembre", "11"},
                {"Diciembre", "12"}
            };

            return meses.ContainsKey(nombreMes) ? meses[nombreMes] : "";
        }

        private void CalcularDiasMesSeleccionado(string anio, string mes)
        {
            try
            {
                // Consulta SQL para combinar datos de PERSONAL_CIT y PERSONAL
                string query = @"
                    SELECT 
                    pc.APENOM as 'Apellido Nombre', 
                    pc.DNI, 
                    pc.F_INICIO as 'FECHA INICIO', 
                    pc.F_FIN as 'FECHA FIN', 
                    pc.Empleador,
                    pc.EsSalud,
                    pc.CIT as 'N° C.I.T.',
                    pc.COL_MED as 'COLEGIO MEDICO',
                    pc.EXPEDIENTE,
                    pc.T_P_ECONOMICA as 'Tipo Contingencia',
                    pc.INFORME,
                    p.CARGO,
                    p.C_TRABAJO as 'CENTRO DE TRABAJO',
                    p.TIPO_SERVIDOR as 'TIPO DE SERVIDOR'
                    FROM PERSONAL_CIT pc
                    JOIN PERSONAL p ON pc.DNI = p.DNI
                    WHERE SUBSTR(pc.F_INICIO, 7, 4) = @Anio";

                SQLiteParameter[] parameters = {
                new SQLiteParameter("@Anio", anio)
                };

                DataTable dataTable = conexion.EjecutarConsulta(query, parameters);

                // Agregar columnas adicionales
                dataTable.Columns.Add("MESES", typeof(string));
                dataTable.Columns.Add("DIAS del MES", typeof(int));
                dataTable.Columns.Add("Dias Ocupados Empleador", typeof(int));
                dataTable.Columns.Add("Dias Ocupados EsSalud", typeof(int));

                // Calcular los datos adicionales
                foreach (DataRow row in dataTable.Rows)
                {
                    string fechaInicio = row["FECHA INICIO"].ToString();
                    string fechaFin = row["FECHA FIN"].ToString();
                    List<string> meses = ObtenerMesesEntreFechas(fechaInicio, fechaFin);
                    string mesesStr = string.Join(", ", meses);
                    row["MESES"] = mesesStr;

                    // Calcular los días del mes seleccionado
                    int diasMes = CalcularDiasMesSeleccionado(fechaInicio, fechaFin, mes, anio);
                    row["DIAS del MES"] = diasMes;

                    // Calcular los días específicos para Empleador y EsSalud
                    (int diasEmpleador, int diasEsSalud) = CalcularDiasEspecificosMesSeleccionado(fechaInicio, fechaFin, mes, anio, row);
                    row["Dias Ocupados Empleador"] = diasEmpleador;
                    row["Dias Ocupados EsSalud"] = diasEsSalud;
                }

                // Filtrar los registros que abarcan el mes seleccionado
                DataTable filteredDataTable = dataTable.AsEnumerable()
                    .Where(row => row.Field<string>("MESES").Contains($"{mes}/{anio}"))
                    .CopyToDataTable();

                dgvMuestra.DataSource = filteredDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los registros del mes seleccionado: " + ex.Message);
            }
        }


        private List<string> ObtenerMesesEntreFechas(string fechaInicio, string fechaFin)
        {
            List<string> meses = new List<string>();

            try
            {
                DateTime fechaInicioDateTime;
                DateTime fechaFinDateTime;

                if (!DateTime.TryParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaInicioDateTime) ||
                    !DateTime.TryParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaFinDateTime))
                {
                    MessageBox.Show("Error al convertir las fechas en formato dd/MM/yyyy");
                    return meses;
                }

                DateTime fechaIteracion = new DateTime(fechaInicioDateTime.Year, fechaInicioDateTime.Month, 1);
                while (fechaIteracion <= fechaFinDateTime)
                {
                    meses.Add(fechaIteracion.ToString("MM/yyyy"));
                    fechaIteracion = fechaIteracion.AddMonths(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los meses entre las fechas: " + ex.Message);
            }

            return meses;
        }

        private int CalcularDiasMesSeleccionado(string fechaInicio, string fechaFin, string mes, string anio)
        {
            int diasMesSeleccionado = 0;

            try
            {
                DateTime fechaInicioDateTime;
                DateTime fechaFinDateTime;

                if (!DateTime.TryParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaInicioDateTime) ||
                    !DateTime.TryParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaFinDateTime))
                {
                    MessageBox.Show("Error al convertir las fechas en formato dd/MM/yyyy");
                    return diasMesSeleccionado;
                }

                int mesSeleccionado = int.Parse(mes);
                int anioSeleccionado = int.Parse(anio);

                DateTime primerDiaMesSeleccionado = new DateTime(anioSeleccionado, mesSeleccionado, 1);
                DateTime ultimoDiaMesSeleccionado = primerDiaMesSeleccionado.AddMonths(1).AddDays(-1);

                DateTime inicio = fechaInicioDateTime < primerDiaMesSeleccionado ? primerDiaMesSeleccionado : fechaInicioDateTime;
                DateTime fin = fechaFinDateTime > ultimoDiaMesSeleccionado ? ultimoDiaMesSeleccionado : fechaFinDateTime;

                diasMesSeleccionado = (fin - inicio).Days + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular los días del mes seleccionado: " + ex.Message);
            }

            return diasMesSeleccionado;
        }

        private (int diasEmpleador, int diasEsSalud) CalcularDiasEspecificosMesSeleccionado(string fechaInicio, string fechaFin, string mes, string anio, DataRow row)
        {
            int diasEmpleador = 0;
            int diasEsSalud = 0;

            try
            {
                DateTime fechaInicioDateTime;
                DateTime fechaFinDateTime;

                if (!DateTime.TryParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaInicioDateTime) ||
                    !DateTime.TryParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaFinDateTime))
                {
                    MessageBox.Show("Error al convertir las fechas en formato dd/MM/yyyy");
                    return (diasEmpleador, diasEsSalud);
                }

                int mesSeleccionado = int.Parse(mes);
                int anioSeleccionado = int.Parse(anio);

                DateTime primerDiaMesSeleccionado = new DateTime(anioSeleccionado, mesSeleccionado, 1);
                DateTime ultimoDiaMesSeleccionado = primerDiaMesSeleccionado.AddMonths(1).AddDays(-1);

                DateTime inicio = fechaInicioDateTime < primerDiaMesSeleccionado ? primerDiaMesSeleccionado : fechaInicioDateTime;
                DateTime fin = fechaFinDateTime > ultimoDiaMesSeleccionado ? ultimoDiaMesSeleccionado : fechaFinDateTime;

                int totalDias = (fin - inicio).Days + 1;
                int totalEmpleador = row["Empleador"] != DBNull.Value ? Convert.ToInt32(row["Empleador"]) : 0;
                int totalEsSalud = row["EsSalud"] != DBNull.Value ? Convert.ToInt32(row["EsSalud"]) : 0;

                // Ajustar los días específicos al mes seleccionado
                DateTime inicioOriginal = fechaInicioDateTime;
                DateTime finOriginal = fechaFinDateTime;
                int totalDiasOriginal = (finOriginal - inicioOriginal).Days + 1;

                if (totalDiasOriginal != 0)
                {
                    double proporcionEmpleador = (double)totalEmpleador / totalDiasOriginal;
                    double proporcionEsSalud = (double)totalEsSalud / totalDiasOriginal;

                    diasEmpleador = (int)Math.Round(proporcionEmpleador * totalDias);
                    diasEsSalud = (int)Math.Round(proporcionEsSalud * totalDias);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular los días específicos del mes seleccionado: " + ex.Message);
            }

            return (diasEmpleador, diasEsSalud);
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            string nombreArchivo = "pdfchancado.pdf";
            string rutaCarpeta = @"C:\Documents\prueba";
            string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

            try
            {
                // Verificar si el directorio existe, si no, crearlo
                if (!Directory.Exists(rutaCarpeta))
                {
                    Directory.CreateDirectory(rutaCarpeta);
                }

                // Verificar si el archivo ya existe
                if (File.Exists(rutaCompleta))
                {
                    File.Delete(rutaCompleta);
                }

                string plantillahtmlPeriodo = Properties.Resources.plantillaPeriodo.ToString();
                string MESseleccionado = cboxMes.Text.ToString();
                string ANIOseleccionado = cboxAnio.Text.ToString();

                plantillahtmlPeriodo = plantillahtmlPeriodo.Replace("@Fecha", DateTime.Now.ToString());
                plantillahtmlPeriodo = plantillahtmlPeriodo.Replace("@Mes", MESseleccionado);
                plantillahtmlPeriodo = plantillahtmlPeriodo.Replace("@Anio", ANIOseleccionado);

                string filas = string.Empty;

                foreach (DataGridViewRow row in dgvMuestra.Rows)
                {
                    filas += "<tr>";
                    filas += "<td>" + row.Cells["Fecha Inicio"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Fecha Fin"].Value.ToString() + "</td>";
                    
                    
                    filas += "<td>" + row.Cells["Apellido Nombre"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["DNI"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["DIAS del MES"].Value.ToString() + " </td>";
                    filas += "<td>" + row.Cells["Tipo de Servidor"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Tipo contingencia"].Value.ToString() + "</td>"; //tipo contingencia
                    filas += "<td>" + row.Cells["N° C.I.T."].Value.ToString() + " </td>";
                    filas += "<td>" + row.Cells["Colegio Medico"].Value.ToString() + "</td>";

                    filas += "<td>" + row.Cells["Expediente"].Value.ToString() + "</td>";
                    
                    filas += "<td>" + row.Cells["Dias Ocupados Empleador"].Value.ToString() + " </td>";
                    filas += "<td>" + row.Cells["Dias Ocupados EsSalud"].Value.ToString() + " </td>";
                    filas += "<td>" + row.Cells["Informe"].Value.ToString() + "</td>";


                    filas += "</tr>";
                }
                plantillahtmlPeriodo = plantillahtmlPeriodo.Replace("@Filas", filas);

                using (FileStream stream = new FileStream(rutaCompleta, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));
                    using (StringReader sr = new StringReader(plantillahtmlPeriodo))
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
                MessageBox.Show($"Ocurrió un error al guardar el archivo: {ex.Message}\n\nDetalles:\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Periodo");

                // Crear estilo para centrar el texto y alinearlo al medio
                ICellStyle centeredStyle = workbook.CreateCellStyle();
                centeredStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                centeredStyle.VerticalAlignment = VerticalAlignment.Center;

                // Crear las celdas combinadas y agregar los textos
                IRow row1 = sheet.CreateRow(0);
                ICell cellA1 = row1.CreateCell(0);
                cellA1.SetCellValue("Unidad de Gestión Local de Tacna - UGEL TACNA");
                cellA1.CellStyle = centeredStyle;
                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 7)); // 1A - 1H

                IRow row2 = sheet.CreateRow(1);
                ICell cellA2 = row2.CreateCell(0);
                cellA2.SetCellValue("RUC: 20533025057");
                cellA2.CellStyle = centeredStyle;
                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 7)); // 2A - 2H

                IRow row3 = sheet.CreateRow(2);
                ICell cellA3 = row3.CreateCell(0);
                string mesSeleccionado = cboxMes.Text.ToString();
                string anioSeleccionado = cboxAnio.Text.ToString();
                cellA3.SetCellValue($"Periodo: {mesSeleccionado} {anioSeleccionado}");
                cellA3.CellStyle = centeredStyle;
                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(2, 2, 0, 7)); // 3A - 3H

                ICell cellI1 = row1.CreateCell(8);
                ICell cellI2 = row2.CreateCell(8);
                ICell cellI3 = row3.CreateCell(8);
                string fecha = DateTime.Now.ToString();
                cellI1.SetCellValue("Fecha:");
                cellI1.CellStyle = centeredStyle;
                cellI2.SetCellValue(fecha);
                cellI2.CellStyle = centeredStyle;
                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 2, 8, 10)); // 1I - 3K

                // Crear las cabeceras de las columnas
                IRow rowColumnHeaders = sheet.CreateRow(3);
                string[] columnasAMostrar = { "Expediente", "Apellido Nombre", "DNI", "N° C.I.T.", "Colegio Medico", "Fecha Inicio", "Fecha Fin",
            "Dias Ocupados Empleador", "Dias Ocupados EsSalud", "Dias del Mes", "Tipo Contingencia" };
                for (int i = 0; i < columnasAMostrar.Length; i++)
                {
                    rowColumnHeaders.CreateCell(i).SetCellValue(columnasAMostrar[i]);
                }

                // Rellenar datos
                for (int i = 0; i < dgvMuestra.Rows.Count; i++)
                {
                    IRow rowData = sheet.CreateRow(i + 4); // Crear filas de datos empezando desde la fila 6
                    foreach (string columna in columnasAMostrar)
                    {
                        if (dgvMuestra.Columns.Contains(columna))
                        {
                            var cellValue = dgvMuestra.Rows[i].Cells[columna].Value?.ToString() ?? "";
                            rowData.CreateCell(Array.IndexOf(columnasAMostrar, columna)).SetCellValue(cellValue);
                        }
                    }
                }

                for (int i = 0; i < columnasAMostrar.Length; i++)
                {
                    sheet.AutoSizeColumn(i);
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Filter = "Archivos de Excel (*.xlsx)|*.xlsx",
                    FileName = $"periodo_{mesSeleccionado}_{anioSeleccionado}.xlsx"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        workbook.Write(fileStream);
                    }
                    MessageBox.Show("Los datos se han exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al exportar a Excel: {ex.Message}\n\nDetalles:\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
