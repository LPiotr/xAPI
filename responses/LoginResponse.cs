using Newtonsoft.Json.Linq;
using xAPI.Records;

namespace xAPI.Responses
{
    public class LoginResponse : BaseResponse
    {
        private string streamSessionId;
        private RedirectRecord redirectRecord;

        public LoginResponse(string body)
          : base(body)
        {
            JObject jobject1 = JObject.Parse(body);
            this.streamSessionId = (string)jobject1[nameof(streamSessionId)];
            JObject jobject2 = (JObject)jobject1["redirect"];
            if (jobject2 == null)
                return;
            this.redirectRecord = new RedirectRecord();
            this.redirectRecord.FieldsFromJSONObject(jobject2);
        }

        public virtual string StreamSessionId => this.streamSessionId;

        public virtual RedirectRecord RedirectRecord => this.redirectRecord;
    }
}
