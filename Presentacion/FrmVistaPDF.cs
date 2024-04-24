using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appLicenciasSC.Presentacion
{
    public partial class FrmVistaPDF : Form
    {
        public FrmVistaPDF()
        {
            InitializeComponent();
            cargarPDF();
        }
        string rutaCarpeta = @"C:\Documents\prueba\pdfchancado.pdf";
        private void cargarPDF()
        {
            PanelPDF.src = rutaCarpeta;
        }

        private void button1_Click(object sender, EventArgs e)
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
