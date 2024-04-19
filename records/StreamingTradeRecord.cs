// Decompiled with JetBrains decompiler
// Type: xAPI.Records.StreamingTradeRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using xAPI.Codes;


namespace xAPI.Records
{
  public class StreamingTradeRecord : BaseResponseRecord
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
      get => this.close_price;
      set => this.close_price = value;
    }

    public long? Close_time
    {
      get => this.close_time;
      set => this.close_time = value;
    }

    public bool? Closed
    {
      get => this.closed;
      set => this.closed = value;
    }

    public long? Cmd
    {
      get => this.cmd;
      set => this.cmd = value;
    }

    public string Comment
    {
      get => this.comment;
      set => this.comment = value;
    }

    public double? Commision
    {
      get => this.commision;
      set => this.commision = value;
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

    public double? Margin_rate
    {
      get => this.margin_rate;
      set => this.margin_rate = value;
    }

    public double? Open_price
    {
      get => this.open_price;
      set => this.open_price = value;
    }

    public long? Open_time
    {
      get => this.open_time;
      set => this.open_time = value;
    }

    public long? Order
    {
      get => this.order;
      set => this.order = value;
    }

    public long? Order2
    {
      get => this.order2;
      set => this.order2 = value;
    }

    public long? Position
    {
      get => this.position;
      set => this.position = value;
    }

    public double? Profit
    {
      get => this.profit;
      set => this.profit = value;
    }

    public double? Sl
    {
      get => this.sl;
      set => this.sl = value;
    }

    public string State
    {
      get => this.state;
      set => this.state = value;
    }

    public double? Storage
    {
      get => this.storage;
      set => this.storage = value;
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

    public STREAMING_TRADE_TYPE Type
    {
      get => this.type;
      set => this.type = value;
    }

    public double? Volume
    {
      get => this.volume;
      set => this.volume = value;
    }

    public int? Digits
    {
      get => this.digits;
      set => this.digits = value;
    }

    public void FieldsFromJSONObject(JObject value)
    {
      this.close_price = (double?) value["close_price"];
      this.close_time = (long?) value["close_time"];
      this.closed = (bool?) value["closed"];
      this.cmd = new long?((long) value["cmd"]);
      this.comment = (string) value["comment"];
      this.commision = (double?) value["commision"];
      this.customComment = (string) value["customComment"];
      this.expiration = (long?) value["expiration"];
      this.margin_rate = (double?) value["margin_rate"];
      this.open_price = (double?) value["open_price"];
      this.open_time = (long?) value["open_time"];
      this.order = (long?) value["order"];
      this.order2 = (long?) value["order2"];
      this.position = (long?) value["position"];
      this.profit = (double?) value["profit"];
      this.type = new STREAMING_TRADE_TYPE((long) value["type"]);
      this.sl = (double?) value["sl"];
      this.state = (string) value["state"];
      this.storage = (double?) value["storage"];
      this.symbol = (string) value["symbol"];
      this.tp = (double?) value["tp"];
      this.volume = (double?) value["volume"];
      this.digits = (int?) value["digits"];
    }

    public override string ToString()
    {
      return "StreamingTradeRecord{symbol=" + this.symbol + ", close_time=" + (object) this.close_time + ", closed=" + (object) this.closed + ", cmd=" + (object) this.cmd + ", comment=" + this.comment + ", commision=" + (object) this.commision + ", customComment=" + this.customComment + ", expiration=" + (object) this.expiration + ", margin_rate=" + (object) this.margin_rate + ", open_price=" + (object) this.open_price + ", open_time=" + (object) this.open_time + ", order=" + (object) this.order + ", order2=" + (object) this.order2 + ", position=" + (object) this.position + ", profit=" + (object) this.profit + ", sl=" + (object) this.sl + ", state=" + this.state + ", storage=" + (object) this.storage + ", symbol=" + this.symbol + ", tp=" + (object) this.tp + ", type=" + (object) this.type.Code + ", volume=" + (object) this.volume + ", digits=" + (object) this.digits + (object) '}';
    }
  }
}
