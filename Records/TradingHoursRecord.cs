using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace xAPI.Records
{
    public record TradingHoursRecord : BaseResponseRecord
    {
        private string symbol;
        private LinkedList<HoursRecord> quotes = new();
        private LinkedList<HoursRecord> trading = new();

        public virtual string Symbol => symbol;

        public virtual LinkedList<HoursRecord> Quotes => quotes;

        public virtual LinkedList<HoursRecord> Trading => trading;

        public void FieldsFromJSONObject(JObject value)
        {
            FieldsFromJSONObject(value, null);
        }

        public bool FieldsFromJSONObject(JObject value, string str)
        {
            symbol = (string)value["symbol"];
            quotes = new LinkedList<HoursRecord>();
            if (value["quotes"] != null)
            {
                foreach (JObject jobject in value["quotes"].Cast<JObject>())
                {
                    HoursRecord hoursRecord = new();
                    hoursRecord.FieldsFromJSONObject(jobject);
                    quotes.AddLast(hoursRecord);
                }
            }
            
            trading = new LinkedList<HoursRecord>();
            
            if (value["trading"] != null)
            {
                foreach (JObject jobject in value["trading"].Cast<JObject>())
                {
                    HoursRecord hoursRecord = new();
                    hoursRecord.FieldsFromJSONObject(jobject);
                    trading.AddLast(hoursRecord);
                }
            }
            return symbol != null && quotes.Count != 0 && trading.Count != 0;
        }

        public override string ToString()
        {
            return "TradingHoursRecord{symbol=" + symbol + ", quotes=" + quotes.ToString() + ", trading=" + trading.ToString() + '}';
        }
    }
}
