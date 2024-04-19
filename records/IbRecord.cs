// Decompiled with JetBrains decompiler
// Type: xAPI.Records.IbRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using xAPI.Codes;


namespace xAPI.Records
{
  public class IbRecord : BaseResponseRecord
  {
    public double ClosePrice { get; set; }

    public string Login { get; set; }

    public double Nominal { get; set; }

    public double OpenPrice { get; set; }

    public Side Side { get; set; }

    public string Surname { get; set; }

    public string Symbol { get; set; }

    public long Timestamp { get; set; }

    public double Volume { get; set; }

    public IbRecord()
    {
    }

    public IbRecord(JObject value) => this.FieldsFromJSONObject(value);

    public void FieldsFromJSONObject(JObject value)
    {
      this.ClosePrice = (double) value["closePrice"];
      this.Login = (string) value["login"];
      this.Nominal = (double) value["nominal"];
      this.OpenPrice = (double) value["openPrice"];
      this.Side = this.Side.FromCode((int) value["side"]);
      this.Surname = (string) value["surname"];
      this.Symbol = (string) value["symbol"];
      this.Timestamp = (long) value["timestamp"];
      this.Volume = (double) value["volume"];
    }
  }
}
