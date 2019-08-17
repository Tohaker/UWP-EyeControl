using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Communication
{
    public interface ISerialPort
    {
        bool Send(string message);
        string Read();
        string Port { get; set; }
    }
}
