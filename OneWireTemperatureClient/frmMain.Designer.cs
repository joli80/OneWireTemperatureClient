namespace OneWireTemperatureClient
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblTemp = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.systrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.systrayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerPollTemperature = new System.Windows.Forms.Timer(this.components);
            this.timerPutToServer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.systrayMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemp.Location = new System.Drawing.Point(18, 27);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(19, 26);
            this.lblTemp.TabIndex = 1;
            this.lblTemp.Text = " ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTemp);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 75);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current temperature";
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(12, 103);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(430, 147);
            this.lbLog.TabIndex = 5;
            // 
            // systrayIcon
            // 
            this.systrayIcon.ContextMenuStrip = this.systrayMenuStrip;
            this.systrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("systrayIcon.Icon")));
            this.systrayIcon.Text = "notifyIcon";
            this.systrayIcon.Visible = true;
            this.systrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.systrayIcon_MouseClick);
            // 
            // systrayMenuStrip
            // 
            this.systrayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
            this.systrayMenuStrip.Name = "systrayMenuStrip";
            this.systrayMenuStrip.Size = new System.Drawing.Size(93, 26);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 264);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "1-Wire Temperature Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.systrayMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.NotifyIcon systrayIcon;
        private System.Windows.Forms.ContextMenuStrip systrayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.Timer timerPollTemperature;
        private System.Windows.Forms.Timer timerPutToServer;
    }
}

