// Decompiled with JetBrains decompiler
// Type: xAPI.Streaming.TickPricesSubscribe
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Streaming
{
  internal class TickPricesSubscribe
  {
    private string symbol;
    private long? minArrivalTime;
    private long? maxLevel;
    private string streamSessionId;

    public TickPricesSubscribe(
      string symbol,
      string streamSessionId,
      long? minArrivalTime = null,
      long? maxLevel = null)
    {
      this.symbol = symbol;
      this.minArrivalTime = minArrivalTime;
      this.streamSessionId = streamSessionId;
      this.maxLevel = maxLevel;
    }

    public override string ToString()
    {
      JObject jobject = new JObject();
      jobject.Add("command", (JToken) "getTickPrices");
      jobject.Add("symbol", (JToken) this.symbol);
      if (this.minArrivalTime.HasValue)
        jobject.Add("minArrivalTime", (JToken) this.minArrivalTime);
      if (this.maxLevel.HasValue)
        jobject.Add("maxLevel", (JToken) this.maxLevel);
      jobject.Add("streamSessionId", (JToken) this.streamSessionId);
      return jobject.ToString();
    }
  }
}
