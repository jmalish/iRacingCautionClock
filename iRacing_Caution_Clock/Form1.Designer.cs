namespace iRacing_Caution_Clock
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.lblConnectedToiRacing = new System.Windows.Forms.Label();
            this.lblCurrentFlag = new System.Windows.Forms.Label();
            this.lblCurrentLap = new System.Windows.Forms.Label();
            this.lblCautionClockStatus = new System.Windows.Forms.Label();
            this.lblCautionClockExpires = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPgQuickInfo = new System.Windows.Forms.TabPage();
            this.btnManualCaution = new System.Windows.Forms.Button();
            this.chkControlsCautions = new System.Windows.Forms.CheckBox();
            this.lblUserIsAdmin = new System.Windows.Forms.Label();
            this.tabPgLargeCountdown = new System.Windows.Forms.TabPage();
            this.btnChangeBgColor = new System.Windows.Forms.Button();
            this.chkStayOnTop = new System.Windows.Forms.CheckBox();
            this.lblCountdownTitle = new System.Windows.Forms.Label();
            this.btnChangeLblColor = new System.Windows.Forms.Button();
            this.lblLargeCounter = new System.Windows.Forms.Label();
            this.tabPgOptions = new System.Windows.Forms.TabPage();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblPlayAudioInfo = new System.Windows.Forms.Label();
            this.chkPlayAudioOnCaution = new System.Windows.Forms.CheckBox();
            this.btnTestAudio = new System.Windows.Forms.Button();
            this.lblCautionClockCutoffUpdate = new System.Windows.Forms.Label();
            this.numUDLapCutoff = new System.Windows.Forms.NumericUpDown();
            this.lblCurrentTimerLength = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCautionClockLength = new System.Windows.Forms.Label();
            this.lblCautionShortcutKey = new System.Windows.Forms.Label();
            this.numUDTimeBetween = new System.Windows.Forms.NumericUpDown();
            this.num10MinHotkey = new System.Windows.Forms.NumericUpDown();
            this.lbl10MinHotkey = new System.Windows.Forms.Label();
            this.num5MinHotkey = new System.Windows.Forms.NumericUpDown();
            this.lbl5MinHotkey = new System.Windows.Forms.Label();
            this.chkEnableMinWarnings = new System.Windows.Forms.CheckBox();
            this.lbl1MinHotkey = new System.Windows.Forms.Label();
            this.num1MinHotkey = new System.Windows.Forms.NumericUpDown();
            this.lblDivider1 = new System.Windows.Forms.Label();
            this.lblDivider2 = new System.Windows.Forms.Label();
            this.btnTestHotkeys = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPgQuickInfo.SuspendLayout();
            this.tabPgLargeCountdown.SuspendLayout();
            this.tabPgOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDLapCutoff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDTimeBetween)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num10MinHotkey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num5MinHotkey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num1MinHotkey)).BeginInit();
            this.SuspendLayout();
            // 
            // lblConnectedToiRacing
            // 
            this.lblConnectedToiRacing.AutoSize = true;
            this.lblConnectedToiRacing.Location = new System.Drawing.Point(15, 15);
            this.lblConnectedToiRacing.Name = "lblConnectedToiRacing";
            this.lblConnectedToiRacing.Size = new System.Drawing.Size(121, 13);
            this.lblConnectedToiRacing.TabIndex = 0;
            this.lblConnectedToiRacing.Text = "Connecting to iRacing...";
            // 
            // lblCurrentFlag
            // 
            this.lblCurrentFlag.AutoSize = true;
            this.lblCurrentFlag.Location = new System.Drawing.Point(15, 69);
            this.lblCurrentFlag.Name = "lblCurrentFlag";
            this.lblCurrentFlag.Size = new System.Drawing.Size(73, 13);
            this.lblCurrentFlag.TabIndex = 0;
            this.lblCurrentFlag.Text = "Current Flag: -";
            // 
            // lblCurrentLap
            // 
            this.lblCurrentLap.AutoSize = true;
            this.lblCurrentLap.Location = new System.Drawing.Point(15, 96);
            this.lblCurrentLap.Name = "lblCurrentLap";
            this.lblCurrentLap.Size = new System.Drawing.Size(49, 13);
            this.lblCurrentLap.TabIndex = 0;
            this.lblCurrentLap.Text = "Lap - of -";
            // 
            // lblCautionClockStatus
            // 
            this.lblCautionClockStatus.AutoSize = true;
            this.lblCautionClockStatus.Location = new System.Drawing.Point(15, 150);
            this.lblCautionClockStatus.Name = "lblCautionClockStatus";
            this.lblCautionClockStatus.Size = new System.Drawing.Size(129, 13);
            this.lblCautionClockStatus.TabIndex = 0;
            this.lblCautionClockStatus.Text = "Caution Clock: Not Active";
            // 
            // lblCautionClockExpires
            // 
            this.lblCautionClockExpires.AutoSize = true;
            this.lblCautionClockExpires.Location = new System.Drawing.Point(15, 123);
            this.lblCautionClockExpires.Name = "lblCautionClockExpires";
            this.lblCautionClockExpires.Size = new System.Drawing.Size(90, 13);
            this.lblCautionClockExpires.TabIndex = 0;
            this.lblCautionClockExpires.Text = "Clock expires in: -";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPgQuickInfo);
            this.tabControl1.Controls.Add(this.tabPgLargeCountdown);
            this.tabControl1.Controls.Add(this.tabPgOptions);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(409, 261);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPgQuickInfo
            // 
            this.tabPgQuickInfo.Controls.Add(this.btnTestHotkeys);
            this.tabPgQuickInfo.Controls.Add(this.btnManualCaution);
            this.tabPgQuickInfo.Controls.Add(this.chkControlsCautions);
            this.tabPgQuickInfo.Controls.Add(this.lblConnectedToiRacing);
            this.tabPgQuickInfo.Controls.Add(this.lblCautionClockExpires);
            this.tabPgQuickInfo.Controls.Add(this.lblCautionClockStatus);
            this.tabPgQuickInfo.Controls.Add(this.lblUserIsAdmin);
            this.tabPgQuickInfo.Controls.Add(this.lblCurrentFlag);
            this.tabPgQuickInfo.Controls.Add(this.lblCurrentLap);
            this.tabPgQuickInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPgQuickInfo.Name = "tabPgQuickInfo";
            this.tabPgQuickInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgQuickInfo.Size = new System.Drawing.Size(401, 235);
            this.tabPgQuickInfo.TabIndex = 0;
            this.tabPgQuickInfo.Text = "Quick Info";
            this.tabPgQuickInfo.UseVisualStyleBackColor = true;
            // 
            // btnManualCaution
            // 
            this.btnManualCaution.Location = new System.Drawing.Point(286, 15);
            this.btnManualCaution.Name = "btnManualCaution";
            this.btnManualCaution.Size = new System.Drawing.Size(103, 25);
            this.btnManualCaution.TabIndex = 1;
            this.btnManualCaution.Text = "Manual Caution";
            this.btnManualCaution.UseVisualStyleBackColor = true;
            this.btnManualCaution.Click += new System.EventHandler(this.btnManualCaution_Click);
            // 
            // chkControlsCautions
            // 
            this.chkControlsCautions.AutoSize = true;
            this.chkControlsCautions.Location = new System.Drawing.Point(286, 146);
            this.chkControlsCautions.Name = "chkControlsCautions";
            this.chkControlsCautions.Size = new System.Drawing.Size(103, 17);
            this.chkControlsCautions.TabIndex = 5;
            this.chkControlsCautions.Text = "Control Cautions";
            this.chkControlsCautions.UseVisualStyleBackColor = true;
            this.chkControlsCautions.CheckedChanged += new System.EventHandler(this.chkControlsCautions_CheckedChanged);
            // 
            // lblUserIsAdmin
            // 
            this.lblUserIsAdmin.AutoSize = true;
            this.lblUserIsAdmin.Location = new System.Drawing.Point(15, 42);
            this.lblUserIsAdmin.Name = "lblUserIsAdmin";
            this.lblUserIsAdmin.Size = new System.Drawing.Size(45, 13);
            this.lblUserIsAdmin.TabIndex = 0;
            this.lblUserIsAdmin.Text = "Admin: -";
            // 
            // tabPgLargeCountdown
            // 
            this.tabPgLargeCountdown.BackColor = System.Drawing.Color.LawnGreen;
            this.tabPgLargeCountdown.Controls.Add(this.btnChangeBgColor);
            this.tabPgLargeCountdown.Controls.Add(this.chkStayOnTop);
            this.tabPgLargeCountdown.Controls.Add(this.lblCountdownTitle);
            this.tabPgLargeCountdown.Controls.Add(this.btnChangeLblColor);
            this.tabPgLargeCountdown.Controls.Add(this.lblLargeCounter);
            this.tabPgLargeCountdown.Location = new System.Drawing.Point(4, 22);
            this.tabPgLargeCountdown.Name = "tabPgLargeCountdown";
            this.tabPgLargeCountdown.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgLargeCountdown.Size = new System.Drawing.Size(401, 235);
            this.tabPgLargeCountdown.TabIndex = 1;
            this.tabPgLargeCountdown.Text = "Large Countdown Timer";
            // 
            // btnChangeBgColor
            // 
            this.btnChangeBgColor.Location = new System.Drawing.Point(168, 6);
            this.btnChangeBgColor.Name = "btnChangeBgColor";
            this.btnChangeBgColor.Size = new System.Drawing.Size(121, 23);
            this.btnChangeBgColor.TabIndex = 5;
            this.btnChangeBgColor.Text = "Edit Background Color";
            this.btnChangeBgColor.UseVisualStyleBackColor = true;
            this.btnChangeBgColor.Click += new System.EventHandler(this.btnChangeBgColor_Click);
            // 
            // chkStayOnTop
            // 
            this.chkStayOnTop.AutoSize = true;
            this.chkStayOnTop.Location = new System.Drawing.Point(8, 12);
            this.chkStayOnTop.Name = "chkStayOnTop";
            this.chkStayOnTop.Size = new System.Drawing.Size(86, 17);
            this.chkStayOnTop.TabIndex = 4;
            this.chkStayOnTop.Text = "Stay On Top";
            this.chkStayOnTop.UseVisualStyleBackColor = true;
            this.chkStayOnTop.CheckedChanged += new System.EventHandler(this.chkStayOnTop_CheckedChanged);
            // 
            // lblCountdownTitle
            // 
            this.lblCountdownTitle.AutoSize = true;
            this.lblCountdownTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCountdownTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdownTitle.Location = new System.Drawing.Point(21, 50);
            this.lblCountdownTitle.Name = "lblCountdownTitle";
            this.lblCountdownTitle.Size = new System.Drawing.Size(350, 55);
            this.lblCountdownTitle.TabIndex = 3;
            this.lblCountdownTitle.Text = "Caution Clock:";
            // 
            // btnChangeLblColor
            // 
            this.btnChangeLblColor.Location = new System.Drawing.Point(295, 6);
            this.btnChangeLblColor.Name = "btnChangeLblColor";
            this.btnChangeLblColor.Size = new System.Drawing.Size(100, 23);
            this.btnChangeLblColor.TabIndex = 1;
            this.btnChangeLblColor.Text = "Edit Number Color";
            this.btnChangeLblColor.UseVisualStyleBackColor = true;
            this.btnChangeLblColor.Click += new System.EventHandler(this.btnChangeLblColor_Click);
            // 
            // lblLargeCounter
            // 
            this.lblLargeCounter.AutoSize = true;
            this.lblLargeCounter.BackColor = System.Drawing.Color.Transparent;
            this.lblLargeCounter.Font = new System.Drawing.Font("Arial", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLargeCounter.Location = new System.Drawing.Point(-4, 78);
            this.lblLargeCounter.Name = "lblLargeCounter";
            this.lblLargeCounter.Size = new System.Drawing.Size(409, 155);
            this.lblLargeCounter.TabIndex = 0;
            this.lblLargeCounter.Text = "00:00";
            // 
            // tabPgOptions
            // 
            this.tabPgOptions.Controls.Add(this.lblDivider2);
            this.tabPgOptions.Controls.Add(this.lblDivider1);
            this.tabPgOptions.Controls.Add(this.chkEnableMinWarnings);
            this.tabPgOptions.Controls.Add(this.num1MinHotkey);
            this.tabPgOptions.Controls.Add(this.lbl1MinHotkey);
            this.tabPgOptions.Controls.Add(this.num5MinHotkey);
            this.tabPgOptions.Controls.Add(this.lbl5MinHotkey);
            this.tabPgOptions.Controls.Add(this.num10MinHotkey);
            this.tabPgOptions.Controls.Add(this.lbl10MinHotkey);
            this.tabPgOptions.Controls.Add(this.lblVersion);
            this.tabPgOptions.Controls.Add(this.lblPlayAudioInfo);
            this.tabPgOptions.Controls.Add(this.chkPlayAudioOnCaution);
            this.tabPgOptions.Controls.Add(this.btnTestAudio);
            this.tabPgOptions.Controls.Add(this.lblCautionClockCutoffUpdate);
            this.tabPgOptions.Controls.Add(this.numUDLapCutoff);
            this.tabPgOptions.Controls.Add(this.lblCurrentTimerLength);
            this.tabPgOptions.Controls.Add(this.numericUpDown1);
            this.tabPgOptions.Controls.Add(this.label1);
            this.tabPgOptions.Controls.Add(this.lblCautionClockLength);
            this.tabPgOptions.Controls.Add(this.lblCautionShortcutKey);
            this.tabPgOptions.Controls.Add(this.numUDTimeBetween);
            this.tabPgOptions.Location = new System.Drawing.Point(4, 22);
            this.tabPgOptions.Name = "tabPgOptions";
            this.tabPgOptions.Size = new System.Drawing.Size(401, 235);
            this.tabPgOptions.TabIndex = 2;
            this.tabPgOptions.Text = "Options";
            this.tabPgOptions.UseVisualStyleBackColor = true;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(328, 217);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(63, 13);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "Version: 1.2";
            // 
            // lblPlayAudioInfo
            // 
            this.lblPlayAudioInfo.AutoSize = true;
            this.lblPlayAudioInfo.Location = new System.Drawing.Point(253, 186);
            this.lblPlayAudioInfo.Name = "lblPlayAudioInfo";
            this.lblPlayAudioInfo.Size = new System.Drawing.Size(137, 26);
            this.lblPlayAudioInfo.TabIndex = 12;
            this.lblPlayAudioInfo.Text = "To change volume, use the\r\n volume mixer in Windows";
            // 
            // chkPlayAudioOnCaution
            // 
            this.chkPlayAudioOnCaution.AutoSize = true;
            this.chkPlayAudioOnCaution.Location = new System.Drawing.Point(22, 192);
            this.chkPlayAudioOnCaution.Name = "chkPlayAudioOnCaution";
            this.chkPlayAudioOnCaution.Size = new System.Drawing.Size(149, 17);
            this.chkPlayAudioOnCaution.TabIndex = 11;
            this.chkPlayAudioOnCaution.Text = "Play Audio File on Caution";
            this.chkPlayAudioOnCaution.UseVisualStyleBackColor = true;
            this.chkPlayAudioOnCaution.CheckedChanged += new System.EventHandler(this.chkPlayAudioOnCaution_CheckedChanged);
            // 
            // btnTestAudio
            // 
            this.btnTestAudio.Location = new System.Drawing.Point(177, 188);
            this.btnTestAudio.Name = "btnTestAudio";
            this.btnTestAudio.Size = new System.Drawing.Size(75, 23);
            this.btnTestAudio.TabIndex = 10;
            this.btnTestAudio.Text = "Test Audio";
            this.btnTestAudio.UseVisualStyleBackColor = true;
            this.btnTestAudio.Click += new System.EventHandler(this.btnTestAudio_Click);
            // 
            // lblCautionClockCutoffUpdate
            // 
            this.lblCautionClockCutoffUpdate.AutoSize = true;
            this.lblCautionClockCutoffUpdate.Location = new System.Drawing.Point(271, 54);
            this.lblCautionClockCutoffUpdate.Name = "lblCautionClockCutoffUpdate";
            this.lblCautionClockCutoffUpdate.Size = new System.Drawing.Size(16, 13);
            this.lblCautionClockCutoffUpdate.TabIndex = 8;
            this.lblCautionClockCutoffUpdate.Text = "...";
            this.lblCautionClockCutoffUpdate.Visible = false;
            // 
            // numUDLapCutoff
            // 
            this.numUDLapCutoff.Location = new System.Drawing.Point(214, 47);
            this.numUDLapCutoff.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUDLapCutoff.Name = "numUDLapCutoff";
            this.numUDLapCutoff.Size = new System.Drawing.Size(51, 20);
            this.numUDLapCutoff.TabIndex = 7;
            this.numUDLapCutoff.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUDLapCutoff.ValueChanged += new System.EventHandler(this.numUDLapCutoff_ValueChanged);
            // 
            // lblCurrentTimerLength
            // 
            this.lblCurrentTimerLength.AutoSize = true;
            this.lblCurrentTimerLength.Location = new System.Drawing.Point(107, 31);
            this.lblCurrentTimerLength.Name = "lblCurrentTimerLength";
            this.lblCurrentTimerLength.Size = new System.Drawing.Size(181, 13);
            this.lblCurrentTimerLength.TabIndex = 2;
            this.lblCurrentTimerLength.Text = "change the counter above to update";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(152, 68);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(34, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Caution Clock Lap Cut off (Defualt is 20)";
            // 
            // lblCautionClockLength
            // 
            this.lblCautionClockLength.AutoSize = true;
            this.lblCautionClockLength.Location = new System.Drawing.Point(8, 10);
            this.lblCautionClockLength.Name = "lblCautionClockLength";
            this.lblCautionClockLength.Size = new System.Drawing.Size(237, 13);
            this.lblCautionClockLength.TabIndex = 1;
            this.lblCautionClockLength.Text = "Time Between Cautions in minutes (Default is 20)";
            // 
            // lblCautionShortcutKey
            // 
            this.lblCautionShortcutKey.AutoSize = true;
            this.lblCautionShortcutKey.Location = new System.Drawing.Point(12, 73);
            this.lblCautionShortcutKey.Name = "lblCautionShortcutKey";
            this.lblCautionShortcutKey.Size = new System.Drawing.Size(83, 13);
            this.lblCautionShortcutKey.TabIndex = 3;
            this.lblCautionShortcutKey.Text = "Caution Hotkey:";
            // 
            // numUDTimeBetween
            // 
            this.numUDTimeBetween.Location = new System.Drawing.Point(249, 8);
            this.numUDTimeBetween.Name = "numUDTimeBetween";
            this.numUDTimeBetween.Size = new System.Drawing.Size(47, 20);
            this.numUDTimeBetween.TabIndex = 0;
            this.numUDTimeBetween.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUDTimeBetween.ValueChanged += new System.EventHandler(this.numUDTimeBetween_ValueChanged);
            // 
            // num10MinHotkey
            // 
            this.num10MinHotkey.Enabled = false;
            this.num10MinHotkey.Location = new System.Drawing.Point(152, 101);
            this.num10MinHotkey.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.num10MinHotkey.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num10MinHotkey.Name = "num10MinHotkey";
            this.num10MinHotkey.Size = new System.Drawing.Size(34, 20);
            this.num10MinHotkey.TabIndex = 14;
            this.num10MinHotkey.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num10MinHotkey.ValueChanged += new System.EventHandler(this.num10MinHotkey_ValueChanged);
            // 
            // lbl10MinHotkey
            // 
            this.lbl10MinHotkey.AutoSize = true;
            this.lbl10MinHotkey.Enabled = false;
            this.lbl10MinHotkey.Location = new System.Drawing.Point(8, 103);
            this.lbl10MinHotkey.Name = "lbl10MinHotkey";
            this.lbl10MinHotkey.Size = new System.Drawing.Size(137, 13);
            this.lbl10MinHotkey.TabIndex = 15;
            this.lbl10MinHotkey.Text = "10 Minute Warning Hotkey:";
            // 
            // num5MinHotkey
            // 
            this.num5MinHotkey.Enabled = false;
            this.num5MinHotkey.Location = new System.Drawing.Point(152, 127);
            this.num5MinHotkey.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.num5MinHotkey.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num5MinHotkey.Name = "num5MinHotkey";
            this.num5MinHotkey.Size = new System.Drawing.Size(34, 20);
            this.num5MinHotkey.TabIndex = 16;
            this.num5MinHotkey.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num5MinHotkey.ValueChanged += new System.EventHandler(this.num5MinHotkey_ValueChanged);
            // 
            // lbl5MinHotkey
            // 
            this.lbl5MinHotkey.AutoSize = true;
            this.lbl5MinHotkey.Enabled = false;
            this.lbl5MinHotkey.Location = new System.Drawing.Point(14, 131);
            this.lbl5MinHotkey.Name = "lbl5MinHotkey";
            this.lbl5MinHotkey.Size = new System.Drawing.Size(131, 13);
            this.lbl5MinHotkey.TabIndex = 17;
            this.lbl5MinHotkey.Text = "5 Minute Warning Hotkey:";
            // 
            // chkEnableMinWarnings
            // 
            this.chkEnableMinWarnings.AutoSize = true;
            this.chkEnableMinWarnings.Location = new System.Drawing.Point(202, 122);
            this.chkEnableMinWarnings.Name = "chkEnableMinWarnings";
            this.chkEnableMinWarnings.Size = new System.Drawing.Size(158, 30);
            this.chkEnableMinWarnings.TabIndex = 18;
            this.chkEnableMinWarnings.Text = "Enable Warning Hotkeys\r\nAffects 10, 5, and 1 minutes";
            this.chkEnableMinWarnings.UseVisualStyleBackColor = true;
            this.chkEnableMinWarnings.CheckedChanged += new System.EventHandler(this.chkEnableMinWarnings_CheckedChanged);
            // 
            // lbl1MinHotkey
            // 
            this.lbl1MinHotkey.AutoSize = true;
            this.lbl1MinHotkey.Enabled = false;
            this.lbl1MinHotkey.Location = new System.Drawing.Point(14, 155);
            this.lbl1MinHotkey.Name = "lbl1MinHotkey";
            this.lbl1MinHotkey.Size = new System.Drawing.Size(131, 13);
            this.lbl1MinHotkey.TabIndex = 17;
            this.lbl1MinHotkey.Text = "1 Minute Warning Hotkey:";
            // 
            // num1MinHotkey
            // 
            this.num1MinHotkey.Enabled = false;
            this.num1MinHotkey.Location = new System.Drawing.Point(152, 153);
            this.num1MinHotkey.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.num1MinHotkey.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num1MinHotkey.Name = "num1MinHotkey";
            this.num1MinHotkey.Size = new System.Drawing.Size(34, 20);
            this.num1MinHotkey.TabIndex = 16;
            this.num1MinHotkey.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.num1MinHotkey.ValueChanged += new System.EventHandler(this.num1MinHotkey_ValueChanged);
            // 
            // lblDivider1
            // 
            this.lblDivider1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider1.Location = new System.Drawing.Point(32, 93);
            this.lblDivider1.Name = "lblDivider1";
            this.lblDivider1.Size = new System.Drawing.Size(326, 2);
            this.lblDivider1.TabIndex = 19;
            this.lblDivider1.Text = "label2";
            // 
            // lblDivider2
            // 
            this.lblDivider2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider2.Location = new System.Drawing.Point(32, 179);
            this.lblDivider2.Name = "lblDivider2";
            this.lblDivider2.Size = new System.Drawing.Size(326, 2);
            this.lblDivider2.TabIndex = 19;
            this.lblDivider2.Text = "label2";
            // 
            // btnTestHotkeys
            // 
            this.btnTestHotkeys.Location = new System.Drawing.Point(286, 46);
            this.btnTestHotkeys.Name = "btnTestHotkeys";
            this.btnTestHotkeys.Size = new System.Drawing.Size(103, 25);
            this.btnTestHotkeys.TabIndex = 6;
            this.btnTestHotkeys.Text = "Test Hotkeys";
            this.btnTestHotkeys.UseVisualStyleBackColor = true;
            this.btnTestHotkeys.Click += new System.EventHandler(this.btnTestHotkeys_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 261);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(425, 300);
            this.MinimumSize = new System.Drawing.Size(425, 300);
            this.Name = "mainForm";
            this.Text = "iRacing Caution Clock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPgQuickInfo.ResumeLayout(false);
            this.tabPgQuickInfo.PerformLayout();
            this.tabPgLargeCountdown.ResumeLayout(false);
            this.tabPgLargeCountdown.PerformLayout();
            this.tabPgOptions.ResumeLayout(false);
            this.tabPgOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDLapCutoff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDTimeBetween)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num10MinHotkey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num5MinHotkey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num1MinHotkey)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblConnectedToiRacing;
        private System.Windows.Forms.Label lblCurrentFlag;
        private System.Windows.Forms.Label lblCurrentLap;
        private System.Windows.Forms.Label lblCautionClockStatus;
        private System.Windows.Forms.Label lblCautionClockExpires;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPgQuickInfo;
        private System.Windows.Forms.TabPage tabPgLargeCountdown;
        private System.Windows.Forms.Label lblLargeCounter;
        private System.Windows.Forms.Button btnChangeLblColor;
        private System.Windows.Forms.Button btnManualCaution;
        private System.Windows.Forms.Label lblUserIsAdmin;
        private System.Windows.Forms.TabPage tabPgOptions;
        private System.Windows.Forms.Label lblCautionClockLength;
        private System.Windows.Forms.NumericUpDown numUDTimeBetween;
        private System.Windows.Forms.Label lblCurrentTimerLength;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblCautionShortcutKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUDLapCutoff;
        private System.Windows.Forms.Label lblCautionClockCutoffUpdate;
        private System.Windows.Forms.CheckBox chkControlsCautions;
        private System.Windows.Forms.Button btnTestAudio;
        private System.Windows.Forms.CheckBox chkPlayAudioOnCaution;
        private System.Windows.Forms.Label lblPlayAudioInfo;
        private System.Windows.Forms.Label lblCountdownTitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.CheckBox chkStayOnTop;
        private System.Windows.Forms.Button btnChangeBgColor;
        private System.Windows.Forms.Label lblDivider2;
        private System.Windows.Forms.Label lblDivider1;
        private System.Windows.Forms.CheckBox chkEnableMinWarnings;
        private System.Windows.Forms.NumericUpDown num1MinHotkey;
        private System.Windows.Forms.Label lbl1MinHotkey;
        private System.Windows.Forms.NumericUpDown num5MinHotkey;
        private System.Windows.Forms.Label lbl5MinHotkey;
        private System.Windows.Forms.NumericUpDown num10MinHotkey;
        private System.Windows.Forms.Label lbl10MinHotkey;
        private System.Windows.Forms.Button btnTestHotkeys;
    }
}

