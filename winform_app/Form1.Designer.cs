using System.Windows.Forms;

namespace winform_app
{
    partial class Form1
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
            this.pbAlbum = new System.Windows.Forms.PictureBox();
            this.dgvAlbum = new System.Windows.Forms.DataGridView();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblCantCanciones = new System.Windows.Forms.Label();
            this.lblFormato = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTituloGenero = new System.Windows.Forms.Label();
            this.lblTituloCantCanciones = new System.Windows.Forms.Label();
            this.lblTituloFormato = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbum)).BeginInit();
            this.SuspendLayout();
            // 
            // pbAlbum
            // 
            this.pbAlbum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbAlbum.Location = new System.Drawing.Point(156, 43);
            this.pbAlbum.Name = "pbAlbum";
            this.pbAlbum.Size = new System.Drawing.Size(293, 234);
            this.pbAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAlbum.TabIndex = 0;
            this.pbAlbum.TabStop = false;
            // 
            // dgvAlbum
            // 
            this.dgvAlbum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlbum.Location = new System.Drawing.Point(156, 308);
            this.dgvAlbum.Name = "dgvAlbum";
            this.dgvAlbum.Size = new System.Drawing.Size(574, 178);
            this.dgvAlbum.TabIndex = 1;
            this.dgvAlbum.SelectionChanged += new System.EventHandler(this.dgvAlbum_SelectionChanged);
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(657, 179);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(35, 13);
            this.lblGenero.TabIndex = 2;
            this.lblGenero.Text = "label1";
            // 
            // lblCantCanciones
            // 
            this.lblCantCanciones.AutoSize = true;
            this.lblCantCanciones.Location = new System.Drawing.Point(657, 103);
            this.lblCantCanciones.Name = "lblCantCanciones";
            this.lblCantCanciones.Size = new System.Drawing.Size(35, 13);
            this.lblCantCanciones.TabIndex = 3;
            this.lblCantCanciones.Text = "label2";
            // 
            // lblFormato
            // 
            this.lblFormato.AutoSize = true;
            this.lblFormato.Location = new System.Drawing.Point(657, 146);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Size = new System.Drawing.Size(35, 13);
            this.lblFormato.TabIndex = 4;
            this.lblFormato.Text = "label3";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(502, 58);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(84, 13);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Características: ";
            // 
            // lblTituloGenero
            // 
            this.lblTituloGenero.AutoSize = true;
            this.lblTituloGenero.Location = new System.Drawing.Point(505, 179);
            this.lblTituloGenero.Name = "lblTituloGenero";
            this.lblTituloGenero.Size = new System.Drawing.Size(48, 13);
            this.lblTituloGenero.TabIndex = 6;
            this.lblTituloGenero.Text = "Género: ";
            // 
            // lblTituloCantCanciones
            // 
            this.lblTituloCantCanciones.AutoSize = true;
            this.lblTituloCantCanciones.Location = new System.Drawing.Point(502, 103);
            this.lblTituloCantCanciones.Name = "lblTituloCantCanciones";
            this.lblTituloCantCanciones.Size = new System.Drawing.Size(123, 13);
            this.lblTituloCantCanciones.TabIndex = 7;
            this.lblTituloCantCanciones.Text = "Cantidad de Canciones: ";
            // 
            // lblTituloFormato
            // 
            this.lblTituloFormato.AutoSize = true;
            this.lblTituloFormato.Location = new System.Drawing.Point(502, 146);
            this.lblTituloFormato.Name = "lblTituloFormato";
            this.lblTituloFormato.Size = new System.Drawing.Size(51, 13);
            this.lblTituloFormato.TabIndex = 8;
            this.lblTituloFormato.Text = "Formato: ";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(760, 308);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(117, 41);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 548);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblTituloFormato);
            this.Controls.Add(this.lblTituloCantCanciones);
            this.Controls.Add(this.lblTituloGenero);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblFormato);
            this.Controls.Add(this.lblCantCanciones);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.dgvAlbum);
            this.Controls.Add(this.pbAlbum);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Albums";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAlbum;
        private System.Windows.Forms.DataGridView dgvAlbum;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblCantCanciones;
        private System.Windows.Forms.Label lblFormato;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTituloGenero;
        private System.Windows.Forms.Label lblTituloCantCanciones;
        private System.Windows.Forms.Label lblTituloFormato;
        private Button btnAgregar;
    }
}

