using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using xAPI.Records;


namespace xAPI.Responses
{
    public class ChartRangeResponse : BaseResponse
    {
        private readonly long? digits;
        private readonly LinkedList<RateInfoRecord> rateInfos = new();

        public ChartRangeResponse(string body)
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
