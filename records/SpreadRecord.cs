using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
    public record SpreadRecord : IBaseResponseRecord
    {
        private long? precision;
        private string symbol;
        private long? value;
        private long? quoteId;

        public virtual long? Precision
        {
            get => precision;
            set => precision = value;
        }

        public virtual string Symbol
        {
            get => symbol;
            set => symbol = value;
        }

        public virtual long? QuoteId
        {
            get => quoteId;
            set => quoteId = value;
        }

        public virtual long? Value
        {
            get => value;
            set => this.value = value;
        }

        public void FieldsFromJSONObject(JObject value)
        {
            Symbol = (string)value["symbol"];
            Precision = (long?)value["precision"];
            Value = (long?)value[nameof(value)];
            QuoteId = (long?)value["quoteId"];
        }
    }
}
