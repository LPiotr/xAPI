using Newtonsoft.Json.Linq;

namespace xAPI.Streaming
{
  internal class KeepAliveSubscribe
  {
    private string streamSessionId;

    public KeepAliveSubscribe(string streamSessionId) => this.streamSessionId = streamSessionId;

    public override string ToString()
    {
      return new JObject()
      {
        {
          "command",
          (JToken) "getKeepAlive"
        },
        {
          "streamSessionId",
          (JToken) this.streamSessionId
        }
      }.ToString();
    }
  }
}
