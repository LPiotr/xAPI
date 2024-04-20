namespace xAPI.Codes
{
    public class Side : BaseCode
    {
        public static readonly Side BUY = new Side(0);
        public static readonly Side SELL = new Side(1);

        public static Side FromCode(int code)
        {
            if (code == 0)
                return BUY;
            return code == 1 ? SELL : null;
        }

        private Side(int code) : base((long)code)
        {
        }
    }
}
