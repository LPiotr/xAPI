using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class ProfitsSubscribe(string streamSessionId)
    {
        private readonly string streamSessionId = streamSessionId;

        public override string ToString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) "getProfits"
        },
        {
          "streamSessionId",
          (JToken) streamSessionId
        }
      }.ToString();
        }
    }
}
