namespace appLicenciasSC.Presentacion
{
    partial class FrmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvTabla2 = new System.Windows.Forms.DataGridView();
            this.OJO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.editarCITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarCITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvTabla1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cboxAnio = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.descargarPersonaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descargarPeriodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla2)).BeginInit();
            this.menuStrip3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvTabla2);
            this.panel1.Controls.Add(this.menuStrip3);
            this.panel1.Controls.Add(this.lblDNI);
            this.panel1.Controls.Add(this.lblNom);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 445);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1623, 429);
            this.panel1.TabIndex = 1;
            // 
            // dgvTabla2
            // 
            this.dgvTabla2.AllowUserToAddRows = false;
            this.dgvTabla2.AllowUserToDeleteRows = false;
            this.dgvTabla2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTabla2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTabla2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.dgvTabla2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTabla2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTabla2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(193)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(193)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabla2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTabla2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabla2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OJO});
            this.dgvTabla2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTabla2.EnableHeadersVisualStyles = false;
            this.dgvTabla2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(204)))), ((int)(((byte)(227)))));
            this.dgvTabla2.Location = new System.Drawing.Point(0, 38);
            this.dgvTabla2.Name = "dgvTabla2";
            this.dgvTabla2.ReadOnly = true;
            this.dgvTabla2.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvTabla2.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTabla2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTabla2.Size = new System.Drawing.Size(1623, 391);
            this.dgvTabla2.TabIndex = 2;
            // 
            // OJO
            // 
            this.OJO.HeaderText = "COLUM_OJO";
            this.OJO.Name = "OJO";
            this.OJO.ReadOnly = true;
            this.OJO.Visible = false;
            // 
            // menuStrip3
            // 
            this.menuStrip3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.menuStrip3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarCITToolStripMenuItem,
            this.eliminarCITToolStripMenuItem});
            this.menuStrip3.Location = new System.Drawing.Point(0, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(1623, 38);
            this.menuStrip3.TabIndex = 1;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // editarCITToolStripMenuItem
            // 
            this.editarCITToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editarCITToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editarCITToolStripMenuItem.Image")));
            this.editarCITToolStripMenuItem.Name = "editarCITToolStripMenuItem";
            this.editarCITToolStripMenuItem.Size = new System.Drawing.Size(94, 34);
            this.editarCITToolStripMenuItem.Text = "Editar";
            this.editarCITToolStripMenuItem.Click += new System.EventHandler(this.editarCITToolStripMenuItem_Click);
            // 
            // eliminarCITToolStripMenuItem
            // 
            this.eliminarCITToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.eliminarCITToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarCITToolStripMenuItem.Image")));
            this.eliminarCITToolStripMenuItem.Name = "eliminarCITToolStripMenuItem";
            this.eliminarCITToolStripMenuItem.Size = new System.Drawing.Size(115, 34);
            this.eliminarCITToolStripMenuItem.Text = "Eliminar";
            this.eliminarCITToolStripMenuItem.Click += new System.EventHandler(this.eliminarCITToolStripMenuItem_Click);
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(563, 13);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(70, 25);
            this.lblDNI.TabIndex = 4;
            this.lblDNI.Text = "label2";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(415, 10);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(70, 25);
            this.lblNom.TabIndex = 3;
            this.lblNom.Text = "label1";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(329, 10);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(32, 25);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "ID";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1623, 445);
            this.panel2.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dgvTabla1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 50);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1623, 389);
            this.panel7.TabIndex = 6;
            // 
            // dgvTabla1
            // 
            this.dgvTabla1.AllowUserToAddRows = false;
            this.dgvTabla1.AllowUserToDeleteRows = false;
            this.dgvTabla1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTabla1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTabla1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.dgvTabla1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTabla1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvTabla1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(96)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(96)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabla1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTabla1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabla1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTabla1.EnableHeadersVisualStyles = false;
            this.dgvTabla1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(204)))), ((int)(((byte)(227)))));
            this.dgvTabla1.Location = new System.Drawing.Point(0, 0);
            this.dgvTabla1.Name = "dgvTabla1";
            this.dgvTabla1.ReadOnly = true;
            this.dgvTabla1.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.dgvTabla1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTabla1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTabla1.Size = new System.Drawing.Size(1623, 389);
            this.dgvTabla1.TabIndex = 1;
            this.dgvTabla1.SelectionChanged += new System.EventHandler(this.dgvTabla1_SelectionChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.panel4.Controls.Add(this.cboxAnio);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.txtFiltro);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1623, 50);
            this.panel4.TabIndex = 5;
            // 
            // cboxAnio
            // 
            this.cboxAnio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cboxAnio.BackColor = System.Drawing.Color.White;
            this.cboxAnio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboxAnio.FormattingEnabled = true;
            this.cboxAnio.Location = new System.Drawing.Point(1101, 9);
            this.cboxAnio.MaxLength = 4;
            this.cboxAnio.Name = "cboxAnio";
            this.cboxAnio.Size = new System.Drawing.Size(121, 33);
            this.cboxAnio.TabIndex = 7;
            this.cboxAnio.SelectedIndexChanged += new System.EventHandler(this.cboxAnio_SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel6.Controls.Add(this.menuStrip4);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1020, 50);
            this.panel6.TabIndex = 7;
            // 
            // menuStrip4
            // 
            this.menuStrip4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.menuStrip4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip4.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14,
            this.toolStripMenuItem15});
            this.menuStrip4.Location = new System.Drawing.Point(0, 0);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.menuStrip4.Size = new System.Drawing.Size(1020, 50);
            this.menuStrip4.TabIndex = 4;
            this.menuStrip4.Text = "menuStrip4";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem10.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem10.Image")));
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Padding = new System.Windows.Forms.Padding(0, 7, 4, 7);
            this.toolStripMenuItem10.Size = new System.Drawing.Size(181, 50);
            this.toolStripMenuItem10.Text = "Ingresar Personal";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem11.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem11.Image")));
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(159, 50);
            this.toolStripMenuItem11.Text = "Ingresar C.I.T.";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem12.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem12.Image")));
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(166, 50);
            this.toolStripMenuItem12.Text = "Editar Registro";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItem12_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem13.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem13.Image")));
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(179, 50);
            this.toolStripMenuItem13.Text = "Eliminar Registro";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItem13_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem14.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem14.Image")));
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(116, 50);
            this.toolStripMenuItem14.Text = "Imprimir";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItem14_Click);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descargarPersonaToolStripMenuItem,
            this.descargarPeriodoToolStripMenuItem});
            this.toolStripMenuItem15.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem15.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem15.Image")));
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(202, 50);
            this.toolStripMenuItem15.Text = "Descargar En Excel";
            this.toolStripMenuItem15.MouseEnter += new System.EventHandler(this.toolStripMenuItem15_MouseEnter);
            this.toolStripMenuItem15.MouseLeave += new System.EventHandler(this.toolStripMenuItem15_MouseLeave);
            // 
            // descargarPersonaToolStripMenuItem
            // 
            this.descargarPersonaToolStripMenuItem.Name = "descargarPersonaToolStripMenuItem";
            this.descargarPersonaToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.descargarPersonaToolStripMenuItem.Text = "Descargar Persona";
            this.descargarPersonaToolStripMenuItem.Click += new System.EventHandler(this.descargarPersonaToolStripMenuItem_Click);
            this.descargarPersonaToolStripMenuItem.MouseEnter += new System.EventHandler(this.descargarPersonaToolStripMenuItem_MouseEnter);
            this.descargarPersonaToolStripMenuItem.MouseLeave += new System.EventHandler(this.descargarPersonaToolStripMenuItem_MouseLeave);
            // 
            // descargarPeriodoToolStripMenuItem
            // 
            this.descargarPeriodoToolStripMenuItem.Name = "descargarPeriodoToolStripMenuItem";
            this.descargarPeriodoToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.descargarPeriodoToolStripMenuItem.Text = "Descargar Periodo";
            this.descargarPeriodoToolStripMenuItem.Click += new System.EventHandler(this.descargarPeriodoToolStripMenuItem_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtFiltro.BackColor = System.Drawing.Color.White;
            this.txtFiltro.ForeColor = System.Drawing.Color.Black;
            this.txtFiltro.Location = new System.Drawing.Point(1231, 10);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(385, 31);
            this.txtFiltro.TabIndex = 5;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(1623, 874);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmInicio";
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla2)).EndInit();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MenuStrip menuStrip4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dgvTabla1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvTabla2;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem editarCITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarCITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.DataGridViewTextBoxColumn OJO;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.ComboBox cboxAnio;
        private System.Windows.Forms.ToolStripMenuItem descargarPersonaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descargarPeriodoToolStripMenuItem;
    }
}