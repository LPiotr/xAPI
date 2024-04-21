using Newtonsoft.Json.Linq;
using xAPI.Codes;

namespace xAPI.Responses
{
    public class TradeTransactionStatusResponse : BaseResponse
    {
        private double? ask;
        private double? bid;
        private string customComment;
        private string message;
        private long? order;
        private REQUEST_STATUS requestStatus;

        public TradeTransactionStatusResponse(string body)
          : base(body)
        {
            JObject returnData = (JObject)ReturnData;
            ask = (double?)returnData[nameof(ask)];
            bid = (double?)returnData[nameof(bid)];
            customComment = (string)returnData[nameof(customComment)];
            message = (string)returnData[nameof(message)];
            order = (long?)returnData[nameof(order)];
            requestStatus = new REQUEST_STATUS((long)returnData[nameof(requestStatus)]);
        }

        public virtual double? Ask
        {
            get => ask;
            set => ask = value;
        }

        public virtual double? Bid
        {
            get => bid;
            set => bid = value;
        }

        public virtual string CustomComment
        {
            get => customComment;
            set => customComment = value;
        }

        public virtual string Message
        {
            get => message;
            set => message = value;
        }

        public virtual long? Order
        {
            get => order;
            set => order = value;
        }

        public virtual REQUEST_STATUS RequestStatus
        {
            get => requestStatus;
            set => requestStatus = value;
        }
    }
}
