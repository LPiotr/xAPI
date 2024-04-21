using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class NewsSubscribe(string streamSessionId)
    {
        private readonly string streamSessionId = streamSessionId;

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
          (JToken) streamSessionId
        }
      }.ToString();
        }
    }
}
