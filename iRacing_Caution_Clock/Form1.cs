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
        #region Variables
        private readonly iRacingSdkWrapper.SdkWrapper wrapper;  // create sdk wrapper, used to connect to iRacing

        private string currentFlag = "-";  // what the flag currently is (eg. green, caution, etc)
        private bool userIsAdmin = false;  // is the user is admin or not, only admins can throw cautions
        private int sessionTime = 0;  // what time it is in the session
        private bool cautionClockActive = false;  // if the caution clock is running
        private int cautionClockTime = 0;  // what time to throw the caution clock, uses the sessionTime
        private int cautionClockTimeLength = 1200;  // how long between cautions, in seconds. Default is 1200

        private bool closing = false;  // form was acting weird when closed, I think because of stuff trying to update after wrapper closed
        #endregion

        #region Form stuff
        public mainForm()
        {
            InitializeComponent();  // initialize the component, you know, that component

            wrapper = new iRacingSdkWrapper.SdkWrapper();  // create wrapper instance

            wrapper.TelemetryUpdated += OnTelemetryUpdated;  // listen to telemetry events
            wrapper.SessionInfoUpdated += OnSessionInfoUpdated;  // listen to session events

            wrapper.Start();  // start wrapper
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            wrapper.Stop();  // stop the wrapper since the form is being closed, otherwise we have a wild wrapper running free TODO: make a joke about debris cautions here
        }
        #endregion

        #region SDK Wrapper Stuff
        private void OnTelemetryUpdated(object sender, iRacingSdkWrapper.SdkWrapper.TelemetryUpdatedEventArgs telemArgs)  // do things when Telemetry updates (supposed to be 60 times per second)
        {
            if (!closing)
            {
                #region Flag stuff
                string newFlag = telemArgs.TelemetryInfo.SessionFlags.Value.ToString().Split(' ')[0];  // get the actual current flag according to the session, splits because it normally shows two states

                lblActualFlag.Text = newFlag;

                if (currentFlag != newFlag)  // flag changed in the last update
                {
                    if (!newFlag.Contains("StartHidden"))  // don't want to show this flag to users, better to just tell them it's still green
                    {
                        currentFlag = newFlag;  // set current flag variable to the new flag

                        if (newFlag.Contains("Caution")) // caution is out, starts out as "CautionWaving" and then turns to "Caution" after a short time
                        {
                            cautionClockActive = false; // turn off caution clock
                        }
                        else if (newFlag == "Green")
                        {
                            cautionClockActive = true; // turn on the caution clock
                            cautionClockTime = sessionTime + cautionClockTimeLength; // set time for caution clock to expire

                            lblCautionClockExpires.Text = (cautionClockTime - sessionTime).ToString();
                        }

                    }

                    CheckCautionClock();
                }

                // currentFlag = telemArgs.TelemetryInfo.SessionFlags.Value.ToString().Split('|')[0]; // gets the current flag state and trims off the unneccessary stuff

                lblCurrentFlag.Text = "Current Flag: " + currentFlag;
                #endregion

                #region Time stuff
                string currentTime = telemArgs.TelemetryInfo.SessionTime.ToString().Split('.')[0];  // get the session time (how long it's been since this session started)
                                                                                                    // splitting at decimal because we don't need to know the exact milisecond
                sessionTime = Convert.ToInt32(currentTime);  // convert it to int so we can use it as a number


                lblTime.Text = "Time: " + sessionTime.ToString();  // update time label
                #endregion
                
                if (wrapper.IsConnected) // check if wrapper has connected yet
                {
                    lblConnectedToiRacing.Text = "Connected to iRacing!";  // let user know we've connected to the wrapper
                }
            }
        }

        // do things when session info updates
        private void OnSessionInfoUpdated(object sender, iRacingSdkWrapper.SdkWrapper.SessionInfoUpdatedEventArgs sessionArgs)
        {
            if (!closing)
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
                            var raceSession = session;  // the session we're dealing with is the race session, just using this to shorten the variable to less than 50 characters
                            int lapsComplete = Convert.ToInt32(raceSession.ResultsLapsComplete);  // get the laps complete

                            if (lapsComplete > 0) // if ResultsLapsComplete is -1, we haven't entered the race yet
                            {
                                lapsComplete += 1; // laps are 0 indexed, need to add 1 to get it to display correctly
                                lblCurrentLap.Text = string.Format("Lap {0} of {1}", lapsComplete.ToString(), raceSession.SessionLaps);  // set label on form to show what lap we're on

                                if ((Convert.ToInt32(session.SessionLaps)) - (Convert.ToInt32(lapsComplete)) <= 20)  // check if we're less than 20 to go in the race
                                {
                                    // cautionClockActive = false;  // turn off caution clock
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
                else
                {
                    Console.WriteLine("Not valid YAML!!"); // this shouldn't ever really be reached, if so, there's something wrong with the wrapper
                }
            }
        }
        #endregion

        #region FUNctions
        private void CheckCautionClock()  // function that pretty much contains the caution clock
        {
            if (cautionClockActive)  // first make sure caution clock is even active
            {
                lblCautionClockStatus.Text = "Caution Clock: ACTIVE";
            } else
            {
                lblCautionClockStatus.Text = "Caution Clock: OFF";
            }

            return;
        }
        #endregion

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
