using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
    public record CalendarRecord : BaseResponseRecord
    {
        private string country;
        private string current;
        private string forecast;
        private string impact;
        private string period;
        private string previous;
        private long? time;
        private string title;

        public void FieldsFromJSONObject(JObject value)
        {
            country = (string)value["country"];
            current = (string)value["current"];
            forecast = (string)value["forecast"];
            impact = (string)value["impact"];
            period = (string)value["period"];
            previous = (string)value["previous"];
            time = (long?)value["time"];
            title = (string)value["title"];
        }

        public override string ToString()
        {
            return "CalendarRecord[country=" + country + ", current=" + current + ", forecast=" + forecast + ", impact=" + impact + ", period=" + period + ", previous=" + previous + ", time=" + time + ", title=" + title + "]";
        }

        public string Country => country;

        public string Current => current;

        public string Forecast => forecast;

        public string Impact => impact;

        public string Period => period;

        public string Previous => previous;

        public long? Time => time;

        public string Title => title;
    }
}
