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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        public String UserNo
        {
            get
            {
                return txtUserNo.Text;
            }
        }

        private void txtUserNo_TextChanged(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}