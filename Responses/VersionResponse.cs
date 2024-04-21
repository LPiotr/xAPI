using Newtonsoft.Json.Linq;


namespace xAPI.Responses
{
    public class VersionResponse : BaseResponse
    {
        private readonly string version;

        public VersionResponse(string body)
          : base(body)
        {
            version = (string)((JObject)ReturnData)[nameof(version)];
        }

        public virtual string Version => version;
    }
}
