using Newtonsoft.Json.Linq;
using System;


namespace xAPI.Records
{
  public record SymbolGroupRecord : BaseResponseRecord
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
