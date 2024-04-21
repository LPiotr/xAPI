using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class CandleRecordsStop(string symbol)
    {
        private readonly string symbol = symbol;

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
          (JToken) symbol
        }
      }.ToString();
        }
    }
}
