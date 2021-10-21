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
    public partial class ClasePresion : Form
    {
        public ClasePresion()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chtPresion.Series["P_hPa"].Enabled = true;
            chtPresion.Series["P_Atm"].Enabled = false;
            chtPresion.Series["P_mmHg"].Enabled = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            chtPresion.Series["P_hPa"].Enabled = false;
            chtPresion.Series["P_Atm"].Enabled = true;
            chtPresion.Series["P_mmHg"].Enabled = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            chtPresion.Series["P_hPa"].Enabled = false;
            chtPresion.Series["P_Atm"].Enabled = false;
            chtPresion.Series["P_mmHg"].Enabled = true;
        }
    }
}
