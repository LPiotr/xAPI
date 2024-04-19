// Decompiled with JetBrains decompiler
// Type: xAPI.Records.RateInfoRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

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
