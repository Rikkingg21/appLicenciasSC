namespace appLicenciasSC.Presentacion
{
    partial class SeleccionDePeriodo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionDePeriodo));
            this.cboxAnio = new System.Windows.Forms.ComboBox();
            this.cboxMes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.dgvMuestra = new System.Windows.Forms.DataGridView();
            this.btn_Excel = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuestra)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboxAnio
            // 
            this.cboxAnio.BackColor = System.Drawing.Color.White;
            this.cboxAnio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboxAnio.FormattingEnabled = true;
            this.cboxAnio.Location = new System.Drawing.Point(199, 96);
            this.cboxAnio.Margin = new System.Windows.Forms.Padding(6);
            this.cboxAnio.MaxLength = 4;
            this.cboxAnio.Name = "cboxAnio";
            this.cboxAnio.Size = new System.Drawing.Size(121, 32);
            this.cboxAnio.TabIndex = 25;
            this.cboxAnio.SelectedIndexChanged += new System.EventHandler(this.cboxAnio_SelectedIndexChanged);
            // 
            // cboxMes
            // 
            this.cboxMes.FormattingEnabled = true;
            this.cboxMes.Location = new System.Drawing.Point(199, 55);
            this.cboxMes.Name = "cboxMes";
            this.cboxMes.Size = new System.Drawing.Size(121, 32);
            this.cboxMes.TabIndex = 29;
            this.cboxMes.SelectedIndexChanged += new System.EventHandler(this.cboxMes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "Seleccionar Mes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(35, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 24);
            this.label2.TabIndex = 31;
            this.label2.Text = "Seleccionar Año:";
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Location = new System.Drawing.Point(460, 58);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(94, 32);
            this.btn_imprimir.TabIndex = 33;
            this.btn_imprimir.Text = "Ver PDF";
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // dgvMuestra
            // 
            this.dgvMuestra.AllowUserToAddRows = false;
            this.dgvMuestra.AllowUserToDeleteRows = false;
            this.dgvMuestra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMuestra.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMuestra.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.dgvMuestra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMuestra.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvMuestra.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(96)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(96)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMuestra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMuestra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMuestra.EnableHeadersVisualStyles = false;
            this.dgvMuestra.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(204)))), ((int)(((byte)(227)))));
            this.dgvMuestra.Location = new System.Drawing.Point(12, 139);
            this.dgvMuestra.Name = "dgvMuestra";
            this.dgvMuestra.ReadOnly = true;
            this.dgvMuestra.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvMuestra.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMuestra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMuestra.Size = new System.Drawing.Size(1720, 466);
            this.dgvMuestra.TabIndex = 34;
            // 
            // btn_Excel
            // 
            this.btn_Excel.Location = new System.Drawing.Point(460, 96);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(94, 32);
            this.btn_Excel.TabIndex = 37;
            this.btn_Excel.Text = "Excel";
            this.btn_Excel.UseVisualStyleBackColor = true;
            this.btn_Excel.Click += new System.EventHandler(this.btn_Excel_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(566, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 35);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(113)))), ((int)(((byte)(163)))));
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(606, 35);
            this.panel2.TabIndex = 38;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(205, 25);
            this.label9.TabIndex = 1;
            this.label9.Text = "Seleccionar Periodo";
            // 
            // SeleccionDePeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(606, 150);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_Excel);
            this.Controls.Add(this.dgvMuestra);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxMes);
            this.Controls.Add(this.cboxAnio);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SeleccionDePeriodo";
            this.Text = "SeleccionDePeriodo";
            this.Load += new System.EventHandler(this.SeleccionDePeriodo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuestra)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboxAnio;
        private System.Windows.Forms.ComboBox cboxMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.DataGridView dgvMuestra;
        private System.Windows.Forms.Button btn_Excel;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
    }
}