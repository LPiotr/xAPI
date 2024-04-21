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
            order = (long?)((JObject)ReturnData)[nameof(order)];
        }

        [Obsolete("Use Order instead")]
        public virtual long? RequestId => Order;

        public long? Order => order;
    }
}
