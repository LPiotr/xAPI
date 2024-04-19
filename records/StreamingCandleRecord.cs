using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
  public record StreamingCandleRecord : BaseResponseRecord
  {
    public double? Close { get; set; }

    public long? Ctm { get; set; }

    public string CtmString { get; set; }

    public double? High { get; set; }

    public double? Low { get; set; }

    public double? Open { get; set; }

    public long? QuoteId { get; set; }

    public string Symbol { get; set; }

    public double? Vol { get; set; }

    public void FieldsFromJSONObject(JObject value)
    {
      this.Close = (double?) value["close"];
      this.Ctm = (long?) value["ctm"];
      this.CtmString = (string) value["ctmString"];
      this.High = (double?) value["high"];
      this.Low = (double?) value["low"];
      this.Open = (double?) value["open"];
      this.QuoteId = (long?) value["quoteId"];
      this.Symbol = (string) value["symbol"];
      this.Vol = (double?) value["vol"];
    }

    public override string ToString()
    {
      return "StreamingCandleRecord {  close: " + (object) this.Close + " ctm: " + (object) this.Ctm + " ctmString: " + this.CtmString + " high: " + (object) this.High + " low: " + (object) this.Low + " open: " + (object) this.Open + " quoteId: " + (object) this.QuoteId + " symbol: " + this.Symbol + " vol: " + (object) this.Vol + " }";
    }
  }
}
