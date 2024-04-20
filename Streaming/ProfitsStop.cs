using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class ProfitsStop
    {
        public override string ToString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) "stopProfits"
        }
      }.ToString();
        }
    }
}
