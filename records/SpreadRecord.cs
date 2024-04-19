// Decompiled with JetBrains decompiler
// Type: xAPI.Records.SpreadRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Records
{
  public class SpreadRecord : BaseResponseRecord
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
