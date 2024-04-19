// Decompiled with JetBrains decompiler
// Type: xAPI.Records.StreamingKeepAliveRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Records
{
  public class StreamingKeepAliveRecord : BaseResponseRecord
  {
    public long? Timestamp { get; set; }

    public void FieldsFromJSONObject(JObject value) => this.Timestamp = (long?) value["timestamp"];

    public override string ToString()
    {
      return "StreamingKeepAliveRecord{timestamp=" + (object) this.Timestamp + (object) '}';
    }
  }
}
