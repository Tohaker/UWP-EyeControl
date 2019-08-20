using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Communication
{
    public interface ISerialPort
    {
        void Send(string message);
        string Read();
        string Port { get; set; }
    }
}
