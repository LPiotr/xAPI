using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class TradeStatusRecordsStop
    {
        public override string ToString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) "stopTradeStatus"
        }
      }.ToString();
        }
    }
}
