// Decompiled with JetBrains decompiler
// Type: xAPI.Responses.AllSymbolGroupsResponse
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using System.Collections.Generic;
using xAPI.Records;


namespace xAPI.Responses
{
  public class AllSymbolGroupsResponse : BaseResponse
  {
    private LinkedList<SymbolGroupRecord> symbolGroupRecords = new LinkedList<SymbolGroupRecord>();

    public AllSymbolGroupsResponse(string body)
      : base(body)
    {
    }

    public virtual LinkedList<SymbolGroupRecord> SymbolGroupRecords => this.symbolGroupRecords;
  }
}
