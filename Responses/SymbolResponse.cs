using Newtonsoft.Json.Linq;
using xAPI.Records;


namespace xAPI.Responses
{
    public class SymbolResponse : BaseResponse
    {
        private SymbolRecord symbol;

        public SymbolResponse(string body)
          : base(body)
        {
            JObject returnData = (JObject)this.ReturnData;
            this.symbol = new SymbolRecord();
            this.symbol.FieldsFromJSONObject(returnData);
        }

        public virtual SymbolRecord Symbol => this.symbol;
    }
}
