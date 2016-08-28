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
        // general variables
        private readonly iRacingSdkWrapper.SdkWrapper wrapper;  // create sdk wrapper, used to connect to iRacing
        private string currentFlag = "-";  // what the flag currently is (eg. green, caution, etc)
        private bool userIsAdmin = false;  // is the user is admin or not, only admins can throw cautions
        private int sessionTime = 0;  // what time it is in the session
        private bool cautionClockActive = false;  // if the caution clock is running
        private int cautionClockTime = 0;  // what time to throw the caution clock, uses the sessionTime

        // veriables that the user can edit
        private int cautionClockTimeLength = 1200;  // how long between cautions, in seconds. Default is 1200
        private decimal cautionShortcutKey = Properties.Settings.Default.CautionShortcutKey;  // which macro is set to send the command to throw the caution, default is 14

        // other variables
        private bool closing = false;  // form was acting weird when closed, I think because of stuff trying to update after wrapper closed
        #endregion

        #region Form stuff
        public mainForm()
        {
            InitializeComponent();  // initialize the component, you know, that component

            chkStreamerFriendlyCounter.Checked = Properties.Settings.Default.LargeCounterStreamerFriendly;  // set large counter to users settings
            numericUpDown1.Value = Properties.Settings.Default.CautionShortcutKey;  // set shortcut key to users settings
            lblLargeCounter.ForeColor = Properties.Settings.Default.LargeCounterNumberColor;
            if (Properties.Settings.Default.LargeCounterStreamerFriendly)  // set background of large counter to users settings
            {
                tabControl1.TabPages[1].BackColor = Color.LawnGreen;
            } else
            {
                tabControl1.TabPages[1].BackColor = Color.Transparent;
            }

            wrapper = new iRacingSdkWrapper.SdkWrapper();  // create wrapper instance

            wrapper.TelemetryUpdated += OnTelemetryUpdated;  // listen to telemetry events
            wrapper.SessionInfoUpdated += OnSessionInfoUpdated;  // listen to session events

            wrapper.Start();  // start wrapper
        }  // basic form stuff

        private void btnChangeLblColor_Click(object sender, EventArgs e)
        {
            ColorDialog clrDialogue = new ColorDialog();  // create a color dialogue
            clrDialogue.AllowFullOpen = false;  // disable it from being able to go full screen
            clrDialogue.ShowHelp = true;  // turn on the help dialogue
            clrDialogue.Color = lblLargeCounter.ForeColor;  // get the current color of the label

            if (clrDialogue.ShowDialog() == DialogResult.OK)  // if the user clicks OK
            {
                lblLargeCounter.ForeColor = clrDialogue.Color;  // set the labels color to the new chosen color
                Properties.Settings.Default.LargeCounterNumberColor = clrDialogue.Color;  // update user settings
                Properties.Settings.Default.Save(); // and save
            }
        } // user has clicked button to change number color

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            wrapper.Stop();  // stop the wrapper since the form is being closed, otherwise we have a wild wrapper running free TODO: make a joke about debris cautions here
        }  // user has closed form

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)  // when user changes the key for caution, we need to update it so they don't have to kee making the change every restart
        {
            Properties.Settings.Default.CautionShortcutKey = numericUpDown1.Value;  // update settings
            Properties.Settings.Default.Save();  // save the new key to settings
        }

        private void chkStreamerFriendlyCounter_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LargeCounterStreamerFriendly = chkStreamerFriendlyCounter.Checked;  // user has changed whether or not to have green screen backing
            Properties.Settings.Default.Save();  // save settings

            if (chkStreamerFriendlyCounter.Checked) // if the value is now true
            {
                tabControl1.TabPages[1].BackColor = Color.LawnGreen;  // set background to bright green
            } else // if the value is false
            {
                tabControl1.TabPages[1].BackColor = Color.Transparent;  // set background to transparent
            }
        }  // user has changed how to display large counter

        private void linkLblCautionShortcutHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(String.Format("{0}\n\n{1}\n\n{2}",
                "The \"Caution Shortcut\" setting is the shortcut you \nhave selected to throw a caution in iRacing.",
                "The setting '1' is the very first shortcut at the top.",
                "I suggest testing in a practice with the \"Manual Caution\" \nbutton in the top right to see if you have the correct setting"));
        }  // user has clicked the ? button next to caution shortcut
        #endregion

        #region SDK Wrapper Stuff
        private void OnTelemetryUpdated(object sender, iRacingSdkWrapper.SdkWrapper.TelemetryUpdatedEventArgs telemArgs)  // do things when Telemetry updates (supposed to be 60 times per second)
        {
            if (!closing)
            {
                #region Flag stuff
                string newFlag = telemArgs.TelemetryInfo.SessionFlags.Value.ToString().Split(' ')[0];  // get the actual current flag according to the session, splits because it normally shows two states

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

                if (cautionClockActive)
                {
                    string time = sessionTime.ToString().Split('.')[0];  // session time minus milliseconds

                    double expireTime = cautionClockTime - Convert.ToDouble(time);  // calculate how much longer we have until caution clock expires

                    TimeSpan timeTilExpire = TimeSpan.FromSeconds(expireTime);  // convert it into a timespan object
                    lblCautionClockExpires.Text = String.Format("Clock expires in: { 0}:{ 1}", timeTilExpire.Minutes, timeTilExpire.Seconds.ToString("00"));  // update label
                    lblLargeCounter.Text = String.Format("Clock expires in: { 0}:{ 1}", timeTilExpire.Minutes, timeTilExpire.Seconds.ToString("00"));  // update label
                }
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
                                    cautionClockActive = false;  // turn off caution clock
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
                                    lblUserIsAdmin.Text = "Admin: True";
                                } else
                                {
                                    lblUserIsAdmin.Text = "Admin: False";
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
                lblCautionClockStatus.Text = "Caution Clock: ACTIVE"; // update label

                if (sessionTime >= cautionClockTime)
                {
                    wrapper.Chat.SendMacro(Convert.ToInt32(cautionShortcutKey));  // throw caution
                    
                }
            } else // if not
            {
                lblCautionClockStatus.Text = "Caution Clock: Not Active";  // update label
                lblCautionClockExpires.Text = String.Format("Clock expires in: -");
                lblLargeCounter.Text = "";
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