using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class TradeRecordsSubscribe
    {
        private string streamSessionId;

        public TradeRecordsSubscribe(string streamSessionId) => this.streamSessionId = streamSessionId;

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
          (JToken) this.streamSessionId
        }
      }.ToString();
        }
    }
}
