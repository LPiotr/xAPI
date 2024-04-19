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
