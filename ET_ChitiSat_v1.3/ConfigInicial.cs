using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Gmap
//using GMap.NET;
//using GMap.NET.MapProviders;
//using GMap.NET.WindowsForms;

namespace ET_ChitiSat_v1._3
{
    public partial class ConfigInicial : Form
    {
        private string latIni;
        private string lonIni;

        private string alturaInicial;
        public ConfigInicial()
        {
            InitializeComponent();
        }

        public string LatIni
        {
            get { return latIni; }
        }

        public string LonIni
        {
            get { return lonIni; }
        }

        public string AlturaInicial
        {
            get { return alturaInicial; }
        }
        private void ConfiguracionInicial()
        {
            latIni = lblLatitud.Text;
            lonIni = lblLongitud.Text;
            if (lblLatitud.Text == String.Empty && lblLongitud.Text == String.Empty)
            {
                MessageBox.Show("No introdujo valores de Latitud y Longitud");
                latIni = Convert.ToString(-16.539221);
                lonIni = Convert.ToString(-68.061681);
            }

            //alturaInicial = lblAlturaInicial.Text;
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ConfiguracionInicial();
        }

        private void ConfigInicial_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConfiguracionInicial();
        }
    }
}
