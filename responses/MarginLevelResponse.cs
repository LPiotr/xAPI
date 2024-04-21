using Newtonsoft.Json.Linq;

namespace xAPI.Responses
{
    public class MarginLevelResponse : BaseResponse
    {
        private readonly double? balance;
        private readonly double? equity;
        private readonly double? margin;
        private readonly double? margin_free;
        private readonly double? margin_level;
        private readonly string currency;
        private readonly double? credit;

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
