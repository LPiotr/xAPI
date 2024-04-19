using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
  internal class TickPricesStop
  {
    private string symbol;

    public TickPricesStop(string symbol) => this.symbol = symbol;

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
          (JToken) this.symbol
        }
      }.ToString();
    }
  }
}
