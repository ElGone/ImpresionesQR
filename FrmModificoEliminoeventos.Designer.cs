namespace ImpresionQR
{
    partial class FrmModificoEliminoeventos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button3 = new System.Windows.Forms.Button();
            this.txtrival = new System.Windows.Forms.TextBox();
            this.pdesde = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvrivales = new System.Windows.Forms.DataGridView();
            this.escudo = new System.Windows.Forms.DataGridViewImageColumn();
            this.rival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_rival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.cuadro = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.nombreequipo1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.vs = new System.Windows.Forms.Label();
            this.txtIdRival = new System.Windows.Forms.TextBox();
            this.IdEvento = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrivales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.cuadro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DodgerBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(716, 225);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 33);
            this.button3.TabIndex = 63;
            this.button3.Text = "Rival";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtrival
            // 
            this.txtrival.BackColor = System.Drawing.Color.Black;
            this.txtrival.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtrival.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtrival.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrival.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtrival.Location = new System.Drawing.Point(294, 227);
            this.txtrival.Name = "txtrival";
            this.txtrival.Size = new System.Drawing.Size(413, 31);
            this.txtrival.TabIndex = 62;
            this.txtrival.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pdesde
            // 
            this.pdesde.CalendarTitleBackColor = System.Drawing.Color.Black;
            this.pdesde.CustomFormat = "yyyy-MM-dd";
            this.pdesde.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pdesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pdesde.Location = new System.Drawing.Point(294, 187);
            this.pdesde.Name = "pdesde";
            this.pdesde.Size = new System.Drawing.Size(118, 25);
            this.pdesde.TabIndex = 60;
            this.pdesde.Value = new System.DateTime(2017, 5, 25, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(273, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 33);
            this.button1.TabIndex = 64;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(476, 292);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 33);
            this.button2.TabIndex = 65;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(679, 292);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(197, 33);
            this.button4.TabIndex = 66;
            this.button4.Text = "Salir";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgvrivales
            // 
            this.dgvrivales.AllowUserToAddRows = false;
            this.dgvrivales.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            this.dgvrivales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvrivales.BackgroundColor = System.Drawing.Color.Black;
            this.dgvrivales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvrivales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvrivales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvrivales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvrivales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvrivales.ColumnHeadersVisible = false;
            this.dgvrivales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.escudo,
            this.rival,
            this.Id_rival});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvrivales.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvrivales.EnableHeadersVisualStyles = false;
            this.dgvrivales.GridColor = System.Drawing.Color.Black;
            this.dgvrivales.Location = new System.Drawing.Point(12, 12);
            this.dgvrivales.Name = "dgvrivales";
            this.dgvrivales.ReadOnly = true;
            this.dgvrivales.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvrivales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvrivales.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvrivales.RowHeadersVisible = false;
            this.dgvrivales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvrivales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvrivales.Size = new System.Drawing.Size(254, 327);
            this.dgvrivales.TabIndex = 70;
            this.dgvrivales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvrivales_CellContentClick);
            // 
            // escudo
            // 
            this.escudo.HeaderText = "";
            this.escudo.Name = "escudo";
            this.escudo.ReadOnly = true;
            this.escudo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.escudo.Width = 30;
            // 
            // rival
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rival.DefaultCellStyle = dataGridViewCellStyle3;
            this.rival.HeaderText = "";
            this.rival.Name = "rival";
            this.rival.ReadOnly = true;
            this.rival.Width = 200;
            // 
            // Id_rival
            // 
            this.Id_rival.HeaderText = "";
            this.Id_rival.Name = "Id_rival";
            this.Id_rival.ReadOnly = true;
            this.Id_rival.Visible = false;
            this.Id_rival.Width = 50;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(195, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(89, 92);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 71;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // cuadro
            // 
            this.cuadro.Controls.Add(this.pictureBox2);
            this.cuadro.Controls.Add(this.nombreequipo1);
            this.cuadro.Controls.Add(this.pictureBox3);
            this.cuadro.Controls.Add(this.label8);
            this.cuadro.Controls.Add(this.vs);
            this.cuadro.Location = new System.Drawing.Point(373, 12);
            this.cuadro.Name = "cuadro";
            this.cuadro.Size = new System.Drawing.Size(401, 156);
            this.cuadro.TabIndex = 399;
            this.cuadro.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ImpresionQR.Properties.Resources.River_Plate;
            this.pictureBox2.Location = new System.Drawing.Point(14, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(95, 92);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 61;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // nombreequipo1
            // 
            this.nombreequipo1.AutoSize = true;
            this.nombreequipo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreequipo1.ForeColor = System.Drawing.Color.White;
            this.nombreequipo1.Location = new System.Drawing.Point(171, 106);
            this.nombreequipo1.Name = "nombreequipo1";
            this.nombreequipo1.Size = new System.Drawing.Size(0, 24);
            this.nombreequipo1.TabIndex = 397;
            this.nombreequipo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 24);
            this.label8.TabIndex = 396;
            this.label8.Text = "River Plate";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vs
            // 
            this.vs.AutoSize = true;
            this.vs.BackColor = System.Drawing.Color.Transparent;
            this.vs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vs.ForeColor = System.Drawing.Color.White;
            this.vs.Location = new System.Drawing.Point(131, 46);
            this.vs.Name = "vs";
            this.vs.Size = new System.Drawing.Size(35, 24);
            this.vs.TabIndex = 63;
            this.vs.Text = "VS";
            this.vs.Visible = false;
            // 
            // txtIdRival
            // 
            this.txtIdRival.Location = new System.Drawing.Point(430, 190);
            this.txtIdRival.Name = "txtIdRival";
            this.txtIdRival.Size = new System.Drawing.Size(29, 20);
            this.txtIdRival.TabIndex = 402;
            this.txtIdRival.Visible = false;
            // 
            // IdEvento
            // 
            this.IdEvento.Location = new System.Drawing.Point(465, 190);
            this.IdEvento.Name = "IdEvento";
            this.IdEvento.Size = new System.Drawing.Size(29, 20);
            this.IdEvento.TabIndex = 403;
            this.IdEvento.Visible = false;
            // 
            // FrmModificoEliminoeventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(888, 351);
            this.Controls.Add(this.IdEvento);
            this.Controls.Add(this.txtIdRival);
            this.Controls.Add(this.cuadro);
            this.Controls.Add(this.dgvrivales);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtrival);
            this.Controls.Add(this.pdesde);
            this.Name = "FrmModificoEliminoeventos";
            this.Text = "Modificacion y Eliminacion de Eventos";
            this.Load += new System.EventHandler(this.FrmModificoEliminoeventos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvrivales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.cuadro.ResumeLayout(false);
            this.cuadro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtrival;
        private System.Windows.Forms.DateTimePicker pdesde;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        internal System.Windows.Forms.DataGridView dgvrivales;
        private System.Windows.Forms.DataGridViewImageColumn escudo;
        private System.Windows.Forms.DataGridViewTextBoxColumn rival;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_rival;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel cuadro;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label nombreequipo1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label vs;
        private System.Windows.Forms.TextBox txtIdRival;
        private System.Windows.Forms.TextBox IdEvento;
    }
}