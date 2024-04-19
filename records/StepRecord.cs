using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
  public class StepRecord : BaseResponseRecord
  {
    private double FromValue;
    private double Step;

    public void FieldsFromJSONObject(JObject value)
    {
      this.FromValue = (double) value["fromValue"];
      this.Step = (double) value["step"];
    }
  }
}
