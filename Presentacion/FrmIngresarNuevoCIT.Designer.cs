namespace appLicenciasSC.Presentacion
{
    partial class FrmIngresarNuevoCIT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIngresarNuevoCIT));
            this.btnRegistrarCIT = new System.Windows.Forms.Button();
            this.dgvMuestra = new System.Windows.Forms.DataGridView();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblDiasES = new System.Windows.Forms.Label();
            this.lblDiasEmpleador = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.cboxInforme = new System.Windows.Forms.ComboBox();
            this.txtDiasLic = new System.Windows.Forms.TextBox();
            this.txtExpediente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtColMedico = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_Fin = new System.Windows.Forms.DateTimePicker();
            this.dtp_Inicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCIT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxTPrestacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellidosNombres = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuestra)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegistrarCIT
            // 
            this.btnRegistrarCIT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(180)))), ((int)(((byte)(99)))));
            this.btnRegistrarCIT.FlatAppearance.BorderSize = 0;
            this.btnRegistrarCIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarCIT.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarCIT.Location = new System.Drawing.Point(353, 250);
            this.btnRegistrarCIT.Name = "btnRegistrarCIT";
            this.btnRegistrarCIT.Size = new System.Drawing.Size(167, 51);
            this.btnRegistrarCIT.TabIndex = 2;
            this.btnRegistrarCIT.Text = "Guardar";
            this.btnRegistrarCIT.UseVisualStyleBackColor = false;
            this.btnRegistrarCIT.Click += new System.EventHandler(this.btnRegistrarCIT_Click);
            // 
            // dgvMuestra
            // 
            this.dgvMuestra.AllowUserToAddRows = false;
            this.dgvMuestra.AllowUserToDeleteRows = false;
            this.dgvMuestra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMuestra.Location = new System.Drawing.Point(17, 392);
            this.dgvMuestra.Name = "dgvMuestra";
            this.dgvMuestra.ReadOnly = true;
            this.dgvMuestra.Size = new System.Drawing.Size(849, 199);
            this.dgvMuestra.TabIndex = 3;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(63, 350);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(70, 25);
            this.lblAnio.TabIndex = 9;
            this.lblAnio.Text = "label8";
            // 
            // lblDiasES
            // 
            this.lblDiasES.AutoSize = true;
            this.lblDiasES.Location = new System.Drawing.Point(774, 350);
            this.lblDiasES.Name = "lblDiasES";
            this.lblDiasES.Size = new System.Drawing.Size(92, 25);
            this.lblDiasES.TabIndex = 10;
            this.lblDiasES.Text = "EsSalud";
            // 
            // lblDiasEmpleador
            // 
            this.lblDiasEmpleador.AutoSize = true;
            this.lblDiasEmpleador.Location = new System.Drawing.Point(560, 350);
            this.lblDiasEmpleador.Name = "lblDiasEmpleador";
            this.lblDiasEmpleador.Size = new System.Drawing.Size(115, 25);
            this.lblDiasEmpleador.TabIndex = 11;
            this.lblDiasEmpleador.Text = "Empleador";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(113)))), ((int)(((byte)(163)))));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 40);
            this.panel1.TabIndex = 12;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 28);
            this.label9.TabIndex = 2;
            this.label9.Text = "Ingresar Nuevo C.I.T.";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(838, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 40);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtDNI);
            this.panel2.Controls.Add(this.cboxInforme);
            this.panel2.Controls.Add(this.txtDiasLic);
            this.panel2.Controls.Add(this.txtExpediente);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtColMedico);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dtp_Fin);
            this.panel2.Controls.Add(this.dtp_Inicio);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtCIT);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboxTPrestacion);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtApellidosNombres);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(878, 201);
            this.panel2.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(595, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 25);
            this.label8.TabIndex = 32;
            this.label8.Text = "Informe:";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(657, 12);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.ReadOnly = true;
            this.txtDNI.Size = new System.Drawing.Size(209, 31);
            this.txtDNI.TabIndex = 29;
            // 
            // cboxInforme
            // 
            this.cboxInforme.FormattingEnabled = true;
            this.cboxInforme.Items.AddRange(new object[] {
            "S/N",
            "REGISTRADO",
            "CANJE",
            "NOTIFICADO"});
            this.cboxInforme.Location = new System.Drawing.Point(690, 59);
            this.cboxInforme.Name = "cboxInforme";
            this.cboxInforme.Size = new System.Drawing.Size(176, 33);
            this.cboxInforme.TabIndex = 31;
            this.cboxInforme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboxInforme_KeyPress);
            // 
            // txtDiasLic
            // 
            this.txtDiasLic.Location = new System.Drawing.Point(831, 108);
            this.txtDiasLic.Name = "txtDiasLic";
            this.txtDiasLic.ReadOnly = true;
            this.txtDiasLic.Size = new System.Drawing.Size(35, 31);
            this.txtDiasLic.TabIndex = 28;
            // 
            // txtExpediente
            // 
            this.txtExpediente.Location = new System.Drawing.Point(631, 154);
            this.txtExpediente.Name = "txtExpediente";
            this.txtExpediente.Size = new System.Drawing.Size(235, 31);
            this.txtExpediente.TabIndex = 27;
            this.txtExpediente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExpediente_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(476, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 25);
            this.label7.TabIndex = 26;
            this.label7.Text = "N° Expediente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "Colegio Medico";
            // 
            // txtColMedico
            // 
            this.txtColMedico.Location = new System.Drawing.Point(179, 154);
            this.txtColMedico.Name = "txtColMedico";
            this.txtColMedico.Size = new System.Drawing.Size(235, 31);
            this.txtColMedico.TabIndex = 24;
            this.txtColMedico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColMedico_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(560, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "Hasta el";
            // 
            // dtp_Fin
            // 
            this.dtp_Fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Fin.Location = new System.Drawing.Point(657, 108);
            this.dtp_Fin.Name = "dtp_Fin";
            this.dtp_Fin.Size = new System.Drawing.Size(167, 31);
            this.dtp_Fin.TabIndex = 22;
            this.dtp_Fin.Value = new System.DateTime(2024, 3, 18, 0, 0, 0, 0);
            // 
            // dtp_Inicio
            // 
            this.dtp_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Inicio.Location = new System.Drawing.Point(387, 108);
            this.dtp_Inicio.Name = "dtp_Inicio";
            this.dtp_Inicio.Size = new System.Drawing.Size(167, 31);
            this.dtp_Inicio.TabIndex = 21;
            this.dtp_Inicio.Value = new System.DateTime(2024, 3, 18, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(307, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "Desde";
            // 
            // txtCIT
            // 
            this.txtCIT.Location = new System.Drawing.Point(81, 108);
            this.txtCIT.Name = "txtCIT";
            this.txtCIT.Size = new System.Drawing.Size(211, 31);
            this.txtCIT.TabIndex = 19;
            this.txtCIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCIT_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "C.I.T.";
            // 
            // cboxTPrestacion
            // 
            this.cboxTPrestacion.FormattingEnabled = true;
            this.cboxTPrestacion.Items.AddRange(new object[] {
            "ENFERMEDAD",
            "MATERNIDAD",
            "PATERNIDAD",
            "RDR EMPERADOR",
            "IMPROCEDENTE L.S/G"});
            this.cboxTPrestacion.Location = new System.Drawing.Point(322, 59);
            this.cboxTPrestacion.Name = "cboxTPrestacion";
            this.cboxTPrestacion.Size = new System.Drawing.Size(267, 33);
            this.cboxTPrestacion.TabIndex = 17;
            this.cboxTPrestacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboxTPrestacion_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Prestación Economica";
            // 
            // txtApellidosNombres
            // 
            this.txtApellidosNombres.Location = new System.Drawing.Point(224, 12);
            this.txtApellidosNombres.Name = "txtApellidosNombres";
            this.txtApellidosNombres.ReadOnly = true;
            this.txtApellidosNombres.Size = new System.Drawing.Size(427, 31);
            this.txtApellidosNombres.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apellidos y Nombres";
            // 
            // FrmIngresarNuevoCIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(878, 321);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDiasEmpleador);
            this.Controls.Add(this.lblDiasES);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.dgvMuestra);
            this.Controls.Add(this.btnRegistrarCIT);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmIngresarNuevoCIT";
            this.Text = "FrmIngresarNuevoCIT";
            this.Load += new System.EventHandler(this.FrmIngresarNuevoCIT_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuestra)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRegistrarCIT;
        private System.Windows.Forms.DataGridView dgvMuestra;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblDiasES;
        private System.Windows.Forms.Label lblDiasEmpleador;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.ComboBox cboxInforme;
        private System.Windows.Forms.TextBox txtDiasLic;
        private System.Windows.Forms.TextBox txtExpediente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtColMedico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_Fin;
        private System.Windows.Forms.DateTimePicker dtp_Inicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCIT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxTPrestacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellidosNombres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCerrar;
    }
}