// Decompiled with JetBrains decompiler
// Type: xAPI.Records.StepRuleRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace xAPI.Records
{
  public class StepRuleRecord : BaseResponseRecord
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
      foreach (JObject jobject in (IEnumerable<JToken>) value["steps"])
      {
        StepRecord stepRecord = new StepRecord();
        stepRecord.FieldsFromJSONObject(jobject);
        this.Steps.AddLast(stepRecord);
      }
    }
  }
}
