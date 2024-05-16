namespace PAMC_104
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.plus_btn = new System.Windows.Forms.Button();
            this.minus_btn = new System.Windows.Forms.Button();
            this.frequency_form = new System.Windows.Forms.TextBox();
            this.frequency_lbl = new System.Windows.Forms.Label();
            this.numOfPulses_lbl = new System.Windows.Forms.Label();
            this.numOfPulses_form = new System.Windows.Forms.TextBox();
            this.cmdToSend_lbl = new System.Windows.Forms.Label();
            this.cmdDirection_text = new System.Windows.Forms.TextBox();
            this.cmdFrequency_text = new System.Windows.Forms.TextBox();
            this.cmdNumOfPulses_text = new System.Windows.Forms.TextBox();
            this.cmdPort_text = new System.Windows.Forms.TextBox();
            this.port_ComboBox = new System.Windows.Forms.ComboBox();
            this.port = new System.Windows.Forms.Label();
            this.excute_btn = new System.Windows.Forms.Button();
            this.axis_ComboBox = new System.Windows.Forms.ComboBox();
            this.axis_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // plus_btn
            // 
            this.plus_btn.Location = new System.Drawing.Point(756, 172);
            this.plus_btn.Name = "plus_btn";
            this.plus_btn.Size = new System.Drawing.Size(31, 34);
            this.plus_btn.TabIndex = 0;
            this.plus_btn.Text = "+";
            this.plus_btn.UseVisualStyleBackColor = true;
            this.plus_btn.Click += new System.EventHandler(this.plus_btn_Click);
            // 
            // minus_btn
            // 
            this.minus_btn.Location = new System.Drawing.Point(793, 172);
            this.minus_btn.Name = "minus_btn";
            this.minus_btn.Size = new System.Drawing.Size(32, 34);
            this.minus_btn.TabIndex = 1;
            this.minus_btn.Text = "-";
            this.minus_btn.UseVisualStyleBackColor = true;
            this.minus_btn.Click += new System.EventHandler(this.minus_btn_Click);
            // 
            // frequency_form
            // 
            this.frequency_form.Location = new System.Drawing.Point(756, 251);
            this.frequency_form.Name = "frequency_form";
            this.frequency_form.Size = new System.Drawing.Size(100, 19);
            this.frequency_form.TabIndex = 2;
            this.frequency_form.TextChanged += new System.EventHandler(this.frequency_form_TextChanged);
            // 
            // frequency_lbl
            // 
            this.frequency_lbl.AutoSize = true;
            this.frequency_lbl.Location = new System.Drawing.Point(756, 233);
            this.frequency_lbl.Name = "frequency_lbl";
            this.frequency_lbl.Size = new System.Drawing.Size(55, 12);
            this.frequency_lbl.TabIndex = 3;
            this.frequency_lbl.Text = "frequency";
            // 
            // numOfPulses_lbl
            // 
            this.numOfPulses_lbl.AutoSize = true;
            this.numOfPulses_lbl.Location = new System.Drawing.Point(758, 304);
            this.numOfPulses_lbl.Name = "numOfPulses_lbl";
            this.numOfPulses_lbl.Size = new System.Drawing.Size(62, 12);
            this.numOfPulses_lbl.TabIndex = 4;
            this.numOfPulses_lbl.Text = "# of pulses";
            // 
            // numOfPulses_form
            // 
            this.numOfPulses_form.Location = new System.Drawing.Point(758, 320);
            this.numOfPulses_form.Name = "numOfPulses_form";
            this.numOfPulses_form.Size = new System.Drawing.Size(100, 19);
            this.numOfPulses_form.TabIndex = 5;
            this.numOfPulses_form.TextChanged += new System.EventHandler(this.numOfPulses_form_TextChanged);
            // 
            // cmdToSend_lbl
            // 
            this.cmdToSend_lbl.AutoSize = true;
            this.cmdToSend_lbl.Location = new System.Drawing.Point(756, 365);
            this.cmdToSend_lbl.Name = "cmdToSend_lbl";
            this.cmdToSend_lbl.Size = new System.Drawing.Size(96, 17);
            this.cmdToSend_lbl.TabIndex = 6;
            this.cmdToSend_lbl.Text = "command to send";
            this.cmdToSend_lbl.UseCompatibleTextRendering = true;
            // 
            // cmdDirection_text
            // 
            this.cmdDirection_text.Location = new System.Drawing.Point(758, 386);
            this.cmdDirection_text.Name = "cmdDirection_text";
            this.cmdDirection_text.ReadOnly = true;
            this.cmdDirection_text.Size = new System.Drawing.Size(29, 19);
            this.cmdDirection_text.TabIndex = 7;
            this.cmdDirection_text.Text = "NR";
            this.cmdDirection_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdFrequency_text
            // 
            this.cmdFrequency_text.Location = new System.Drawing.Point(791, 386);
            this.cmdFrequency_text.Name = "cmdFrequency_text";
            this.cmdFrequency_text.ReadOnly = true;
            this.cmdFrequency_text.Size = new System.Drawing.Size(45, 19);
            this.cmdFrequency_text.TabIndex = 8;
            this.cmdFrequency_text.Text = "0000";
            // 
            // cmdNumOfPulses_text
            // 
            this.cmdNumOfPulses_text.Location = new System.Drawing.Point(839, 386);
            this.cmdNumOfPulses_text.Name = "cmdNumOfPulses_text";
            this.cmdNumOfPulses_text.ReadOnly = true;
            this.cmdNumOfPulses_text.Size = new System.Drawing.Size(47, 19);
            this.cmdNumOfPulses_text.TabIndex = 9;
            this.cmdNumOfPulses_text.Text = "0000";
            // 
            // cmdPort_text
            // 
            this.cmdPort_text.Location = new System.Drawing.Point(888, 386);
            this.cmdPort_text.Name = "cmdPort_text";
            this.cmdPort_text.ReadOnly = true;
            this.cmdPort_text.Size = new System.Drawing.Size(29, 19);
            this.cmdPort_text.TabIndex = 10;
            this.cmdPort_text.Text = "A";
            this.cmdPort_text.TextChanged += new System.EventHandler(this.cmdPort_text_TextChanged);
            // 
            // port_ComboBox
            // 
            this.port_ComboBox.FormattingEnabled = true;
            this.port_ComboBox.Location = new System.Drawing.Point(108, 186);
            this.port_ComboBox.Name = "port_ComboBox";
            this.port_ComboBox.Size = new System.Drawing.Size(121, 20);
            this.port_ComboBox.TabIndex = 11;
            // 
            // port
            // 
            this.port.AutoSize = true;
            this.port.Location = new System.Drawing.Point(106, 157);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(26, 12);
            this.port.TabIndex = 12;
            this.port.Text = "Port";
            // 
            // excute_btn
            // 
            this.excute_btn.Location = new System.Drawing.Point(783, 474);
            this.excute_btn.Name = "excute_btn";
            this.excute_btn.Size = new System.Drawing.Size(75, 23);
            this.excute_btn.TabIndex = 13;
            this.excute_btn.Text = "Excute";
            this.excute_btn.UseVisualStyleBackColor = true;
            this.excute_btn.Click += new System.EventHandler(this.excute_btn_Click);
            // 
            // axis_ComboBox
            // 
            this.axis_ComboBox.FormattingEnabled = true;
            this.axis_ComboBox.Location = new System.Drawing.Point(108, 487);
            this.axis_ComboBox.Name = "axis_ComboBox";
            this.axis_ComboBox.Size = new System.Drawing.Size(121, 20);
            this.axis_ComboBox.TabIndex = 14;
            this.axis_ComboBox.SelectedIndexChanged += new System.EventHandler(this.axis_ComboBox_SelectedIndexChanged);
            // 
            // axis_lbl
            // 
            this.axis_lbl.AutoSize = true;
            this.axis_lbl.Location = new System.Drawing.Point(106, 472);
            this.axis_lbl.Name = "axis_lbl";
            this.axis_lbl.Size = new System.Drawing.Size(28, 12);
            this.axis_lbl.TabIndex = 15;
            this.axis_lbl.Text = "Axis";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 880);
            this.Controls.Add(this.axis_lbl);
            this.Controls.Add(this.axis_ComboBox);
            this.Controls.Add(this.excute_btn);
            this.Controls.Add(this.port);
            this.Controls.Add(this.port_ComboBox);
            this.Controls.Add(this.cmdPort_text);
            this.Controls.Add(this.cmdNumOfPulses_text);
            this.Controls.Add(this.cmdFrequency_text);
            this.Controls.Add(this.cmdDirection_text);
            this.Controls.Add(this.cmdToSend_lbl);
            this.Controls.Add(this.numOfPulses_form);
            this.Controls.Add(this.numOfPulses_lbl);
            this.Controls.Add(this.frequency_lbl);
            this.Controls.Add(this.frequency_form);
            this.Controls.Add(this.minus_btn);
            this.Controls.Add(this.plus_btn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button plus_btn;
        private System.Windows.Forms.Button minus_btn;
        private System.Windows.Forms.TextBox frequency_form;
        private System.Windows.Forms.Label frequency_lbl;
        private System.Windows.Forms.Label numOfPulses_lbl;
        private System.Windows.Forms.TextBox numOfPulses_form;
        private System.Windows.Forms.Label cmdToSend_lbl;
        private System.Windows.Forms.TextBox cmdDirection_text;
        private System.Windows.Forms.TextBox cmdFrequency_text;
        private System.Windows.Forms.TextBox cmdNumOfPulses_text;
        private System.Windows.Forms.TextBox cmdPort_text;
        private System.Windows.Forms.ComboBox port_ComboBox;
        private System.Windows.Forms.Label port;
        private System.Windows.Forms.Button excute_btn;
        private System.Windows.Forms.ComboBox axis_ComboBox;
        private System.Windows.Forms.Label axis_lbl;
    }
}

