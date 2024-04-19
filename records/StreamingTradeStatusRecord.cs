using Newtonsoft.Json.Linq;
using xAPI.Codes;

namespace xAPI.Records
{
  public class StreamingTradeStatusRecord : BaseResponseRecord
  {
    private string customComment;
    private string message;
    private long? order;
    private REQUEST_STATUS requestStatus;
    private double? price;

    public string CustomComment
    {
      get => this.customComment;
      set => this.customComment = value;
    }

    public string Message
    {
      get => this.message;
      set => this.message = value;
    }

    public long? Order
    {
      get => this.order;
      set => this.order = value;
    }

    public double? Price
    {
      get => this.price;
      set => this.price = value;
    }

    public REQUEST_STATUS RequestStatus
    {
      get => this.requestStatus;
      set => this.requestStatus = value;
    }

    public void FieldsFromJSONObject(JObject value)
    {
      this.customComment = (string) value["customComment"];
      this.message = (string) value["message"];
      this.order = (long?) value["order"];
      this.price = (double?) value["price"];
      this.requestStatus = new REQUEST_STATUS((long) value["requestStatus"]);
    }

    public override string ToString()
    {
      return "StreamingTradeStatusRecord{customComment=" + this.customComment + "message=" + this.message + ", order=" + (object) this.order + ", requestStatus=" + (object) this.requestStatus.Code + ", price=" + (object) this.price + (object) '}';
    }
  }
}
