using Newtonsoft.Json.Linq;
using xAPI.Codes;

namespace xAPI.Records
{
    public record ChartLastInfoRecord
    {
        private readonly string symbol;
        private readonly PERIOD_CODE period;
        private readonly long? start;

        public ChartLastInfoRecord(string symbol, PERIOD_CODE period, long? start)
        {
            this.symbol = symbol;
            this.period = period;
            this.start = start;
        }

        public virtual JObject ToJSONObject()
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
        }
      };
        }
    }
}
