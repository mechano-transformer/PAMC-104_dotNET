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
            this.baudRate_lbl = new System.Windows.Forms.Label();
            this.baudRate_form = new System.Windows.Forms.TextBox();
            this.dataBits_lbl = new System.Windows.Forms.Label();
            this.dataBits_form = new System.Windows.Forms.TextBox();
            this.stopBits_lbl = new System.Windows.Forms.Label();
            this.stopBits_comboBox = new System.Windows.Forms.ComboBox();
            this.parity_lbl = new System.Windows.Forms.Label();
            this.parity_comboBox = new System.Windows.Forms.ComboBox();
            this.flowControl_lbl = new System.Windows.Forms.Label();
            this.flowControl_comboBox = new System.Windows.Forms.ComboBox();
            this.timeout_lbl = new System.Windows.Forms.Label();
            this.timeout_form = new System.Windows.Forms.TextBox();
            this.conToggle_btn = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
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
            // 
            // port_ComboBox
            // 
            this.port_ComboBox.FormattingEnabled = true;
            this.port_ComboBox.Location = new System.Drawing.Point(108, 186);
            this.port_ComboBox.Name = "port_ComboBox";
            this.port_ComboBox.Size = new System.Drawing.Size(121, 20);
            this.port_ComboBox.TabIndex = 11;
            this.port_ComboBox.SelectedIndexChanged += new System.EventHandler(this.port_ComboBox_SelectedIndexChanged);
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
            this.excute_btn.Enabled = false;
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
            this.axis_ComboBox.Location = new System.Drawing.Point(108, 656);
            this.axis_ComboBox.Name = "axis_ComboBox";
            this.axis_ComboBox.Size = new System.Drawing.Size(121, 20);
            this.axis_ComboBox.TabIndex = 14;
            this.axis_ComboBox.SelectedIndexChanged += new System.EventHandler(this.axis_ComboBox_SelectedIndexChanged);
            // 
            // axis_lbl
            // 
            this.axis_lbl.AutoSize = true;
            this.axis_lbl.Location = new System.Drawing.Point(106, 641);
            this.axis_lbl.Name = "axis_lbl";
            this.axis_lbl.Size = new System.Drawing.Size(28, 12);
            this.axis_lbl.TabIndex = 15;
            this.axis_lbl.Text = "Axis";
            // 
            // baudRate_lbl
            // 
            this.baudRate_lbl.AutoSize = true;
            this.baudRate_lbl.Location = new System.Drawing.Point(108, 233);
            this.baudRate_lbl.Name = "baudRate_lbl";
            this.baudRate_lbl.Size = new System.Drawing.Size(91, 12);
            this.baudRate_lbl.TabIndex = 27;
            this.baudRate_lbl.Text = "band rate(19200)";
            // 
            // baudRate_form
            // 
            this.baudRate_form.Location = new System.Drawing.Point(108, 251);
            this.baudRate_form.Name = "baudRate_form";
            this.baudRate_form.Size = new System.Drawing.Size(100, 19);
            this.baudRate_form.TabIndex = 26;
            this.baudRate_form.Text = "115200";
            this.baudRate_form.TextChanged += new System.EventHandler(this.baudRate_form_TextChanged);
            // 
            // dataBits_lbl
            // 
            this.dataBits_lbl.AutoSize = true;
            this.dataBits_lbl.Location = new System.Drawing.Point(108, 286);
            this.dataBits_lbl.Name = "dataBits_lbl";
            this.dataBits_lbl.Size = new System.Drawing.Size(64, 12);
            this.dataBits_lbl.TabIndex = 29;
            this.dataBits_lbl.Text = "data bits(8)";
            // 
            // dataBits_form
            // 
            this.dataBits_form.Location = new System.Drawing.Point(108, 304);
            this.dataBits_form.Name = "dataBits_form";
            this.dataBits_form.Size = new System.Drawing.Size(100, 19);
            this.dataBits_form.TabIndex = 28;
            this.dataBits_form.Text = "8";
            this.dataBits_form.TextChanged += new System.EventHandler(this.dataBits_form_TextChanged);
            // 
            // stopBits_lbl
            // 
            this.stopBits_lbl.AutoSize = true;
            this.stopBits_lbl.Location = new System.Drawing.Point(108, 385);
            this.stopBits_lbl.Name = "stopBits_lbl";
            this.stopBits_lbl.Size = new System.Drawing.Size(53, 12);
            this.stopBits_lbl.TabIndex = 31;
            this.stopBits_lbl.Text = "Stop Bits";
            // 
            // stopBits_comboBox
            // 
            this.stopBits_comboBox.FormattingEnabled = true;
            this.stopBits_comboBox.Location = new System.Drawing.Point(108, 400);
            this.stopBits_comboBox.Name = "stopBits_comboBox";
            this.stopBits_comboBox.Size = new System.Drawing.Size(121, 20);
            this.stopBits_comboBox.TabIndex = 30;
            this.stopBits_comboBox.SelectedIndexChanged += new System.EventHandler(this.stopBits_comboBox_SelectedIndexChanged);
            // 
            // parity_lbl
            // 
            this.parity_lbl.AutoSize = true;
            this.parity_lbl.Location = new System.Drawing.Point(108, 338);
            this.parity_lbl.Name = "parity_lbl";
            this.parity_lbl.Size = new System.Drawing.Size(35, 12);
            this.parity_lbl.TabIndex = 33;
            this.parity_lbl.Text = "Parity";
            // 
            // parity_comboBox
            // 
            this.parity_comboBox.FormattingEnabled = true;
            this.parity_comboBox.Location = new System.Drawing.Point(108, 353);
            this.parity_comboBox.Name = "parity_comboBox";
            this.parity_comboBox.Size = new System.Drawing.Size(121, 20);
            this.parity_comboBox.TabIndex = 32;
            this.parity_comboBox.SelectedIndexChanged += new System.EventHandler(this.parity_comboBox_SelectedIndexChanged);
            // 
            // flowControl_lbl
            // 
            this.flowControl_lbl.AutoSize = true;
            this.flowControl_lbl.Location = new System.Drawing.Point(108, 443);
            this.flowControl_lbl.Name = "flowControl_lbl";
            this.flowControl_lbl.Size = new System.Drawing.Size(70, 12);
            this.flowControl_lbl.TabIndex = 35;
            this.flowControl_lbl.Text = "Flow Control";
            // 
            // flowControl_comboBox
            // 
            this.flowControl_comboBox.FormattingEnabled = true;
            this.flowControl_comboBox.Location = new System.Drawing.Point(108, 458);
            this.flowControl_comboBox.Name = "flowControl_comboBox";
            this.flowControl_comboBox.Size = new System.Drawing.Size(121, 20);
            this.flowControl_comboBox.TabIndex = 34;
            this.flowControl_comboBox.SelectedIndexChanged += new System.EventHandler(this.flowControl_comboBox_SelectedIndexChanged);
            // 
            // timeout_lbl
            // 
            this.timeout_lbl.AutoSize = true;
            this.timeout_lbl.Location = new System.Drawing.Point(110, 498);
            this.timeout_lbl.Name = "timeout_lbl";
            this.timeout_lbl.Size = new System.Drawing.Size(81, 12);
            this.timeout_lbl.TabIndex = 37;
            this.timeout_lbl.Text = "timeout(10sec)";
            // 
            // timeout_form
            // 
            this.timeout_form.Location = new System.Drawing.Point(110, 516);
            this.timeout_form.Name = "timeout_form";
            this.timeout_form.Size = new System.Drawing.Size(100, 19);
            this.timeout_form.TabIndex = 36;
            this.timeout_form.Text = "10000";
            this.timeout_form.TextChanged += new System.EventHandler(this.timeout_form_TextChanged);
            // 
            // conToggle_btn
            // 
            this.conToggle_btn.Location = new System.Drawing.Point(112, 576);
            this.conToggle_btn.Name = "conToggle_btn";
            this.conToggle_btn.Size = new System.Drawing.Size(75, 23);
            this.conToggle_btn.TabIndex = 38;
            this.conToggle_btn.Text = "Connect";
            this.conToggle_btn.UseVisualStyleBackColor = true;
            this.conToggle_btn.Click += new System.EventHandler(this.conToggle_btn_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(570, 687);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(713, 203);
            this.logTextBox.TabIndex = 39;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 877);
            this.Controls.Add(this.conToggle_btn);
            this.Controls.Add(this.timeout_lbl);
            this.Controls.Add(this.timeout_form);
            this.Controls.Add(this.flowControl_lbl);
            this.Controls.Add(this.flowControl_comboBox);
            this.Controls.Add(this.parity_lbl);
            this.Controls.Add(this.parity_comboBox);
            this.Controls.Add(this.stopBits_lbl);
            this.Controls.Add(this.stopBits_comboBox);
            this.Controls.Add(this.dataBits_lbl);
            this.Controls.Add(this.dataBits_form);
            this.Controls.Add(this.baudRate_lbl);
            this.Controls.Add(this.baudRate_form);
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
            this.Enabled = false;
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
        private System.Windows.Forms.Label baudRate_lbl;
        private System.Windows.Forms.TextBox baudRate_form;
        private System.Windows.Forms.Label dataBits_lbl;
        private System.Windows.Forms.TextBox dataBits_form;
        private System.Windows.Forms.Label stopBits_lbl;
        private System.Windows.Forms.ComboBox stopBits_comboBox;
        private System.Windows.Forms.Label parity_lbl;
        private System.Windows.Forms.ComboBox parity_comboBox;
        private System.Windows.Forms.Label flowControl_lbl;
        private System.Windows.Forms.ComboBox flowControl_comboBox;
        private System.Windows.Forms.Label timeout_lbl;
        private System.Windows.Forms.TextBox timeout_form;
        private System.Windows.Forms.Button conToggle_btn;
    }
}

