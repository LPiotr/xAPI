using System;
using System.Collections.Generic;

namespace xAPI.Sync
{
    [Obsolete("Use Servers class instead")]
    public class ServerData
    {
        private static readonly string XAPI_A = "xapi.xtb.com";
        private static readonly string XAPI_B = "xapi.xtb.com";
        private static readonly int[] PORTS_REAL =
        [
      5112,
      5113
        ];
        private static readonly int[] PORTS_DEMO =
        [
      5124,
      5125
        ];
        private static Dictionary<string, string> xapiList;

        public ServerData() => SetUpList();

        private static void SetUpList()
        {
            ServerData.xapiList = new Dictionary<string, string>
            {
                { "A", ServerData.XAPI_A },
                { "B", ServerData.XAPI_B }
            };
        }

        public static Dictionary<string, Server> ProductionServers
        {
            get
            {
                return AddServers(AddServers([], ServerData.PORTS_DEMO, "DEMO"), PORTS_REAL, "REAL");
            }
        }

        private static Dictionary<string, Server> AddServers(
          Dictionary<string, Server> dict,
          int[] portsArray,
          string desc)
        {
            if (ServerData.xapiList == null)
                ServerData.SetUpList();
            int ports1 = portsArray[0];
            int ports2 = portsArray[1];
            foreach (string key1 in ServerData.xapiList.Keys)
            {
                string xapi = ServerData.xapiList[key1];
                string key2 = "XSERVER_" + desc + "_" + key1;
                string description = "xServer " + desc + " " + key1;
                dict.Add(key2, new Server(xapi, ports1, ports2, true, description));
            }
            return dict;
        }
    }
}
