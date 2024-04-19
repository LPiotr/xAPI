using Newtonsoft.Json.Linq;
using xAPI.Codes;

namespace xAPI.Records
{
  public record ChartLastInfoRecord
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
