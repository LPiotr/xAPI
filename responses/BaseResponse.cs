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
      this.status = jobject != null ? (bool?) jobject[nameof (status)] : throw new APIReplyParseException("JSON Parse exception: " + body);
      this.errCode = new ERR_CODE((string) jobject["errorCode"]);
      this.errorDescr = (string) jobject[nameof (errorDescr)];
      this.returnData = (JContainer) jobject[nameof (returnData)];
      this.customTag = (string) jobject[nameof (customTag)];
      if (!this.status.HasValue)
      {
        Console.Error.WriteLine(body);
        throw new APIReplyParseException("JSON Parse error: \"status\" is null!");
      }
      int num;
      if (this.status.HasValue)
      {
        bool? status = this.status;
        num = !(status.HasValue ? new bool?(!status.GetValueOrDefault()) : new bool?()).Value ? 1 : 0;
      }
      else
        num = 0;
      if (num == 0 && jobject["redirect"] == null)
        this.errorDescr = this.errorDescr == null ? ERR_CODE.getErrorDescription(this.errCode.StringValue) : throw new APIErrorResponse(this.errCode, this.errorDescr, body);
    }

    public virtual object ReturnData => (object) this.returnData;

    public virtual bool? Status => this.status;

    public virtual string ErrorDescr => this.errorDescr;

    public string CustomTag => this.customTag;

    public string ToJSONString()
    {
      JObject jobject = new JObject();
      jobject.Add("status", (JToken) this.status);
      if (this.returnData != null)
        jobject.Add("returnData", (JToken) this.returnData.ToString());
      if (this.errCode != null)
        jobject.Add("errorCode", (JToken) this.errCode.StringValue);
      if (this.errorDescr != null)
        jobject.Add("errorDescr", (JToken) this.errorDescr);
      if (this.customTag != null)
        jobject.Add("customTag", (JToken) this.customTag);
      return jobject.ToString();
    }
  }
}
