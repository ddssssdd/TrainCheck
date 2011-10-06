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
    public partial class BaseFormScanFor60 : Form
    {
        Scanner scanner = new Scanner();

        /// <summary>
        /// 自动扫描关闭激光计数器,10秒没有扫描到条码则关闭自动扫描
        /// </summary>
        private int scanCount = 0;
        public BaseFormScanFor60()
        {
            InitializeComponent();
        }

        private void BaseFormScanFor60_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
          

            scanner.DecodeEvent += new EventHandler<DecodeEventArgs>(scanner_DecodeEvent);
            scanner.Start();
        }
        void scanner_DecodeEvent(object sender, DecodeEventArgs e)
        {
            Win32.sndPlaySound(Properties.Resources.Scan, Win32.SND_ASYNC | Win32.SND_MEMORY);

            this.BeginInvoke((Action<string>)delegate(string barcode)
            {
                scanCount = 0;
                //ListViewItem item = new ListViewItem(new string[] { barcode });
                //lstView.Items.Insert(0, item);
                onGetBarCode(barcode);
            }, e.Barcode);
        }
        virtual protected void onGetBarCode(string barcode)
        { 
            
        }

        private void BaseFormScanFor60_Closing(object sender, CancelEventArgs e)
        {
            scanner.Stop();
        }

       
    }
}