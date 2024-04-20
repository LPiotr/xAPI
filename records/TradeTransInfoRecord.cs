using Newtonsoft.Json.Linq;
using System;
using xAPI.Codes;


namespace xAPI.Records
{
    public record TradeTransInfoRecord
    {
        private TRADE_OPERATION_CODE cmd;
        private string customComment;
        private long? expiration;
        private long? order;
        private double? price;
        private double? sl;
        private string symbol;
        private double? tp;
        private TRADE_TRANSACTION_TYPE type;
        private double? volume;

        public TRADE_OPERATION_CODE Cmd
        {
            get => this.cmd;
            set => this.cmd = value;
        }

        public string CustomComment
        {
            get => this.customComment;
            set => this.customComment = value;
        }

        public long? Expiration
        {
            get => this.expiration;
            set => this.expiration = value;
        }

        public long? Order
        {
            get => this.order;
            set => this.order = value;
        }

        public double? Price
        {
            get => this.price;
            set => this.price = value;
        }

        public double? Sl
        {
            get => this.sl;
            set => this.sl = value;
        }

        public string Symbol
        {
            get => this.symbol;
            set => this.symbol = value;
        }

        public double? Tp
        {
            get => this.tp;
            set => this.tp = value;
        }

        public TRADE_TRANSACTION_TYPE Type
        {
            get => this.type;
            set => this.type = value;
        }

        public double? Volume
        {
            get => this.volume;
            set => this.volume = value;
        }

        public TradeTransInfoRecord(
          TRADE_OPERATION_CODE cmd,
          TRADE_TRANSACTION_TYPE type,
          double? price,
          double? sl,
          double? tp,
          string symbol,
          double? volume,
          long? order,
          string customComment,
          long? expiration)
        {
            this.cmd = cmd;
            this.type = type;
            this.price = price;
            this.sl = sl;
            this.tp = tp;
            this.symbol = symbol;
            this.volume = volume;
            this.order = order;
            this.customComment = customComment;
            this.expiration = expiration;
        }

        [Obsolete("Fields ie_devation and comment are not used anymore. Use another constructor instead.")]
        public TradeTransInfoRecord(
          TRADE_OPERATION_CODE cmd,
          TRADE_TRANSACTION_TYPE type,
          double? price,
          double? sl,
          double? tp,
          string symbol,
          double? volume,
          long? ie_deviation,
          long? order,
          string comment,
          long? expiration)
        {
            this.cmd = cmd;
            this.type = type;
            this.price = price;
            this.sl = sl;
            this.tp = tp;
            this.symbol = symbol;
            this.volume = volume;
            this.order = order;
            this.expiration = expiration;
            this.customComment = comment;
        }

        public virtual JObject toJSONObject()
        {
            return new JObject()
      {
        {
          "cmd",
          (JToken) this.cmd.Code
        },
        {
          "type",
          (JToken) this.type.Code
        },
        {
          "price",
          (JToken) this.price
        },
        {
          "sl",
          (JToken) this.sl
        },
        {
          "tp",
          (JToken) this.tp
        },
        {
          "symbol",
          (JToken) this.symbol
        },
        {
          "volume",
          (JToken) this.volume
        },
        {
          "order",
          (JToken) this.order
        },
        {
          "customComment",
          (JToken) this.customComment
        },
        {
          "expiration",
          (JToken) this.expiration
        }
      };
        }

        public override string ToString()
        {
            return "TradeTransInfo [" + this.cmd.ToString() + ", " + this.type.ToString() + ", " + this.price.ToString() + ", " + this.sl.ToString() + ", " + this.tp.ToString() + ", " + this.symbol.ToString() + ", " + this.volume.ToString() + this.order.ToString() + ", " + this.customComment.ToString() + ", " + this.expiration.ToString() + ", ]";
        }
    }
}
