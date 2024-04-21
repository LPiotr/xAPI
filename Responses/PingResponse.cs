using Newtonsoft.Json.Linq;


namespace xAPI.Responses
{
    public class PingResponse : BaseResponse
    {
        private readonly long? time;
        private readonly string timeString;

        public PingResponse(string body) : base(body)
        {
            JObject returnData = (JObject)ReturnData;
        }
    }
}
