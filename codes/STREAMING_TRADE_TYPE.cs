﻿namespace xAPI.Codes
{
  public class STREAMING_TRADE_TYPE : BaseCode
  {
    public static readonly STREAMING_TRADE_TYPE OPEN = new STREAMING_TRADE_TYPE(0L);
    public static readonly STREAMING_TRADE_TYPE PENDING = new STREAMING_TRADE_TYPE(1L);
    public static readonly STREAMING_TRADE_TYPE CLOSE = new STREAMING_TRADE_TYPE(2L);

    public STREAMING_TRADE_TYPE(long code)
      : base(code)
    {
    }
  }
}
