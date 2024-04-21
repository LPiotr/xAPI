using Newtonsoft.Json.Linq;

namespace xAPI.Responses
{
    public class CommissionDefResponse : BaseResponse
    {
        private readonly double? commission;
        private readonly double? rateOfExchange;

        public CommissionDefResponse(string body)
          : base(body)
        {
            JObject returnData = (JObject)ReturnData;
            commission = (double?)returnData[nameof(commission)];
            rateOfExchange = (double?)returnData[nameof(rateOfExchange)];
        }

        public virtual double? Commission => commission;

        public virtual double? RateOfExchange => rateOfExchange;
    }
}
