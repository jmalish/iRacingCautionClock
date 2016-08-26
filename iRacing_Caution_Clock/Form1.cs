// This relies heavily on Nick Thissen's iRacing SDK Wrapper: https://github.com/NickThissen/iRacingSdkWrapper

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace iRacing_Caution_Clock
{
    public partial class mainForm : Form
    {
        private readonly iRacingSdkWrapper.SdkWrapper wrapper;
        private bool racing = false;
        private bool twentyToGo = false;
        private string currentFlag = "-";

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
            // Console.WriteLine("telemetry updated");
            // Console.WriteLine(telemArgs.TelemetryInfo.SessionTime.ToString());

            currentFlag = telemArgs.TelemetryInfo.SessionFlags.Value.ToString().Split('|')[0]; // gets the current flag state and trims off the unneccessary stuff

            lblCurrentFlag.Text = "Current Flag: " + currentFlag;

            if (wrapper.IsConnected)
            {
                lblConnectedToiRacing.Text = "Connected to iRacing!";
            } else
            {
                lblConnectedToiRacing.Text = "Not Connected!";
            }



            if (!racing || twentyToGo)
            {
                // turn off caution clock
            }
        }

        // do things when session info updates
        private void OnSessionInfoUpdated(object sender, iRacingSdkWrapper.SdkWrapper.SessionInfoUpdatedEventArgs sessionArgs)
        {
            Console.WriteLine("Session info updated: " + DateTime.Now.ToString());
            if (sessionArgs.SessionInfo.IsValidYaml)
            {
                Deserializer deserializer = new Deserializer(namingConvention: new PascalCaseNamingConvention(), ignoreUnmatched: true);
                var input = new StringReader(sessionArgs.SessionInfo.Yaml);

                var sessionInfo = deserializer.Deserialize<SDKReturn>(input);

                foreach (var session in sessionInfo.SessionInfo.Sessions)
                {
                    if (session.SessionType == "Race") // find the race session
                    {
                        racing = true; // set racing to true, so we know the race session has started
                        var raceSession = session;

                        int lapsComplete = Convert.ToInt32(raceSession.ResultsLapsComplete);

                        if (lapsComplete > 0) // if ResultsLapsComplete is -1, we haven't entered the race yet
                        {
                            lapsComplete += 1; // laps are 0 indexed, need to add 1 to get it to display correctly

                            lblCurrentLap.Text = string.Format("Lap {0} of {1}", lapsComplete.ToString(), raceSession.SessionLaps);

                            if ((Convert.ToInt32(session.SessionLaps)) - (Convert.ToInt32(lapsComplete)) <= 20)
                            {
                                twentyToGo = true; // race is now twenty to go, caution clock needs to be turned off
                            }
                        } else
                        {
                            // Console.WriteLine("Not in race session yet");
                        }
                    }
                }
            } else {
                Console.WriteLine("Not valid YAML");
            }
        }

        private void mainForm_Leave(object sender, EventArgs e)
        {
            
        }


        // Classes for YAML junk
        public class SDKReturn
        {
            public SessionInfo SessionInfo { get; set; }
        }

        public class SessionInfo
        {
            public List<Session> Sessions { get; set; }
        }

        public class Session
        {
            public string ResultsLapsComplete { get; set; }
            public string SessionLaps { get; set; }
            public string SessionType { get; set; }
        }
    }
}
