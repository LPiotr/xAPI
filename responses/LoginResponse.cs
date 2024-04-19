// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.LoginResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using xAPI.Records;


namespace xAPI.Responses
{
  public class LoginResponse : BaseResponse
  {
    private string streamSessionId;
    private RedirectRecord redirectRecord;

    public LoginResponse(string body)
      : base(body)
    {
      JObject jobject1 = JObject.Parse(body);
      this.streamSessionId = (string) jobject1[nameof (streamSessionId)];
      JObject jobject2 = (JObject) jobject1["redirect"];
      if (jobject2 == null)
        return;
      this.redirectRecord = new RedirectRecord();
      this.redirectRecord.FieldsFromJSONObject(jobject2);
    }

    public virtual string StreamSessionId => this.streamSessionId;

    public virtual RedirectRecord RedirectRecord => this.redirectRecord;
  }
}
