using System;

using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsCE.Forms;

namespace TrainCheck
{
    class MsgWindow : MessageWindow
    {

        private BaseFormScan msgform;

        public MsgWindow(BaseFormScan msgform)
        {
            this.msgform = msgform;
        }

        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {
                case (int)BaseFormScan.WM_SCANMSG:
                    this.msgform.GetBarcode(msg.WParam);
                    break;
                default:
                    base.WndProc(ref msg);
                    break;
            }
        }
    }
}
