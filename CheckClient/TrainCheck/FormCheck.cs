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
    public partial class FormCheck : Form
    {
        public FormCheck()
        {
            InitializeComponent();
        }
        public FormCheck(JobMain job):this()
        {
            CurrentJob = job;
            if (job.Items.Count > 0)
            {
                Int32 specsid = job.Items.Max(jobdetail => jobdetail.SpecsID);
                Specs spec = DbFactory.FindByFilter("ID=" + specsid.ToString());
                if (spec != null)
                {
                    CurrentSpecs = spec;
                    InitView();
                }
            }
        }
        private JobMain CurrentJob { get; set; }
        private Specs CurrentSpecs { get; set; }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBarCode.Text))
            {
                Specs spec = DbFactory.Find(txtBarCode.Text);
                if (spec != null)
                { 
                    //first process last spec;
                    CurrentSpecs = spec;
                    InitView();
                }
            }
        }
        private void InitView()
        {
            if (CurrentJob != null)
            {
                CurrentJob.SetCheckToSpecs(CurrentSpecs);
            }
            lblSection.Text = String.Format("{0}→{1}({2})", CurrentSpecs.Seciton, CurrentSpecs.CheckPosition, CurrentSpecs.CheckMethod);
            Text = String.Format("{2}.{0}→{1}", CurrentSpecs.Seciton, CurrentSpecs.CheckPosition,CurrentSpecs.Sequence);           
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
                    item.Checked = true;
                item.Tag = detail.ID;
                lvMain.Items.Add(item);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvMain.Items)
            {
                SpecsDetail detail = CurrentSpecs.FindByID(Int32.Parse(item.Tag.ToString()));
                detail.isChecked = item.Checked;

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
            CurrentJob.Items.Add(jobdetail);
            if (jobdetail.ID == 0)
            {
                jobdetail.ID = DbFactory.JobDetailInsert(jobdetail);
                CurrentJob.CheckPosition += CurrentJob.CheckPosition;
            }
            else
                DbFactory.JobDetailUpdate(jobdetail);

            //DbFactory.SaveJob(CurrentJob);
            Specs spec = DbFactory.FindBySequence(CurrentSpecs.Sequence + 1);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (CurrentSpecs == null)
                return;
            Int32 sequ = CurrentSpecs.Sequence - 1;
            if (sequ <=0)
            {
                sequ = 1;
            }
            Specs spec = DbFactory.FindBySequence(sequ);
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
            Specs spec = DbFactory.FindBySequence(sequ);
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
    }
}