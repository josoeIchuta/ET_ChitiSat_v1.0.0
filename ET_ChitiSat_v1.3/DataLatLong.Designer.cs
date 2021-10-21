namespace ET_ChitiSat_v1._3
{
    partial class DataLatLong
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Latitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Latitud,
            this.Longitud});
            this.dataGridView1.Location = new System.Drawing.Point(33, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(382, 386);
            this.dataGridView1.TabIndex = 0;
            // 
            // Latitud
            // 
            this.Latitud.HeaderText = "latitude";
            this.Latitud.MinimumWidth = 6;
            this.Latitud.Name = "Latitud";
            this.Latitud.Width = 125;
            // 
            // Longitud
            // 
            this.Longitud.HeaderText = "longitude";
            this.Longitud.MinimumWidth = 6;
            this.Longitud.Name = "Longitud";
            this.Longitud.Width = 125;
            // 
            // DataLatLong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 449);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DataLatLong";
            this.Text = "DataLatLong";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitud;
    }
}