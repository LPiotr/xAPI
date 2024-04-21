using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class NewsSubscribe(string streamSessionId)
    {
        private string streamSessionId = streamSessionId;

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
