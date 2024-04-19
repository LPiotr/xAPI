using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;


namespace xAPI.Responses
{
  public class NewsResponse : BaseResponse
  {
    private LinkedList<NewsTopicRecord> newsTopicRecords = new LinkedList<NewsTopicRecord>();

    public NewsResponse(string body)
      : base(body)
    {
      foreach (JObject jobject in (IEnumerable<JToken>) this.ReturnData)
      {
        NewsTopicRecord newsTopicRecord = new NewsTopicRecord();
        newsTopicRecord.FieldsFromJSONObject(jobject);
        this.newsTopicRecords.AddLast(newsTopicRecord);
      }
    }

    public virtual LinkedList<NewsTopicRecord> NewsTopicRecords => this.newsTopicRecords;
  }
}
