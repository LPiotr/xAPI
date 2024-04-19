// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.VersionResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Responses
{
  public class VersionResponse : BaseResponse
  {
    private string version;

    public VersionResponse(string body)
      : base(body)
    {
      this.version = (string) ((JObject) this.ReturnData)[nameof (version)];
    }

    public virtual string Version => this.version;
  }
}
