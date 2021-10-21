using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//NameSpace para la comunicacion UART
using System.IO.Ports;
using System.IO;

//Gmap
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

//Plot
using ScottPlot;

//to check internet conection
using System.Runtime.InteropServices;

//Para el Video webCam
using AForge.Video.DirectShow;
using AForge.Video;

namespace ET_ChitiSat_v1._3
{
    public partial class Form1 : Form
    {
        //Esto es para detectar la conexion a internet
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        //Esto es para detectar la conexion a internet FIN

        //Para el Video
        private bool HayDispositivos;
        private FilterInfoCollection MiDispositivos;
        private VideoCaptureDevice MiWebCam;
        //Para el Video FIN

        public Form1()
        {
            InitializeComponent();
        }

        double LatInicial = -16.527352;
        double LngInicial = -68.176698;

        ClaseTemperatura datosTemp = new ClaseTemperatura();
        ClasePresion datosPresion = new ClasePresion();
        ClaseCorrVolt datosPotencia = new ClaseCorrVolt();
        ClaseUV datosUV = new ClaseUV();
        ClaseAcelerometro datosAcel = new ClaseAcelerometro();
        ClaseGiroscopio datosGiro = new ClaseGiroscopio();
        ClaseMagnetometro datosMagne = new ClaseMagnetometro();
        ClaseAlturaLocal datosAltura = new ClaseAlturaLocal();
        DataGrid datos = new DataGrid();
        
        DataLatLong datosLatLong = new DataLatLong();
        ImageScotPlot dotosImagen = new ImageScotPlot();

        #region Inicio
        private void Form1_Load(object sender, EventArgs e)
        {
            
            //Lee los puertos COM conectados a la PC
            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.AddRange(ports);

            btnConectar.Enabled = true;
            btnDesconectar.Enabled = false;

            toolStripStatusLblConectado.Text = "Desconectado";

            //Datos iniciales para GMAP
            gMapControl1.DragButton = MouseButtons.Left;
            //gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            //gMapControl1.MapProvider = BingMapProvider.Instance;
            //GMaps.Instance.Mode = AccessMode.ServerOnly;
            //gMapControl1.SetPositionByKeywords("Paris, France");

            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            //puntos.Add(new PointLatLng(LatInicial, LngInicial));
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 12;
            gMapControl1.AutoScroll = true;
            gMapControl1.Visible = true;
            gMapControl1.ShowCenter = false;

            //datos.Show();
            //datosLatLong.Show();
            //dotosImagen.Show();

            //Inicializacion de los graficos
            //InicioCharts();
        }

        private void InicioCharts()
        {
            int longitudGrafica = 250;
            for (int i = 0; i <= longitudGrafica; i++)
            {
                datosTemp.chtTemperatura.Series[0].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);
                datosTemp.chtTemperatura.Series[1].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);

                datosPresion.chtPresion.Series[0].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);
                datosPresion.chtPresion.Series[1].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);
                datosPresion.chtPresion.Series[2].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);

                datosPotencia.chtCorriente.Series[0].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);
                datosPotencia.chtVoltaje.Series[0].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);

                datosUV.chtUV.Series[0].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);

                datosAcel.chtAcelerometro.Series[0].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);
                //datosAcel.chtAcelerometro.Series[1].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);
                //datosAcel.chtAcelerometro.Series[2].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);

                datosGiro.chtGiroscopio.Series[0].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);
                //datosGiro.chtGiroscopio.Series[1].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);
                //datosGiro.chtGiroscopio.Series[2].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);

                datosMagne.chtMagnetometro.Series[0].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);
                //datosMagne.chtMagnetometro.Series[1].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);
                //datosMagne.chtMagnetometro.Series[2].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);

                datosAltura.chtAlturaLocal.Series[0].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), 0);
            }      
        }
        #endregion

        #region Conexion COM
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cBoxCOMPORT.Text;
                serialPort1.BaudRate = 115200;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;

                serialPort1.DtrEnable = false;
                serialPort1.RtsEnable = false;

                serialPort1.Open();

                btnConectar.Enabled = false;
                btnDesconectar.Enabled = true;

                toolStripStatusLblConectado.Text = "Reciviendo Datos";
                timer1.Enabled = true;
                //timer2.Enabled = true;
                serialPort1.DiscardInBuffer();
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error al Conectarse con el Puerto Serial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConectar.Enabled = true;
                btnDesconectar.Enabled = false;
            }
        }
        #endregion

        #region Desconectar COM
        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();

                btnConectar.Enabled = true;
                btnDesconectar.Enabled = false;

                toolStripStatusLblConectado.Text = "Desconectado";
                timer1.Enabled = false;
                timer2.Enabled = false;
            }

        }

        private void ActualizarPuertoCOM_Click(object sender, EventArgs e)
        {
            cBoxCOMPORT.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.AddRange(ports);
        }
        #endregion

        #region Rececpcion de datos telemetria
        byte[] trama = new byte[40];    //cambiado 32 para pruebas
        byte[] foto = new byte[8678];
        int numByte;
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int i;
           
            numByte = serialPort1.BytesToRead;
            if (serialPort1.BytesToRead > 0)
            {
                byte b = (byte)serialPort1.ReadByte();
                if (b == 0x0D)
                {
                    for (i = 1; i < 40; i++)        //cambiado 32 para pruebas
                    {
                        b = (byte)serialPort1.ReadByte();
                        trama[i] = b;
                    }

                    UpdateDatos();
                    this.Invoke(new EventHandler(ShowData));
                }
            }
        }
        #endregion


        #region Decodificacion Trama de datos
        double Temp, Temp1, PresHpa, PresAtm, PresmmHg, AlturaNivelMar, AlturaLocal;
        double Voltaje, Corriente, UltraVioleta;
        double AcelX, AcelY, AcelZ;
        double GiroX, GiroY, GiroZ;
        double MagX, MagY, MagZ, Azimut;
        double Latitud, Longitud;

        private void UpdateDatos()
        {
            short MgnX, MgnY, MgnZ;
            short AclX, AclY, AclZ;
            short GcpX, GcpY, GcpZ;

            short auxTemperatura;
            ushort auxAltura;
            short auxUv, auxVoltaje, auxCorriente;
            int auxPresion;

            int auxLat, auxLong;

            //Temperatura
            auxTemperatura = (short)(trama[2] << 8 | trama[1]);
            Temp = auxTemperatura / 10.0;
            Temp1 = Temp - 3;

            //Presion
            auxPresion = trama[5] << 16 | trama[4] << 8 | trama[3];
            PresHpa = auxPresion / 100.0;
            PresAtm = Math.Round((PresHpa * 0.000986923), 3);
            PresmmHg = Math.Round((PresHpa * 0.7050061505), 3);

            //Altura
            auxAltura = (ushort)(trama[7] << 8 | trama[6]);
            AlturaNivelMar = auxAltura / 10.0;

            //double presioNivelMarHpa = 1013.25;
            //AlturaNivelMar = Math.Round(44330.0 * (1.0 - Math.Pow((PresHpa / presioNivelMarHpa), 0.1903)), 3);

            //UV
            auxUv = (short)(trama[9] << 8 | trama[8]);
            UltraVioleta = auxUv * 1.0;

            //Acelerometro
            AclX = (short)(trama[11] << 8 | trama[10]);
            AcelX = AclX / 10.0;

            AclY = (short)(trama[13] << 8 | trama[12]);
            AcelY = AclY / 10.0;

            AclZ = (short)(trama[15] << 8 | trama[14]);
            AcelZ = AclZ / 10.0;
            //Giroscopio
            GcpX = (short)(trama[17] << 8 | trama[16]);
            GiroX = GcpX / 10.0;

            GcpY = (short)(trama[19] << 8 | trama[18]);
            GiroY = GcpY / 10.0;

            GcpZ = (short)(trama[21] << 8 | trama[20]);
            GiroZ = GcpZ / 10.0;

            //Magnetometro
            MgnX = (short)(trama[23] << 8 | trama[22]);
            MagX = MgnX * 1.0;

            MgnY = (short)(trama[25] << 8 | trama[24]);
            MagY = MgnY * 1.0;

            MgnZ = (short)(trama[27] << 8 | trama[26]);
            MagZ = MgnZ * 1.0;

            Azimut = Math.Round((Math.Atan2(MagY, MagX)) * 57.29578, 4);

            //Voltaje
            auxVoltaje = (short)(trama[29] << 8 | trama[28]);
            Voltaje = auxVoltaje / 100.0;

            //Corriente
            auxCorriente = (short)(trama[31] << 8 | trama[30]);
            Corriente = auxCorriente / 100.0;

            //Latitud
            auxLat = trama[35] << 24 | trama[34] << 16 | trama[33] << 8 | trama[32];
            Latitud = auxLat / 1000000.0;
            //Longitud
            auxLong = trama[39] << 24 | trama[38] << 16 | trama[37] << 8 | trama[36];
            Longitud = auxLong / 1000000.0;
        }
        #endregion

        #region Visualizacion numerica y 2D
        private void ShowData(object sender, EventArgs e)   //private void ShowData()
        {

            lblTemperatura.Text = Temp.ToString();
            lblPresion.Text = PresHpa.ToString();

            lblAcelX.Text = AcelX.ToString();
            lblAcelY.Text = AcelY.ToString();
            lblAcelZ.Text = AcelZ.ToString();

            lblGiroX.Text = GiroX.ToString();
            lblGiroY.Text = GiroY.ToString();
            lblGiroZ.Text = GiroZ.ToString();

            lblMagX.Text = MagX.ToString();
            lblMagY.Text = MagY.ToString();
            lblMagZ.Text = MagZ.ToString();
            lblAzimuth.Text = Azimut.ToString();

            lblLatitud.Text = Latitud.ToString();
            lblLongitud.Text = Longitud.ToString();

            lblAltiraMsnm.Text = AlturaNivelMar.ToString();

            lblVoltBat.Text = Voltaje.ToString();
            lblCorrBat.Text = Corriente.ToString();

            lblUv.Text = UltraVioleta.ToString();

            //lblNumBytes.Text = numByte.ToString();

            //vecTemp[i] = Temp;
            //vecPres[i] = PresHpa;
            //i++;


            UpdateCpuChart();
            InsertarDatosDataGrid();
        }

        string tiempo;
        int caliAltura;
        private void InsertarDatosDataGrid()
        {
            tiempo = DateTime.Now.ToString();
            int n = datos.dataGridView1.Rows.Add();
            datos.dataGridView1.Rows[n].Cells[0].Value = tiempo;
            datos.dataGridView1.Rows[n].Cells[1].Value = Temp;
            datos.dataGridView1.Rows[n].Cells[2].Value = Temp1;
            datos.dataGridView1.Rows[n].Cells[3].Value = PresHpa;
            datos.dataGridView1.Rows[n].Cells[4].Value = MagX;
            datos.dataGridView1.Rows[n].Cells[5].Value = MagY;
            datos.dataGridView1.Rows[n].Cells[6].Value = MagZ;
            datos.dataGridView1.Rows[n].Cells[7].Value = AcelX;
            datos.dataGridView1.Rows[n].Cells[8].Value = AcelY;
            datos.dataGridView1.Rows[n].Cells[9].Value = AcelZ;
            datos.dataGridView1.Rows[n].Cells[10].Value = GiroX;
            datos.dataGridView1.Rows[n].Cells[11].Value = GiroY;
            datos.dataGridView1.Rows[n].Cells[12].Value = GiroZ;
            datos.dataGridView1.Rows[n].Cells[13].Value = AlturaNivelMar;
            datos.dataGridView1.Rows[n].Cells[14].Value = UltraVioleta;

            int n2 = datosLatLong.dataGridView1.Rows.Add();
            datosLatLong.dataGridView1.Rows[n2].Cells[0].Value = Latitud;
            datosLatLong.dataGridView1.Rows[n2].Cells[1].Value = Longitud;
            
            if (caliAltura > 10)
            {
                double[] datosAlturaLocal = new double[10];

                for (int filas = 0; filas < 10; filas++)
                {
                    datosAlturaLocal[filas] = Convert.ToDouble(datos.dataGridView1.Rows[filas].Cells[13].Value);
                }
                double auxAlturaLocal = Math.Round((datosAlturaLocal[0] + datosAlturaLocal[1] + datosAlturaLocal[2] + datosAlturaLocal[3] + datosAlturaLocal[4]
                    + datosAlturaLocal[5] + datosAlturaLocal[6] + datosAlturaLocal[7] + datosAlturaLocal[8] + datosAlturaLocal[9])/ 10, 3);
                //double auxAlturaLocal = Convert.ToDouble(datos.dataGridView1.Rows[0].Cells[13].Value);
                AlturaLocal = Math.Round(AlturaNivelMar - auxAlturaLocal, 3);
                if(AlturaLocal<-5 & AlturaLocal > 5)
                {
                    AlturaLocal = 0.0;
                }
                //lblAlturaLocal.Text = AlturaLocal.ToString();
            }
            caliAltura++;
        }

        private void UpdateCpuChart()
        {
            //Para ver las  grficas con el EJE X como cronomtro
            string segundos1 = seg.ToString();
            string minutos1 = min.ToString();
            string horas1 = hor.ToString();

            if (seg < 10) { segundos1 = "0" + seg.ToString(); }
            if (min < 10) { minutos1 = "0" + min.ToString(); }
            if (hor < 10) { horas1 = "0" + hor.ToString(); }
            string formato1 = minutos1 + ":" + segundos1;
            //datosTemp.chtTemperatura.Series["T1"].Points.Clear();
            datosTemp.chtTemperatura.Series["T1"].Points.AddXY(formato1, Temp);
            //datosTemp.chtTemperatura.Series["T2"].Points.AddXY(formato1, Temp1);

            datosPresion.chtPresion.Series["P_hPa"].Points.AddXY(formato1, PresHpa);
            datosPresion.chtPresion.Series["P_Atm"].Points.AddXY(formato1, PresAtm);
            datosPresion.chtPresion.Series["P_mmHg"].Points.AddXY(formato1, PresmmHg);

            if (caliAltura > 10)
            {
                datosAltura.chtAlturaLocal.Series["Altura"].Points.AddXY(formato1, AlturaLocal);
            }

            //datosPotencia.chtVoltaje.Series["voltaje"].Points.AddXY(formato1, Voltaje);
            //datosPotencia.chtVoltaje.Series["voltaje"].Points.AddXY(formato1, Corriente);

            //datosUV.chtUV.Series["UV"].Points.AddXY(formato1, UltraVioleta);

            datosAcel.chtAcelerometro.Series["A_X"].Points.AddXY(formato1, AcelX);
            datosAcel.chtAcelerometro.Series["A_Y"].Points.AddXY(formato1, AcelY);
            datosAcel.chtAcelerometro.Series["A_Z"].Points.AddXY(formato1, AcelZ);

            datosGiro.chtGiroscopio.Series["G_X"].Points.AddXY(formato1, GiroX);
            datosGiro.chtGiroscopio.Series["G_Y"].Points.AddXY(formato1, GiroY);
            datosGiro.chtGiroscopio.Series["G_Z"].Points.AddXY(formato1, GiroZ);

            datosMagne.chtMagnetometro.Series["M_X"].Points.AddXY(formato1, MagX);
            datosMagne.chtMagnetometro.Series["M_Y"].Points.AddXY(formato1, MagY);
            datosMagne.chtMagnetometro.Series["M_Z"].Points.AddXY(formato1, MagZ);

            datosPotencia.chtVoltaje.Series[0].Points.AddXY(formato1, Voltaje);
            datosPotencia.chtCorriente.Series[0].Points.AddXY(formato1, Corriente);

            datosUV.chtUV.Series[0].Points.AddXY(formato1, UltraVioleta);


            if (datosTemp.chtTemperatura.Series["T1"].Points.Count == 600)
            {
                datosTemp.chtTemperatura.Series["T1"].Points.RemoveAt(0);
                //datosTemp.chtTemperatura.Series["T2"].Points.RemoveAt(0);

                datosPresion.chtPresion.Series["P_hPa"].Points.RemoveAt(0);
                datosPresion.chtPresion.Series["P_Atm"].Points.RemoveAt(0);
                datosPresion.chtPresion.Series["P_mmHg"].Points.RemoveAt(0);

                datosAcel.chtAcelerometro.Series["A_X"].Points.RemoveAt(0);
                datosAcel.chtAcelerometro.Series["A_Y"].Points.RemoveAt(0);
                datosAcel.chtAcelerometro.Series["A_Z"].Points.RemoveAt(0);

                datosGiro.chtGiroscopio.Series["G_X"].Points.RemoveAt(0);
                datosGiro.chtGiroscopio.Series["G_Y"].Points.RemoveAt(0);
                datosGiro.chtGiroscopio.Series["G_Z"].Points.RemoveAt(0);

                datosMagne.chtMagnetometro.Series["M_X"].Points.RemoveAt(0);
                datosMagne.chtMagnetometro.Series["M_Y"].Points.RemoveAt(0);
                datosMagne.chtMagnetometro.Series["M_Z"].Points.RemoveAt(0);

                datosPotencia.chtVoltaje.Series[0].Points.RemoveAt(0);
                datosPotencia.chtCorriente.Series[0].Points.RemoveAt(0);

                datosUV.chtUV.Series[0].Points.RemoveAt(0);
            }

            //datosTemp.chtTemperatura.Series["Temperatura"].Points.AddY(Temp);
            //datosTemp.chtTemperatura.Series["Temperatura"].Points.AddY(Temp1);

            //datosPresion.chtPresion.Series["Presion"].Points.AddY(Pres);

        }
        #endregion

        #region Exportar Datos Excel
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarDatos(datos.dataGridView1);
        }

        public void ExportarDatos(DataGridView datalistado)
        {
            Microsoft.Office.Interop.Excel.Application exportarexcel = new Microsoft.Office.Interop.Excel.Application();
            exportarexcel.Application.Workbooks.Add(true);
            int IndiceColumna = 0;
            foreach (DataGridViewColumn columna in datalistado.Columns)
            {
                IndiceColumna++;
                exportarexcel.Cells[1, IndiceColumna] = columna.Name;
            }
            int IndiceFila = 0;
            foreach (DataGridViewRow fila in datalistado.Rows)
            {
                IndiceFila++;
                IndiceColumna = 0;
                foreach (DataGridViewColumn columna in datalistado.Columns)
                {
                    IndiceColumna++;
                    exportarexcel.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
                }
            }
            exportarexcel.Visible = true;
        }

        private void btnExportarTxt_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|CSV file (*.csv)|*.csv";
            string nombreArchivo;
            try
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    nombreArchivo = dlg.FileName; 
                    TextWriter guardarDatos = new StreamWriter(nombreArchivo);
                    for (int i = 0; i < datos.dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < datos.dataGridView1.Columns.Count; j++)
                        {
                            if (datos.dataGridView1.Rows[i].Cells[j].Value == null)
                            {
                                guardarDatos.Write("null");
                            }
                            else
                            {
                                guardarDatos.Write("\t" + datos.dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + ",");
                            }
                        }
                        guardarDatos.WriteLine("");
                        //writer.WriteLine("-----------------------------------------------------");
                    }
                    guardarDatos.Close();
                    MessageBox.Show("Se han exportado los datos exitosamente");

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar");
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ExportarDatos(datosLatLong.dataGridView1);
        }
        #endregion

        #region Geolocalizacion
        private void timer2_Tick(object sender, EventArgs e)
        {
            //int n1 = datosLatLong.dataGridView1.Rows.Add();
            //datosLatLong.dataGridView1.Rows[n1].Cells[0].Value = Latitud;
            //datosLatLong.dataGridView1.Rows[n1].Cells[1].Value = Longitud;

            GMapOverlay Ruta = new GMapOverlay("CapaRuta");
            List<PointLatLng> puntos = new List<PointLatLng>();

            //Variables para almacenar
            double LatDataGrid, LongDataGrid;
            //Extraemos los datos del DataGrid
            for (int filas = 0; filas < datosLatLong.dataGridView1.Rows.Count - 1; filas++)
            {
                //if (filas == 0)
                //{
                //    puntos.Add(new PointLatLng(Latitud, Longitud));
                //}
                LatDataGrid = Convert.ToDouble(datosLatLong.dataGridView1.Rows[filas].Cells[0].Value);
                LongDataGrid = Convert.ToDouble(datosLatLong.dataGridView1.Rows[filas].Cells[1].Value);
                puntos.Add(new PointLatLng(LatDataGrid, LongDataGrid));

            }

            //Para dibujar la Ruta
            GMapRoute PuntosRuta = new GMapRoute(puntos, "Ruta");
            Ruta.Routes.Add(PuntosRuta);
            gMapControl1.Overlays.Add(Ruta);
            //Actualizar mapa
            gMapControl1.Zoom = gMapControl1.Zoom + 0.1;
            gMapControl1.Zoom = gMapControl1.Zoom - 0.1;

            puntos.Clear();
            ////Borrar datos del DataGrid
            //datosLatLong.dataGridView1.Rows.Clear();
            //datosLatLong.dataGridView1.Refresh();
        }
        #endregion

        #region Verificar conexion a Internet
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Test();
        }

        public void Test()
        {
            System.Uri Url = new System.Uri("http://www.google.com/");
            System.Net.WebRequest WebRequest;
            WebRequest = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse objResp;
            try
            {
                objResp = WebRequest.GetResponse();
                //result = "Su dispositivo está correctamente conectado a internet";
                objResp.Close();
                WebRequest = null;
            }
            catch (Exception err)
            {
                //result = "Error al intentar conectarse a internet " + ex.Message;
                MessageBox.Show(err.Message, "Error al Conectarse a Internet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WebRequest = null;

            }
        }
        #endregion

        int dimensionRows;
        private void toolStripGraficar_Click(object sender, EventArgs e)
        {
            dimensionRows = datos.dataGridView1.Rows.Count;
            double[] datosPlotear = new double[dimensionRows - 1];

            for (int filas = 0; filas < datos.dataGridView1.Rows.Count - 1; filas++)
            {
                datosPlotear[filas] = Convert.ToDouble(datos.dataGridView1.Rows[filas].Cells[1].Value);
            }

            //double[] xs = new double[datosPlotear.Length];
            double[] xs = DataGen.Consecutive(dimensionRows - 1);

            dotosImagen.formsPlot1.plt.Title("Tempteratura");
            dotosImagen.formsPlot1.plt.XLabel("tiempo [s]");
            //dotosImagen.formsPlot1.plt.Ticks(dateTimeX: true);
            dotosImagen.formsPlot1.plt.YLabel("Temperatura [°C]");
            dotosImagen.formsPlot1.plt.AxisAuto(horizontalMargin: 0, verticalMargin: 0.5);

            dotosImagen.formsPlot1.plt.PlotScatter(xs, datosPlotear);
            dotosImagen.formsPlot1.Render();

            dotosImagen.ShowDialog();
        }

        private void btnCrearRuta_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        #region Transmitir Comando
        String datoOUT;             //Variable para el envio de comandos
        private void btnTransmitir_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                datoOUT = Convert.ToString(comando.Text);
                //serialPort1.Write(datoOUT);
                if (datoOUT == "Inicio Comm") { serialPort1.Write("00"); }
                if (datoOUT == "Finalizar Comm") { serialPort1.Write("01"); }
                if (datoOUT == "1 trama/0.5 seg") { serialPort1.Write("02"); }
                if (datoOUT == "1 trama/1 seg") { serialPort1.Write("03"); }
                if (datoOUT == "1 trama/2 seg") { serialPort1.Write("04"); }
                if (datoOUT == "1 trama/5 seg") { serialPort1.Write("05"); }
                if (datoOUT == "ON Antena Tracking") { serialPort1.Write("0R0"); }
                if (datoOUT == "OFF Antena Tracking") { serialPort1.Write("0R1"); }
            }
        }
        #endregion

        #region Video
        private void btnComenzarMostrarVideo_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach(Form f in Application.OpenForms)
            {
                if (f.Text == "Video")
                {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }

            if (isOpen == false)
            {
                Video imageVideo = new Video();
                imageVideo.Show();
            }           
        }
        #endregion

        private void btnBorrarTablaLatLong_Click(object sender, EventArgs e)
        {
            //Borrar datos del DataGrid
            datosLatLong.dataGridView1.Rows.Clear();
            datosLatLong.dataGridView1.Refresh();
        }

        GMapOverlay makerOverlay;
        GMarkerGoogle marker;

        double alturaInicial;
        private void btnConfiguracionInicial_Click(object sender, EventArgs e)
        {
            ConfigInicial ConfiguracionInicial = new ConfigInicial();

            ConfiguracionInicial.ShowDialog();

            LatInicial = Convert.ToDouble(ConfiguracionInicial.LatIni);
            LngInicial = Convert.ToDouble(ConfiguracionInicial.LonIni);

            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);

            //Marcador
            makerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red);
            makerOverlay.Markers.Add(marker);

            gMapControl1.Zoom = 15;
        }

        private void btnTemperatura_Click(object sender, EventArgs e)
        {
            AbrirFormHija(datosTemp);
            //openChildFormInPanel(datosTemp);
        }

        private void btnPresion_Click(object sender, EventArgs e)
        {
            //datosPresion.chtPresion.ChartAreas["ChartArea1"].AxisY.Title = "campo[uT]";
            AbrirFormHija(datosPresion);
        }

        private void btnCorrienteVoltaje_Click(object sender, EventArgs e)
        {
            AbrirFormHija(datosPotencia);
            //openChildFormInPanel(new ClaseCorrVolt());
        }

        private void btnUV_Click(object sender, EventArgs e)
        {
            AbrirFormHija(datosUV);
            //openChildFormInPanel(new ClaseUV());
        }

        private void btnAcelerometro_Click(object sender, EventArgs e)
        {
            AbrirFormHija(datosAcel);
            //openChildFormInPanel(new ClaseAcelerometro());
        }

        private void btnGiroscopio_Click(object sender, EventArgs e)
        {
            AbrirFormHija(datosGiro);
            //openChildFormInPanel(new ClaseGiroscopio());
        }

        private void btnMagnetometro_Click(object sender, EventArgs e)
        {
            AbrirFormHija(datosMagne);
            //openChildFormInPanel(new ClaseMagnetometro());
        }

        private void btnAltura_Click(object sender, EventArgs e)
        {
            AbrirFormHija(datosAltura);
            //openChildFormInPanel(new ClaseAlturaLocal());
        }

        //Para el cronometro de la mision
        int seg, min, hor;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();

            //Para el cronometro de la mision
            seg += 1;
            string segundos1 = seg.ToString();
            string minutos1 = min.ToString();
            string horas1 = hor.ToString();

            if (seg < 10) { segundos1 = "0" + seg.ToString(); }
            if (min < 10) { minutos1 = "0" + min.ToString(); }
            if (hor < 10) { horas1 = "0" + hor.ToString(); }

            lblTiempoMision1.Text = horas1 + ":" + minutos1 + ":" + segundos1;

            if (seg == 59)
            {
                min += 1;
                seg = 0;
            }
            if (min == 59)
            {
                hor += 1;
                min = 0;
            }
        }

        private void AbrirFormHija(object formhija)
        {
            if (this.panelPrincipal.Controls.Count > 0)
            {
                this.panelPrincipal.Controls.RemoveAt(0);
                this.panelPrincipal.Controls.Clear();
            }
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(fh);
            this.panelPrincipal.Tag = fh;
            fh.Show();
        }

        private void btnConexionInternet_Click(object sender, EventArgs e)
        {
            //Esto es para detectar la conexion a internet
            int Description;
            bool ConecionInternet;
            //MessageBox.Show(InternetGetConnectedState(out Description, 0).ToString());
            ConecionInternet = InternetGetConnectedState(out Description, 0);
            if (ConecionInternet == true)
            {
                MessageBox.Show("Buena conexion a Internet, Se extraeran los datos del Mapa del servidor de Google Maps");
                //GMaps.Instance.Mode = AccessMode.ServerOnly;
            }
            else
            {
                MessageBox.Show("Por Favor revice su conexion a Internet, Es posible que no se actualice algunas reguines del mapa");
            }
            //Esto es para detectar la conexion a internet FIN
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();

                btnConectar.Enabled = true;
                btnDesconectar.Enabled = false;

                toolStripStatusLblConectado.Text = "Desconectado";
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();

                btnConectar.Enabled = true;
                btnDesconectar.Enabled = false;

                toolStripStatusLblConectado.Text = "Desconectado";
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
        }
    }
}
