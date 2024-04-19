using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
  internal class CandleRecordsSubscribe
  {
    private string symbol;
    private string streamSessionId;

    public CandleRecordsSubscribe(string symbol, string streamSessionId)
    {
      this.streamSessionId = streamSessionId;
      this.symbol = symbol;
    }

    public override string ToString()
    {
      return new JObject()
      {
        {
          "command",
          (JToken) "getCandles"
        },
        {
          "streamSessionId",
          (JToken) this.streamSessionId
        },
        {
          "symbol",
          (JToken) this.symbol
        }
      }.ToString();
    }
  }
}
