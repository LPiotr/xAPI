using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
  public class CalendarRecord : BaseResponseRecord
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
      this.country = (string) value["country"];
      this.current = (string) value["current"];
      this.forecast = (string) value["forecast"];
      this.impact = (string) value["impact"];
      this.period = (string) value["period"];
      this.previous = (string) value["previous"];
      this.time = (long?) value["time"];
      this.title = (string) value["title"];
    }

    public override string ToString()
    {
      return "CalendarRecord[country=" + this.country + ", current=" + this.current + ", forecast=" + this.forecast + ", impact=" + this.impact + ", period=" + this.period + ", previous=" + this.previous + ", time=" + (object) this.time + ", title=" + this.title + "]";
    }

    public string Country => this.country;

    public string Current => this.current;

    public string Forecast => this.forecast;

    public string Impact => this.impact;

    public string Period => this.period;

    public string Previous => this.previous;

    public long? Time => this.time;

    public string Title => this.title;
  }
}
