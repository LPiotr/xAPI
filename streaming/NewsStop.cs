using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
  internal class NewsStop
  {
    public override string ToString()
    {
      return new JObject()
      {
        {
          "command",
          (JToken) "stopNews"
        }
      }.ToString();
    }
  }
}
