using Newtonsoft.Json.Linq;
using xAPI.Codes;


namespace xAPI.Records
{
    public record StreamingTradeRecord : BaseResponseRecord
    {
        private double? close_price;
        private long? close_time;
        private bool? closed;
        private long? cmd;
        private string comment;
        private double? commision;
        private string customComment;
        private long? expiration;
        private double? margin_rate;
        private double? open_price;
        private long? open_time;
        private long? order;
        private long? order2;
        private long? position;
        private double? profit;
        private double? sl;
        private string state;
        private double? storage;
        private string symbol;
        private double? tp;
        private STREAMING_TRADE_TYPE type;
        private double? volume;
        private int? digits;

        public double? Close_price
        {
            get => close_price;
            set => close_price = value;
        }

        public long? Close_time
        {
            get => close_time;
            set => close_time = value;
        }

        public bool? Closed
        {
            get => closed;
            set => closed = value;
        }

        public long? Cmd
        {
            get => cmd;
            set => cmd = value;
        }

        public string Comment
        {
            get => comment;
            set => comment = value;
        }

        public double? Commision
        {
            get => commision;
            set => commision = value;
        }

        public string CustomComment
        {
            get => customComment;
            set => customComment = value;
        }

        public long? Expiration
        {
            get => expiration;
            set => expiration = value;
        }

        public double? Margin_rate
        {
            get => margin_rate;
            set => margin_rate = value;
        }

        public double? Open_price
        {
            get => open_price;
            set => open_price = value;
        }

        public long? Open_time
        {
            get => open_time;
            set => open_time = value;
        }

        public long? Order
        {
            get => order;
            set => order = value;
        }

        public long? Order2
        {
            get => order2;
            set => order2 = value;
        }

        public long? Position
        {
            get => position;
            set => position = value;
        }

        public double? Profit
        {
            get => profit;
            set => profit = value;
        }

        public double? Sl
        {
            get => sl;
            set => sl = value;
        }

        public string State
        {
            get => state;
            set => state = value;
        }

        public double? Storage
        {
            get => storage;
            set => storage = value;
        }

        public string Symbol
        {
            get => symbol;
            set => symbol = value;
        }

        public double? Tp
        {
            get => tp;
            set => tp = value;
        }

        public STREAMING_TRADE_TYPE Type
        {
            get => type;
            set => type = value;
        }

        public double? Volume
        {
            get => volume;
            set => volume = value;
        }

        public int? Digits
        {
            get => digits;
            set => digits = value;
        }

        public void FieldsFromJSONObject(JObject value)
        {
            close_price = (double?)value["close_price"];
            close_time = (long?)value["close_time"];
            closed = (bool?)value["closed"];
            cmd = new long?((long)value["cmd"]);
            comment = (string)value["comment"];
            commision = (double?)value["commision"];
            customComment = (string)value["customComment"];
            expiration = (long?)value["expiration"];
            margin_rate = (double?)value["margin_rate"];
            open_price = (double?)value["open_price"];
            open_time = (long?)value["open_time"];
            order = (long?)value["order"];
            order2 = (long?)value["order2"];
            position = (long?)value["position"];
            profit = (double?)value["profit"];
            type = new STREAMING_TRADE_TYPE((long)value["type"]);
            sl = (double?)value["sl"];
            state = (string)value["state"];
            storage = (double?)value["storage"];
            symbol = (string)value["symbol"];
            tp = (double?)value["tp"];
            volume = (double?)value["volume"];
            digits = (int?)value["digits"];
        }

        public override string ToString()
        {
            return "StreamingTradeRecord{symbol=" + symbol + ", close_time=" + (object)close_time + ", closed=" + (object)closed + ", cmd=" + (object)cmd + ", comment=" + comment + ", commision=" + (object)commision + ", customComment=" + customComment + ", expiration=" + (object)expiration + ", margin_rate=" + (object)margin_rate + ", open_price=" + (object)open_price + ", open_time=" + (object)open_time + ", order=" + (object)order + ", order2=" + (object)order2 + ", position=" + (object)position + ", profit=" + (object)profit + ", sl=" + (object)sl + ", state=" + state + ", storage=" + (object)storage + ", symbol=" + symbol + ", tp=" + (object)tp + ", type=" + (object)type.Code + ", volume=" + (object)volume + ", digits=" + (object)digits + (object)'}';
        }
    }
}
