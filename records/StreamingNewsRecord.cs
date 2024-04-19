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
      this.Body = (string) value["body"];
      this.Key = (string) value["key"];
      this.Time = (long?) value["time"];
      this.Title = (string) value["title"];
    }
  }
}
