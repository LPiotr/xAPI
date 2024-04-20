using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class NewsSubscribe
    {
        private string streamSessionId;

        public NewsSubscribe(string streamSessionId) => this.streamSessionId = streamSessionId;

        public override string ToString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) "getNews"
        },
        {
          "streamSessionId",
          (JToken) this.streamSessionId
        }
      }.ToString();
        }
    }
}
