// This relies heavily on Nick Thissen's iRacing SDK Wrapper: https://github.com/NickThissen/iRacingSdkWrapper

using System;
using System.Collections.Generic;
using System.Drawing;
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
        private string currentTrack;  // the track that we're at
        private bool isRaceSession = false; // whether we're in a race session (as opposed to practice or qual) -
        private int currentLap;  // what lap the race is on
        private bool cautionThrown = false; // whether the caution has been thrown yet, keeps from spamming the chat
        private int raceLengthLaps;  // how many laps the race is
        private string logFile = "log.txt";

        // veriables that the user can edit
        private int cautionClockTime = 0;  // what time to throw the caution clock, uses the sessionTime
        private int cautionClockCutoffLap = 20;  // what lap the caution clock is turned off, default is 20
        private int cautionClockTimeLength = 1200;  // how long between cautions, in seconds. Default is 1200
        private bool controlsCautions = false;

        // other variables
        private bool closing = false;  // form was acting weird when closed, I think because of stuff trying to update after wrapper closed
        #endregion

        #region Form stuff
        public mainForm()
        {
            if (!File.Exists(logFile))  // make sure file exists
            {
                // File.Create(logFile); // if not, create it
                using (StreamWriter sw = File.AppendText(logFile))
                {
                    sw.WriteLine(DateTime.Now.ToString("h:mm:ss") + " - File created");
                }
            }

            InitializeComponent();  // initialize the component, you know, that component

            chkStreamerFriendlyCounter.Checked = Properties.Settings.Default.LargeCounterStreamerFriendly;  // set large counter to users settings
            numericUpDown1.Value = Properties.Settings.Default.CautionShortcutKey;  // set shortcut key to users settings
            lblLargeCounter.ForeColor = Properties.Settings.Default.LargeCounterNumberColor; // set color for large counter text
            lblCountdownTitle.ForeColor = Properties.Settings.Default.LargeCounterNumberColor;
            if (Properties.Settings.Default.LargeCounterStreamerFriendly)  // set background of large counter to users settings
            {
                tabControl1.TabPages[1].BackColor = Color.LawnGreen;
            } else
            {
                tabControl1.TabPages[1].BackColor = Color.Transparent;
            }
            chkControlsCautions.Checked = false;
            chkControlsCautions.Enabled = false;
            chkPlayAudioOnCaution.Checked = Properties.Settings.Default.PlayAudioFileOnCaution;
            //lblCountdownTitle.Visible = false;
            //lblLargeCounter.Visible = false;

            #region wrapper stuff
            try
            {
                wrapper = new iRacingSdkWrapper.SdkWrapper();  // create wrapper instance

                wrapper.TelemetryUpdated += OnTelemetryUpdated;  // listen to telemetry events
                wrapper.SessionInfoUpdated += OnSessionInfoUpdated;  // listen to session events

                wrapper.Start();  // start wrapper
            } catch (Exception exc)
            {
                WriteToLogFile("wrapper stuff", exc.Message.ToString());
            }


            #endregion
        }  // basic form stuff

        private void btnChangeLblColor_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog clrDialogue = new ColorDialog();  // create a color dialogue
                clrDialogue.AllowFullOpen = false;  // disable it from being able to go full screen
                clrDialogue.ShowHelp = true;  // turn on the help dialogue
                clrDialogue.Color = lblLargeCounter.ForeColor;  // get the current color of the label

                if (clrDialogue.ShowDialog() == DialogResult.OK)  // if the user clicks OK
                {
                    lblLargeCounter.ForeColor = clrDialogue.Color;  // set the labels color to the new chosen color
                    lblCountdownTitle.ForeColor = clrDialogue.Color;
                    Properties.Settings.Default.LargeCounterNumberColor = clrDialogue.Color;  // update user settings
                    Properties.Settings.Default.Save(); // and save
                }
            } catch (Exception exc)
            {
                WriteToLogFile("btnChangeLblColor_Click", exc.Message.ToString());
            }
        } // user has clicked button to change number color

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)  // user has closed form
        {
            closing = true;
            wrapper.Stop();  // stop the wrapper since the form is being closed, otherwise we have a wild wrapper running free TODO: make a joke about debris cautions here
            Application.Exit();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)  // when user changes the key for caution, we need to update it so they don't have to kee making the change every restart
        {
            Properties.Settings.Default.CautionShortcutKey = numericUpDown1.Value;  // update settings
            Properties.Settings.Default.Save();  // save the new key to settings
            lblCautionShortcutUpdated.Visible = false;
            lblCautionShortcutUpdated.Text = String.Format("Setting changed to {0}", Properties.Settings.Default.CautionShortcutKey);
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

        private void chkControlsCautions_CheckedChanged(object sender, EventArgs e)
        {
            if (chkControlsCautions.Checked)
            {
                controlsCautions = true;
            } else
            {
                controlsCautions = false;
            }
        }

        private void numUDLapCutoff_ValueChanged(object sender, EventArgs e)  // lets the user change the caution clock cut off lap
        {
            cautionClockCutoffLap = Convert.ToInt32(numUDLapCutoff.Value);  // change the caution clock lap cut off
            lblCautionClockCutoffUpdate.Visible = true;
            lblCautionClockCutoffUpdate.Text = String.Format("Cutoff is now {0} laps", cautionClockCutoffLap);
        }

        private void btnManualCaution_Click(object sender, EventArgs e)
        {
            try
            {
                wrapper.Chat.SendMacro(Convert.ToInt32(Properties.Settings.Default.CautionShortcutKey - 1));
            } catch (Exception exc)
            {
                WriteToLogFile("btnManualCaution_Click", exc.Message.ToString());
            }
        }

        private void numUDTimeBetween_ValueChanged(object sender, EventArgs e)
        {
            cautionClockTimeLength = Convert.ToInt32(numUDTimeBetween.Value) * 60;
            lblCurrentTimerLength.Text = string.Format("Timer now set to {0} minutes, which is {1} seconds", numUDTimeBetween.Value, cautionClockTimeLength);
        }

        private void btnTestAudio_Click(object sender, EventArgs e)
        {
            try
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = "putitout.wav";
                player.Load();
                player.Play();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Oops... Something went wrong with the audio player.\n\nError:\n" + exc.Message, "Error");
                WriteToLogFile("btnTestAudio_Click", exc.Message.ToString());
            }
        }

        private void chkPlayAudioOnCaution_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.PlayAudioFileOnCaution = chkPlayAudioOnCaution.Checked;
                Properties.Settings.Default.Save();
            } catch (Exception exc)
            {
                WriteToLogFile("chkPlayAudioOnCaution_CheckedChanged", exc.Message.ToString());
            }
        }
        #endregion

        #region SDK Wrapper Stuff
        private void OnTelemetryUpdated(object sender, iRacingSdkWrapper.SdkWrapper.TelemetryUpdatedEventArgs telemArgs)  // do things when Telemetry updates (supposed to be 60 times per second)
        {
            try
            {
                if (!closing)
                {
                    currentLap = telemArgs.TelemetryInfo.Lap.Value;
                    CheckCautionClock();

                    #region Flag stuff
                    if (isRaceSession)  // only do this stuff during the race session
                    {
                        string newFlag = telemArgs.TelemetryInfo.SessionFlags.Value.ToString().Split(' ')[0];  // get the actual current flag according to the session, splits because it normally shows two states

                        if (currentFlag != newFlag)  // flag changed in the last update
                        {
                            if (!newFlag.Contains("StartHidden") && (!newFlag.Contains("Servicible")) && (!newFlag.Contains("Black")))  // don't want to show this flag to users, better to just tell them it's still green
                            {
                                currentFlag = newFlag;  // set current flag variable to the new flag

                                if (newFlag.Contains("CautionWaving")) // caution is out, starts out as "CautionWaving" and then turns to "Caution" after a short time
                                {
                                    cautionClockActive = false; // turn off caution clock

                                    if (chkPlayAudioOnCaution.Checked)
                                    {
                                        try
                                        {
                                            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                                            player.SoundLocation = "putitout.wav";
                                            player.Load();
                                            player.Play();
                                        }
                                        catch { }
                                    }
                                }
                                else if (newFlag == "Green")
                                {
                                    cautionThrown = false;
                                    cautionClockActive = true; // turn on the caution clock
                                    cautionClockTime = sessionTime + cautionClockTimeLength; // set time for caution clock to expire
                                    Console.WriteLine("Green flag!");
                                }
                            }
                        }

                        // currentFlag = telemArgs.TelemetryInfo.SessionFlags.Value.ToString().Split('|')[0]; // gets the current flag state and trims off the unneccessary stuff

                        lblCurrentFlag.Text = "Current Flag: " + currentFlag;
                    }
                    #endregion

                    #region Time and some lap stuff
                    string currentTime = telemArgs.TelemetryInfo.SessionTime.ToString().Split('.')[0];  // get the session time (how long it's been since this session started) splitting at decimal because we don't need to know the exact time to milliseconds
                    int realCutOffLap = raceLengthLaps - cautionClockCutoffLap;

                    if (currentLap > realCutOffLap)  // if we're past the lap cutoff, no need to run this section
                    {
                        sessionTime = Convert.ToInt32(currentTime);  // convert it to int so we can use it as a number

                        if (cautionClockActive)
                        {
                            string time = sessionTime.ToString().Split('.')[0];  // session time minus milliseconds
                            double expireTime = cautionClockTime - Convert.ToDouble(time);  // calculate how much longer we have until caution clock expires

                            TimeSpan timeTilExpire = TimeSpan.FromSeconds(expireTime);  // convert it into a timespan object
                            lblCautionClockExpires.Text = String.Format("Clock expires in: {0}:{1}", timeTilExpire.Minutes, timeTilExpire.Seconds.ToString("00"));  // update label
                            lblLargeCounter.Visible = true;
                            lblCountdownTitle.Visible = true;
                            lblLargeCounter.Text = String.Format("{0}:{1}", timeTilExpire.Minutes.ToString("00"), timeTilExpire.Seconds.ToString("00"));  // update label
                        }
                    }
                    else  // if we are past that point, just hide the counter
                    {
                        lblLargeCounter.Visible = false;
                        lblCountdownTitle.Visible = false;
                    }
                    #endregion

                    if (wrapper.IsConnected) // check if wrapper has connected yet
                    {
                        lblConnectedToiRacing.Text = "Connected to iRacing!";  // let user know we've connected to the wrapper
                    }
                }
            }
            catch (Exception exc)
            {
                WriteToLogFile("OnTelemetryUpdated", exc.Message.ToString());
            }
        }

        // do things when session info updates
        private void OnSessionInfoUpdated(object sender, iRacingSdkWrapper.SdkWrapper.SessionInfoUpdatedEventArgs sessionArgs)
        {
            try
            {
                if (!closing)
                {
                    if (sessionArgs.SessionInfo.IsValidYaml)  // check if yaml is valid
                    {
                        Deserializer deserializer = new Deserializer(namingConvention: new PascalCaseNamingConvention(), ignoreUnmatched: true);  // create a deserializer
                        var input = new StringReader(sessionArgs.SessionInfo.Yaml);  // read the yaml
                        var sessionInfo = deserializer.Deserialize<SDKReturn>(input);  // deserialize the yaml

                        #region Track info
                        var track = sessionInfo.WeekendInfo.TrackDisplayName;
                        if (track != currentTrack)
                        {
                            currentTrack = track;  // currently, in the real CWTS, nascar stops the cautoin clock at 10 laps to go, so we need to see if we're at one of those tracks

                            if (currentTrack == "Canadian Tire Motorsport Park" || currentTrack == "Pocono Raceway")  // if we're at one of the two tracks
                            {
                                // let the user know about the IRL rules
                                var msgBoxResult = MessageBox.Show("It looks like you're either at Canadian Tire or Pocono. \nThese tracks have the caution clock turn off at 10 laps to go in the real CWTS. \nClick OK to set the caution clock to turn off at 10 laps, or cancel to leave it at 20.", "", MessageBoxButtons.OKCancel);

                                if (msgBoxResult == DialogResult.OK)
                                {
                                    cautionClockCutoffLap = 10;
                                    numUDLapCutoff.Value = 10;
                                }
                            }
                        }
                        #endregion

                        #region Session Info
                        foreach (var session in sessionInfo.SessionInfo.Sessions)  // look through all the sessions (normally they're Practice, Qualifying, and Race)
                        {
                            if (session.SessionType == "Race") // find the race session
                            {
                                var raceSession = session;  // the session we're dealing with is the race session, just using this to shorten the variable to less than 50 characters
                                int lapsComplete = Convert.ToInt32(raceSession.ResultsLapsComplete);  // get the laps complete

                                raceLengthLaps = Convert.ToInt32(raceSession.SessionLaps);
                                if (lapsComplete >= 0) // if ResultsLapsComplete is -1, we haven't entered the race yet
                                {
                                    isRaceSession = true;
                                    lapsComplete += 1; // laps are 0 indexed, need to add 1 to get it to display correctly
                                    lblCurrentLap.Text = string.Format("Lap {0} of {1}", lapsComplete.ToString(), raceLengthLaps);  // set label on form to show what lap we're on

                                    try
                                    {
                                        if ((Convert.ToInt32(raceLengthLaps)) - (Convert.ToInt32(lapsComplete)) <= cautionClockCutoffLap)  // check if we're less than 20 to go in the race
                                        {
                                            cautionClockActive = false;  // turn off caution clock
                                        }
                                    }
                                    catch
                                    {
                                        MessageBox.Show("It looks like the session you're in is a timed race.");
                                    }
                                }
                            }
                        }
                        #endregion

                        #region Radio Info / Admin check
                        if (!userIsAdmin)  // if user is admin, no need to keep running this block, people being removed from admin is so rare I'm not worried about dealing with that
                        {
                            foreach (var radio in sessionInfo.RadioInfo.Radios)  // look through all the radios (normally only 1)
                            {
                                foreach (var freq in radio.Frequencies)  // look through all the frequencies
                                {
                                    if (freq.FrequencyName == "@ADMIN")  // check to see if there's a radio named ADMIN
                                    {
                                        userIsAdmin = true;  // if so, user is admin, so we know they can control cautions
                                        lblUserIsAdmin.Text = "Admin: True";
                                        chkControlsCautions.Enabled = true;
                                    }
                                    else
                                    {
                                        if (!userIsAdmin) // this shouldn't even be reached if user is admin, but just in case
                                        {
                                            lblUserIsAdmin.Text = "Admin: False";
                                        }
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
            } catch (Exception exc)
            {
                WriteToLogFile("OnSessionInfoUpdated", exc.Message.ToString());
            }
        }
        #endregion

        #region FUNctions
        private void CheckCautionClock()  // function that pretty much contains the caution clock
        {
            try
            {
                if (cautionClockActive)  // first make sure caution clock is even active
                {
                    lblCautionClockStatus.Text = "Caution Clock: ACTIVE"; // update label

                    if (userIsAdmin && controlsCautions)  // make sure user is admin and wants to control cautions
                    {
                        if (sessionTime >= cautionClockTime)  // check if it's time to throw the caution
                        {
                            if (!cautionThrown || currentFlag.Contains("CautionWaving"))
                            {
                                wrapper.Chat.SendMacro(Convert.ToInt32(Properties.Settings.Default.CautionShortcutKey - 1));  // throw caution
                            }
                            cautionThrown = true;
                        }
                    }
                }
                else // if not
                {
                    // update all relevant labels
                    lblCautionClockStatus.Text = "Caution Clock: Not Active";
                    lblCautionClockExpires.Text = "Clock expires in: -";
                    lblLargeCounter.Visible = false;
                    lblCountdownTitle.Visible = false;
                }
            } catch (Exception exc)
            {
                WriteToLogFile("Check Caution Clock function", exc.Message.ToString());
            }

            return;
        }

        private void WriteToLogFile(string errorLocation, string textToLog)
        {
            using (StreamWriter sw = File.AppendText(logFile))
            {
                sw.WriteLine(String.Format("{0} - Error occured in {1} :: Error Message: {2}",
                    DateTime.Now.ToString("h:mm:ss"),
                    errorLocation,
                    textToLog));
            }
        }  // function to handle error catching
        #endregion

        #region Classes for YAML Parsing
        public class SDKReturn
        {
            public SessionInfo SessionInfo { get; set; }
            public RadioInfo RadioInfo { get; set; }
            public WeekendInfo WeekendInfo { get; set; }
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

        public class WeekendInfo
        {
            public string TrackDisplayName { get; set; }
        }
        #endregion
    }
}