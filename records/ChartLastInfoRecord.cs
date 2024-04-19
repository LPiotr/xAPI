// Decompiled with JetBrains decompiler
// Type: xAPI.Records.ChartLastInfoRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using xAPI.Codes;


namespace xAPI.Records
{
  public class ChartLastInfoRecord
  {
    private string symbol;
    private PERIOD_CODE period;
    private long? start;

    public ChartLastInfoRecord(string symbol, PERIOD_CODE period, long? start)
    {
      this.symbol = symbol;
      this.period = period;
      this.start = start;
    }

    public virtual JObject toJSONObject()
    {
      return new JObject()
      {
        {
          "symbol",
          (JToken) this.symbol
        },
        {
          "period",
          (JToken) new long?(this.period.Code)
        },
        {
          "start",
          (JToken) this.start
        }
      };
    }
  }
}
