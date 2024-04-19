using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace xAPI.Records
{
  public class TradingHoursRecord : BaseResponseRecord
  {
    private string symbol;
    private LinkedList<HoursRecord> quotes = new LinkedList<HoursRecord>();
    private LinkedList<HoursRecord> trading = new LinkedList<HoursRecord>();

    public virtual string Symbol => this.symbol;

    public virtual LinkedList<HoursRecord> Quotes => this.quotes;

    public virtual LinkedList<HoursRecord> Trading => this.trading;

    public void FieldsFromJSONObject(JObject value)
    {
      this.FieldsFromJSONObject(value, (string) null);
    }

    public bool FieldsFromJSONObject(JObject value, string str)
    {
      this.symbol = (string) value["symbol"];
      this.quotes = new LinkedList<HoursRecord>();
      if (value["quotes"] != null)
      {
        foreach (JObject jobject in (IEnumerable<JToken>) value["quotes"])
        {
          HoursRecord hoursRecord = new HoursRecord();
          hoursRecord.FieldsFromJSONObject(jobject);
          this.quotes.AddLast(hoursRecord);
        }
      }
      this.trading = new LinkedList<HoursRecord>();
      if (value["trading"] != null)
      {
        foreach (JObject jobject in (IEnumerable<JToken>) value["trading"])
        {
          HoursRecord hoursRecord = new HoursRecord();
          hoursRecord.FieldsFromJSONObject(jobject);
          this.trading.AddLast(hoursRecord);
        }
      }
      return this.symbol != null && this.quotes.Count != 0 && this.trading.Count != 0;
    }

    public override string ToString()
    {
      return "TradingHoursRecord{symbol=" + this.symbol + ", quotes=" + this.quotes.ToString() + ", trading=" + this.trading.ToString() + (object) '}';
    }
  }
}
