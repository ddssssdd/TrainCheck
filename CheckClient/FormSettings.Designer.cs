namespace TrainCheck
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserNoDim = new System.Windows.Forms.NumericUpDown();
            this.txtBarCodeDim = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServerUrl = new System.Windows.Forms.TextBox();
            this.txtLocalUserNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocalTrainNo = new System.Windows.Forms.TextBox();
            this.chkUpdateDB = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.Text = "用户编码长度";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtUserNoDim
            // 
            this.txtUserNoDim.Location = new System.Drawing.Point(109, 9);
            this.txtUserNoDim.Name = "txtUserNoDim";
            this.txtUserNoDim.Size = new System.Drawing.Size(131, 24);
            this.txtUserNoDim.TabIndex = 1;
            // 
            // txtBarCodeDim
            // 
            this.txtBarCodeDim.Location = new System.Drawing.Point(109, 43);
            this.txtBarCodeDim.Name = "txtBarCodeDim";
            this.txtBarCodeDim.Size = new System.Drawing.Size(131, 24);
            this.txtBarCodeDim.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.Text = "条码长度";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "服务地址";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtServerUrl
            // 
            this.txtServerUrl.Location = new System.Drawing.Point(109, 77);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.Size = new System.Drawing.Size(131, 23);
            this.txtServerUrl.TabIndex = 6;
            // 
            // txtLocalUserNo
            // 
            this.txtLocalUserNo.Location = new System.Drawing.Point(109, 110);
            this.txtLocalUserNo.Name = "txtLocalUserNo";
            this.txtLocalUserNo.Size = new System.Drawing.Size(131, 23);
            this.txtLocalUserNo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "本机用户编号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "本机检查火车";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtLocalTrainNo
            // 
            this.txtLocalTrainNo.Location = new System.Drawing.Point(109, 143);
            this.txtLocalTrainNo.Name = "txtLocalTrainNo";
            this.txtLocalTrainNo.Size = new System.Drawing.Size(131, 23);
            this.txtLocalTrainNo.TabIndex = 10;
            // 
            // chkUpdateDB
            // 
            this.chkUpdateDB.Location = new System.Drawing.Point(110, 180);
            this.chkUpdateDB.Name = "chkUpdateDB";
            this.chkUpdateDB.Size = new System.Drawing.Size(100, 20);
            this.chkUpdateDB.TabIndex = 11;
            this.chkUpdateDB.Text = "存到磁盘";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(14, 224);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(120, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 270);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkUpdateDB);
            this.Controls.Add(this.txtLocalTrainNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLocalUserNo);
            this.Controls.Add(this.txtServerUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBarCodeDim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserNoDim);
            this.Controls.Add(this.label1);
            this.Name = "FormSettings";
            this.Text = "本机设置";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtUserNoDim;
        private System.Windows.Forms.NumericUpDown txtBarCodeDim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServerUrl;
        private System.Windows.Forms.TextBox txtLocalUserNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLocalTrainNo;
        private System.Windows.Forms.CheckBox chkUpdateDB;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}