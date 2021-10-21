using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Para el Video webCam
using AForge.Video.DirectShow;
using AForge.Video;


namespace ET_ChitiSat_v1._3
{
    public partial class Video : Form
    {
        public Video()
        {
            InitializeComponent();
        }

        //Para el Video
        private bool HayDispositivos;
        private FilterInfoCollection MiDispositivos;
        private VideoCaptureDevice MiWebCam;
        //Para el Video FIN

        private void Video_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarWebCam_Click(object sender, EventArgs e)
        {
            CargaDispositivos();
        }

        public void CargaDispositivos()
        {
            MiDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (MiDispositivos.Count > 0)
            {
                HayDispositivos = true;
                for (int i = 0; i < MiDispositivos.Count; i++)
                    cmboxListaWebCam.Items.Add(MiDispositivos[i].Name.ToString());
                cmboxListaWebCam.Text = MiDispositivos[0].ToString();
            }
            else
            {
                HayDispositivos = false;
            }
        }

        private void btnAbrirWebCam_Click(object sender, EventArgs e)
        {
            CerrarWebCam();
            if(btnAbrirWebCam.Text == "Abrir WebCam" && cmboxListaWebCam.Text != String.Empty)
            {
                int i = cmboxListaWebCam.SelectedIndex;
                string NombreVideo = MiDispositivos[i].MonikerString;
                MiWebCam = new VideoCaptureDevice(NombreVideo);
                MiWebCam.NewFrame += new NewFrameEventHandler(Capturando);
                MiWebCam.Start();
                btnAbrirWebCam.Text = "Cerrar WebCam";
            }
            else if(btnAbrirWebCam.Text == "Cerrar WebCam")
            {
                CerrarWebCam();
            }

        }

        private void Capturando(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = Imagen;
        }

        public void CerrarWebCam()
        {
            if (MiWebCam != null && MiWebCam.IsRunning)
            {
                MiWebCam.SignalToStop();
                MiWebCam = null;
            }
        }

        private void btnCerrarWebCam_Click(object sender, EventArgs e)
        {
            CerrarWebCam();
        }

        private void Video_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarWebCam();
        }
    }
}
