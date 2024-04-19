using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using xAPI.Records;


namespace xAPI.Responses
{
  public class AllSymbolsResponse : BaseResponse
  {
    private LinkedList<SymbolRecord> symbolRecords = new LinkedList<SymbolRecord>();

    public AllSymbolsResponse(string body)
      : base(body)
    {
      foreach (JObject jobject in (IEnumerable<JToken>) this.ReturnData)
      {
        SymbolRecord symbolRecord = new SymbolRecord();
        symbolRecord.FieldsFromJSONObject(jobject);
        this.symbolRecords.AddLast(symbolRecord);
      }
    }

    public virtual LinkedList<SymbolRecord> SymbolRecords => this.symbolRecords;
  }
}
