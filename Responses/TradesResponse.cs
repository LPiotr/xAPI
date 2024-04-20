using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;

namespace xAPI.Responses
{
    public class TradesResponse : BaseResponse
    {
        private LinkedList<TradeRecord> tradeRecords = new LinkedList<TradeRecord>();

        public TradesResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in (IEnumerable<JToken>)this.ReturnData)
            {
                TradeRecord tradeRecord = new TradeRecord();
                tradeRecord.FieldsFromJSONObject(jobject);
                this.tradeRecords.AddLast(tradeRecord);
            }
        }

        public virtual LinkedList<TradeRecord> TradeRecords => this.tradeRecords;
    }
}
