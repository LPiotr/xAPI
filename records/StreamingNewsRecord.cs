// Decompiled with JetBrains decompiler
// Type: xAPI.Records.StreamingNewsRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Records
{
  public class StreamingNewsRecord : BaseResponseRecord
  {
    public string Body { get; set; }

    public string Key { get; set; }

    public long? Time { get; set; }

    public string Title { get; set; }

    public void FieldsFromJSONObject(JObject value)
    {
      this.Body = (string) value["body"];
      this.Key = (string) value["key"];
      this.Time = (long?) value["time"];
      this.Title = (string) value["title"];
    }
  }
}
