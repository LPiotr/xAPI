using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
  public class StreamingKeepAliveRecord : BaseResponseRecord
  {
    public long? Timestamp { get; set; }

    public void FieldsFromJSONObject(JObject value) => this.Timestamp = (long?) value["timestamp"];

    public override string ToString()
    {
      return "StreamingKeepAliveRecord{timestamp=" + (object) this.Timestamp + (object) '}';
    }
  }
}
