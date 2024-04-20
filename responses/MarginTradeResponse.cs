using Newtonsoft.Json.Linq;

namespace xAPI.Responses
{
    public class MarginTradeResponse : BaseResponse
    {
        private double? margin;

        public MarginTradeResponse(string body)
          : base(body)
        {
            this.margin = (double?)((JObject)this.ReturnData)[nameof(margin)];
        }

        public virtual double? Margin => this.margin;
    }
}
