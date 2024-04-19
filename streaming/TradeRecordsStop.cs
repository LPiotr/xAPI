using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
  internal class TradeRecordsStop
  {
    public override string ToString()
    {
      return new JObject()
      {
        {
          "command",
          (JToken) "stopTrades"
        }
      }.ToString();
    }
  }
}
