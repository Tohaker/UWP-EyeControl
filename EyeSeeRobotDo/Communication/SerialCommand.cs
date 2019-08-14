using System;
using System.Collections.Generic;
using System.Text;

namespace Communication
{
    public class SerialCommand : BaseCommand
    {
        public String SerialPort { get; private set; }
        public SerialCommand(String port)
        {
            type = CommandType.Serial;
            SerialPort = port;

        }
        public override string StatusCheck()
        {
            return "0";
        }
    }
}
