namespace xAPI.Codes
{
    public class PROFIT_MODE(long code) : BaseCode(code)
    {
        public static readonly PROFIT_MODE FOREX = new(5L);
        public static readonly PROFIT_MODE CFD = new(6L);
    }
}
