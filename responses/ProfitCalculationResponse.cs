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
