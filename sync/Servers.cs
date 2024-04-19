// Decompiled with JetBrains decompiler
// Type: xAPI.Sync.Servers
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using System;
using System.Collections.Generic;
using xAPI.Errors;


namespace xAPI.Sync
{
  public static class Servers
  {
    private static Servers.PortSet DEMO_PORTS = new Servers.PortSet(5124, 5125);
    private static Servers.PortSet REAL_PORTS = new Servers.PortSet(5112, 5113);
    private static List<Server> demoServers;
    private static List<Server> realServers;
    private static List<Servers.ApiAddress> addresses;

    private static List<Servers.ApiAddress> ADDRESSES
    {
      get
      {
        if (Servers.addresses == null)
        {
          Servers.addresses = new List<Servers.ApiAddress>();
          Servers.addresses.Add(new Servers.ApiAddress("xapi.xtb.com", "xAPI A"));
          Servers.addresses.Add(new Servers.ApiAddress("xapi.xtb.com", "xAPI B"));
        }
        return Servers.addresses;
      }
    }

    public static Server DEMO => Servers.DEMO_SERVERS[0];

    public static Server REAL => Servers.REAL_SERVERS[0];

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
        if (Servers.realServers == null)
        {
          Servers.realServers = new List<Server>();
          foreach (Servers.ApiAddress apiAddress in Servers.ADDRESSES)
            Servers.realServers.Add(new Server(apiAddress.Address, Servers.REAL_PORTS.MainPort, Servers.REAL_PORTS.StreamingPort, true, apiAddress.Name + " REAL SSL"));
          Servers.realServers.Shuffle<Server>();
        }
        return Servers.realServers;
      }
    }

    public static Server GetBackup(Server server)
    {
      Servers.ApiAddress nextAddress = Servers.GetNextAddress(server.Address);
      return new Server(nextAddress.Address, server.MainPort, server.StreamingPort, server.Secure, nextAddress.Name);
    }

    public static Servers.ApiAddress GetNextAddress(string address)
    {
      Servers.ADDRESSES.Remove(Servers.ADDRESSES.Find((Predicate<Servers.ApiAddress>) (item => item.Address == address)) ?? throw new APICommunicationException("Connection error (and no backup server available for " + address + ")"));
      return Servers.ADDRESSES.Count > 0 ? Servers.ADDRESSES[0] : throw new APICommunicationException("Connection error (and no more backup servers available)");
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
