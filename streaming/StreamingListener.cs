// Decompiled with JetBrains decompiler
// Type: xAPI.Streaming.StreamingListener
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using xAPI.Records;


namespace xAPI.Streaming
{
  public interface StreamingListener
  {
    void ReceiveTradeRecord(StreamingTradeRecord tradeRecord);

    void ReceiveTickRecord(StreamingTickRecord tickRecord);

    void ReceiveBalanceRecord(StreamingBalanceRecord balanceRecord);

    void ReceiveTradeStatusRecord(StreamingTradeStatusRecord tradeStatusRecord);

    void ReceiveProfitRecord(StreamingProfitRecord profitRecord);

    void ReceiveNewsRecord(StreamingNewsRecord newsRecord);

    void ReceiveKeepAliveRecord(StreamingKeepAliveRecord keepAliveRecord);

    void ReceiveCandleRecord(StreamingCandleRecord candleRecord);
  }
}
