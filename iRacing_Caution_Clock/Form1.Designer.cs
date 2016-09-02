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
            this.lblUserIsAdmin = new System.Windows.Forms.Label();
            this.tabPgLargeCountdown = new System.Windows.Forms.TabPage();
            this.chkStreamerFriendlyCounter = new System.Windows.Forms.CheckBox();
            this.btnChangeLblColor = new System.Windows.Forms.Button();
            this.lblLargeCounter = new System.Windows.Forms.Label();
            this.tabPgOptions = new System.Windows.Forms.TabPage();
            this.lblCautionShortcutUpdated = new System.Windows.Forms.Label();
            this.lblCautionClockCutoffUpdate = new System.Windows.Forms.Label();
            this.numUDLapCutoff = new System.Windows.Forms.NumericUpDown();
            this.lblCurrentTimerLength = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCautionClockLength = new System.Windows.Forms.Label();
            this.lblCautionShortcutKey = new System.Windows.Forms.Label();
            this.numUDTimeBetween = new System.Windows.Forms.NumericUpDown();
            this.chkControlsCautions = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPgQuickInfo.SuspendLayout();
            this.tabPgLargeCountdown.SuspendLayout();
            this.tabPgOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDLapCutoff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDTimeBetween)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(409, 214);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPgQuickInfo
            // 
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
            this.tabPgQuickInfo.Size = new System.Drawing.Size(401, 188);
            this.tabPgQuickInfo.TabIndex = 0;
            this.tabPgQuickInfo.Text = "Quick Info";
            this.tabPgQuickInfo.UseVisualStyleBackColor = true;
            // 
            // btnManualCaution
            // 
            this.btnManualCaution.Location = new System.Drawing.Point(286, 15);
            this.btnManualCaution.Name = "btnManualCaution";
            this.btnManualCaution.Size = new System.Drawing.Size(103, 40);
            this.btnManualCaution.TabIndex = 1;
            this.btnManualCaution.Text = "Manual Caution / Test button";
            this.btnManualCaution.UseVisualStyleBackColor = true;
            this.btnManualCaution.Click += new System.EventHandler(this.btnManualCaution_Click);
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
            this.tabPgLargeCountdown.Controls.Add(this.chkStreamerFriendlyCounter);
            this.tabPgLargeCountdown.Controls.Add(this.btnChangeLblColor);
            this.tabPgLargeCountdown.Controls.Add(this.lblLargeCounter);
            this.tabPgLargeCountdown.Location = new System.Drawing.Point(4, 22);
            this.tabPgLargeCountdown.Name = "tabPgLargeCountdown";
            this.tabPgLargeCountdown.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgLargeCountdown.Size = new System.Drawing.Size(401, 188);
            this.tabPgLargeCountdown.TabIndex = 1;
            this.tabPgLargeCountdown.Text = "Large Countdown Timer";
            // 
            // chkStreamerFriendlyCounter
            // 
            this.chkStreamerFriendlyCounter.AutoSize = true;
            this.chkStreamerFriendlyCounter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkStreamerFriendlyCounter.Checked = true;
            this.chkStreamerFriendlyCounter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStreamerFriendlyCounter.Location = new System.Drawing.Point(161, 10);
            this.chkStreamerFriendlyCounter.Name = "chkStreamerFriendlyCounter";
            this.chkStreamerFriendlyCounter.Size = new System.Drawing.Size(107, 17);
            this.chkStreamerFriendlyCounter.TabIndex = 2;
            this.chkStreamerFriendlyCounter.Text = "Streamer Friendly";
            this.chkStreamerFriendlyCounter.UseVisualStyleBackColor = true;
            this.chkStreamerFriendlyCounter.CheckedChanged += new System.EventHandler(this.chkStreamerFriendlyCounter_CheckedChanged);
            // 
            // btnChangeLblColor
            // 
            this.btnChangeLblColor.Location = new System.Drawing.Point(274, 6);
            this.btnChangeLblColor.Name = "btnChangeLblColor";
            this.btnChangeLblColor.Size = new System.Drawing.Size(121, 23);
            this.btnChangeLblColor.TabIndex = 1;
            this.btnChangeLblColor.Text = "Change Number Color";
            this.btnChangeLblColor.UseVisualStyleBackColor = true;
            this.btnChangeLblColor.Click += new System.EventHandler(this.btnChangeLblColor_Click);
            // 
            // lblLargeCounter
            // 
            this.lblLargeCounter.AutoSize = true;
            this.lblLargeCounter.BackColor = System.Drawing.Color.Transparent;
            this.lblLargeCounter.Font = new System.Drawing.Font("Arial", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLargeCounter.Location = new System.Drawing.Point(3, 30);
            this.lblLargeCounter.Name = "lblLargeCounter";
            this.lblLargeCounter.Size = new System.Drawing.Size(409, 155);
            this.lblLargeCounter.TabIndex = 0;
            this.lblLargeCounter.Text = "00:00";
            // 
            // tabPgOptions
            // 
            this.tabPgOptions.Controls.Add(this.lblCautionShortcutUpdated);
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
            this.tabPgOptions.Size = new System.Drawing.Size(401, 188);
            this.tabPgOptions.TabIndex = 2;
            this.tabPgOptions.Text = "Options";
            this.tabPgOptions.UseVisualStyleBackColor = true;
            // 
            // lblCautionShortcutUpdated
            // 
            this.lblCautionShortcutUpdated.AutoSize = true;
            this.lblCautionShortcutUpdated.Location = new System.Drawing.Point(147, 76);
            this.lblCautionShortcutUpdated.Name = "lblCautionShortcutUpdated";
            this.lblCautionShortcutUpdated.Size = new System.Drawing.Size(16, 13);
            this.lblCautionShortcutUpdated.TabIndex = 9;
            this.lblCautionShortcutUpdated.Text = "...";
            this.lblCautionShortcutUpdated.Visible = false;
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
            this.numericUpDown1.Location = new System.Drawing.Point(107, 71);
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
            this.lblCautionShortcutKey.Size = new System.Drawing.Size(89, 13);
            this.lblCautionShortcutKey.TabIndex = 3;
            this.lblCautionShortcutKey.Text = "Caution Shortcut:";
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
            // chkControlsCautions
            // 
            this.chkControlsCautions.AutoSize = true;
            this.chkControlsCautions.Location = new System.Drawing.Point(286, 150);
            this.chkControlsCautions.Name = "chkControlsCautions";
            this.chkControlsCautions.Size = new System.Drawing.Size(103, 17);
            this.chkControlsCautions.TabIndex = 5;
            this.chkControlsCautions.Text = "Control Cautions";
            this.chkControlsCautions.UseVisualStyleBackColor = true;
            this.chkControlsCautions.CheckedChanged += new System.EventHandler(this.chkControlsCautions_CheckedChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 214);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(425, 253);
            this.MinimumSize = new System.Drawing.Size(425, 253);
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
        private System.Windows.Forms.CheckBox chkStreamerFriendlyCounter;
        private System.Windows.Forms.TabPage tabPgOptions;
        private System.Windows.Forms.Label lblCautionClockLength;
        private System.Windows.Forms.NumericUpDown numUDTimeBetween;
        private System.Windows.Forms.Label lblCurrentTimerLength;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblCautionShortcutKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUDLapCutoff;
        private System.Windows.Forms.Label lblCautionClockCutoffUpdate;
        private System.Windows.Forms.Label lblCautionShortcutUpdated;
        private System.Windows.Forms.CheckBox chkControlsCautions;
    }
}

