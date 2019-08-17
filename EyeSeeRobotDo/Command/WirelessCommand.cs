using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class WirelessCommand : BaseCommand
    {
        public String HostName { get; private set; }
        public WirelessCommand(String hostname)
        {
            HostName = hostname;
            type = CommandType.Wireless;
        }

        public override string StatusCheck()
        {
            return HostName + "/";
        }

        public override string MoveFingers(int[] fingers, bool hold)
        {
            string result = String.Format("{0}/move?fingers=", HostName);
            int fingerResult = 0;

            for (int i = 0; i < fingers.Length; i++)
            {
                if (fingers[i] == 1)
                    fingerResult += fingers[i] << i;
            }

            result += String.Format("{0}&hold={1}", fingerResult, hold.ToString().ToLower());
            return result;
        }
    }
}
