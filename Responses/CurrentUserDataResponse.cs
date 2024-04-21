using Newtonsoft.Json.Linq;
using System;

namespace xAPI.Responses
{
    public class CurrentUserDataResponse : BaseResponse
    {
        private readonly string currency;
        private readonly long? leverage;
        private readonly double? leverageMultiplier;
        private readonly string group;
        private readonly int? companyUnit;
        private readonly string spreadType;
        private readonly bool? ibAccount;

        public CurrentUserDataResponse(string body)
          : base(body)
        {
            JObject returnData = (JObject)ReturnData;
            currency = (string)returnData[nameof(currency)];
            leverage = (long?)returnData[nameof(leverage)];
            leverageMultiplier = (double?)returnData[nameof(leverageMultiplier)];
            group = (string)returnData[nameof(group)];
            companyUnit = (int?)returnData[nameof(companyUnit)];
            spreadType = (string)returnData[nameof(spreadType)];
            ibAccount = (bool?)returnData[nameof(ibAccount)];
        }

        public virtual string Currency => currency;

        [Obsolete("Use LeverageMultiplier instead")]
        public virtual long? Leverage => leverage;

        public virtual double? LeverageMultiplier => leverageMultiplier;

        public virtual string Group => group;

        public virtual int? CompanyUnit => companyUnit;

        public virtual string SpreadType => spreadType;

        public virtual bool? IbAccount => ibAccount;
    }
}
