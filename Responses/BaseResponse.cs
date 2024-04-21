using Newtonsoft.Json.Linq;
using System;
using xAPI.Errors;

namespace xAPI.Responses
{
    public class BaseResponse
    {
        private bool? status;
        private string errorDescr;
        private ERR_CODE errCode;
        private JContainer returnData;
        private string customTag;

        public BaseResponse(string body)
        {
            JObject jobject;
            try
            {
                jobject = JObject.Parse(body);
            }
            catch (Exception ex)
            {
                throw new APIReplyParseException("JSON Parse exception: " + body + "\n" + ex.Message);
            }
            status = jobject != null ? (bool?)jobject[nameof(status)] : throw new APIReplyParseException("JSON Parse exception: " + body);
            errCode = new ERR_CODE((string)jobject["errorCode"]);
            errorDescr = (string)jobject[nameof(errorDescr)];
            returnData = (JContainer)jobject[nameof(returnData)];
            customTag = (string)jobject[nameof(customTag)];
            if (!status.HasValue)
            {
                Console.Error.WriteLine(body);
                throw new APIReplyParseException("JSON Parse error: \"status\" is null!");
            }
            int num;
            if (status.HasValue)
            {
                bool? status = this.status;
                num = !(status.HasValue ? new bool?(!status.GetValueOrDefault()) : new bool?()).Value ? 1 : 0;
            }
            else
                num = 0;
            if (num == 0 && jobject["redirect"] == null)
                errorDescr = errorDescr == null ? ERR_CODE.getErrorDescription(errCode.StringValue) : throw new APIErrorResponse(errCode, errorDescr, body);
        }

        public virtual object ReturnData => returnData;

        public virtual bool? Status => status;

        public virtual string ErrorDescr => errorDescr;

        public string CustomTag => customTag;

        public string ToJSONString()
        {
            JObject jobject = new()
            {
                { "status", (JToken)status }
            };
            if (returnData != null)
                jobject.Add("returnData", (JToken)returnData.ToString());
            if (errCode != null)
                jobject.Add("errorCode", (JToken)errCode.StringValue);
            if (errorDescr != null)
                jobject.Add("errorDescr", (JToken)errorDescr);
            if (customTag != null)
                jobject.Add("customTag", (JToken)customTag);
            return jobject.ToString();
        }
    }
}
