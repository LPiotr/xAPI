using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
    public record StreamingBalanceRecord : BaseResponseRecord
    {
        private double? balance;
        private double? margin;
        private double? marginFree;
        private double? marginLevel;
        private double? equity;
        private double? credit;

        public double? Balance
        {
            get => balance;
            set => balance = value;
        }

        public double? Margin
        {
            get => margin;
            set => margin = value;
        }

        public double? MarginFree
        {
            get => marginFree;
            set => marginFree = value;
        }

        public double? MarginLevel
        {
            get => marginLevel;
            set => marginLevel = value;
        }

        public double? Equity
        {
            get => equity;
            set => equity = value;
        }

        public double? Credit
        {
            get => credit;
            set => credit = value;
        }

        public void FieldsFromJSONObject(JObject value)
        {
            Balance = (double?)value["balance"];
            Margin = (double?)value["margin"];
            MarginFree = (double?)value["marginFree"];
            MarginLevel = (double?)value["marginLevel"];
            Equity = (double?)value["equity"];
            Credit = (double?)value["credit"];
        }

        public override string ToString()
        {
            return "StreamingBalanceRecord{balance=" + (object)Balance + ", margin=" + (object)Margin + ", marginFree=" + (object)MarginFree + ", marginLevel=" + (object)MarginLevel + ", equity=" + (object)Equity + ", credit=" + (object)Credit + (object)'}';
        }
    }
}
