using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
  public class HoursRecord : BaseResponseRecord
  {
    private long? day;
    private long? fromT;
    private long? toT;

    public virtual long? Day => this.day;

    public virtual long? FromT => this.fromT;

    public virtual long? ToT => this.toT;

    public void FieldsFromJSONObject(JObject value)
    {
      this.day = (long?) value["day"];
      this.fromT = (long?) value["fromT"];
      this.toT = (long?) value["toT"];
    }

    public override string ToString()
    {
      return "HoursRecord{day=" + (object) this.day + ", fromT=" + (object) this.fromT + ", toT=" + (object) this.toT + (object) '}';
    }
  }
}
