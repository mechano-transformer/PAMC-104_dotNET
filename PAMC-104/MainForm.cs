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
        private Parity[] prities = { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space };
        private string[] flowControls = { "(None)", "XON/XOFF", "RTS/CTS", "XON/XOFF & RTS/CTS", "DTR/DSR", "XON/XOFF & DTR/DSR" };


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            rs232c = new RS232C(serialPort);

            // RS232C用ポート候補
            foreach (string port in rs232c.ports)
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
            axis_ComboBox.Items.AddRange(prities.Select(x=> x.ToString()).ToArray());
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
                numOfPulses_form.Text = result;
            }
        }

        
        private void excute_btn_Click(object sender, EventArgs e)
        {
            string command = cmdDirection_text.Text + cmdFrequency_text.Text + cmdNumOfPulses_text.Text;
            rs232c.send(command);
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

                // ボタンの表示を切り替える
                conToggle_btn.Text = "Disconnect";
            } 
            else if (conToggle_btn.Text == "Disconnect")
            {

                // ボタンの表示を切り替える
                conToggle_btn.Text = "Connect";
            }
        }
    }
}
