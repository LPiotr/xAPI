using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;


namespace xAPI.Responses
{
    public class StepRulesResponse : BaseResponse
    {
        private LinkedList<StepRuleRecord> stepRulesRecords = new LinkedList<StepRuleRecord>();

        public StepRulesResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in (IEnumerable<JToken>)this.ReturnData)
            {
                StepRuleRecord stepRuleRecord = new StepRuleRecord();
                stepRuleRecord.FieldsFromJSONObject(jobject);
                this.stepRulesRecords.AddLast(stepRuleRecord);
            }
        }

        public virtual LinkedList<StepRuleRecord> StepRulesRecords => this.stepRulesRecords;
    }
}
