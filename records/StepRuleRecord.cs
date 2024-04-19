using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace xAPI.Records
{
  public record StepRuleRecord : BaseResponseRecord
  {
    private int Id { get; set; }

    private string Name { get; set; }

    private LinkedList<StepRecord> Steps { get; set; }

    public void FieldsFromJSONObject(JObject value)
    {
      this.Id = (int) value["id"];
      this.Name = (string) value["name"];
      this.Steps = new LinkedList<StepRecord>();
      if (value["steps"] == null)
        return;
            foreach (JObject jobject in (IEnumerable<JToken>)value["steps"])
      {
        StepRecord stepRecord = new StepRecord();
        stepRecord.FieldsFromJSONObject(jobject);
        this.Steps.AddLast(stepRecord);
      }
    }
  }
}
