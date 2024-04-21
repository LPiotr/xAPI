using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace xAPI.Records
{
    public record StepRuleRecord : BaseResponseRecord
    {
        private int Id { get; set; }

        private string Name { get; set; }

        private LinkedList<StepRecord> Steps { get; set; }

        public void FieldsFromJSONObject(JObject value)
        {
            Id = (int)value["id"];
            Name = (string)value["name"];
            Steps = new LinkedList<StepRecord>();
            if (value["steps"] == null)
                return;
            foreach (JObject jobject in value["steps"].Cast<JObject>())
            {
                StepRecord stepRecord = new ();
                stepRecord.FieldsFromJSONObject(jobject);
                Steps.AddLast(stepRecord);
            }
        }
    }
}
