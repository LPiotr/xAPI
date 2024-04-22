using Newtonsoft.Json.Linq;
using System;


namespace xAPI.Records
{
    public record SymbolGroupRecord : IBaseResponseRecord
    {
        private long? type;
        private string description;
        private string name;

        [Obsolete("Command getAllSymbolGroups is not available in API any more")]
        public SymbolGroupRecord()
        {
        }

        public virtual long? Type => type;

        public virtual string Description => description;

        public virtual string Name => name;

        public void FieldsFromJSONObject(JObject value)
        {
            type = (long?)value["type"];
            description = (string)value["description"];
            name = (string)value["name"];
        }
    }
}
