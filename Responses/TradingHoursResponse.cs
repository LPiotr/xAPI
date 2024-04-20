using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;

namespace xAPI.Responses
{
    public class TradingHoursResponse : BaseResponse
    {
        private LinkedList<TradingHoursRecord> tradingHoursRecords = new LinkedList<TradingHoursRecord>();

        public TradingHoursResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in (IEnumerable<JToken>)this.ReturnData)
            {
                TradingHoursRecord tradingHoursRecord = new TradingHoursRecord();
                tradingHoursRecord.FieldsFromJSONObject(jobject);
                this.tradingHoursRecords.AddLast(tradingHoursRecord);
            }
        }

        public virtual LinkedList<TradingHoursRecord> TradingHoursRecords => this.tradingHoursRecords;
    }
}
