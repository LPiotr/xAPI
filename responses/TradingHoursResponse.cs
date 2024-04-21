using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using xAPI.Records;

namespace xAPI.Responses
{
    public class TradingHoursResponse : BaseResponse
    {
        private LinkedList<TradingHoursRecord> tradingHoursRecords = new();

        public TradingHoursResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in ((IEnumerable<JToken>)ReturnData).Cast<JObject>())
            {
                TradingHoursRecord tradingHoursRecord = new();
                tradingHoursRecord.FieldsFromJSONObject(jobject);
                tradingHoursRecords.AddLast(tradingHoursRecord);
            }
        }

        public virtual LinkedList<TradingHoursRecord> TradingHoursRecords => tradingHoursRecords;
    }
}
