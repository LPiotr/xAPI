using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
  public record RedirectRecord : BaseResponseRecord
  {
    private int mainPort;
    private int streamingPort;
    private string address;

    public void FieldsFromJSONObject(JObject value)
    {
      this.mainPort = (int) value["mainPort"];
      this.streamingPort = (int) value["streamingPort"];
      this.address = (string) value["address"];
    }

    public int MainPort => this.mainPort;

    public int StreamingPort => this.streamingPort;

    public string Address => this.address;

    public override string ToString()
    {
      return "RedirectRecord [mainPort=" + (object) this.mainPort + ", streamingPort=" + (object) this.streamingPort + ", address=" + this.address + "]";
    }
  }
}
