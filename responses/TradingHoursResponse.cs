// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.TradingHoursResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;


namespace xAPI.Responses
{
  public class TradingHoursResponse : BaseResponse
  {
    private LinkedList<TradingHoursRecord> tradingHoursRecords = new LinkedList<TradingHoursRecord>();

    public TradingHoursResponse(string body)
      : base(body)
    {
      foreach (JObject jobject in (IEnumerable<JToken>) this.ReturnData)
      {
        TradingHoursRecord tradingHoursRecord = new TradingHoursRecord();
        tradingHoursRecord.FieldsFromJSONObject(jobject);
        this.tradingHoursRecords.AddLast(tradingHoursRecord);
      }
    }

    public virtual LinkedList<TradingHoursRecord> TradingHoursRecords => this.tradingHoursRecords;
  }
}
