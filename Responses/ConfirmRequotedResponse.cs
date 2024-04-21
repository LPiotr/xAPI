using Newtonsoft.Json.Linq;

namespace xAPI.Responses
{
    public class ConfirmRequotedResponse : BaseResponse
    {
        private long? newRequestId;

        public ConfirmRequotedResponse(string body) : base(body)
        {
            newRequestId = (long?)((JObject)ReturnData)["requestId"];
        }

        public virtual long? NewRequestId => newRequestId;
    }
}
