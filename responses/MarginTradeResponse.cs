using Newtonsoft.Json.Linq;

namespace xAPI.Responses
{
    public class MarginTradeResponse : BaseResponse
    {
        private double? margin;

        public MarginTradeResponse(string body)
          : base(body)
        {
            margin = (double?)((JObject)ReturnData)[nameof(margin)];
        }

        public virtual double? Margin => margin;
    }
}
