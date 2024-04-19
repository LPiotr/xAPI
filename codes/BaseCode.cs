using System;


namespace xAPI.Codes
{
  public class BaseCode
  {
    private long code;

    public BaseCode(long code) => this.code = code;

    public long Code
    {
      get => this.code;
      set => this.code = value;
    }

    public static bool operator ==(BaseCode baseCode1, BaseCode baseCode2)
    {
      if (object.ReferenceEquals((object) baseCode1, (object) baseCode2))
        return true;
      return (object) baseCode1 != null && (object) baseCode2 != null && baseCode1.Code == baseCode2.Code;
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
      return (object) baseCode != null && this.Code == baseCode.Code;
    }

    public override int GetHashCode() => base.GetHashCode();

    [Obsolete("Use Code instead")]
    public long LongValue
    {
      get => this.code;
      set => this.code = value;
    }

    [Obsolete("Use Code instead")]
    public long longValue() => this.code;
  }
}
