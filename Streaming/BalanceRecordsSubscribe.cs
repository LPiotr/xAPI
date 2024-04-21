using Newtonsoft.Json.Linq;


namespace xAPI.Streaming
{
    internal class BalanceRecordsSubscribe(string streamSessionId)
    {
        private readonly string streamSessionId = streamSessionId;

        public override string ToString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) "getBalance"
        },
        {
          "streamSessionId",
          (JToken) streamSessionId
        }
      }.ToString();
        }
    }
}
