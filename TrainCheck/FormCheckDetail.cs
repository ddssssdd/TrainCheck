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
    public partial class FormCheckDetail : Form
    {
        public FormCheckDetail()
        {
            InitializeComponent();
        }
        private SpecsDetail _detail;
        public FormCheckDetail(SpecsDetail detail)
            : this()
        {
            _detail = detail;
            initView();
        }
        private void initView()
        {
            this.Text = _detail.CheckDetail;
            txtInfo.Text = String.Format("{0}\r\n{1}\r\n{2}\r\n{3}", _detail.CheckDetail,
                string.Format("检查方法->{0}", _detail.CheckMethod),
                string.Format("规定尺寸、高度-{0}",_detail.SpecifiedSizeHeight),
                String.Format("打点位置->{0}",_detail.KnockPosition));
            txtMemo.Text = _detail.Note;
            txtInfo.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _detail.Note = txtMemo.Text.Trim().Replace("$","").Replace("|","");
        }

        private void txtMemo_GotFocus(object sender, EventArgs e)
        {
            Win32.SipShowIM(1);
        }

        private void txtMemo_LostFocus(object sender, EventArgs e)
        {
            Win32.SipShowIM(0);
        }

        private void FormCheckDetail_Closed(object sender, EventArgs e)
        {
            Win32.SipShowIM(0);
        }
    }
}