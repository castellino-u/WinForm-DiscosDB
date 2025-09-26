namespace Proyecto_DiscosV1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.lblGenero.Location = new System.Drawing.Point(510, 101);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(35, 13);
            this.lblGenero.TabIndex = 2;
            this.lblGenero.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 498);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

