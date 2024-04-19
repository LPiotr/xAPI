// Decompiled with JetBrains decompiler
// Type: xAPI.Records.TradeRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using System;


namespace xAPI.Records
{
  public class TradeRecord : BaseResponseRecord
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

    public virtual double? Close_price => this.close_price;

    public virtual long? Close_time => this.close_time;

    public virtual bool? Closed => this.closed;

    public virtual long? Cmd => this.cmd;

    public virtual string Comment => this.comment;

    public virtual double? Commission => this.commission;

    public virtual double? Commission_agent => this.commission_agent;

    public virtual string CustomComment => this.customComment;

    public virtual long? Digits => this.digits;

    public virtual long? Expiration => this.expiration;

    public virtual string ExpirationString => this.expirationString;

    [Obsolete]
    public virtual long? Login => new long?();

    public virtual double? Margin_rate => this.margin_rate;

    public virtual double? Open_price => this.open_price;

    public virtual long? Open_time => this.open_time;

    public virtual long? Order => this.order;

    public virtual long? Order2 => this.order2;

    public virtual long? Position => this.position;

    public virtual double? Profit => this.profit;

    public virtual double? Sl => this.sl;

    [Obsolete("Not used any more")]
    public virtual long? Spread => new long?();

    public virtual double? Storage => this.storage;

    public virtual string Symbol => this.symbol;

    [Obsolete("Not used any more")]
    public virtual double? Taxes => new double?();

    public virtual long? Timestamp => this.timestamp;

    public virtual double? Tp => this.tp;

    public virtual long? Value_date => this.value_date;

    public virtual double? Volume => this.volume;

    public void FieldsFromJSONObject(JObject value)
    {
      this.close_price = (double?) value["close_price"];
      this.close_time = (long?) value["close_time"];
      this.closed = (bool?) value["closed"];
      this.cmd = (long?) value["cmd"];
      this.comment = (string) value["comment"];
      this.commission = (double?) value["commission"];
      this.commission_agent = (double?) value["commission_agent"];
      this.customComment = (string) value["customComment"];
      this.digits = (long?) value["digits"];
      this.expiration = (long?) value["expiration"];
      this.expirationString = (string) value["expirationString"];
      this.margin_rate = (double?) value["margin_rate"];
      this.open_price = (double?) value["open_price"];
      this.open_time = (long?) value["open_time"];
      this.order = (long?) value["order"];
      this.order2 = (long?) value["order2"];
      this.position = (long?) value["position"];
      this.profit = (double?) value["profit"];
      this.sl = (double?) value["sl"];
      this.storage = (double?) value["storage"];
      this.symbol = (string) value["symbol"];
      this.timestamp = (long?) value["timestamp"];
      this.tp = (double?) value["tp"];
      this.value_date = (long?) value["value_date"];
      this.volume = (double?) value["volume"];
    }

    [Obsolete("Method outdated")]
    public bool FieldsFromJSONObject(JObject value, string str) => false;

    public override string ToString()
    {
      return "TradeRecord{close_price=" + (object) this.close_price + ", close_time=" + (object) this.close_time + ", closed=" + (object) this.closed + ", cmd=" + (object) this.cmd + ", comment=" + this.comment + ", commission=" + (object) this.commission + ", commission_agent=" + (object) this.commission_agent + ", customComment=" + this.customComment + ", digits=" + (object) this.digits + ", expiration=" + (object) this.expiration + ", expirationString=" + this.expirationString + ", margin_rate=" + (object) this.margin_rate + ", open_price=" + (object) this.open_price + ", open_time=" + (object) this.open_time + ", order=" + (object) this.order + ", order2=" + (object) this.Order2 + ", position=" + (object) this.Position + ", profit=" + (object) this.profit + ", sl=" + (object) this.sl + ", storage=" + (object) this.storage + ", symbol=" + this.symbol + ", timestamp=" + (object) this.timestamp + ", tp=" + (object) this.tp + ", value_date=" + (object) this.value_date + ", volume=" + (object) this.volume + (object) '}';
    }
  }
}
