using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrainCheck
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            InitView();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {

        }
        private void InitView()
        {
            txtUserNoDim.Value = AppHelper.UserNoDim;
            txtBarCodeDim.Value = AppHelper.BarCodeDim;
            txtServerUrl.Text = AppHelper.ServiceUrl;
            txtLocalUserNo.Text = AppHelper.LocalUserNo;
            txtLocalTrainNo.Text = AppHelper.LocalTrainNo;
        }
        private void SaveSettings()
        {
            AppHelper.UserNoDim = (int)txtUserNoDim.Value;
            AppHelper.BarCodeDim = (int)txtBarCodeDim.Value;
            AppHelper.ServiceUrl = txtServerUrl.Text;
            AppHelper.LocalUserNo = txtLocalUserNo.Text;
            AppHelper.LocalTrainNo = txtLocalTrainNo.Text;
            if (chkUpdateDB.Checked)
            {
                Settings.SetSettings("UserNoDim", AppHelper.UserNoDim.ToString());
                Settings.SetSettings("BarCodeDim", AppHelper.BarCodeDim.ToString());
                Settings.SetSettings("WebServiceUrl", AppHelper.ServiceUrl);
                Settings.SetSettings("LocalUserNo", AppHelper.LocalUserNo);
                Settings.SetSettings("LocalTrainNo", AppHelper.LocalTrainNo);
            }

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}