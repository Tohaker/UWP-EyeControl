using System;
using System.Collections.Generic;
using System.Text;

namespace Communication
{
    public class SerialCommand : BaseCommand
    {
        public string SerialPort { get; private set; }
        public SerialCommand(string port)
        {
            type = CommandType.Serial;
            SerialPort = port;

        }
        public override string StatusCheck()
        {
            return "0";
        }

        public override string MoveFingers(int[] fingers, bool hold)
        {
            throw new NotImplementedException();
        }
    }
}
