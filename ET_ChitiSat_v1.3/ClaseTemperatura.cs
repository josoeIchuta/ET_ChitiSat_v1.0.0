using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ET_ChitiSat_v1._3
{
    public partial class ClaseTemperatura : Form
    {
        public ClaseTemperatura()
        {
            InitializeComponent();
        }

        ImageScotPlot datosScotPlot = new ImageScotPlot();

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chtTemperatura.Series["T1"].Enabled = true;
            chtTemperatura.Series["T2"].Enabled = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            chtTemperatura.Series["T1"].Enabled = false;
            chtTemperatura.Series["T2"].Enabled = true;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            chtTemperatura.Series["T1"].Enabled = true;
            chtTemperatura.Series["T2"].Enabled = true;
        }

        private void Imagen_Click(object sender, EventArgs e)
        {
            datosScotPlot.ShowDialog();
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
