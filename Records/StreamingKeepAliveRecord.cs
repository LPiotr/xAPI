using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
    public record StreamingKeepAliveRecord : BaseResponseRecord
    {
        public long? Timestamp { get; set; }

        public void FieldsFromJSONObject(JObject value) => Timestamp = (long?)value["timestamp"];

        public override string ToString()
        {
            return "StreamingKeepAliveRecord{timestamp=" + Timestamp + '}';
        }
    }
}
