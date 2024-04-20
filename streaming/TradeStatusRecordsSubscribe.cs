using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class TradeStatusRecordsSubscribe
    {
        private string streamSessionId;

        public TradeStatusRecordsSubscribe(string streamSessionId)
        {
            this.streamSessionId = streamSessionId;
        }

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
          (JToken) this.streamSessionId
        }
      }.ToString();
        }
    }
}
