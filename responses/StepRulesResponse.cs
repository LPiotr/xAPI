using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using xAPI.Records;


namespace xAPI.Responses
{
    public class StepRulesResponse : BaseResponse
    {
        private readonly LinkedList<StepRuleRecord> stepRulesRecords = new();

        public StepRulesResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in ((IEnumerable<JToken>)ReturnData).Cast<JObject>())
            {
                StepRuleRecord stepRuleRecord = new();
                stepRuleRecord.FieldsFromJSONObject(jobject);
                stepRulesRecords.AddLast(stepRuleRecord);
            }
        }

        public virtual LinkedList<StepRuleRecord> StepRulesRecords => stepRulesRecords;
    }
}
