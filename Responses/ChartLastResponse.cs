using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;


namespace xAPI.Responses
{
    public class ChartLastResponse : BaseResponse
    {
        private long? digits;
        private LinkedList<RateInfoRecord> rateInfos = new LinkedList<RateInfoRecord>();

        public ChartLastResponse(string body)
          : base(body)
        {
            JObject returnData = (JObject)this.ReturnData;
            this.digits = (long?)returnData[nameof(digits)];
            foreach (JObject jobject in (IEnumerable<JToken>)returnData[nameof(rateInfos)])
            {
                RateInfoRecord rateInfoRecord = new RateInfoRecord();
                rateInfoRecord.FieldsFromJSONObject(jobject);
                this.rateInfos.AddLast(rateInfoRecord);
            }
        }

        public virtual long? Digits => this.digits;

        public virtual LinkedList<RateInfoRecord> RateInfos => this.rateInfos;
    }
}
