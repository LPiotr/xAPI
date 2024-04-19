// Decompiled with JetBrains decompiler
// Type: xAPI.Records.TickRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Records
{
  public class TickRecord : BaseResponseRecord
  {
    private double? ask;
    private long? askVolume;
    private double? bid;
    private long? bidVolume;
    private double? high;
    private long? level;
    private double? low;
    private double? spreadRaw;
    private double? spreadTable;
    private string symbol;
    private long? timestamp;

    public virtual double? Ask => this.ask;

    public virtual long? AskVolume => this.askVolume;

    public virtual double? Bid => this.bid;

    public virtual long? BidVolume => this.bidVolume;

    public virtual double? High => this.high;

    public virtual long? Level => this.level;

    public virtual double? Low => this.low;

    public virtual double? SpreadRaw => this.spreadRaw;

    public virtual double? SpreadTable => this.spreadTable;

    public virtual string Symbol => this.symbol;

    public virtual long? Timestamp => this.timestamp;

    public void FieldsFromJSONObject(JObject value)
    {
      this.FieldsFromJSONObject(value, (string) null);
    }

    public bool FieldsFromJSONObject(JObject value, string str)
    {
      this.ask = (double?) value["ask"];
      this.askVolume = (long?) value["askVolume"];
      this.bid = (double?) value["bid"];
      this.bidVolume = (long?) value["bidVolume"];
      this.high = (double?) value["high"];
      this.level = (long?) value["level"];
      this.low = (double?) value["low"];
      this.spreadRaw = (double?) value["spreadRaw"];
      this.spreadTable = (double?) value["spreadTable"];
      this.symbol = (string) value["symbol"];
      this.timestamp = (long?) value["timestamp"];
      return this.ask.HasValue && this.bid.HasValue && this.symbol != null && this.timestamp.HasValue;
    }

    public override string ToString()
    {
      return "TickRecord{ask=" + (object) this.ask + ", bid=" + (object) this.bid + ", askVolume=" + (object) this.askVolume + ", bidVolume=" + (object) this.bidVolume + ", high=" + (object) this.high + ", low=" + (object) this.low + ", symbol=" + this.symbol + ", timestamp=" + (object) this.timestamp + ", level=" + (object) this.level + ", spreadRaw=" + (object) this.spreadRaw + ", spreadTable=" + (object) this.spreadTable + (object) '}';
    }
  }
}
