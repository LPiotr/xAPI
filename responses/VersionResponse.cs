using Newtonsoft.Json.Linq;


namespace xAPI.Responses
{
  public class VersionResponse : BaseResponse
  {
    private string version;

    public VersionResponse(string body)
      : base(body)
    {
      this.version = (string) ((JObject) this.ReturnData)[nameof (version)];
    }

    public virtual string Version => this.version;
  }
}
