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
        public bool isPortConnected = false;
        public string[] ports;
        SerialPort _serialPort;
        string DELIMITER = "\r\n";
        private  Logger _logger;

        public RS232C(SerialPort serialPort, PortSettings portSettings)
        {
            _logger = Logger.GetInstance;
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
                isPortConnected = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }

        // ポートを閉じる
        public void Close()
        {
            isPortConnected = false;
            _serialPort.Close();
        }

        // RS232C経由で情報を送信
        public Task Send(string content)
        {
            _serialPort.NewLine = DELIMITER;
            try
            {
                _serialPort.Write(content); // 本チャンはこうやってRS232C経由で書きこむ
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _logger.Error(ex.Message);
            }
            return Task.CompletedTask;
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
                _logger.Error(ex.Message);
            }

            // ポートを閉じる
            Close();
        }
    }
}
