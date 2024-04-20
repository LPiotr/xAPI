using Newtonsoft.Json.Linq;

namespace xAPI.Responses
{
    public class ServerTimeResponse : BaseResponse
    {
        private long? time;
        private string timeString;

        public ServerTimeResponse(string body)
          : base(body)
        {
            JObject returnData = (JObject)this.ReturnData;
            this.time = (long?)returnData[nameof(time)];
            this.timeString = (string)returnData[nameof(timeString)];
        }

        public virtual long? Time => this.time;

        public virtual string TimeString => this.timeString;
    }
}
