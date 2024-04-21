using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using xAPI.Records;

namespace xAPI.Responses
{
    public class IbsHistoryResponse : BaseResponse
    {
        public LinkedList<IbRecord> IbRecords { get; set; }

        public IbsHistoryResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in ((IEnumerable<JToken>)ReturnData).Cast<JObject>())
                IbRecords.AddLast(new IbRecord(jobject));
        }
    }
}
