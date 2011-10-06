using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

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
           
            if (!String.IsNullOrEmpty(AppHelper.LocalUserNo))
            {
                AppHelper.UserID = Int32.Parse(AppHelper.LocalUserNo);
                AppHelper.UserName = "Local";
                ShowStatus("");
            }
            else
            {
                FormLogin login = new FormLogin();
                int icount = 0;
                while (icount < 3)
                {
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        if (login.UserNo == "999")
                        {
                            AppHelper.UserID = 999;
                            AppHelper.UserName = "admin";
                            ShowStatus("管理员登录");
                            break;
                        }
                        else
                        {
                            using (IDataReader dr = DataAccess.ExecuteReader(
                                String.Format("select ID,userName from users where userNo='{0}' or UserName='{0}'", login.UserNo)))
                            {
                                if (dr.Read() == false)
                                {
                                    dr.Close();
                                    MessageBox.Show("用户名称或者编号不存在！");
                                }
                                else
                                {
                                    AppHelper.UserID = Int32.Parse(dr["id"].ToString());
                                    AppHelper.UserName = (dr["UserName"] == DBNull.Value) ? "" : dr["UserName"].ToString();
                                    dr.Close();
                                    ShowStatus("");
                                    break;
                                }
                            }
                        }
                    }
                    else
                        Application.Exit();
                    icount++;
                }
                if (icount == 3)
                    Application.Exit();
            }
           
        }


        private void menuItem6_Click(object sender, EventArgs e)
        {
            if (AppHelper.UserName.ToLower().Equals("admin"))
            {
                (new FormDataQuery()).ShowDialog();
            }
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            if (AppHelper.UserName.ToLower().Equals("admin"))
            {
                if (MessageBox.Show("下载数据会初始化PDA字典数据，需要重新设置编码，是否继续?", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    ShowStatus("DownLoad...");
                    this.Refresh();
                    DownLoad dl = new DownLoad();

                    ShowStatus("SpecsList DownLoad...");
                    this.Refresh();
                    dl.DownloadSpecsList();
                    ShowStatus("Settings DownLoad..");
                    this.Refresh();
                    dl.DownloadSettings();
                    ShowStatus("DownLoad Successfully.");
                }
            }
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            TrainCheck(true);
            
        }
        public void TrainCheck(bool isfull)
        {
            JobMain job = DbFactory.FindToDayJob(isfull);
            if (job != null)
            {
                DialogResult dresult = MessageBox.Show("当前有一次未完成的检查，是否继续？", "请确认", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dresult == DialogResult.Cancel)
                    return;
                if (dresult == DialogResult.No)
                {
                    DbFactory.DeleteJobMain(job);
                    job = DbFactory.Create(0, isfull);
                }

            }
            else
                job = DbFactory.Create(0, isfull);
            FormCheck checkform = new FormCheck(job);
            checkform.ShowDialog();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("准备上传巡检数据，请确认已经联网？", "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                try
                {
                    ShowStatus("Uploading...");
                    this.Refresh();
                    UpLoad upload = new UpLoad();
                    upload.UpLoadJob();

                    //upload.UpLoadSpecsBarCode();
                    ShowStatus("Uploaded Successfully.");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            if (AppHelper.UserName.ToLower().Equals("admin"))
                (new FormSpecsEdit()).ShowDialog();
        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            TrainCheck(false);
        }

        private void menuItem14_Click(object sender, EventArgs e)
        {
            if (AppHelper.UserName.ToLower().Equals("admin"))
            {
                if (MessageBox.Show("下载用户数据，是否继续?", "请确认" ,MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    ShowStatus("DownLoad...");
                    this.Refresh();
                    DownLoad dl = new DownLoad();
                    ShowStatus("User Downloaded...");
                    this.Refresh();
                    dl.DownloadUserList();
                    ShowStatus("DownLoad Successfully.");
                }
            }
        }

        private void menuItem13_Click(object sender, EventArgs e)
        {
            (new FormSettings()).ShowDialog();
        }

    
        private void SetMenuStatus(bool isConnect)
        {            
            menuItem3.Enabled = isConnect;
            menuItem5.Enabled = isConnect;
            menuItem14.Enabled = isConnect;
        }

        private void menuItem17_Click(object sender, EventArgs e)
        {
            AppHelper.StartWlan();
        }

        private void menuItem16_Click(object sender, EventArgs e)
        {
            AppHelper.StopWlan();
        }

        private void menuItem2_Popup(object sender, EventArgs e)
        {
            bool isConnect = AppHelper.IsConnected();
            SetMenuStatus(isConnect);
        }

        private void FormMain_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
             FormLogin login = new FormLogin();

             if (login.ShowDialog() == DialogResult.OK)
             {
                 if (login.UserNo == "999")
                 {
                     AppHelper.UserID = 999;
                     AppHelper.UserName = "admin";
                     ShowStatus("管理员登录");
                     e.Cancel = false; 
                 }
             }

        }

      
    }
}