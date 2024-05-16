using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO.Ports;

namespace PAMC_104
{
    public partial class MainForm : Form
    {
        private RS232C rs232c;
        private string[] axis = { "(None)", "Axix1", "Axis2", "Axix3", "Axis4" };
        private StopBits[] stopBits = { StopBits.None, StopBits.One, StopBits.OnePointFive, StopBits.Two };
        private Parity[] parities = { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space };
        private string[] flowControls = { "(None)", "XON/XOFF", "RTS/CTS", "XON/XOFF & RTS/CTS", "DTR/DSR", "XON/XOFF & DTR/DSR" };
        private PortSettings portSettings;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            portSettings = new PortSettings();

            // RS232C用ポート候補
            string[] serialPorts = RS232C.GetPortNames();
            foreach (string port in serialPorts)
            {
                port_ComboBox.Items.Add(port);
            }
            if (port_ComboBox.Items.Count > 0)
                port_ComboBox.SelectedIndex = 0;

            // Axis選択用
            axis_ComboBox.Items.AddRange(axis);
            axis_ComboBox.SelectedIndex = 0;

            // Stop Bits選択用
            stopBits_comboBox.Items.AddRange(stopBits.Select(x => x.ToString()).ToArray());
            stopBits_comboBox.SelectedIndex = 0;

            // Parity選択用
            axis_ComboBox.Items.AddRange(parities.Select(x=> x.ToString()).ToArray());
            axis_ComboBox.SelectedIndex = 0;

            // flow control選択用
            flowControl_comboBox.Items.AddRange(flowControls);
            flowControl_comboBox.SelectedIndex = 0;
        }

        private void plus_btn_Click(object sender, EventArgs e)
        {
            cmdDirection_text.Text = "NR";
        }

        private void minus_btn_Click(object sender, EventArgs e)
        {
            cmdDirection_text.Text = "RR";
        }

        private void frequency_form_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(frequency_form.Text, out int inputVal))
            {
                string result = inputVal.ToString("D4");
                cmdFrequency_text.Text = result;
            }
        }

        private void numOfPulses_form_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(numOfPulses_form.Text, out int inputVal))
            {
                string result = inputVal.ToString("D4");
                cmdNumOfPulses_text.Text = result;
            }
        }

        
        private void excute_btn_Click(object sender, EventArgs e)
        {
            string command = cmdDirection_text.Text + cmdFrequency_text.Text + cmdNumOfPulses_text.Text + cmdPort_text.Text;
            rs232c.Send(command);
        }

        private void axis_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (axis_ComboBox.SelectedItem) 
            {
                case "Axis1":
                    cmdPort_text.Text = "A";
                    break;
                case "Axis2":
                    cmdPort_text.Text = "B";
                    break;
                case "Axis3":
                    cmdPort_text.Text = "C";
                    break;
                case "Axis4":
                    cmdPort_text.Text = "D";
                    break;
                default:
                    cmdPort_text.Text = "";
                    break;

            }
        }

        private void conToggle_btn_Click(object sender, EventArgs e)
        {
            if (conToggle_btn.Text == "Connect")
            {
                // Connectする
                rs232c = new RS232C(serialPort, portSettings);
                rs232c.Open();

                excute_btn.Enabled = true;

                // ボタンの表示を切り替える
                conToggle_btn.Text = "Disconnect";
            } 
            else if (conToggle_btn.Text == "Disconnect")
            {

                excute_btn.Enabled = false;

                // ボタンの表示を切り替える
                conToggle_btn.Text = "Connect";
            }
        }

        private void port_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            portSettings.Name = port_ComboBox.SelectedItem.ToString();
        }

        private void baudRate_form_TextChanged(object sender, EventArgs e)
        {
            try
            {
                portSettings.BaudRate = int.Parse(baudRate_form.Text);
            }
            catch (FormatException ex)
            {
                // 変換に失敗した場合の処理
                // エラーメッセージを表示するなど
            }
        }

        private void dataBits_form_TextChanged(object sender, EventArgs e)
        {
            try
            {
                portSettings.DataBits = int.Parse(dataBits_form.Text);
            }
            catch (FormatException ex)
            {
                // 変換に失敗した場合の処理
                // エラーメッセージを表示するなど
            }
        }

        private void parity_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            portSettings.Parity = parities[parity_comboBox.SelectedIndex];
        }

        private void stopBits_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            portSettings.StopBits = stopBits[stopBits_comboBox.SelectedIndex];
        }

        private void flowControl_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            portSettings.FlowControl = flowControls[flowControl_comboBox.SelectedIndex];
        }

        private void timeout_form_TextChanged(object sender, EventArgs e)
        {
            try
            {
                portSettings.Timeout = int.Parse(timeout_form.Text);
            }
            catch (FormatException ex)
            {
                // 変換に失敗した場合の処理
                // エラーメッセージを表示するなど
            }
        }
    }
}
