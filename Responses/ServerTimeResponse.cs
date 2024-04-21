using Newtonsoft.Json.Linq;

namespace xAPI.Responses
{
    public class ServerTimeResponse : BaseResponse
    {
        private readonly long? time;
        private readonly string timeString;

        public ServerTimeResponse(string body)
          : base(body)
        {
            JObject returnData = (JObject)ReturnData;
            time = (long?)returnData[nameof(time)];
            timeString = (string)returnData[nameof(timeString)];
        }

        public virtual long? Time => time;

        public virtual string TimeString => timeString;
    }
}
