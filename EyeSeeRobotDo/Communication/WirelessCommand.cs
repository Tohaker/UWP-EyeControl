using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
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
    }
}
