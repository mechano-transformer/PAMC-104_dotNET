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
    public class RS232C
    {
        string[] ports;
        SerialPort _serialPort;
        string DELIMITER = "\r\n";

        public RS232C(SerialPort serialPort)
        {
            // ポート情報を初期化
            ports = SerialPort.GetPortNames();
            _serialPort = serialPort;
            _serialPort.PortName = ports[0];
            _serialPort.PortName = ports[0];
            _serialPort.BaudRate = 9600;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;

            // ポートオープン
            open();
        }

        // ポートオープン
        private void open()
        {
            // 既にポートが開いてるときは何もしない
            if (_serialPort.IsOpen) return;

            try
            {
                _serialPort.Open();
            }
            catch (Exception ex)
            {

            }
        }

        // ポートを閉じる
        private void close()
        {
            if (_serialPort.IsOpen == true) _serialPort.Close();
        }

        // RS232C経由で情報を送信
        public void send(string content)
        {
            _serialPort.NewLine = DELIMITER;
            try
            {
                System.Console.WriteLine(content); // とりあえず動作検証用にコンソール出力
                // _serialPort.Write(content); // 本チャンはこうやってRS232C経由で書きこむ
            }
            catch (Exception ex) 
            {

            }
        }

        // RS232C経由で情報を受信
        public void receive(object sender, SerialDataReceivedEventArgs e)
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
            close();
        }
    }
}
