using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class CandleRecordsSubscribe(string symbol, string streamSessionId)
    {
        private string symbol = symbol;
        private string streamSessionId = streamSessionId;

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
