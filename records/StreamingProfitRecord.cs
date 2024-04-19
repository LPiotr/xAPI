// Decompiled with JetBrains decompiler
// Type: xAPI.Records.StreamingProfitRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Records
{
  public class StreamingProfitRecord : BaseResponseRecord
  {
    private long? order;
    private long? order2;
    private long? position;
    private double? profit;

    public long? Order
    {
      get => this.order;
      set => this.order = value;
    }

    public long? Order2
    {
      get => this.order2;
      set => this.order2 = value;
    }

    public long? Position
    {
      get => this.position;
      set => this.position = value;
    }

    public double? Profit
    {
      get => this.profit;
      set => this.profit = value;
    }

    public void FieldsFromJSONObject(JObject value)
    {
      this.profit = (double?) value["profit"];
      this.order = (long?) value["order"];
    }

    public override string ToString()
    {
      return "StreamingProfitRecord{profit=" + (object) this.profit + ", order=" + (object) this.order + (object) '}';
    }
  }
}
