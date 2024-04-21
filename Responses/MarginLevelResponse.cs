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
            JObject returnData = (JObject)ReturnData;
            balance = (double?)returnData[nameof(balance)];
            equity = (double?)returnData[nameof(equity)];
            currency = (string)returnData[nameof(currency)];
            margin = (double?)returnData[nameof(margin)];
            margin_free = (double?)returnData[nameof(margin_free)];
            margin_level = (double?)returnData[nameof(margin_level)];
            credit = (double?)returnData[nameof(credit)];
        }

        public virtual double? Balance => balance;

        public virtual double? Equity => equity;

        public virtual double? Margin => margin;

        public virtual double? Margin_free => margin_free;

        public virtual double? Margin_level => margin_level;

        public virtual string Currency => currency;

        public virtual double? Credit => credit;
    }
}
