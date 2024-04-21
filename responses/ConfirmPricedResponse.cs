using Newtonsoft.Json.Linq;

namespace xAPI.Responses
{
    public class ConfirmPricedResponse : BaseResponse
    {
        private long? newRequestId;

        public ConfirmPricedResponse(string body) : base(body)
        {
            newRequestId = (long?)((JObject)ReturnData)["requestId"];
        }

        public virtual long? NewRequestId => newRequestId;
    }
}
