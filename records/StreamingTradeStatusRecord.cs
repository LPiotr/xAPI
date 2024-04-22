using Newtonsoft.Json.Linq;
using xAPI.Codes;

namespace xAPI.Records
{
    public record StreamingTradeStatusRecord : IBaseResponseRecord
    {
        private string customComment;
        private string message;
        private long? order;
        private REQUEST_STATUS requestStatus;
        private double? price;

        public string CustomComment
        {
            get => customComment;
            set => customComment = value;
        }

        public string Message
        {
            get => message;
            set => message = value;
        }

        public long? Order
        {
            get => order;
            set => order = value;
        }

        public double? Price
        {
            get => price;
            set => price = value;
        }

        public REQUEST_STATUS RequestStatus
        {
            get => requestStatus;
            set => requestStatus = value;
        }

        public void FieldsFromJSONObject(JObject value)
        {
            customComment = (string)value["customComment"];
            message = (string)value["message"];
            order = (long?)value["order"];
            price = (double?)value["price"];
            requestStatus = new REQUEST_STATUS((long)value["requestStatus"]);
        }

        public override string ToString()
        {
            return "StreamingTradeStatusRecord{customComment=" + customComment + "message=" + message + ", order=" + order + ", requestStatus=" + requestStatus.Code + ", price=" + price + '}';
        }
    }
}
