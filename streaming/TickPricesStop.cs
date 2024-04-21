using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class TickPricesStop(string symbol)
    {
        private string symbol = symbol;

        public override string ToString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) "stopTickPrices"
        },
        {
          "symbol",
          (JToken) symbol
        }
      }.ToString();
        }
    }
}
