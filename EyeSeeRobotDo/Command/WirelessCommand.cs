using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Command
{
    public class WirelessCommand : BaseCommand
    {
        public string HostName { get; private set; }
        public HttpClient client { get; private set; }
        public WirelessCommand(string hostname)
        {
            HostName = hostname;
            type = CommandType.Wireless;
        }

        public override string StatusCheck()
        {
            return "http://" + HostName + "/";
        }

        public override string MoveFingers(int[] fingers, bool hold)
        {
            string result = String.Format("http://{0}/move?fingers=", HostName);
            int fingerResult = 0;

            for (int i = 0; i < fingers.Length; i++)
            {
                if (fingers[i] == 1)
                    fingerResult += fingers[i] << i;
            }

            result += String.Format("{0}&hold={1}", fingerResult, hold.ToString().ToLower());
            return result;
        }

        public async Task<Dictionary<string, string>> Request(string url)
        {
            Dictionary<string, string> response = new Dictionary<string, string>();
            if (client == null)
                client = new HttpClient();
            HttpResponseMessage httpResponse = await client.GetAsync(url);
            
            if (httpResponse.IsSuccessStatusCode)
                response = JsonConvert.DeserializeObject<Dictionary<string, string>>(httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult());

            return response;
        }
    }
}
