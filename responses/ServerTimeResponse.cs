// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.ServerTimeResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Responses
{
  public class ServerTimeResponse : BaseResponse
  {
    private long? time;
    private string timeString;

    public ServerTimeResponse(string body)
      : base(body)
    {
      JObject returnData = (JObject) this.ReturnData;
      this.time = (long?) returnData[nameof (time)];
      this.timeString = (string) returnData[nameof (timeString)];
    }

    public virtual long? Time => this.time;

    public virtual string TimeString => this.timeString;
  }
}
