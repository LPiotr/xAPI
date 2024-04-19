// Decompiled with JetBrains decompiler
// Type: xAPI.Records.RedirectRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Records
{
  public class RedirectRecord : BaseResponseRecord
  {
    private int mainPort;
    private int streamingPort;
    private string address;

    public void FieldsFromJSONObject(JObject value)
    {
      this.mainPort = (int) value["mainPort"];
      this.streamingPort = (int) value["streamingPort"];
      this.address = (string) value["address"];
    }

    public int MainPort => this.mainPort;

    public int StreamingPort => this.streamingPort;

    public string Address => this.address;

    public override string ToString()
    {
      return "RedirectRecord [mainPort=" + (object) this.mainPort + ", streamingPort=" + (object) this.streamingPort + ", address=" + this.address + "]";
    }
  }
}
