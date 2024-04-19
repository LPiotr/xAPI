// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.ChartLastResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;


namespace xAPI.Responses
{
  public class ChartLastResponse : BaseResponse
  {
    private long? digits;
    private LinkedList<RateInfoRecord> rateInfos = new LinkedList<RateInfoRecord>();

    public ChartLastResponse(string body)
      : base(body)
    {
      JObject returnData = (JObject) this.ReturnData;
      this.digits = (long?) returnData[nameof (digits)];
      foreach (JObject jobject in (IEnumerable<JToken>) returnData[nameof (rateInfos)])
      {
        RateInfoRecord rateInfoRecord = new RateInfoRecord();
        rateInfoRecord.FieldsFromJSONObject(jobject);
        this.rateInfos.AddLast(rateInfoRecord);
      }
    }

    public virtual long? Digits => this.digits;

    public virtual LinkedList<RateInfoRecord> RateInfos => this.rateInfos;
  }
}
