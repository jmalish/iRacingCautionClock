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
            this.lblConnectedToiRacing = new System.Windows.Forms.Label();
            this.lblCurrentFlag = new System.Windows.Forms.Label();
            this.lblCurrentLap = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblConnectedToiRacing
            // 
            this.lblConnectedToiRacing.AutoSize = true;
            this.lblConnectedToiRacing.Location = new System.Drawing.Point(12, 9);
            this.lblConnectedToiRacing.Name = "lblConnectedToiRacing";
            this.lblConnectedToiRacing.Size = new System.Drawing.Size(121, 13);
            this.lblConnectedToiRacing.TabIndex = 0;
            this.lblConnectedToiRacing.Text = "Connecting to iRacing...";
            // 
            // lblCurrentFlag
            // 
            this.lblCurrentFlag.AutoSize = true;
            this.lblCurrentFlag.Location = new System.Drawing.Point(12, 66);
            this.lblCurrentFlag.Name = "lblCurrentFlag";
            this.lblCurrentFlag.Size = new System.Drawing.Size(73, 13);
            this.lblCurrentFlag.TabIndex = 0;
            this.lblCurrentFlag.Text = "Current Flag: -";
            // 
            // lblCurrentLap
            // 
            this.lblCurrentLap.AutoSize = true;
            this.lblCurrentLap.Location = new System.Drawing.Point(12, 106);
            this.lblCurrentLap.Name = "lblCurrentLap";
            this.lblCurrentLap.Size = new System.Drawing.Size(49, 13);
            this.lblCurrentLap.TabIndex = 0;
            this.lblCurrentLap.Text = "Lap - of -";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 283);
            this.Controls.Add(this.lblCurrentLap);
            this.Controls.Add(this.lblCurrentFlag);
            this.Controls.Add(this.lblConnectedToiRacing);
            this.Name = "mainForm";
            this.Text = "iRacing Caution Clock";
            this.Leave += new System.EventHandler(this.mainForm_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnectedToiRacing;
        private System.Windows.Forms.Label lblCurrentFlag;
        private System.Windows.Forms.Label lblCurrentLap;
    }
}

