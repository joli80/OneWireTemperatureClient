using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using OneWireTemperatureClient.Properties;

namespace OneWireTemperatureClient
{
    public partial class frmMain : Form
    {
        private Sensor sensor;
        private double? currentTemp = null;
        private bool doExit = false;
        private System.Globalization.CultureInfo serverCulture = new System.Globalization.CultureInfo("en-US");

        public frmMain()
        {
            InitializeComponent();
            systrayIcon.Text = this.Text;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
#if !DEBUG
                sensor = new Sensor(Settings.Default.OneWireAdapterName, Settings.Default.OneWirePortName);
#endif
                timerPollTemperature.Interval = Settings.Default.TemperaturePollIntervalSeconds * 1000;
                timerPollTemperature.Tick += new EventHandler(timerPollTemperature_Tick);
                timerPollTemperature.Start();
                timerPollTemperature_Tick(this, EventArgs.Empty);

                timerPutToServer.Interval = Settings.Default.UploadIntervalSeconds * 1000;
                timerPutToServer.Tick += new EventHandler(timerPutToServer_Tick);
                timerPutToServer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                doExit = true;
                this.Close();
            }
        }

        void timerPutToServer_Tick(object sender, EventArgs e)
        {
            timerPutToServer.Stop();
            try
            {
                if (currentTemp != null)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Settings.Default.PachubeCsvUrl);
                    request.Method = "PUT";
                    request.Headers.Add(Settings.Default.PachubeHttpHeader);
                    string temperature = currentTemp.Value.ToString(this.serverCulture);
                    byte[] bytes = Encoding.ASCII.GetBytes(temperature);
                    request.ContentLength = bytes.Length;
#if !DEBUG
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                    }
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                            throw new ApplicationException(message);
                        }
                        Log("Upload: " + temperature + " - " + response.StatusDescription);
                    }
#endif
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
            timerPutToServer.Start();
        }

        void timerPollTemperature_Tick(object sender, EventArgs e)
        {
            timerPollTemperature.Stop();
            try
            {                
#if DEBUG
                currentTemp = -1.23423;
#else
                currentTemp = sensor.GetTemperature();
#endif
                if (currentTemp.HasValue)
                {
                    lblTemp.Text = currentTemp.Value.ToString("0.0") + " °C";
                    systrayIcon.Text = lblTemp.Text;
                    Log("Temperature: " + currentTemp);
                }                
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
            timerPollTemperature.Start();
        }        

        private void Log(string message)
        {
            lbLog.Items.Insert(0, DateTime.Now + " " + message);
            if (lbLog.Items.Count > 100)
                lbLog.Items.RemoveAt(100);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !doExit)
            {
                e.Cancel = true;
                this.Visible = false;
                this.systrayIcon.BalloonTipText = "This application was minimized to tray";
                this.systrayIcon.BalloonTipTitle = this.Text;
                this.systrayIcon.ShowBalloonTip(1000);
            }
            else
            {
                this.systrayIcon.Visible = false;
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            doExit = true;
            this.Close();
        }

        private void systrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.Visible = true;
        }

    }
}
