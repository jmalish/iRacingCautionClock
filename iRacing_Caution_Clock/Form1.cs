// This relies heavily on Nick Thissen's iRacing SDK Wrapper: https://github.com/NickThissen/iRacingSdkWrapper

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRacing_Caution_Clock
{
    public partial class mainForm : Form
    {
        private readonly iRacingSdkWrapper.SdkWrapper wrapper;

        public mainForm()
        {
            InitializeComponent();

            // create instance
            wrapper = new iRacingSdkWrapper.SdkWrapper();

            // listen to events
            wrapper.TelemetryUpdated += OnTelemetryUpdated;
            wrapper.SessionInfoUpdated += OnSessionInfoUpdated;

            // start wrapper
            wrapper.Start();
        }

        // do things when Telemetry updates (supposed to be 60 times per second)
        private void OnTelemetryUpdated(object sender, iRacingSdkWrapper.SdkWrapper.TelemetryUpdatedEventArgs telemArgs)
        {
            Console.WriteLine("telemetry updated");

            string currentFlag = telemArgs.TelemetryInfo.SessionFlags.Value.ToString();
            // .Split('|')[0];

            lblCurrentFlag.Text = "Current Flag: " + currentFlag;

            if (wrapper.IsConnected)
            {
                lblConnectedToiRacing.Text = "Connected to iRacing!";
            } else
            {
                lblConnectedToiRacing.Text = "Not Connected!";
            }
        }

        // do things when session info updates
        private void OnSessionInfoUpdated(object sender, iRacingSdkWrapper.SdkWrapper.SessionInfoUpdatedEventArgs SessionArgs)
        {
             // TODO: get leader and which lap he's on (need to know when we're 20 to go)

            Console.WriteLine("session info updated");
        }

        private void mainForm_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
