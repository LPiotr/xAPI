using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
  public class RateInfoRecord : BaseResponseRecord
  {
    private long? ctm;
    private double? open;
    private double? high;
    private double? low;
    private double? close;
    private double? vol;

    public virtual long? Ctm
    {
      get => this.ctm;
      set => this.ctm = value;
    }

    public virtual double? Open
    {
      get => this.open;
      set => this.open = value;
    }

    public virtual double? High
    {
      get => this.high;
      set => this.high = value;
    }

    public virtual double? Low
    {
      get => this.low;
      set => this.low = value;
    }

    public virtual double? Close
    {
      get => this.close;
      set => this.close = value;
    }

    public virtual double? Vol
    {
      get => this.vol;
      set => this.vol = value;
    }

    public void FieldsFromJSONObject(JObject value)
    {
      this.Close = (double?) value["close"];
      this.Ctm = (long?) value["ctm"];
      this.High = (double?) value["high"];
      this.Low = (double?) value["low"];
      this.Open = (double?) value["open"];
      this.Vol = (double?) value["vol"];
    }
  }
}
