// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.CommissionDefResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Responses
{
  public class CommissionDefResponse : BaseResponse
  {
    private double? commission;
    private double? rateOfExchange;

    public CommissionDefResponse(string body)
      : base(body)
    {
      JObject returnData = (JObject) this.ReturnData;
      this.commission = (double?) returnData[nameof (commission)];
      this.rateOfExchange = (double?) returnData[nameof (rateOfExchange)];
    }

    public virtual double? Commission => this.commission;

    public virtual double? RateOfExchange => this.rateOfExchange;
  }
}
