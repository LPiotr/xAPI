// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.TradesHistoryResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;


namespace xAPI.Responses
{
  public class TradesHistoryResponse : BaseResponse
  {
    private LinkedList<TradeRecord> tradeRecords = new LinkedList<TradeRecord>();

    public TradesHistoryResponse(string body)
      : base(body)
    {
      foreach (JObject jobject in (IEnumerable<JToken>) this.ReturnData)
      {
        TradeRecord tradeRecord = new TradeRecord();
        tradeRecord.FieldsFromJSONObject(jobject);
        this.tradeRecords.AddLast(tradeRecord);
      }
    }

    public virtual LinkedList<TradeRecord> TradeRecords => this.tradeRecords;
  }
}
