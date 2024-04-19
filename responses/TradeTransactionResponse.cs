// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.TradeTransactionResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using System;


namespace xAPI.Responses
{
  public class TradeTransactionResponse : BaseResponse
  {
    private long? order;

    public TradeTransactionResponse(string body)
      : base(body)
    {
      this.order = (long?) ((JObject) this.ReturnData)[nameof (order)];
    }

    [Obsolete("Use Order instead")]
    public virtual long? RequestId => this.Order;

    public long? Order => this.order;
  }
}
