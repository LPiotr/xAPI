using Newtonsoft.Json.Linq;


namespace xAPI.Records
{
  public class StreamingTickRecord : BaseResponseRecord
  {
    private double? ask;
    private double? bid;
    private long? askVolume;
    private long? bidVolume;
    private double? high;
    private double? low;
    private string symbol;
    private double? spreadRaw;
    private double? spreadTable;
    private long? timestamp;
    private long? level;
    private long? quoteId;

    public double? Ask
    {
      get => this.ask;
      set => this.ask = value;
    }

    public double? Bid
    {
      get => this.bid;
      set => this.bid = value;
    }

    public long? AskVolume
    {
      get => this.askVolume;
      set => this.askVolume = value;
    }

    public long? BidVolume
    {
      get => this.bidVolume;
      set => this.bidVolume = value;
    }

    public double? High
    {
      get => this.high;
      set => this.high = value;
    }

    public double? Low
    {
      get => this.low;
      set => this.low = value;
    }

    public string Symbol
    {
      get => this.symbol;
      set => this.symbol = value;
    }

    public double? SpreadRaw
    {
      get => this.spreadRaw;
      set => this.spreadRaw = value;
    }

    public double? SpreadTable
    {
      get => this.spreadTable;
      set => this.spreadTable = value;
    }

    public long? Timestamp
    {
      get => this.timestamp;
      set => this.timestamp = value;
    }

    public long? Level
    {
      get => this.level;
      set => this.level = value;
    }

    public long? QuoteId
    {
      get => this.quoteId;
      set => this.quoteId = value;
    }

    public void FieldsFromJSONObject(JObject value)
    {
      this.ask = (double?) value["ask"];
      this.bid = (double?) value["bid"];
      this.askVolume = (long?) value["askVolume"];
      this.bidVolume = (long?) value["bidVolume"];
      this.high = (double?) value["high"];
      this.low = (double?) value["low"];
      this.symbol = (string) value["symbol"];
      this.timestamp = (long?) value["timestamp"];
      this.level = (long?) value["level"];
      this.quoteId = (long?) value["quoteId"];
      this.spreadRaw = (double?) value["spreadRaw"];
      this.spreadTable = (double?) value["spreadTable"];
    }

    public override string ToString()
    {
      return "StreamingTickRecord{ask=" + (object) this.ask + ", bid=" + (object) this.bid + ", askVolume=" + (object) this.askVolume + ", bidVolume=" + (object) this.bidVolume + ", high=" + (object) this.high + ", low=" + (object) this.low + ", symbol=" + this.symbol + ", timestamp=" + (object) this.timestamp + ", level=" + (object) this.level + ", quoteId=" + (object) this.quoteId + ", spreadRaw=" + (object) this.spreadRaw + ", spreadTable=" + (object) this.spreadTable + (object) '}';
    }
  }
}
