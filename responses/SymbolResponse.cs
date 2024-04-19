// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.SymbolResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using xAPI.Records;


namespace xAPI.Responses
{
  public class SymbolResponse : BaseResponse
  {
    private SymbolRecord symbol;

    public SymbolResponse(string body)
      : base(body)
    {
      JObject returnData = (JObject) this.ReturnData;
      this.symbol = new SymbolRecord();
      this.symbol.FieldsFromJSONObject(returnData);
    }

    public virtual SymbolRecord Symbol => this.symbol;
  }
}
