using System;
using System.Collections.Generic;
using System.Text;

namespace Command
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
            int result = 0;

            for (int i = 0; i < fingers.Length; i++)
            {
                if (fingers[i] == 1)
                    result += fingers[i] << i;
            }

            if (hold)
                result += 1 << 4;

            return result.ToString();
        }
    }
}
