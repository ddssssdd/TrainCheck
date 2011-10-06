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
    public partial class FormCheck : BaseFormScan
    {
        public FormCheck()
        {
            InitializeComponent();
            btnNext.Visible = !AppHelper.IsLockOnCheck;
            btnPrev.Visible = !AppHelper.IsLockOnCheck;
        }
        public FormCheck(JobMain job):this()
        {
            CurrentJob = job;
            if (job.Items.Count > 0)
            {
                Int32 specsid = job.Items.Max(jobdetail => jobdetail.SpecsID);
                Specs spec = DbFactory.FindByFilter("ID=" + specsid.ToString(),job.IsFull);
                if (spec != null)
                {
                    CurrentSpecs = spec;
                    InitView();
                }
            }
            this.EnableScaner();
        }
        protected override void OnGetBarcode(string barCode)
        {
            this.txtBarCode.Text = barCode;
            if (txtBarCode.Text.Trim().Length == AppHelper.BarCodeDim)
            {
                if ((!isInInitView) && (CurrentSpecs != null) && (!string.IsNullOrEmpty(CurrentSpecs.BarCode)) && (CurrentSpecs.BarCode.Equals(txtBarCode.Text)))
                {
                    btnSave_Click(null, null);
                }
                else
                    button1_Click(null, null);
            }
        }
        private JobMain CurrentJob { get; set; }
        private Specs CurrentSpecs { get; set; }
        private bool isInInitView = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBarCode.Text))
            {               
                Specs spec = DbFactory.Find(txtBarCode.Text,CurrentJob.IsFull);
                if (spec != null)
                {
                    //first process last spec;
                    if ((CurrentJob.IsFull==false) && (spec.IsFull))
                    {
                        if (MessageBox.Show("此项检查是全面检查项目，是否继续检查?", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                            return;
                    }
                    CurrentSpecs = spec;
                    InitView();
                }
                else
                {
                    MessageBox.Show("输入的编码不存在，请重新输入");
                }
            }
        }
        private void InitView()
        {
            isInInitView = true;
            try
            {
                if (CurrentJob != null)
                {
                    CurrentJob.SetCheckToSpecs(CurrentSpecs);
                }
                lblSection.Text = String.Format("{0}→{1}({2})", CurrentSpecs.Seciton, CurrentSpecs.CheckPosition, CurrentSpecs.CheckMethod);
                Text = String.Format("{2}.{0}→{1}", CurrentSpecs.Seciton, CurrentSpecs.CheckPosition, CurrentSpecs.Sequence);
                txtBarCode.Text = CurrentSpecs.BarCode;
                lvMain.Items.Clear();
                foreach (SpecsDetail detail in CurrentSpecs.Items)
                {
                 
                    ListViewItem item = new ListViewItem(detail.CheckDetail);
                    //item.SubItems.Add(detail.CheckMethod);
                    item.SubItems.Add(detail.SpecifiedSizeHeight);
                    item.SubItems.Add(detail.KnockPosition);
                    if (detail.isDone)
                    {
                        item.ForeColor = System.Drawing.Color.Blue;
                        item.Checked = detail.isChecked;
                    }
                    else
                    {
                        item.Checked = true;
                        if ((CurrentJob.IsFull) && (detail.IsFull))
                            item.ForeColor = System.Drawing.Color.Brown;
                    }
                    item.Tag = detail.ID;
          
                    lvMain.Items.Add(item);
                }
                txtBarCode.SelectAll();
                txtBarCode.Focus();
            }
            finally
            {
                isInInitView = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CurrentSpecs.IsCheckAll = true;
            foreach (ListViewItem item in lvMain.Items)
            {
                SpecsDetail detail = CurrentSpecs.FindByID(Int32.Parse(item.Tag.ToString()));
                detail.isChecked = item.Checked;
                if (!detail.isChecked )
                    CurrentSpecs.IsCheckAll = false;

            }
            JobDetail jobdetail = CurrentJob.FindBySpecsID(CurrentSpecs.ID);
            if (jobdetail == null)
            {
                jobdetail = new JobDetail();
            }
            jobdetail.JobID = CurrentJob.ID;
            jobdetail.SpecsID = CurrentSpecs.ID;
            jobdetail.CheckTime = DateTime.Now;
            jobdetail.isChecked = CurrentSpecs.IsCheckAll;
            jobdetail.CheckDetailList = CurrentSpecs.CheckDetailList;
            jobdetail.BarCode = CurrentSpecs.BarCode;
            CurrentJob.Items.Add(jobdetail);
            if (jobdetail.ID == 0)
            {
                jobdetail.ID = DbFactory.JobDetailInsert(jobdetail);
                CurrentJob.CheckPosition += 1;
            }
            else
                DbFactory.JobDetailUpdate(jobdetail);

            //DbFactory.SaveJob(CurrentJob);
            if (AppHelper.IsLockOnCheck == false)
            {
                Specs spec = DbFactory.FindBySequence(CurrentSpecs.Sequence + 1,CurrentJob.IsFull);
                if (spec != null)
                {
                    CurrentSpecs = spec;
                    InitView();
                }
                else
                {
                    //work done.
                    MessageBox.Show("已经检查到最大序号！");
                }
            }
            else
            {
                InitView();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CurrentSpecs == null)
                return;
            Int32 sequ = CurrentSpecs.Sequence - 1;
            if (sequ <=0)
            {
                sequ = 1;
            }
            Specs spec = DbFactory.FindBySequence(sequ,CurrentJob.IsFull);
            if (spec != null)
            {
                CurrentSpecs = spec;
                InitView();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CurrentSpecs == null)
                return;
            Int32 sequ = CurrentSpecs.Sequence + 1;
            if (sequ >= CurrentJob.NeedCheckPosition)
            {
                sequ = CurrentJob.NeedCheckPosition;
            }
            Specs spec = DbFactory.FindBySequence(sequ,CurrentJob.IsFull);
            if (spec != null)
            {
                CurrentSpecs = spec;
                InitView();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormJobMainView viewform = new FormJobMainView(CurrentJob);
            viewform.Show();
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtBarCode_GotFocus(object sender, EventArgs e)
        {
            txtBarCode.SelectAll();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (lvMain.SelectedIndices.Count > 0)
            {

                ListViewItem item = lvMain.Items[lvMain.SelectedIndices[0]];
                SpecsDetail detail = CurrentSpecs.FindByID(Int32.Parse(item.Tag.ToString()));
                //MessageBox.Show(String.Format("{0},{1}", item.Text, item.SubItems.ToString()));
                FormCheckDetail detailform = new FormCheckDetail(detail);
                if (detailform.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(detail.Note);
                }
            }
        }

       
    }
}