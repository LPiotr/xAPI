﻿using Newtonsoft.Json.Linq;
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
            get => cmd;
            set => cmd = value;
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

        public long? Order
        {
            get => order;
            set => order = value;
        }

        public double? Price
        {
            get => price;
            set => price = value;
        }

        public double? Sl
        {
            get => sl;
            set => sl = value;
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

        public TRADE_TRANSACTION_TYPE Type
        {
            get => type;
            set => type = value;
        }

        public double? Volume
        {
            get => volume;
            set => volume = value;
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
            customComment = comment;
        }

        public virtual JObject ToJSONObject()
        {
            return new JObject()
      {
        {
          "cmd",
          (JToken) cmd.Code
        },
        {
          "type",
          (JToken) type.Code
        },
        {
          "price",
          (JToken) price
        },
        {
          "sl",
          (JToken) sl
        },
        {
          "tp",
          (JToken) tp
        },
        {
          "symbol",
          (JToken) symbol
        },
        {
          "volume",
          (JToken) volume
        },
        {
          "order",
          (JToken) order
        },
        {
          "customComment",
          (JToken) customComment
        },
        {
          "expiration",
          (JToken) expiration
        }
      };
        }

        public override string ToString()
        {
            return "TradeTransInfo [" + cmd.ToString() + ", " + type.ToString() + ", " + price.ToString() + ", " + sl.ToString() + ", " + tp.ToString() + ", " + symbol.ToString() + ", " + volume.ToString() + order.ToString() + ", " + customComment.ToString() + ", " + expiration.ToString() + ", ]";
        }
    }
}
