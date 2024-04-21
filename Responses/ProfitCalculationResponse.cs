using Newtonsoft.Json.Linq;


namespace xAPI.Responses
{
    public class ProfitCalculationResponse : BaseResponse
    {
        private double? profit;

        public ProfitCalculationResponse(string body)
          : base(body)
        {
            profit = (double?)((JObject)ReturnData)[nameof(profit)];
        }

        public virtual double? Profit => profit;
    }
}
