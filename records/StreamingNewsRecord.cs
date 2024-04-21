using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
    public record StreamingNewsRecord : BaseResponseRecord
    {
        public string Body { get; set; }

        public string Key { get; set; }

        public long? Time { get; set; }

        public string Title { get; set; }

        public void FieldsFromJSONObject(JObject value)
        {
            Body = (string)value["body"];
            Key = (string)value["key"];
            Time = (long?)value["time"];
            Title = (string)value["title"];
        }
    }
}
