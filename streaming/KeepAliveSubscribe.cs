using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class KeepAliveSubscribe(string streamSessionId)
    {
        private string streamSessionId = streamSessionId;

        public override string ToString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) "getKeepAlive"
        },
        {
          "streamSessionId",
          (JToken) streamSessionId
        }
      }.ToString();
        }
    }
}
