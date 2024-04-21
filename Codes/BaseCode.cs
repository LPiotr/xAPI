using System;

namespace xAPI.Codes
{
    public class BaseCode(long code)
    {
        private long code = code;

        public long Code
        {
            get => code;
            set => code = value;
        }

        public static bool operator ==(BaseCode baseCode1, BaseCode baseCode2)
        {
            if (ReferenceEquals(baseCode1, baseCode2))
                return true;
            return (object)baseCode1 != null && (object)baseCode2 != null && baseCode1.Code == baseCode2.Code;
        }

        public static bool operator !=(BaseCode baseCode1, BaseCode baseCode2)
        {
            return !(baseCode1 == baseCode2);
        }

        public override bool Equals(object target)
        {
            if (target == null)
                return false;

            BaseCode baseCode = target as BaseCode;

            return (object)baseCode != null && Code == baseCode.Code;
        }

        public override int GetHashCode() => base.GetHashCode();

        public long LongValue
        {
            get => code;
            set => code = value;
        }

        public long longValue() => code;
    }
}
