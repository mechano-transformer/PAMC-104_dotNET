using System;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PAMC_104
{
    public partial class MainForm : Form
    {
        private RS232C rs232c;
        private string[] axis = { "None", "Axis1", "Axis2", "Axis3", "Axis4" };
        private PortSettings portSettings;
        private Logger _logger;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _logger = Logger.GetInstance;
            SetExcuteButtonEnable(false);

            portSettings = new PortSettings();

            // RS232C用ポート候補
            string[] ports = RS232C.GetPortNames();
            if (ports.Length > 0)
            {
                foreach (string port in ports)
                {
                    port_ComboBox.Items.Add(port);
                }
            }
            if (port_ComboBox.Items.Count > 0)
                port_ComboBox.SelectedIndex = 0;

            // Axis選択用
            axis_ComboBox.Items.AddRange(axis);
            axis_ComboBox.SelectedIndex = 0;

            // Stop Bits選択用
            stopBits_comboBox.Items.AddRange(RS232C.STOP_BITS.Select(x => x.ToString()).ToArray());
            stopBits_comboBox.SelectedIndex = 0;

            // Parity選択用
            parity_comboBox.Items.AddRange(RS232C.PARITIES.Select(x => x.ToString()).ToArray());
            parity_comboBox.SelectedIndex = 0;

            // flow control選択用
            flowControl_comboBox.Items.AddRange(RS232C.FLOW_CONTROLS);
            flowControl_comboBox.SelectedIndex = 0;

            // アプリ名やアプリのバージョンなどのメタ情報
            AssemblyName assembly = Assembly.GetExecutingAssembly().GetName();
            Version ver = assembly.Version;
            verInfo_text.Text = $"{ver.Major}.{ver.Minor}.{ver.Build}.{ver.Revision}";
            _logger.Notice("Main loaded.");
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


        private async void excute_btn_Click(object sender, EventArgs e)
        {
            DisableAllButtons();
            string command = cmdDirection_text.Text + cmdFrequency_text.Text + cmdNumOfPulses_text.Text + cmdPort_text.Text;
            await rs232c.Send(command);

            await Task.Delay(3000);

            // コマンド実行終了したら明示的にストップする
            // TODO: タイマーを入れるべきか検討
            ExcuteStopCommand(); 

            SetStatusMessage("Sent command successfully.");
            EnableAllButtons();
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
                try
                {
                    SetPortSettings();
                    rs232c = new RS232C(serialPort, portSettings);
                    rs232c.Open();
                }
                catch (Exception ex)
                {
                    SetStatusMessage("Failed to connect.", true);
                    return;
                }

                // コマンド実行ボタンの有効化
                SetExcuteButtonEnable(true);
                // ボタンの表示を切り替える
                conToggle_btn.Text = "Disconnect";
                SetStatusMessage("Connected successfully.");
            }
            else if (conToggle_btn.Text == "Disconnect")
            {
                try
                {
                    rs232c.Close();
                }
                catch (Exception ex)
                {
                    SetStatusMessage("Failed to disconnect.", true);
                    return;
                }

                SetExcuteButtonEnable(false);


                // ボタンの表示を切り替える
                conToggle_btn.Text = "Connect";
                SetStatusMessage("Disconnected successfully.");
            }
        }

        /// <summary>
        /// ログを GUI 上に追加表示
        /// logTextBoxへのアクセサメソッド
        /// バッググラウンドスレッドからの実行はデフォルト許可されないので
        /// 専用のUIスレッドを立てて実行するようにする
        /// </summary>
        /// <param name="text">表示するテキスト</param>
        public void AppendGUILog(string text)
        {
            if (logTextBox.InvokeRequired)
            {
                logTextBox.Invoke((Action)(() =>
                {
                    logTextBox.AppendText($"{text}\r\n");
                }));
            }
            else
            {
                logTextBox.AppendText($"{text}\r\n");
            }
        }

        private void SetStatusMessage(string text, bool isError = false)
        {
            statusIndicator_text.Text = text;
            if (isError)
            {
                _logger.Error(text);
            } else
            {
                _logger.Notice(text);
            }
        }

        private void SetExcuteButtonEnable(bool activate)
        {
            excute_btn.Enabled = activate;
        }

        // STOP用のコマンドを実行する
        private void stop_btn_Click(object sender, EventArgs e)
        {
            ExcuteStopCommand();
        }

        private async void ExcuteStopCommand()
        {
            // コマンド：「S]を送ればストップできる
            await rs232c.Send("S");
        }

        private void DisableAllButtons()
        {
            conToggle_btn.Enabled = false;
            excute_btn.Enabled= false;
            plus_btn.Enabled= false;
            minus_btn.Enabled = false;

        }
        private void EnableAllButtons()
        {
            conToggle_btn.Enabled = true;
            excute_btn.Enabled = true;
            plus_btn.Enabled = true;
            minus_btn.Enabled = true;

        }

        private void SetPortSettings()
        {
            portSettings.Name = port_ComboBox.SelectedItem.ToString();
            portSettings.BaudRate = int.Parse(baudRate_form.Text);
            portSettings.DataBits = int.Parse(dataBits_form.Text);
            portSettings.Parity = RS232C.PARITIES[parity_comboBox.SelectedIndex];
            portSettings.StopBits = RS232C.STOP_BITS[stopBits_comboBox.SelectedIndex];
            portSettings.FlowControl = RS232C.FLOW_CONTROLS[flowControl_comboBox.SelectedIndex];
            portSettings.Timeout = int.Parse(timeout_form.Text);
        }

        private void frequency_form_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsSkipKeyInput(frequency_form, e);
        }

        private void numOfPulses_form_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsSkipKeyInput(numOfPulses_form, e);
        }

        private bool IsSkipKeyInput(System.Windows.Forms.TextBox textBox, KeyPressEventArgs e)
        {
            // 数字以外のキーは無視する
            // ４文字を超えるキー入力も受け付けない
            // ただしBackSpaceキー等の制御キーは受け付ける
            return ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || (textBox.Text.Length >= 4 && !char.IsControl(e.KeyChar)));
        }
    }
}
