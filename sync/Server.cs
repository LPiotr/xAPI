// Decompiled with JetBrains decompiler
// Type: xAPI.Sync.Server
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll


namespace xAPI.Sync
{
  public class Server
  {
    private string address;
    private int mainPort;
    private int streamingPort;
    private string description;
    private bool secure;

    public Server(
      string address,
      int mainPort,
      int streamingPort,
      bool secure,
      string description)
    {
      this.address = address;
      this.mainPort = mainPort;
      this.streamingPort = streamingPort;
      this.secure = secure;
      this.description = description;
    }

    public string Address
    {
      get => this.address;
      set => this.address = value;
    }

    public string Description
    {
      get => this.description;
      set => this.description = value;
    }

    public int MainPort
    {
      get => this.mainPort;
      set => this.mainPort = value;
    }

    public int StreamingPort
    {
      get => this.streamingPort;
      set => this.streamingPort = value;
    }

    public bool Secure
    {
      get => this.secure;
      set => this.secure = value;
    }

    public override string ToString()
    {
      return this.Description + " (" + this.Address + ":" + (object) this.MainPort + "/" + (object) this.StreamingPort + ")";
    }
  }
}
