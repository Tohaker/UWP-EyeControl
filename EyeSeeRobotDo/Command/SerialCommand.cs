using Command.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    public class SerialCommand : BaseCommand
    {
        public ISerialPort SerialPort { get; private set; }
        public SerialCommand(ISerialPort port)
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

        public bool Send(string message)
        {
            try
            {
                SerialPort.Send(message);
                return true;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public string Read()
        {
            try
            {
                string response = SerialPort.Read();
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }
    }
}
