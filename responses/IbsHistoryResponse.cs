using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;

namespace xAPI.Responses
{
    public class IbsHistoryResponse : BaseResponse
    {
        public LinkedList<IbRecord> IbRecords { get; set; }

        public IbsHistoryResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in (IEnumerable<JToken>)this.ReturnData)
                this.IbRecords.AddLast(new IbRecord(jobject));
        }
    }
}
