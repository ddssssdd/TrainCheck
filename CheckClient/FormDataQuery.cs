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
    public partial class FormDataQuery : Form
    {
        public FormDataQuery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtSql.Text, "select ", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                dgMain.DataSource = DataAccess.ExecuteDataTable(txtSql.Text);
            else
                DataAccess.ExecuteNonQuery(txtSql.Text);
        }

       
    }
}