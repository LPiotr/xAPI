using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
  public record SpreadRecord : BaseResponseRecord
  {
    private long? precision;
    private string symbol;
    private long? value;
    private long? quoteId;

    public virtual long? Precision
    {
      get => this.precision;
      set => this.precision = value;
    }

    public virtual string Symbol
    {
      get => this.symbol;
      set => this.symbol = value;
    }

    public virtual long? QuoteId
    {
      get => this.quoteId;
      set => this.quoteId = value;
    }

    public virtual long? Value
    {
      get => this.value;
      set => this.value = value;
    }

    public void FieldsFromJSONObject(JObject value)
    {
      this.Symbol = (string) value["symbol"];
      this.Precision = (long?) value["precision"];
      this.Value = (long?) value[nameof (value)];
      this.QuoteId = (long?) value["quoteId"];
    }
  }
}
