using Newtonsoft.Json.Linq;


namespace xAPI.Streaming
{
    internal class BalanceRecordsSubscribe(string streamSessionId)
    {
        private string streamSessionId = streamSessionId;

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
