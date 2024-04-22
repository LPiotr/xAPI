using Newtonsoft.Json.Linq;


namespace xAPI.Records
{
    public record StreamingTickRecord : IBaseResponseRecord
    {
        private double? ask;
        private double? bid;
        private long? askVolume;
        private long? bidVolume;
        private double? high;
        private double? low;
        private string symbol;
        private double? spreadRaw;
        private double? spreadTable;
        private long? timestamp;
        private long? level;
        private long? quoteId;

        public double? Ask
        {
            get => ask;
            set => ask = value;
        }

        public double? Bid
        {
            get => bid;
            set => bid = value;
        }

        public long? AskVolume
        {
            get => askVolume;
            set => askVolume = value;
        }

        public long? BidVolume
        {
            get => bidVolume;
            set => bidVolume = value;
        }

        public double? High
        {
            get => high;
            set => high = value;
        }

        public double? Low
        {
            get => low;
            set => low = value;
        }

        public string Symbol
        {
            get => symbol;
            set => symbol = value;
        }

        public double? SpreadRaw
        {
            get => spreadRaw;
            set => spreadRaw = value;
        }

        public double? SpreadTable
        {
            get => spreadTable;
            set => spreadTable = value;
        }

        public long? Timestamp
        {
            get => timestamp;
            set => timestamp = value;
        }

        public long? Level
        {
            get => level;
            set => level = value;
        }

        public long? QuoteId
        {
            get => quoteId;
            set => quoteId = value;
        }

        public void FieldsFromJSONObject(JObject value)
        {
            ask = (double?)value["ask"];
            bid = (double?)value["bid"];
            askVolume = (long?)value["askVolume"];
            bidVolume = (long?)value["bidVolume"];
            high = (double?)value["high"];
            low = (double?)value["low"];
            symbol = (string)value["symbol"];
            timestamp = (long?)value["timestamp"];
            level = (long?)value["level"];
            quoteId = (long?)value["quoteId"];
            spreadRaw = (double?)value["spreadRaw"];
            spreadTable = (double?)value["spreadTable"];
        }

        public override string ToString()
        {
            return "StreamingTickRecord{ask=" + ask + ", bid=" + bid + ", askVolume=" + askVolume + ", bidVolume=" + bidVolume + ", high=" + high + ", low=" + low + ", symbol=" + symbol + ", timestamp=" + timestamp + ", level=" + level + ", quoteId=" + quoteId + ", spreadRaw=" + spreadRaw + ", spreadTable=" + spreadTable + '}';
        }
    }
}
