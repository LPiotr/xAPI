using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class CandleRecordsSubscribe(string symbol, string streamSessionId)
    {
        private readonly string symbol = symbol;
        private readonly string streamSessionId = streamSessionId;

        public override string ToString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) "getCandles"
        },
        {
          "streamSessionId",
          (JToken) streamSessionId
        },
        {
          "symbol",
          (JToken) symbol
        }
      }.ToString();
        }
    }
}
