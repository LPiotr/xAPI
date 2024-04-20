using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class CandleRecordsStop
    {
        private string symbol;

        public CandleRecordsStop(string symbol) => this.symbol = symbol;

        public override string ToString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) "stopCandles"
        },
        {
          "symbol",
          (JToken) this.symbol
        }
      }.ToString();
        }
    }
}
