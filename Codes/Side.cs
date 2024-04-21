namespace xAPI.Codes
{
    public class Side : BaseCode
    {
        public static readonly Side BUY = new(0);
        public static readonly Side SELL = new(1);

        public static Side FromCode(int code)
        {
            if (code == 0)
                return BUY;
            return code == 1 ? SELL : null;
        }

        private Side(int code) : base(code)
        {
        }
    }
}
