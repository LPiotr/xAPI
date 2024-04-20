using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class ProfitsSubscribe
    {
        private string streamSessionId;

        public ProfitsSubscribe(string streamSessionId) => this.streamSessionId = streamSessionId;

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
          (JToken) this.streamSessionId
        }
      }.ToString();
        }
    }
}
