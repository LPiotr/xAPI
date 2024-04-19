using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;

namespace xAPI.Responses
{
  public class CalendarResponse : BaseResponse
  {
    private List<CalendarRecord> calendarRecords = new List<CalendarRecord>();

    public CalendarResponse(string body)
      : base(body)
    {
      foreach (JObject jobject in (IEnumerable<JToken>) this.ReturnData)
      {
        CalendarRecord calendarRecord = new CalendarRecord();
        calendarRecord.FieldsFromJSONObject(jobject);
        this.calendarRecords.Add(calendarRecord);
      }
    }

    public List<CalendarRecord> CalendarRecords => this.calendarRecords;
  }
}
