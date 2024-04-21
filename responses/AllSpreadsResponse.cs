using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using xAPI.Records;


namespace xAPI.Responses
{
    public class AllSpreadsResponse : BaseResponse
    {
        private readonly LinkedList<SpreadRecord> spreadRecords = new();

        public AllSpreadsResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in ((IEnumerable<JToken>)ReturnData).Cast<JObject>())
            {
                SpreadRecord spreadRecord = new();
                spreadRecord.FieldsFromJSONObject(jobject);
                spreadRecords.AddLast(spreadRecord);
            }
        }

        public virtual LinkedList<SpreadRecord> SpreadRecords => spreadRecords;
    }
}
