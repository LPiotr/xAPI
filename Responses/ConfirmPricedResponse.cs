using Newtonsoft.Json.Linq;

namespace xAPI.Responses
{
    public class ConfirmPricedResponse : BaseResponse
    {
        private long? newRequestId;

        public ConfirmPricedResponse(string body) : base(body)
        {
            this.newRequestId = (long?)((JObject)this.ReturnData)["requestId"];
        }

        public virtual long? NewRequestId => this.newRequestId;
    }
}
