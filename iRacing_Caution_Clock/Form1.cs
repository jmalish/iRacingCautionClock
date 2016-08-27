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
        private bool userIsAdmin = false;

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
            if (sessionArgs.SessionInfo.IsValidYaml)  // check if yaml is valid
            {
                Deserializer deserializer = new Deserializer(namingConvention: new PascalCaseNamingConvention(), ignoreUnmatched: true);  // create a deserializer
                var input = new StringReader(sessionArgs.SessionInfo.Yaml);  // read the yaml
                var sessionInfo = deserializer.Deserialize<SDKReturn>(input);  // deserialize the yaml

                #region Session Info
                foreach (var session in sessionInfo.SessionInfo.Sessions)  // look through all the sessions (normally they're Practice, Qualifying, and Race)
                {
                    if (session.SessionType == "Race") // find the race session
                    {
                        racing = true; // set racing to true, so we know the race session has started
                        var raceSession = session;  // the session we're dealing with is the race session, just using this to shorten the variable to less than 50 characters

                        int lapsComplete = Convert.ToInt32(raceSession.ResultsLapsComplete);  // get the laps complete

                        if (lapsComplete > 0) // if ResultsLapsComplete is -1, we haven't entered the race yet
                        {
                            lapsComplete += 1; // laps are 0 indexed, need to add 1 to get it to display correctly

                            lblCurrentLap.Text = string.Format("Lap {0} of {1}", lapsComplete.ToString(), raceSession.SessionLaps);  // set label on form to show what lap we're on

                            if ((Convert.ToInt32(session.SessionLaps)) - (Convert.ToInt32(lapsComplete)) <= 20)  // check if we're less than 20 to go in the race
                            {
                                twentyToGo = true; // race is now twenty to go, caution clock needs to be turned off
                            }
                        }
                    }
                }
                #endregion

                #region Radio Info
                if (userIsAdmin)  // if this is true, we already know user is admin, no reason to keep checking every few seconds
                {
                    foreach (var radio in sessionInfo.RadioInfo.Radios)  // look through all the radios (normally only 1)
                    {
                        foreach (var freq in radio.Frequencies)  // look through all the frequencies
                        {
                            if (freq.FrequencyName.Contains("ADMIN"))  // check to see if there's a radio named ADMIN
                            {
                                userIsAdmin = true;  // if so, user is admin, so we know they can control cautions
                            }
                        }
                    }
                }
                #endregion
            }
            else {
                Console.WriteLine("Not valid YAML");
            }
        }

        private void mainForm_Leave(object sender, EventArgs e)
        {
            
        }


        #region Classes for YAML Parsing
        public class SDKReturn
        {
            public SessionInfo SessionInfo { get; set; }
            public RadioInfo RadioInfo { get; set; }
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

        public class RadioInfo
        {
            public List<Radios> Radios { get; set; }
        }

        public class Radios
        {
            public List<Frequencies> Frequencies { get; set; }
        }

        public class Frequencies
        {
            public string FrequencyName { get; set; }
            public string CanSquawk { get; set; }
        }
        #endregion
    }
}
