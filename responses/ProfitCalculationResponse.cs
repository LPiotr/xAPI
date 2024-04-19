// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.ProfitCalculationResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Responses
{
  public class ProfitCalculationResponse : BaseResponse
  {
    private double? profit;

    public ProfitCalculationResponse(string body)
      : base(body)
    {
      this.profit = (double?) ((JObject) this.ReturnData)[nameof (profit)];
    }

    public virtual double? Profit => this.profit;
  }
}
