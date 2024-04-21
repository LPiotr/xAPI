using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class TradeStatusRecordsSubscribe(string streamSessionId)
    {
        private readonly string streamSessionId = streamSessionId;

        public override string ToString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) "getTradeStatus"
        },
        {
          "streamSessionId",
          (JToken) streamSessionId
        }
      }.ToString();
        }
    }
}
