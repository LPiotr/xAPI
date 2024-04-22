namespace xAPI.Codes
{
    public class BaseCode
    {
        private long code;

        public BaseCode(long code)
        {
            this.code = code;
        }

        public long Code
        {
            get => code;
            set => code = value;
        }

        public static bool operator ==(BaseCode baseCode1, BaseCode baseCode2)
        {
            if (ReferenceEquals(baseCode1, baseCode2))
                return true;
            return baseCode1 != null && baseCode2 != null && baseCode1.Code == baseCode2.Code;
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

            return baseCode != null && Code == baseCode.Code;
        }

        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Gets or sets the long value of the base code.
        /// </summary>
        public long LongValue
        {
            get => code;
            set => code = value;
        }

        /// <summary>
        /// Gets the long value of the base code.
        /// </summary>
        /// <returns>The long value of the base code.</returns>
        public long GetLongValue() => code;
    }
}
