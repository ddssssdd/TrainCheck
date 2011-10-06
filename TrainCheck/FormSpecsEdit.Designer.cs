namespace TrainCheck
{
    partial class FormSpecsEdit
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSequ = new System.Windows.Forms.NumericUpDown();
            this.cboSection = new System.Windows.Forms.TextBox();
            this.cboPosition = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.Text = "编码：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(89, 91);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(139, 23);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.Text = "部位：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(25, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.Text = "顺序：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.Text = "检查处所：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(19, 120);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(209, 106);
            this.txtDetail.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(147, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 29);
            this.button1.TabIndex = 14;
            this.button1.Text = "更新";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSequ
            // 
            this.txtSequ.Location = new System.Drawing.Point(89, 3);
            this.txtSequ.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtSequ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSequ.Name = "txtSequ";
            this.txtSequ.Size = new System.Drawing.Size(139, 24);
            this.txtSequ.TabIndex = 15;
            this.txtSequ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSequ.ValueChanged += new System.EventHandler(this.txtSequ_ValueChanged);
            // 
            // cboSection
            // 
            this.cboSection.Location = new System.Drawing.Point(89, 33);
            this.cboSection.Name = "cboSection";
            this.cboSection.Size = new System.Drawing.Size(139, 23);
            this.cboSection.TabIndex = 16;
            // 
            // cboPosition
            // 
            this.cboPosition.Location = new System.Drawing.Point(89, 62);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(139, 23);
            this.cboPosition.TabIndex = 17;
            // 
            // FormSpecsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 270);
            this.Controls.Add(this.cboPosition);
            this.Controls.Add(this.cboSection);
            this.Controls.Add(this.txtSequ);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.Name = "FormSpecsEdit";
            this.Text = "编码维护";
            this.Load += new System.EventHandler(this.FormSpecsEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown txtSequ;
        private System.Windows.Forms.TextBox cboSection;
        private System.Windows.Forms.TextBox cboPosition;
    }
}