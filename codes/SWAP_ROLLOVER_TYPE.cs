﻿namespace xAPI.Codes
{
    public class SWAP_ROLLOVER_TYPE(long code) : BaseCode(code)
    {
        public static readonly SWAP_ROLLOVER_TYPE MONDAY = new(0L);
        public static readonly SWAP_ROLLOVER_TYPE TUESDAY = new(1L);
        public static readonly SWAP_ROLLOVER_TYPE WEDNSDAY = new(2L);
        public static readonly SWAP_ROLLOVER_TYPE THURSDAY = new(3L);
        public static readonly SWAP_ROLLOVER_TYPE FRIDAY = new(4L);
    }
}
