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
        private readonly bool running = false;

        public event OnConnectedCallback OnConnected;

        public event OnTick TickRecordReceived;

        public event OnTrade TradeRecordReceived;

        public event OnBalance BalanceRecordReceived;

        public event OnTradeStatus TradeStatusRecordReceived;

        public event OnProfit ProfitRecordReceived;

        public event OnNews NewsRecordReceived;

        public event OnKeepAlive KeepAliveRecordReceived;

        public event OnCandle CandleRecordReceived;

        public StreamingAPIConnector(Server server)
        {
            this.server = server;
            apiConnected = false;
        }

        public StreamingAPIConnector(
          Server server,
          string streamSessionId,
          StreamingListener streamingListner)
        {
            this.server = server;
            this.streamSessionId = streamSessionId;
            Connect(streamingListner, streamSessionId);
        }

        public void Connect(StreamingListener streamingListener)
        {
            Connect(streamingListener, streamSessionId);
        }

        public void Connect() => Connect(null, streamSessionId);

        public void Connect(StreamingListener streamingListener, string streamSessionId)
        {
            this.streamSessionId = streamSessionId;
            if (this.streamSessionId == null)
                throw new APICommunicationException("please login first");
            if (Connected())
                throw new APICommunicationException("stream already connected");
            
            sl = streamingListener;
            apiSocket = new TcpClient(server.Address, server.StreamingPort);
            apiConnected = true;
            OnConnected?.Invoke(server);
            
            if (server.Secure)
            {
                SslStream sslStream = new(apiSocket.GetStream(), false, new RemoteCertificateValidationCallback(SSLHelper.TrustAllCertificatesCallback));
                sslStream.AuthenticateAsClient(server.Address);
                apiWriteStream = new StreamWriter(sslStream);
                apiReadStream = new StreamReader(sslStream);
            }
            else
            {
                NetworkStream stream = apiSocket.GetStream();
                apiWriteStream = new StreamWriter(stream);
                apiReadStream = new StreamReader(stream);
            }
            new Thread(() =>
            {
                while (Connected())
                    ReadStreamMessage();
            }).Start();
        }

        public string StreamSessionId
        {
            get => streamSessionId;
            set => streamSessionId = value;
        }

        [Obsolete("Use StreamingAPIConnector(Server server) instead")]
        private StreamingAPIConnector(
          StreamingListener sl,
          string ip,
          int port,
          LoginResponse lr,
          bool secure)
        {
            running = true;
            this.sl = sl;
            streamSessionId = lr.StreamSessionId;
            apiSocket = new TcpClient(ip, port);
            if (secure)
            {
                SslStream sslStream = new(apiSocket.GetStream());
                sslStream.AuthenticateAsClient(ip);
                apiWriteStream = new StreamWriter(sslStream);
                apiReadStream = new StreamReader(sslStream);
            }
            else
            {
                NetworkStream stream = apiSocket.GetStream();
                apiWriteStream = new StreamWriter(stream);
                apiReadStream = new StreamReader(stream);
            }
            new Thread(() =>
            {
                while (running)
                {
                    ReadStreamMessage();
                    Thread.Sleep(50);
                }
            }).Start();
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
                string json = ReadMessage();
                if (json == null)
                    return;
                JObject jobject = JObject.Parse(json);
                switch (jobject["command"].ToString())
                {
                    case "tickPrices":
                        StreamingTickRecord tickRecord = new();
                        tickRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        TickRecordReceived?.Invoke(tickRecord);
                        if (sl != null)
                        {
                            sl.ReceiveTickRecord(tickRecord);
                            break;
                        }
                        break;
                    case "trade":
                        StreamingTradeRecord tradeRecord = new();
                        tradeRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        TradeRecordReceived?.Invoke(tradeRecord);
                        if (sl != null)
                        {
                            sl.ReceiveTradeRecord(tradeRecord);
                            break;
                        }
                        break;
                    case "balance":
                        StreamingBalanceRecord balanceRecord = new();
                        balanceRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        BalanceRecordReceived?.Invoke(balanceRecord);
                        if (sl != null)
                        {
                            sl.ReceiveBalanceRecord(balanceRecord);
                            break;
                        }
                        break;
                    case "tradeStatus":
                        StreamingTradeStatusRecord tradeStatusRecord = new();
                        tradeStatusRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        TradeStatusRecordReceived?.Invoke(tradeStatusRecord);
                        if (sl != null)
                        {
                            sl.ReceiveTradeStatusRecord(tradeStatusRecord);
                            break;
                        }
                        break;
                    case "profit":
                        StreamingProfitRecord profitRecord = new();
                        profitRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        ProfitRecordReceived?.Invoke(profitRecord);
                        if (sl != null)
                        {
                            sl.ReceiveProfitRecord(profitRecord);
                            break;
                        }
                        break;
                    case "news":
                        StreamingNewsRecord newsRecord = new();
                        newsRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        NewsRecordReceived?.Invoke(newsRecord);
                        if (sl != null)
                        {
                            sl.ReceiveNewsRecord(newsRecord);
                            break;
                        }
                        break;
                    case "keepAlive":
                        StreamingKeepAliveRecord keepAliveRecord = new();
                        keepAliveRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        KeepAliveRecordReceived?.Invoke(keepAliveRecord);
                        if (sl != null)
                        {
                            sl.ReceiveKeepAliveRecord(keepAliveRecord);
                            break;
                        }
                        break;
                    case "candle":
                        StreamingCandleRecord candleRecord = new();
                        candleRecord.FieldsFromJSONObject((JObject)jobject["data"]);
                        CandleRecordReceived?.Invoke(candleRecord);
                        if (sl != null)
                        {
                            sl.ReceiveCandleRecord(candleRecord);
                            break;
                        }
                        break;
                    default:
                        throw new APICommunicationException("Unknown streaming record received");
                }
            }
            catch (Exception ex)
            {
                throw new APICommunicationException("Error while reading the data: " + ex.Message);
            }
        }

        public void SubscribePrice(string symbol, long? minArrivalTime = null, long? maxLevel = null)
        {
            WriteMessage(new TickPricesSubscribe(symbol, streamSessionId, minArrivalTime, maxLevel).ToString());
        }

        public void UnsubscribePrice(string symbol)
        {
            WriteMessage(new TickPricesStop(symbol).ToString());
        }

        public void SubscribePrices(IEnumerable<string> symbols)
        {
            foreach (string symbol in symbols)
                SubscribePrice(symbol);
        }

        public void UnsubscribePrices(LinkedList<string> symbols)
        {
            foreach (string symbol in symbols)
                UnsubscribePrice(symbol);
        }

        public void SubscribeTrades()
        {
            WriteMessage(new TradeRecordsSubscribe(streamSessionId).ToString());
        }

        public void UnsubscribeTrades() => WriteMessage(new TradeRecordsStop().ToString());

        public void SubscribeBalance()
        {
            WriteMessage(new BalanceRecordsSubscribe(streamSessionId).ToString());
        }

        public void UnsubscribeBalance() => WriteMessage(new BalanceRecordsStop().ToString());

        [Obsolete("Use SubscribeTradeStatus instead")]
        public void SubscribeReqStatus() => SubscribeTradeStatus();

        [Obsolete("Use UnsubscribeTradeStatus instead")]
        public void UnsubscribeReqStatus()
        {
            WriteMessage(new TradeStatusRecordsStop().ToString());
        }

        public void SubscribeTradeStatus()
        {
            WriteMessage(new TradeStatusRecordsSubscribe(streamSessionId).ToString());
        }

        public void UnsubscribeTradeStatus()
        {
            WriteMessage(new TradeStatusRecordsStop().ToString());
        }

        public void SubscribeProfits()
        {
            WriteMessage(new ProfitsSubscribe(streamSessionId).ToString());
        }

        public void UnsubscribeProfits() => WriteMessage(new ProfitsStop().ToString());

        public void SubscribeNews()
        {
            WriteMessage(new NewsSubscribe(streamSessionId).ToString());
        }

        public void UnsubscribeNews() => WriteMessage(new NewsStop().ToString());

        public void SubscribeKeepAlive()
        {
            WriteMessage(new KeepAliveSubscribe(streamSessionId).ToString());
        }

        public void UnsubscribeKeepAlive() => WriteMessage(new KeepAliveStop().ToString());

        public void SubscribeCandles(string symbol)
        {
            WriteMessage(new CandleRecordsSubscribe(symbol, streamSessionId).ToString());
        }

        public void UnsubscribeCandles(string symbol)
        {
            WriteMessage(new CandleRecordsStop(symbol).ToString());
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
