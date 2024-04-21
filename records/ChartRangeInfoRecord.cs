using Newtonsoft.Json.Linq;
using xAPI.Codes;

namespace xAPI.Records
{
    public record ChartRangeInfoRecord
    {
        private readonly string symbol;
        private readonly PERIOD_CODE period;
        private readonly long? start;
        private readonly long? end;
        private readonly long? ticks;

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
          (JToken) symbol
        },
        {
          "period",
          (JToken) new long?(period.Code)
        },
        {
          "start",
          (JToken) start
        },
        {
          "end",
          (JToken) end
        },
        {
          "ticks",
          (JToken) ticks
        }
      };
        }
    }
}
