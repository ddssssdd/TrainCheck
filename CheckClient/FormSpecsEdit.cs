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
    public partial class FormSpecsEdit : Form
    {
       


        public FormSpecsEdit()
        {
            InitializeComponent();
        }
        private Specs CurrentSpecs { get; set; }
        private void FormSpecsEdit_Load(object sender, EventArgs e)
        {
            CurrentSpecs = DbFactory.FindBySequence(1,true);
            InitCombobox();
            InitView();
        }
        private void InitCombobox()
        {
            //AppHelper.FillCombobox(cboSection, "select distinct section from dictSpecs");
        }
        private void InitView()
        {
            if (CurrentSpecs != null)
            {
                cboSection.Text = CurrentSpecs.Seciton;
                cboPosition.Text = CurrentSpecs.CheckPosition;
                txtBarcode.Text = CurrentSpecs.BarCode;
                txtSequ.Value = CurrentSpecs.Sequence;
                List<String> childs = new List<string>();
                foreach (SpecsDetail detail in CurrentSpecs.Items)
                {
                    childs.Add(String.Format("{0}({1})--{2}--{3}", detail.CheckDetail, detail.CheckMethod, detail.SpecifiedSizeHeight, detail.KnockPosition));
                }
                txtDetail.Text = String.Join("\r\n", childs.ToArray());
                txtBarcode.SelectAll();
                txtBarcode.Focus();
            }

        }

        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
           // String oldvalue = cboPosition.Text;

           // AppHelper.FillCombobox(cboPosition, String.Format("select distinct CheckPosition from dictSpecs where section='{0}'", cboSection.Text));
           // cboPosition.Text = oldvalue;

        }

        private void txtSequ_ValueChanged(object sender, EventArgs e)
        {            
            CurrentSpecs = DbFactory.FindBySequence(Int32.Parse(txtSequ.Value.ToString()),true);
            InitView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CurrentSpecs.BarCode.Equals(txtBarcode.Text))
            {
                if (MessageBox.Show("已经更改条码，请确认更新？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    DbFactory.UpdateSpecsBarCode(CurrentSpecs, txtBarcode.Text);
                    txtSequ.Value += 1;
                }
            }
        }
     
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Trim().Length == AppHelper.BarCodeDim)
            {
                button1_Click(null, null);
            }
        }
    }
}