using Newtonsoft.Json.Linq;
using xAPI.Records;

namespace xAPI.Responses
{
    public class LoginResponse : BaseResponse
    {
        private readonly string streamSessionId;
        private readonly RedirectRecord redirectRecord;

        public LoginResponse(string body)
          : base(body)
        {
            JObject jobject1 = JObject.Parse(body);
            streamSessionId = (string)jobject1[nameof(streamSessionId)];
            JObject jobject2 = (JObject)jobject1["redirect"];
            if (jobject2 == null)
                return;
            redirectRecord = new RedirectRecord();
            redirectRecord.FieldsFromJSONObject(jobject2);
        }

        public virtual string StreamSessionId => streamSessionId;

        public virtual RedirectRecord RedirectRecord => redirectRecord;
    }
}
