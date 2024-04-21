using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using xAPI.Records;


namespace xAPI.Responses
{
    public class NewsResponse : BaseResponse
    {
        private readonly LinkedList<NewsTopicRecord> newsTopicRecords = new();

        public NewsResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in ((IEnumerable<JToken>)ReturnData).Cast<JObject>())
            {
                NewsTopicRecord newsTopicRecord = new();
                newsTopicRecord.FieldsFromJSONObject(jobject);
                newsTopicRecords.AddLast(newsTopicRecord);
            }
        }

        public virtual LinkedList<NewsTopicRecord> NewsTopicRecords => newsTopicRecords;
    }
}
