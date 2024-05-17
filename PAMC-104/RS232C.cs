using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAMC_104
{
    public class PortSettings
    {
        public string Name { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public Parity Parity { get; set; }
        public StopBits StopBits { get; set; }
        public string FlowControl { get; set; }
        public int Timeout { get; set; }

    }

    public class RS232C
    {
        public string[] ports;
        SerialPort _serialPort;
        string DELIMITER = "\r\n";
        private static Logger _logger = new Logger();

        public RS232C(SerialPort serialPort, PortSettings portSettings)
        {
            try
            {
                // ポート情報を初期化
                _serialPort = serialPort;
                _serialPort.PortName = portSettings.Name;
                _serialPort.BaudRate = portSettings.BaudRate;
                _serialPort.DataBits = portSettings.DataBits;
                _serialPort.Parity = portSettings.Parity;
                _serialPort.StopBits = portSettings.StopBits;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static string[] GetPortNames()
        {
            _logger.Error("test");
            return SerialPort.GetPortNames();
        }

        // ポートオープン
        public void Open()
        {
            // 既にポートが開いてるときは何もしない
            if (_serialPort.IsOpen) return;

            try
            {
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ポートを閉じる
        public void Close()
        {
            if (_serialPort.IsOpen == true) _serialPort.Close();
        }

        // RS232C経由で情報を送信
        public void Send(string content)
        {
            _serialPort.NewLine = DELIMITER;
            try
            {
                MessageBox.Show(content);
                System.Console.WriteLine(content); // とりあえず動作検証用にコンソール出力
                // _serialPort.Write(content); // 本チャンはこうやってRS232C経由で書きこむ
            }
            catch (Exception ex)
            {

            }
        }

        // RS232C経由で情報を受信
        public void Receive(object sender, SerialDataReceivedEventArgs e)
        {
            string dataReceived = "";
            try
            {
                dataReceived = _serialPort.ReadLine();
                MessageBox.Show(dataReceived);

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message); 一応これダイアログ出るね
            }

            // ポートを閉じる
            Close();
        }
    }
}
