namespace ET_ChitiSat_v1._3
{
    partial class Video
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAbrirWebCam = new System.Windows.Forms.Button();
            this.btnBuscarWebCam = new System.Windows.Forms.Button();
            this.cmboxListaWebCam = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAbrirWebCam);
            this.panel2.Controls.Add(this.btnBuscarWebCam);
            this.panel2.Controls.Add(this.cmboxListaWebCam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(886, 48);
            this.panel2.TabIndex = 2;
            // 
            // btnAbrirWebCam
            // 
            this.btnAbrirWebCam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirWebCam.Location = new System.Drawing.Point(591, 8);
            this.btnAbrirWebCam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAbrirWebCam.Name = "btnAbrirWebCam";
            this.btnAbrirWebCam.Size = new System.Drawing.Size(131, 25);
            this.btnAbrirWebCam.TabIndex = 3;
            this.btnAbrirWebCam.Text = "Abrir WebCam";
            this.btnAbrirWebCam.UseVisualStyleBackColor = true;
            this.btnAbrirWebCam.Click += new System.EventHandler(this.btnAbrirWebCam_Click);
            // 
            // btnBuscarWebCam
            // 
            this.btnBuscarWebCam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarWebCam.Location = new System.Drawing.Point(8, 8);
            this.btnBuscarWebCam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscarWebCam.Name = "btnBuscarWebCam";
            this.btnBuscarWebCam.Size = new System.Drawing.Size(136, 25);
            this.btnBuscarWebCam.TabIndex = 2;
            this.btnBuscarWebCam.Text = "Buscar WebCam";
            this.btnBuscarWebCam.UseVisualStyleBackColor = true;
            this.btnBuscarWebCam.Click += new System.EventHandler(this.btnBuscarWebCam_Click);
            // 
            // cmboxListaWebCam
            // 
            this.cmboxListaWebCam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboxListaWebCam.FormattingEnabled = true;
            this.cmboxListaWebCam.Location = new System.Drawing.Point(148, 8);
            this.cmboxListaWebCam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmboxListaWebCam.Name = "cmboxListaWebCam";
            this.cmboxListaWebCam.Size = new System.Drawing.Size(427, 25);
            this.cmboxListaWebCam.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(886, 417);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 417);
            this.panel1.TabIndex = 3;
            // 
            // Video
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 465);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximumSize = new System.Drawing.Size(902, 504);
            this.Name = "Video";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Video_FormClosed);
            this.Load += new System.EventHandler(this.Video_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAbrirWebCam;
        private System.Windows.Forms.Button btnBuscarWebCam;
        private System.Windows.Forms.ComboBox cmboxListaWebCam;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}