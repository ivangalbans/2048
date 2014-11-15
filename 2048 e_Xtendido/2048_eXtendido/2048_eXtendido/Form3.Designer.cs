namespace _2048_eXtendido
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.pbxFotoIvan = new System.Windows.Forms.PictureBox();
            this.lblInformationPersonal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoIvan)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxFotoIvan
            // 
            this.pbxFotoIvan.ErrorImage = null;
            this.pbxFotoIvan.Image = ((System.Drawing.Image)(resources.GetObject("pbxFotoIvan.Image")));
            this.pbxFotoIvan.InitialImage = null;
            this.pbxFotoIvan.Location = new System.Drawing.Point(12, 3);
            this.pbxFotoIvan.Name = "pbxFotoIvan";
            this.pbxFotoIvan.Size = new System.Drawing.Size(253, 308);
            this.pbxFotoIvan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxFotoIvan.TabIndex = 0;
            this.pbxFotoIvan.TabStop = false;
            // 
            // lblInformationPersonal
            // 
            this.lblInformationPersonal.AutoSize = true;
            this.lblInformationPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformationPersonal.Location = new System.Drawing.Point(282, 30);
            this.lblInformationPersonal.Name = "lblInformationPersonal";
            this.lblInformationPersonal.Size = new System.Drawing.Size(436, 100);
            this.lblInformationPersonal.TabIndex = 1;
            this.lblInformationPersonal.Text = "Iván Galbán Smith\r\nDireción correo: i.galban@lab.matcom.uh.cu\r\nFacultad de Matemá" +
    "tica y Computación\r\nUniversidad de La Habana, Cuba";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(737, 311);
            this.Controls.Add(this.lblInformationPersonal);
            this.Controls.Add(this.pbxFotoIvan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAbout";
            this.Text = "About Created";
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoIvan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxFotoIvan;
        private System.Windows.Forms.Label lblInformationPersonal;
    }
}