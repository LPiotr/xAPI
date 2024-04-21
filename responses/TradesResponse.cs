using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using xAPI.Records;

namespace xAPI.Responses
{
    public class TradesResponse : BaseResponse
    {
        private readonly LinkedList<TradeRecord> tradeRecords = new();

        public TradesResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in ((IEnumerable<JToken>)ReturnData).Cast<JObject>())
            {
                TradeRecord tradeRecord = new();
                tradeRecord.FieldsFromJSONObject(jobject);
                tradeRecords.AddLast(tradeRecord);
            }
        }

        public virtual LinkedList<TradeRecord> TradeRecords => tradeRecords;
    }
}
