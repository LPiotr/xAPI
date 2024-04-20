using Newtonsoft.Json.Linq;
using System;

namespace xAPI.Responses
{
    public class CurrentUserDataResponse : BaseResponse
    {
        private string currency;
        private long? leverage;
        private double? leverageMultiplier;
        private string group;
        private int? companyUnit;
        private string spreadType;
        private bool? ibAccount;

        public CurrentUserDataResponse(string body)
          : base(body)
        {
            JObject returnData = (JObject)this.ReturnData;
            this.currency = (string)returnData[nameof(currency)];
            this.leverage = (long?)returnData[nameof(leverage)];
            this.leverageMultiplier = (double?)returnData[nameof(leverageMultiplier)];
            this.group = (string)returnData[nameof(group)];
            this.companyUnit = (int?)returnData[nameof(companyUnit)];
            this.spreadType = (string)returnData[nameof(spreadType)];
            this.ibAccount = (bool?)returnData[nameof(ibAccount)];
        }

        public virtual string Currency => this.currency;

        [Obsolete("Use LeverageMultiplier instead")]
        public virtual long? Leverage => this.leverage;

        public virtual double? LeverageMultiplier => this.leverageMultiplier;

        public virtual string Group => this.group;

        public virtual int? CompanyUnit => this.companyUnit;

        public virtual string SpreadType => this.spreadType;

        public virtual bool? IbAccount => this.ibAccount;
    }
}
