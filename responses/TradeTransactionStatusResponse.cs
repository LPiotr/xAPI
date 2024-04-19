// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.TradeTransactionStatusResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using xAPI.Codes;


namespace xAPI.Responses
{
  public class TradeTransactionStatusResponse : BaseResponse
  {
    private double? ask;
    private double? bid;
    private string customComment;
    private string message;
    private long? order;
    private REQUEST_STATUS requestStatus;

    public TradeTransactionStatusResponse(string body)
      : base(body)
    {
      JObject returnData = (JObject) this.ReturnData;
      this.ask = (double?) returnData[nameof (ask)];
      this.bid = (double?) returnData[nameof (bid)];
      this.customComment = (string) returnData[nameof (customComment)];
      this.message = (string) returnData[nameof (message)];
      this.order = (long?) returnData[nameof (order)];
      this.requestStatus = new REQUEST_STATUS((long) returnData[nameof (requestStatus)]);
    }

    public virtual double? Ask
    {
      get => this.ask;
      set => this.ask = value;
    }

    public virtual double? Bid
    {
      get => this.bid;
      set => this.bid = value;
    }

    public virtual string CustomComment
    {
      get => this.customComment;
      set => this.customComment = value;
    }

    public virtual string Message
    {
      get => this.message;
      set => this.message = value;
    }

    public virtual long? Order
    {
      get => this.order;
      set => this.order = value;
    }

    public virtual REQUEST_STATUS RequestStatus
    {
      get => this.requestStatus;
      set => this.requestStatus = value;
    }
  }
}
