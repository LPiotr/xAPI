﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace xAPI.Records
{
    public record TradingHoursRecord : BaseResponseRecord
    {
        private string symbol;
        private LinkedList<HoursRecord> quotes = new();
        private LinkedList<HoursRecord> trading = new();

        public virtual string Symbol => this.symbol;

        public virtual LinkedList<HoursRecord> Quotes => this.quotes;

        public virtual LinkedList<HoursRecord> Trading => this.trading;

        public void FieldsFromJSONObject(JObject value)
        {
            this.FieldsFromJSONObject(value, (string)null);
        }

        public bool FieldsFromJSONObject(JObject value, string str)
        {
            symbol = (string)value["symbol"];
            quotes = new LinkedList<HoursRecord>();
            if (value["quotes"] != null)
            {
                foreach (JObject jobject in (IEnumerable<JToken>)value["quotes"])
                {
                    HoursRecord hoursRecord = new HoursRecord();
                    hoursRecord.FieldsFromJSONObject(jobject);
                    quotes.AddLast(hoursRecord);
                }
            }
            
            trading = new LinkedList<HoursRecord>();
            
            if (value["trading"] != null)
            {
                foreach (JObject jobject in (IEnumerable<JToken>)value["trading"])
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
            return "TradingHoursRecord{symbol=" + symbol + ", quotes=" + quotes.ToString() + ", trading=" + trading.ToString() + (object)'}';
        }
    }
}