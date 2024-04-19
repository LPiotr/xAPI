// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.MarginLevelResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Responses
{
  public class MarginLevelResponse : BaseResponse
  {
    private double? balance;
    private double? equity;
    private double? margin;
    private double? margin_free;
    private double? margin_level;
    private string currency;
    private double? credit;

    public MarginLevelResponse(string body)
      : base(body)
    {
      JObject returnData = (JObject) this.ReturnData;
      this.balance = (double?) returnData[nameof (balance)];
      this.equity = (double?) returnData[nameof (equity)];
      this.currency = (string) returnData[nameof (currency)];
      this.margin = (double?) returnData[nameof (margin)];
      this.margin_free = (double?) returnData[nameof (margin_free)];
      this.margin_level = (double?) returnData[nameof (margin_level)];
      this.credit = (double?) returnData[nameof (credit)];
    }

    public virtual double? Balance => this.balance;

    public virtual double? Equity => this.equity;

    public virtual double? Margin => this.margin;

    public virtual double? Margin_free => this.margin_free;

    public virtual double? Margin_level => this.margin_level;

    public virtual string Currency => this.currency;

    public virtual double? Credit => this.credit;
  }
}
