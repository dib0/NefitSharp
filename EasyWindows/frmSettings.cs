﻿using System;
using System.Windows.Forms;
using DigitalThermostat.Properties;

namespace DigitalThermostat
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {            
            InitializeComponent();
            tbxSerial.Text = Settings.Default.serial;
            tbxAccessCode.Text = Settings.Default.accessKey;
            tbxPassword.Text = Settings.Default.password;
            nudRefreshInterval.Value = Convert.ToDecimal(Settings.Default.refreshInterval/1000.0);
            cbxScale.SelectedIndex = (int) (4 - Settings.Default.scale/0.25F);
            cbxDebugMode.Checked = Settings.Default.debugMode;
            cbxDebugMode.CheckedChanged += cbxDebug_CheckedChanged;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxSerial.Text.Length == 9 && tbxAccessCode.Text.Length == 16 && tbxPassword.Text.Length >= 4)
            {
                Settings.Default.serial = tbxSerial.Text;
                Settings.Default.accessKey = tbxAccessCode.Text;
                Settings.Default.password = tbxPassword.Text;
                Settings.Default.refreshInterval = Convert.ToInt32(nudRefreshInterval.Value*1000);
                Settings.Default.scale = (4 - cbxScale.SelectedIndex)*0.25F;
                Settings.Default.firstStart = false;
                Settings.Default.debugMode = cbxDebugMode.Checked;
                Settings.Default.Save();
                DialogResult = DialogResult.OK;                
            }
            else
            {
                MessageBox.Show(@"Please check the credentials you provided.", @"Invalid credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void cbxDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDebugMode.Enabled)
            {
               if(MessageBox.Show("Are you sure you want to enable debug mode?\r\nThis will only log the communication between Bosch server and this application" +
                                "\r\nUse only if you are instructed or want to debug the protocol for yourself","Are you sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
               {
                   cbxDebugMode.Enabled = false;
               }
            }
        }
    }
}
