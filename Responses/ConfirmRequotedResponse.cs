using Newtonsoft.Json.Linq;

namespace xAPI.Responses
{
    public class ConfirmRequotedResponse : BaseResponse
    {
        private long? newRequestId;

        public ConfirmRequotedResponse(string body) : base(body)
        {
            this.newRequestId = (long?)((JObject)this.ReturnData)["requestId"];
        }

        public virtual long? NewRequestId => this.newRequestId;
    }
}
