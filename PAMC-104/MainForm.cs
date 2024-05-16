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

namespace PAMC_104
{
    public partial class MainForm : Form
    {
        private RS232C rs232c;
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
            string[] axis = { "(Choose)", "Axix1", "Axis2", "Axix3", "Axis4" };
            axis_ComboBox.Items.AddRange(axis);
            axis_ComboBox.SelectedIndex = 0;
            
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
    }
}
