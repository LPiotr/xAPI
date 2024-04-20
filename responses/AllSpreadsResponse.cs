using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;


namespace xAPI.Responses
{
    public class AllSpreadsResponse : BaseResponse
    {
        private LinkedList<SpreadRecord> spreadRecords = new LinkedList<SpreadRecord>();

        public AllSpreadsResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in (IEnumerable<JToken>)this.ReturnData)
            {
                SpreadRecord spreadRecord = new SpreadRecord();
                spreadRecord.FieldsFromJSONObject(jobject);
                this.spreadRecords.AddLast(spreadRecord);
            }
        }

        public virtual LinkedList<SpreadRecord> SpreadRecords => this.spreadRecords;
    }
}
