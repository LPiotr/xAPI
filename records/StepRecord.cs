// Decompiled with JetBrains decompiler
// Type: xAPI.Records.StepRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Records
{
  public class StepRecord : BaseResponseRecord
  {
    private double FromValue;
    private double Step;

    public void FieldsFromJSONObject(JObject value)
    {
      this.FromValue = (double) value["fromValue"];
      this.Step = (double) value["step"];
    }
  }
}
