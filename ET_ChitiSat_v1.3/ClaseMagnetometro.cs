using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ET_ChitiSat_v1._3
{
    public partial class ClaseMagnetometro : Form
    {
        public ClaseMagnetometro()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chtMagnetometro.Series["M_Z"].Enabled = false;
            chtMagnetometro.Series["M_X"].Enabled = true;
            chtMagnetometro.Series["M_Y"].Enabled = true;
            //chtMagnetometro.ChartAreas["ChartArea1"].AxisX.Title = "hola";
            //chtMagnetometro.ChartAreas["ChartArea1"].AxisY.Title = "campo[uT]";

            //ChartArea magne = new ChartArea();

            //magne.AxisX.Title = "HOla";
            //magne.AxisX.Title = "Time";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            chtMagnetometro.Series["M_Z"].Enabled = true;
            chtMagnetometro.Series["M_X"].Enabled = false;
            chtMagnetometro.Series["M_Y"].Enabled = false;
            //chtMagnetometro.ChartAreas["ChartArea1"].AxisX.Title = "Time";
            //chtMagnetometro.ChartAreas["ChartArea1"].AxisY.Title = "campo Mgt [uT]";
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }
    }
}
