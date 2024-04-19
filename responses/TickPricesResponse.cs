using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;


namespace xAPI.Responses
{
  public class TickPricesResponse : BaseResponse
  {
    private LinkedList<TickRecord> ticks = new LinkedList<TickRecord>();

    public TickPricesResponse(string body)
      : base(body)
    {
      foreach (JObject jobject in (IEnumerable<JToken>) ((JObject) this.ReturnData)["quotations"])
      {
        TickRecord tickRecord = new TickRecord();
        tickRecord.FieldsFromJSONObject(jobject);
        this.ticks.AddLast(tickRecord);
      }
    }

    public virtual LinkedList<TickRecord> Ticks => this.ticks;
  }
}
