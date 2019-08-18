using System;
using System.IO.Ports;

namespace Command.Communication
{
    class RobotSerialPort : ISerialPort
    {
        public string Port { get; set; }
        public SerialPort serialPort { get; private set; }

        public RobotSerialPort(string port)
        {
            Port = port;
            serialPort = new SerialPort(Port, 9600);
        }

        public string Read()
        {
            return serialPort.ReadExisting();
        }

        public void Send(string message)
        {
            serialPort.WriteLine(message);
        }
    }
}
