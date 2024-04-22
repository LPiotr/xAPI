using Newtonsoft.Json.Linq;
using System;
using xAPI.Codes;


namespace xAPI.Records
{
    public record SymbolRecord : IBaseResponseRecord
    {
        private double? ask;
        private double? bid;
        private string categoryName;
        private long? contractSize;
        private string currency;
        private bool? currencyPair;
        private string currencyProfit;
        private string description;
        private long? expiration;
        private string groupName;
        private double? high;
        private long? initialMargin;
        private long? instantMaxVolume;
        private double? leverage;
        private bool? longOnly;
        private double? lotMax;
        private double? lotMin;
        private double? lotStep;
        private double? low;
        private long? marginHedged;
        private bool? marginHedgedStrong;
        private long? marginMaintenance;
        private MARGIN_MODE marginMode;
        private long? precision;
        private double? percentage;
        private PROFIT_MODE profitMode;
        private long? quoteId;
        private readonly double? spreadRaw;
        private double? spreadTable;
        private long? starting;
        private long? stepRuleId;
        private long? stopsLevel;
        private bool? swapEnable;
        private double? swapLong;
        private double? swapShort;
        private SWAP_TYPE swapType;
        private SWAP_ROLLOVER_TYPE swapRollover;
        private string symbol;
        private double? tickSize;
        private double? tickValue;
        private long? time;
        private string timeString;
        private long? type;

        public virtual double? Ask
        {
            get => ask;
            set => ask = value;
        }

        public virtual double? Bid
        {
            get => bid;
            set => bid = value;
        }

        public virtual string CategoryName
        {
            get => categoryName;
            set => categoryName = value;
        }

        public virtual long? ContractSize
        {
            get => contractSize;
            set => contractSize = value;
        }

        public virtual string Currency
        {
            get => currency;
            set => currency = value;
        }

        public virtual bool? CurrencyPair
        {
            get => currencyPair;
            set => currencyPair = value;
        }

        [Obsolete("Use Precision instead")]
        public virtual long? Digits => Precision;

        public string CurrencyProfit
        {
            get => currencyProfit;
            set => currencyProfit = value;
        }

        public virtual string Description
        {
            get => description;
            set => description = value;
        }

        public virtual long? Expiration
        {
            get => expiration;
            set => expiration = value;
        }

        public virtual string GroupName
        {
            get => groupName;
            set => groupName = value;
        }

        public virtual double? High
        {
            get => high;
            set => high = value;
        }

        public virtual long? InitialMargin
        {
            get => initialMargin;
            set => initialMargin = value;
        }

        public virtual long? InstantMaxVolume
        {
            get => instantMaxVolume;
            set => instantMaxVolume = value;
        }

        public virtual double? Leverage
        {
            get => leverage;
            set => leverage = value;
        }

        public virtual bool? LongOnly
        {
            get => longOnly;
            set => longOnly = value;
        }

        public virtual double? LotMax
        {
            get => lotMax;
            set => lotMax = value;
        }

        public virtual double? LotMin
        {
            get => lotMin;
            set => lotMin = value;
        }

        public virtual double? LotStep
        {
            get => lotStep;
            set => lotStep = value;
        }

        public virtual double? Low
        {
            get => low;
            set => low = value;
        }

        public virtual long? MarginHedged
        {
            get => marginHedged;
            set => marginHedged = value;
        }

        public virtual bool? MarginHedgedStrong
        {
            get => marginHedgedStrong;
            set => marginHedgedStrong = value;
        }

        public virtual long? MarginMaintenance
        {
            get => marginMaintenance;
            set => marginMaintenance = value;
        }

        public virtual MARGIN_MODE MarginMode
        {
            get => marginMode;
            set => marginMode = value;
        }

        public virtual long? Precision
        {
            get => precision;
            set => precision = value;
        }

        public virtual double? Percentage
        {
            get => percentage;
            set => percentage = value;
        }

        public virtual PROFIT_MODE ProfitMode
        {
            get => profitMode;
            set => profitMode = value;
        }

        public long? QuoteId
        {
            get => quoteId;
            set => quoteId = value;
        }

        public virtual double? SpreadRaw
        {
            get => spreadRaw;
            set => spreadTable = value;
        }

        public virtual double? SpreadTable
        {
            get => spreadTable;
            set => spreadTable = value;
        }

        public virtual long? Starting
        {
            get => starting;
            set => starting = value;
        }

        public virtual long? StepRuleId
        {
            get => stepRuleId;
            set => stepRuleId = value;
        }

        public virtual long? StopsLevel
        {
            get => stopsLevel;
            set => stopsLevel = value;
        }

        public virtual bool? SwapEnable
        {
            get => swapEnable;
            set => swapEnable = value;
        }

        public virtual double? SwapLong
        {
            get => swapLong;
            set => swapLong = value;
        }

        public virtual double? SwapShort
        {
            get => swapShort;
            set => swapShort = value;
        }

        public virtual SWAP_TYPE SwapType
        {
            get => swapType;
            set => swapType = value;
        }

        public virtual SWAP_ROLLOVER_TYPE SwapRollover
        {
            get => swapRollover;
            set => swapRollover = value;
        }

        public virtual string Symbol
        {
            get => symbol;
            set => symbol = value;
        }

        public virtual double? TickSize
        {
            get => tickSize;
            set => tickSize = value;
        }

        public virtual double? TickValue
        {
            get => tickValue;
            set => tickValue = value;
        }

        public virtual long? Time
        {
            get => time;
            set => time = value;
        }

        public virtual string TimeString
        {
            get => timeString;
            set => timeString = value;
        }

        public virtual long? Type
        {
            get => type;
            set => type = value;
        }

        public void FieldsFromJSONObject(JObject value)
        {
            Ask = (double?)value["ask"];
            Bid = (double?)value["bid"];
            CategoryName = (string)value["categoryName"];
            Currency = (string)value["currency"];
            CurrencyPair = (bool?)value["currencyPair"];
            CurrencyProfit = (string)value["currencyProfit"];
            Description = (string)value["description"];
            Expiration = (long?)value["expiration"];
            GroupName = (string)value["groupName"];
            High = (double?)value["high"];
            InstantMaxVolume = (long?)value["instantMaxVolume"];
            Leverage = new double?((double)value["leverage"]);
            LongOnly = (bool?)value["longOnly"];
            LotMax = (double?)value["lotMax"];
            LotMin = (double?)value["lotMin"];
            LotStep = (double?)value["lotStep"];
            Low = (double?)value["low"];
            Precision = (long?)value["precision"];
            Starting = (long?)value["starting"];
            StopsLevel = (long?)value["stopsLevel"];
            Symbol = (string)value["symbol"];
            Time = (long?)value["time"];
            TimeString = (string)value["timeString"];
            Type = (long?)value["type"];
            ContractSize = (long?)value["contractSize"];
            InitialMargin = (long?)value["initialMargin"];
            MarginHedged = (long?)value["marginHedged"];
            MarginHedgedStrong = (bool?)value["marginHedgedStrong"];
            MarginMaintenance = (long?)value["marginMaintenance"];
            MarginMode = new MARGIN_MODE((long)value["marginMode"]);
            Percentage = (double?)value["percentage"];
            ProfitMode = new PROFIT_MODE((long)value["profitMode"]);
            QuoteId = (long?)value["quoteId"];
            SpreadRaw = (double?)value["spreadRaw"];
            SpreadTable = (double?)value["spreadTable"];
            StepRuleId = (long?)value["stepRuleId"];
            SwapEnable = (bool?)value["swapEnable"];
            SwapLong = (double?)value["swapLong"];
            SwapShort = (double?)value["swapShort"];
            SwapType = new SWAP_TYPE((long)value["swapType"]);
            SwapRollover = new SWAP_ROLLOVER_TYPE((long)value["swap_rollover3days"]);
            TickSize = (double?)value["tickSize"];
            TickValue = (double?)value["tickValue"];
        }
    }
}
