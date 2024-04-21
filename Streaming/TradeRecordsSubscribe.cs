using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class TradeRecordsSubscribe(string streamSessionId)
    {
        private string streamSessionId = streamSessionId;

        public override string ToString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) "getTrades"
        },
        {
          "streamSessionId",
          (JToken) streamSessionId
        }
      }.ToString();
        }
    }
}
