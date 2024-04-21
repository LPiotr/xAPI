using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using xAPI.Records;

namespace xAPI.Responses
{
    public class CalendarResponse : BaseResponse
    {
        private List<CalendarRecord> calendarRecords = [];

        public CalendarResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in ((IEnumerable<JToken>)ReturnData).Cast<JObject>())
            {
                CalendarRecord calendarRecord = new();
                calendarRecord.FieldsFromJSONObject(jobject);
                calendarRecords.Add(calendarRecord);
            }
        }

        public List<CalendarRecord> CalendarRecords => calendarRecords;
    }
}
