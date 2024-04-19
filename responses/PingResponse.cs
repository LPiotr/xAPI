using Newtonsoft.Json.Linq;


namespace xAPI.Responses
{
  public class PingResponse : BaseResponse
  {
    private long? time;
    private string timeString;

    public PingResponse(string body)
      : base(body)
    {
      JObject returnData = (JObject) this.ReturnData;
    }
  }
}
