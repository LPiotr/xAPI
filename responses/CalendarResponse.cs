// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.CalendarResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

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
