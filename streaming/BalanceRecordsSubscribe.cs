using Newtonsoft.Json.Linq;


namespace xAPI.Streaming
{
    internal class BalanceRecordsSubscribe
    {
        private string streamSessionId;

        public BalanceRecordsSubscribe(string streamSessionId)
        {
            this.streamSessionId = streamSessionId;
        }

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
          (JToken) this.streamSessionId
        }
      }.ToString();
        }
    }
}
