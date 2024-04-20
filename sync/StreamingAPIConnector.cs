using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading;
using xAPI.Errors;
using xAPI.Records;
using xAPI.Responses;
using xAPI.Streaming;
using xAPI.Utils;

namespace xAPI.Sync
{
    public class StreamingAPIConnector : Connector, IDisposable
    {
        private StreamingListener sl;
        private string streamSessionId;
        [Obsolete("Used only in older method")]
        private bool running = false;

        public event StreamingAPIConnector.OnConnectedCallback OnConnected;

        public event StreamingAPIConnector.OnTick TickRecordReceived;

        public event StreamingAPIConnector.OnTrade TradeRecordReceived;

        public event StreamingAPIConnector.OnBalance BalanceRecordReceived;

        public event StreamingAPIConnector.OnTradeStatus TradeStatusRecordReceived;

        public event StreamingAPIConnector.OnProfit ProfitRecordReceived;

        public event StreamingAPIConnector.OnNews NewsRecordReceived;

        public event StreamingAPIConnector.OnKeepAlive KeepAliveRecordReceived;

        public event StreamingAPIConnector.OnCandle CandleRecordReceived;

        public StreamingAPIConnector(Server server)
        {
            this.server = server;
            this.apiConnected = false;
        }

        public StreamingAPIConnector(
          Server server,
          string streamSessionId,
          StreamingListener streamingListner)
        {
            this.server = server;
            this.streamSessionId = streamSessionId;
            this.Connect(streamingListner, streamSessionId);
        }

        public void Connect(StreamingListener streamingListener)
        {
            this.Connect(streamingListener, this.streamSessionId);
        }

        public void Connect() => this.Connect((StreamingListener)null, this.streamSessionId);

        public void Connect(StreamingListener streamingListener, string streamSessionId)
        {
            this.streamSessionId = streamSessionId;
            if (this.streamSessionId == null)
                throw new APICommunicationException("please login first");
            if (this.Connected())
                throw new APICommunicationException("stream already connected");
            this.sl = streamingListener;
            this.apiSocket = new TcpClient(this.server.Address, this.server.StreamingPort);
            this.apiConnected = true;
            if (this.OnConnected != null)
                this.OnConnected(this.server);
            if (this.server.Secure)
            {
                SslStream sslStream = new SslStream((Stream)this.apiSocket.GetStream(), false, new RemoteCertificateValidationCallback(SSLHelper.TrustAllCertificatesCallback));
                sslStream.AuthenticateAsClient(this.server.Address);
                this.apiWriteStream = new StreamWriter((Stream)sslStream);
                this.apiReadStream = new StreamReader((Stream)sslStream);
            }
            else
            {
                NetworkStream stream = this.apiSocket.GetStream();
                this.apiWriteStream = new StreamWriter((Stream)stream);
                this.apiReadStream = new StreamReader((Stream)stream);
            }
            new Thread((ThreadStart)(() =>
            {
                while (this.Connected())
                    this.ReadStreamMessage();
            })).Start();
        }

        public string StreamSessionId
        {
            get => this.streamSessionId;
            set => this.streamSessionId = value;
        }

        [Obsolete("Use StreamingAPIConnector(Server server) instead")]
        private StreamingAPIConnector(
          StreamingListener sl,
          string ip,
          int port,
          LoginResponse lr,
          bool secure)
        {
            this.running = true;
            this.sl = sl;
            this.streamSessionId = lr.StreamSessionId;
            this.apiSocket = new TcpClient(ip, port);
            if (secure)
            {
                SslStream sslStream = new SslStream((Stream)this.apiSocket.GetStream());
                sslStream.AuthenticateAsClient(ip);
                this.apiWriteStream = new StreamWriter((Stream)sslStream);
                this.apiReadStream = new StreamReader((Stream)sslStream);
            }
            else
            {
                NetworkStream stream = this.apiSocket.GetStream();
                this.apiWriteStream = new StreamWriter((Stream)stream);
                this.apiReadStream = new StreamReader((Stream)stream);
            }
            new Thread((ThreadStart)(() =>
            {
                while (this.running)
                {
                    this.ReadStreamMessage();
                    Thread.Sleep(50);
                }
            })).Start();
        }

        [Obsolete("Use StreamingAPIConnector(Server server) instead")]
        private StreamingAPIConnector(StreamingListener sl, string ip, int port, LoginResponse lr)
          : this(sl, ip, port, lr, false)
        {
        }

        [Obsolete("Use StreamingAPIConnector(Server server) instead")]
        public StreamingAPIConnector(StreamingListener sl, Server dt, LoginResponse lr)
          : this(sl, dt.Address, dt.StreamingPort, lr, dt.Secure)
        {
        }

        private void ReadStreamMessage()
        {
            try
            {
                string json = this.ReadMessage();
                if (json == null)
                    return;
                JObject jobject = JObject.Parse(json);
                switch (jobject["command"].ToString())
                {
                    case "tickPrices":
                        StreamingTickRecord tickRecord = new StreamingTickRecord();
                        tickRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        if (this.TickRecordReceived != null)
                            this.TickRecordReceived(tickRecord);
                        if (this.sl != null)
                        {
                            this.sl.ReceiveTickRecord(tickRecord);
                            break;
                        }
                        break;
                    case "trade":
                        StreamingTradeRecord tradeRecord = new StreamingTradeRecord();
                        tradeRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        if (this.TradeRecordReceived != null)
                            this.TradeRecordReceived(tradeRecord);
                        if (this.sl != null)
                        {
                            this.sl.ReceiveTradeRecord(tradeRecord);
                            break;
                        }
                        break;
                    case "balance":
                        StreamingBalanceRecord balanceRecord = new StreamingBalanceRecord();
                        balanceRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        if (this.BalanceRecordReceived != null)
                            this.BalanceRecordReceived(balanceRecord);
                        if (this.sl != null)
                        {
                            this.sl.ReceiveBalanceRecord(balanceRecord);
                            break;
                        }
                        break;
                    case "tradeStatus":
                        StreamingTradeStatusRecord tradeStatusRecord = new StreamingTradeStatusRecord();
                        tradeStatusRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        if (this.TradeStatusRecordReceived != null)
                            this.TradeStatusRecordReceived(tradeStatusRecord);
                        if (this.sl != null)
                        {
                            this.sl.ReceiveTradeStatusRecord(tradeStatusRecord);
                            break;
                        }
                        break;
                    case "profit":
                        StreamingProfitRecord profitRecord = new StreamingProfitRecord();
                        profitRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        if (this.ProfitRecordReceived != null)
                            this.ProfitRecordReceived(profitRecord);
                        if (this.sl != null)
                        {
                            this.sl.ReceiveProfitRecord(profitRecord);
                            break;
                        }
                        break;
                    case "news":
                        StreamingNewsRecord newsRecord = new StreamingNewsRecord();
                        newsRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        if (this.NewsRecordReceived != null)
                            this.NewsRecordReceived(newsRecord);
                        if (this.sl != null)
                        {
                            this.sl.ReceiveNewsRecord(newsRecord);
                            break;
                        }
                        break;
                    case "keepAlive":
                        StreamingKeepAliveRecord keepAliveRecord = new StreamingKeepAliveRecord();
                        keepAliveRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        if (this.KeepAliveRecordReceived != null)
                            this.KeepAliveRecordReceived(keepAliveRecord);
                        if (this.sl != null)
                        {
                            this.sl.ReceiveKeepAliveRecord(keepAliveRecord);
                            break;
                        }
                        break;
                    case "candle":
                        StreamingCandleRecord candleRecord = new StreamingCandleRecord();
                        candleRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        if (this.CandleRecordReceived != null)
                            this.CandleRecordReceived(candleRecord);
                        if (this.sl != null)
                        {
                            this.sl.ReceiveCandleRecord(candleRecord);
                            break;
                        }
                        break;
                    default:
                        throw new APICommunicationException("Unknown streaming record received");
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void SubscribePrice(string symbol, long? minArrivalTime = null, long? maxLevel = null)
        {
            this.WriteMessage(new TickPricesSubscribe(symbol, this.streamSessionId, minArrivalTime, maxLevel).ToString());
        }

        public void UnsubscribePrice(string symbol)
        {
            this.WriteMessage(new TickPricesStop(symbol).ToString());
        }

        public void SubscribePrices(IEnumerable<string> symbols)
        {
            foreach (string symbol in symbols)
                this.SubscribePrice(symbol);
        }

        public void UnsubscribePrices(LinkedList<string> symbols)
        {
            foreach (string symbol in symbols)
                this.UnsubscribePrice(symbol);
        }

        public void SubscribeTrades()
        {
            this.WriteMessage(new TradeRecordsSubscribe(this.streamSessionId).ToString());
        }

        public void UnsubscribeTrades() => this.WriteMessage(new TradeRecordsStop().ToString());

        public void SubscribeBalance()
        {
            this.WriteMessage(new BalanceRecordsSubscribe(this.streamSessionId).ToString());
        }

        public void UnsubscribeBalance() => this.WriteMessage(new BalanceRecordsStop().ToString());

        [Obsolete("Use SubscribeTradeStatus instead")]
        public void SubscribeReqStatus() => this.SubscribeTradeStatus();

        [Obsolete("Use UnsubscribeTradeStatus instead")]
        public void UnsubscribeReqStatus()
        {
            this.WriteMessage(new TradeStatusRecordsStop().ToString());
        }

        public void SubscribeTradeStatus()
        {
            this.WriteMessage(new TradeStatusRecordsSubscribe(this.streamSessionId).ToString());
        }

        public void UnsubscribeTradeStatus()
        {
            this.WriteMessage(new TradeStatusRecordsStop().ToString());
        }

        public void SubscribeProfits()
        {
            this.WriteMessage(new ProfitsSubscribe(this.streamSessionId).ToString());
        }

        public void UnsubscribeProfits() => this.WriteMessage(new ProfitsStop().ToString());

        public void SubscribeNews()
        {
            this.WriteMessage(new NewsSubscribe(this.streamSessionId).ToString());
        }

        public void UnsubscribeNews() => this.WriteMessage(new NewsStop().ToString());

        public void SubscribeKeepAlive()
        {
            this.WriteMessage(new KeepAliveSubscribe(this.streamSessionId).ToString());
        }

        public void UnsubscribeKeepAlive() => this.WriteMessage(new KeepAliveStop().ToString());

        public void SubscribeCandles(string symbol)
        {
            this.WriteMessage(new CandleRecordsSubscribe(symbol, this.streamSessionId).ToString());
        }

        public void UnsubscribeCandles(string symbol)
        {
            this.WriteMessage(new CandleRecordsStop(symbol).ToString());
        }

        public delegate void OnConnectedCallback(Server server);

        public delegate void OnTick(StreamingTickRecord tickRecord);

        public delegate void OnTrade(StreamingTradeRecord tradeRecord);

        public delegate void OnBalance(StreamingBalanceRecord balanceRecord);

        public delegate void OnTradeStatus(StreamingTradeStatusRecord tradeStatusRecord);

        public delegate void OnProfit(StreamingProfitRecord profitRecord);

        public delegate void OnNews(StreamingNewsRecord newsRecord);

        public delegate void OnKeepAlive(StreamingKeepAliveRecord keepAliveRecord);

        public delegate void OnCandle(StreamingCandleRecord candleRecord);
    }
}
