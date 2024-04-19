using Newtonsoft.Json.Linq;
using xAPI.Codes;

namespace xAPI.Records
{
  public class ChartRangeInfoRecord
  {
    private string symbol;
    private PERIOD_CODE period;
    private long? start;
    private long? end;
    private long? ticks;

    public ChartRangeInfoRecord(
      string symbol,
      PERIOD_CODE period,
      long? start,
      long? end,
      long? ticks)
    {
      this.symbol = symbol;
      this.period = period;
      this.start = start;
      this.end = end;
      this.ticks = ticks;
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
        },
        {
          "end",
          (JToken) this.end
        },
        {
          "ticks",
          (JToken) this.ticks
        }
      };
    }
  }
}
