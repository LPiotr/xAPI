using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
    internal class TickPricesSubscribe(
      string symbol,
      string streamSessionId,
      long? minArrivalTime = null,
      long? maxLevel = null)
    {
        private readonly string symbol = symbol;
        private readonly long? minArrivalTime = minArrivalTime;
        private readonly long? maxLevel = maxLevel;
        private readonly string streamSessionId = streamSessionId;

        public override string ToString()
        {
            JObject jobject = new()
            {
                { "command", (JToken)"getTickPrices" },
                { "symbol", (JToken)symbol }
            };
            if (minArrivalTime.HasValue)
                jobject.Add("minArrivalTime", (JToken)minArrivalTime);
            if (maxLevel.HasValue)
                jobject.Add("maxLevel", (JToken)maxLevel);
            jobject.Add("streamSessionId", (JToken)streamSessionId);
            return jobject.ToString();
        }
    }
}
