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
    public partial class BaseFormScan : Form
    {
        public BaseFormScan()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 扫瞄通知
        /// </summary>
        public const uint WM_SCANMSG = 0x500;


        /// <summary>
        /// 自动扫描关闭激光计数器,10秒没有扫描到条码则关闭自动扫描
        /// </summary>
        private int scanCount = 0;

        /// <summary>
        /// 是否正在连续扫描模式
        /// </summary>
        private bool isScaning = false;

        /// <summary>
        /// 扫描事件控制--开始扫描
        /// </summary>
        private IntPtr scanStartEvent;

        /// <summary>
        /// 扫描事件控制--扫描结束
        /// </summary>
        private IntPtr scanStopEvent;

        /// <summary>
        /// 程序结束事件控制--结束扫描线程scanThreadProc
        /// </summary>
        private IntPtr stopEvent;

        /// <summary>
        /// 接收条码
        /// </summary>
        private MsgWindow msgWindow;

        private void BaseFormScan_Load(object sender, EventArgs e)
        {
            /*
            * tips:
            * 1、在程序启动的时候开启扫描头；
            * 2、在程序退出的时候关闭扫描头；
            */
            this.KeyPreview = true;

            scanStartEvent = Win32.CreateEvent(IntPtr.Zero, true, false, null);
            scanStopEvent = Win32.CreateEvent(IntPtr.Zero, true, false, null);
            stopEvent = Win32.CreateEvent(IntPtr.Zero, false, false, null);

            msgWindow = new MsgWindow(this);
           // Scanner.RegisterScannerMessage(msgWindow.Hwnd, BaseFormScan.WM_SCANMSG);

            // 启动扫描线程
            Thread tScan = new Thread(new ThreadStart(this.scanThreadProc));
            tScan.Start();
        }

        private void BaseFormScan_Closing(object sender, CancelEventArgs e)
        {
            try
            {

                // 关闭扫描头以及结束 barcodeThreadProc
                if (Scanner.IsScannerEnabled())
                {
                    Scanner.DisableScanner();
                }

                // 结束 scanThreadProc
                Win32.EventModify(stopEvent, Win32.EVENT_SET);

                // 等待背景线程结束
                Thread.Sleep(0);

                Win32.CloseHandle(scanStartEvent);
                Win32.CloseHandle(scanStopEvent);
                Win32.CloseHandle(stopEvent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected void EnableScaner()
        {
            // 开启扫描头
            try
            {
              
                Scanner.EnableScanner();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected void DisableScaner()
        {
            // 关闭扫描头
            try
            {
                // 关闭扫描头以及结束 barcodeThreadProc
                Scanner.DisableScanner();

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BaseFormScan_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F23:  // 侧面扫描键
                    if (!isScaning)
                    {
                        isScaning = true;
                        Scanner.SetTriggerMode((int)Scanner.TriggerMode.Continuous);
                        scanCount = 0;
                    }
                    else
                    {
                        isScaning = false;
                        Scanner.SetTriggerMode((int)Scanner.TriggerMode.Normal);
                        scanCount = 0;
                    }
                    break;

                case Keys.F24:  // 正面扫描键[Scan]
                    if (!isScaning)
                    {
                        if (Win32.WaitForSingleObject(scanStartEvent, 0) == 0)
                        {
                            break;  // 上次扫描还没执行完,则不执行扫描
                        }

                        Win32.EventModify(scanStartEvent, Win32.EVENT_SET);
                    }
                    break;
                default:
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //10秒没扫到东西则关闭扫描头
            if (isScaning && (++scanCount == 10))
            {
                isScaning = false;
                Scanner.SetTriggerMode((int)Scanner.TriggerMode.Normal);
            }
        }
        /// <summary>
        /// 扫描线程。使用线程以避免重复扫描（第一次扫描还没结束，就按[Scan]键启动了第二次扫描）
        /// </summary>
        private void scanThreadProc()
        {
            IntPtr[] evts = { stopEvent, scanStartEvent };

            while (true)
            {
                uint retEvt = Win32.WaitForMultipleObjects(2, evts, false, Win32.INFINITE);

                switch (retEvt)
                {
                    case 0:
                        return;
                    case 1:
                        Win32.EventModify(scanStopEvent, Win32.EVENT_RESET);

                        Scanner.StartScan();

                        Win32.WaitForSingleObject(scanStopEvent, 2000); //等待激光关闭

                        Scanner.StopScan();

                        Win32.EventModify(scanStartEvent, Win32.EVENT_RESET);
                        break;
                }
            }
        }

        public void GetBarcode(IntPtr wParam)
        {
            string barcode = Marshal.PtrToStringUni(wParam);

            Win32.EventModify(scanStopEvent, Win32.EVENT_SET);
            Win32.sndPlaySound(Properties.Resources.Scan, Win32.SND_ASYNC | Win32.SND_MEMORY);

            if (isScaning)
            {
                scanCount = 0;
            }

            OnGetBarcode(barcode);
        }

        /// <summary>
        /// 接收/显示条码
        /// </summary>
        /// <param name="barCode"></param>
        /// <param name="codeType"></param>
        protected virtual void OnGetBarcode(string barCode)
        {            
        }
       
    }
}