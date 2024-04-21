using System.Collections.Generic;
using xAPI.Records;


namespace xAPI.Responses
{
    public class AllSymbolGroupsResponse(string body) : BaseResponse(body)
    {
        private readonly LinkedList<SymbolGroupRecord> symbolGroupRecords = new();

        public virtual LinkedList<SymbolGroupRecord> SymbolGroupRecords => symbolGroupRecords;
    }
}
