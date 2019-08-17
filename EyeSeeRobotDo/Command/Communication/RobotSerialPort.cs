using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Communication
{
    class RobotSerialPort : ISerialPort
    {
        public string Port { get; set; }

        public RobotSerialPort(string port)
        {
            Port = port;
        }

        public string Read()
        {
            throw new NotImplementedException();
        }

        public bool Send(string message)
        {
            throw new NotImplementedException();
        }
    }
}
