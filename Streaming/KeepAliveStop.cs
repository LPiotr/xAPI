using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class KeepAliveStop
    {
        public override string ToString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) "stopKeepAlive"
        }
      }.ToString();
        }
    }
}
