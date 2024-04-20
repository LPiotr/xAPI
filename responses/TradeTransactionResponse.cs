using Newtonsoft.Json.Linq;
using System;

namespace xAPI.Responses
{
    public class TradeTransactionResponse : BaseResponse
    {
        private long? order;

        public TradeTransactionResponse(string body)
          : base(body)
        {
            this.order = (long?)((JObject)this.ReturnData)[nameof(order)];
        }

        [Obsolete("Use Order instead")]
        public virtual long? RequestId => this.Order;

        public long? Order => this.order;
    }
}
