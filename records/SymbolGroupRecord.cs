// Decompiled with JetBrains decompiler
// Type: xAPI.Records.SymbolGroupRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using System;


namespace xAPI.Records
{
  public class SymbolGroupRecord : BaseResponseRecord
  {
    private long? type;
    private string description;
    private string name;

    [Obsolete("Command getAllSymbolGroups is not available in API any more")]
    public SymbolGroupRecord()
    {
    }

    public virtual long? Type => this.type;

    public virtual string Description => this.description;

    public virtual string Name => this.name;

    public void FieldsFromJSONObject(JObject value)
    {
      this.type = (long?) value["type"];
      this.description = (string) value["description"];
      this.name = (string) value["name"];
    }
  }
}
