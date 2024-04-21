namespace xAPI.Codes
{
    public class EXECUTION_CODE(long code) : BaseCode(code)
    {
        public static readonly EXECUTION_CODE EXE_REQUEST = new(0L);
        public static readonly EXECUTION_CODE EXE_INSTANT = new(1L);
        public static readonly EXECUTION_CODE EXE_MARKET = new(2L);
    }
}
