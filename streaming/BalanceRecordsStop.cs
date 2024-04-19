using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
  internal class BalanceRecordsStop
  {
    public override string ToString()
    {
      return new JObject()
      {
        {
          "command",
          (JToken) "stopBalance"
        }
      }.ToString();
    }
  }
}
