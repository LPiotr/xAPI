namespace xAPI.Codes
{
  public class Side : BaseCode
  {
    public static readonly Side BUY = new Side(0);
    public static readonly Side SELL = new Side(1);

    public Side FromCode(int code)
    {
      if (code == 0)
        return Side.BUY;
      return code == 1 ? Side.SELL : (Side) null;
    }

    private Side(int code)
      : base((long) code)
    {
    }
  }
}
