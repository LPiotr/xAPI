namespace xAPI.Codes
{
    public class MARGIN_MODE(long code) : BaseCode(code)
    {
        public static readonly MARGIN_MODE FOREX = new(101L);
        public static readonly MARGIN_MODE CFD_LEVERAGED = new(102L);
        public static readonly MARGIN_MODE CFD = new(103L);
    }
}
