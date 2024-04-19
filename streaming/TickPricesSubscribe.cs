using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
  internal class TickPricesSubscribe
  {
    private string symbol;
    private long? minArrivalTime;
    private long? maxLevel;
    private string streamSessionId;

    public TickPricesSubscribe(
      string symbol,
      string streamSessionId,
      long? minArrivalTime = null,
      long? maxLevel = null)
    {
      this.symbol = symbol;
      this.minArrivalTime = minArrivalTime;
      this.streamSessionId = streamSessionId;
      this.maxLevel = maxLevel;
    }

    public override string ToString()
    {
      JObject jobject = new JObject();
      jobject.Add("command", (JToken) "getTickPrices");
      jobject.Add("symbol", (JToken) this.symbol);
      if (this.minArrivalTime.HasValue)
        jobject.Add("minArrivalTime", (JToken) this.minArrivalTime);
      if (this.maxLevel.HasValue)
        jobject.Add("maxLevel", (JToken) this.maxLevel);
      jobject.Add("streamSessionId", (JToken) this.streamSessionId);
      return jobject.ToString();
    }
  }
}
