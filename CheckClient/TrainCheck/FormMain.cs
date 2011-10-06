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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        public void ShowStatus(String sInfo)
        {
            sbMain.Text = String.Format("操作员:{0} 信息:{1}", AppHelper.UserName, sInfo);
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                using (IDataReader dr = DataAccess.ExecuteReader(
                    String.Format("select ID,userName from users where userNo='{0}' or UserName='{0}'", login.UserNo)))
                {
                    if (dr.Read() == false)
                    {
                        dr.Close();
                        MessageBox.Show("用户名称或者编号不存在！");
                        Application.Exit();
                    }
                    else
                    {
                        AppHelper.UserID = Int32.Parse(dr["id"].ToString());
                        AppHelper.UserName = (dr["UserName"] == DBNull.Value) ? "" : dr["UserName"].ToString();
                        dr.Close();
                        ShowStatus("");
                    }
                }
            }
            else
                Application.Exit();

        }


        private void menuItem6_Click(object sender, EventArgs e)
        {
            (new FormDataQuery()).ShowDialog();
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            ShowStatus( "DownLoad...");
            this.Refresh();
            DownLoad dl = new DownLoad();

            dl.DownloadUserList();
            ShowStatus( "User Downloaded.");
            dl.DownloadSpecsList();
            ShowStatus( "DownLoad Successfully.");

        }

        private void menuItem8_Click(object sender, EventArgs e)
        {

            JobMain job = DbFactory.FindToDayJob();
            if (job != null)
            {
                DialogResult dresult= MessageBox.Show("当前有一次未完成的检查，是否继续？","请确认", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dresult == DialogResult.Cancel)
                    return;
                if (dresult == DialogResult.No)
                {
                    DbFactory.DeleteJobMain(job);
                    job = DbFactory.Create(0);
                }

            }
            else
                job = DbFactory.Create(0);
            FormCheck checkform = new FormCheck(job);
            checkform.ShowDialog();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            ShowStatus("Uploading...");
            this.Refresh();
            UpLoad upload = new UpLoad();
            upload.UpLoadJob();
            ShowStatus("Uploaded Successfully.");
        }
    }
}