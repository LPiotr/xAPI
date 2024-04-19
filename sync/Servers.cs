using System;
using System.Collections.Generic;
using xAPI.Errors;

namespace xAPI.Sync
{
    public static class Servers
    {
        private static readonly PortSet DEMO_PORTS = new(5124, 5125);
        private static readonly PortSet REAL_PORTS = new(5112, 5113);
        private static List<Server> demoServers;
        private static List<Server> realServers;
        private static List<ApiAddress> addresses;

        private static List<ApiAddress> ADDRESSES
        {
            get
            {
                if (addresses == null)
                {
                    addresses =
                    [
                        new ApiAddress("xapi.xtb.com", "xAPI A"),
                        new ApiAddress("xapi.xtb.com", "xAPI B"),
                    ];
                }
                return addresses;
            }
        }

        public static Server DEMO => DEMO_SERVERS[0];

        public static Server REAL => REAL_SERVERS[0];

        public static List<Server> DEMO_SERVERS
        {
            get
            {
                if (Servers.demoServers == null)
                {
                    Servers.demoServers = new List<Server>();
                    foreach (Servers.ApiAddress apiAddress in Servers.ADDRESSES)
                        Servers.demoServers.Add(new Server(apiAddress.Address, Servers.DEMO_PORTS.MainPort, Servers.DEMO_PORTS.StreamingPort, true, apiAddress.Name + " DEMO SSL"));
                    Servers.demoServers.Shuffle<Server>();
                }
                return Servers.demoServers;
            }
        }

        public static List<Server> REAL_SERVERS
        {
            get
            {
                if (realServers == null)
                {
                    realServers = new List<Server>();
                    foreach (ApiAddress apiAddress in Servers.ADDRESSES)
                        realServers.Add(new Server(apiAddress.Address, Servers.REAL_PORTS.MainPort, Servers.REAL_PORTS.StreamingPort, true, apiAddress.Name + " REAL SSL"));
                        realServers.Shuffle();
                }
                return realServers;
            }
        }

        public static Server GetBackup(Server server)
        {
            ApiAddress nextAddress = Servers.GetNextAddress(server.Address);
            return new Server(nextAddress.Address, server.MainPort, server.StreamingPort, server.Secure, nextAddress.Name);
        }

        public static ApiAddress GetNextAddress(string address)
        {
            ADDRESSES.Remove(ADDRESSES.Find(item => item.Address == address) ?? throw new APICommunicationException("Connection error (and no backup server available for " + address + ")"));
            return ADDRESSES.Count > 0 ? ADDRESSES[0] : throw new APICommunicationException("Connection error (and no more backup servers available)");
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            Random random = new Random();
            int count = list.Count;
            while (count > 1)
            {
                --count;
                int index = random.Next(count + 1);
                T obj = list[index];
                list[index] = list[count];
                list[count] = obj;
            }
        }

        public class PortSet
        {
            private int mainPort;
            private int streamingPort;

            public PortSet(int mainPort, int streamingPort)
            {
                this.mainPort = mainPort;
                this.streamingPort = streamingPort;
            }

            public int MainPort => this.mainPort;

            public int StreamingPort => this.streamingPort;
        }

        public class ApiAddress
        {
            private string address;
            private string name;

            public ApiAddress(string address, string name)
            {
                this.address = address;
                this.name = name;
            }

            public string Address => this.address;

            public string Name => this.name;
        }
    }
}
