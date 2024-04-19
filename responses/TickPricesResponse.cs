// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.TickPricesResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;


namespace xAPI.Responses
{
  public class TickPricesResponse : BaseResponse
  {
    private LinkedList<TickRecord> ticks = new LinkedList<TickRecord>();

    public TickPricesResponse(string body)
      : base(body)
    {
      foreach (JObject jobject in (IEnumerable<JToken>) ((JObject) this.ReturnData)["quotations"])
      {
        TickRecord tickRecord = new TickRecord();
        tickRecord.FieldsFromJSONObject(jobject);
        this.ticks.AddLast(tickRecord);
      }
    }

    public virtual LinkedList<TickRecord> Ticks => this.ticks;
  }
}
