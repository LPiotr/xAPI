using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using xAPI.Records;


namespace xAPI.Responses
{
    public class ChartLastResponse : BaseResponse
    {
        private long? digits;
        private LinkedList<RateInfoRecord> rateInfos = new();

        public ChartLastResponse(string body)
          : base(body)
        {
            JObject returnData = (JObject)ReturnData;
            digits = (long?)returnData[nameof(digits)];
            foreach (JObject jobject in returnData[nameof(rateInfos)].Cast<JObject>())
            {
                RateInfoRecord rateInfoRecord = new();
                rateInfoRecord.FieldsFromJSONObject(jobject);
                rateInfos.AddLast(rateInfoRecord);
            }
        }

        public virtual long? Digits => digits;

        public virtual LinkedList<RateInfoRecord> RateInfos => rateInfos;
    }
}
