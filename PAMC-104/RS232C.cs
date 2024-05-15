using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAMC_104
{
    public class RS232C
    {
        string[] ports;

        public RS232C(SerialPort serialPort)
        {
            ports = SerialPort.GetPortNames();
            serialPort.PortName = ports[0];
            serialPort.PortName = ports[0];
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.StopBits = System.IO.Ports.StopBits.One;
            serialPort.Parity = System.IO.Ports.Parity.None;
        }
    }
}
