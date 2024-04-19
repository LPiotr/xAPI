using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using xAPI.Records;


namespace xAPI.Responses
{
    public class AllSymbolsResponse : BaseResponse
    {
        private LinkedList<SymbolRecord> symbolRecords = new LinkedList<SymbolRecord>();

        public AllSymbolsResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in (IEnumerable<JToken>)ReturnData)
            {
                SymbolRecord symbolRecord = new SymbolRecord();
                symbolRecord.FieldsFromJSONObject(jobject);
                this.symbolRecords.AddLast(symbolRecord);
            }
        }

        public virtual LinkedList<SymbolRecord> SymbolRecords => symbolRecords;

        public List<SymbolRecord> GetSymbolsFromSpecificGroupName(string groupName)
        {
            return symbolRecords
                .Where(symbolRecord => symbolRecord.GroupName.Equals(groupName))
                .OrderBy(symbolRecord => symbolRecord.Symbol)
                .ToList();
        }


    }
}
