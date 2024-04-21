﻿using Newtonsoft.Json.Linq;
using System;

namespace xAPI.Records
{
    public record TradeRecord : BaseResponseRecord
    {
        private double? close_price;
        private long? close_time;
        private bool? closed;
        private long? cmd;
        private string comment;
        private double? commission;
        private double? commission_agent;
        private string customComment;
        private long? digits;
        private long? expiration;
        private string expirationString;
        private double? margin_rate;
        private double? open_price;
        private long? open_time;
        private long? order;
        private long? order2;
        private long? position;
        private double? profit;
        private double? sl;
        private double? storage;
        private string symbol;
        private long? timestamp;
        private double? tp;
        private long? value_date;
        private double? volume;

        public virtual double? Close_price => close_price;

        public virtual long? Close_time => close_time;

        public virtual bool? Closed => closed;

        public virtual long? Cmd => cmd;

        public virtual string Comment => comment;

        public virtual double? Commission => commission;

        public virtual double? Commission_agent => commission_agent;

        public virtual string CustomComment => customComment;

        public virtual long? Digits => digits;

        public virtual long? Expiration => expiration;

        public virtual string ExpirationString => expirationString;

        [Obsolete]
        public virtual long? Login => new long?();

        public virtual double? Margin_rate => margin_rate;

        public virtual double? Open_price => open_price;

        public virtual long? Open_time => open_time;

        public virtual long? Order => order;

        public virtual long? Order2 => order2;

        public virtual long? Position => position;

        public virtual double? Profit => profit;

        public virtual double? Sl => sl;

        [Obsolete("Not used any more")]
        public virtual long? Spread => new long?();

        public virtual double? Storage => storage;

        public virtual string Symbol => symbol;

        [Obsolete("Not used any more")]
        public virtual double? Taxes => new double?();

        public virtual long? Timestamp => timestamp;

        public virtual double? Tp => tp;

        public virtual long? Value_date => value_date;

        public virtual double? Volume => volume;

        public void FieldsFromJSONObject(JObject value)
        {
            close_price = (double?)value["close_price"];
            close_time = (long?)value["close_time"];
            closed = (bool?)value["closed"];
            cmd = (long?)value["cmd"];
            comment = (string)value["comment"];
            commission = (double?)value["commission"];
            commission_agent = (double?)value["commission_agent"];
            customComment = (string)value["customComment"];
            digits = (long?)value["digits"];
            expiration = (long?)value["expiration"];
            expirationString = (string)value["expirationString"];
            margin_rate = (double?)value["margin_rate"];
            open_price = (double?)value["open_price"];
            open_time = (long?)value["open_time"];
            order = (long?)value["order"];
            order2 = (long?)value["order2"];
            position = (long?)value["position"];
            profit = (double?)value["profit"];
            sl = (double?)value["sl"];
            storage = (double?)value["storage"];
            symbol = (string)value["symbol"];
            timestamp = (long?)value["timestamp"];
            tp = (double?)value["tp"];
            value_date = (long?)value["value_date"];
            volume = (double?)value["volume"];
        }

        [Obsolete("Method outdated")]
        public bool FieldsFromJSONObject(JObject value, string str) => false;

        public override string ToString()
        {
            return "TradeRecord{close_price=" + (object)close_price + ", close_time=" + (object)close_time + ", closed=" + (object)closed + ", cmd=" + (object)cmd + ", comment=" + comment + ", commission=" + (object)commission + ", commission_agent=" + (object)commission_agent + ", customComment=" + customComment + ", digits=" + (object)digits + ", expiration=" + (object)expiration + ", expirationString=" + expirationString + ", margin_rate=" + (object)margin_rate + ", open_price=" + (object)open_price + ", open_time=" + (object)open_time + ", order=" + (object)order + ", order2=" + (object)Order2 + ", position=" + (object)Position + ", profit=" + (object)profit + ", sl=" + (object)sl + ", storage=" + (object)storage + ", symbol=" + symbol + ", timestamp=" + (object)timestamp + ", tp=" + (object)tp + ", value_date=" + (object)value_date + ", volume=" + (object)volume + (object)'}';
        }
    }
}
