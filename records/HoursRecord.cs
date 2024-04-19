// Decompiled with JetBrains decompiler
// Type: xAPI.Records.HoursRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Records
{
  public class HoursRecord : BaseResponseRecord
  {
    private long? day;
    private long? fromT;
    private long? toT;

    public virtual long? Day => this.day;

    public virtual long? FromT => this.fromT;

    public virtual long? ToT => this.toT;

    public void FieldsFromJSONObject(JObject value)
    {
      this.day = (long?) value["day"];
      this.fromT = (long?) value["fromT"];
      this.toT = (long?) value["toT"];
    }

    public override string ToString()
    {
      return "HoursRecord{day=" + (object) this.day + ", fromT=" + (object) this.fromT + ", toT=" + (object) this.toT + (object) '}';
    }
  }
}
