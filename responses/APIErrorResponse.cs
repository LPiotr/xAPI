using System;
using xAPI.Errors;

namespace xAPI.Responses
{
  public class APIErrorResponse : Exception
  {
    private ERR_CODE code;
    private string errDesc;
    private string msg;

    public APIErrorResponse(ERR_CODE code, string errDesc, string msg)
      : base(msg)
    {
      this.code = code;
      this.errDesc = errDesc;
      this.msg = msg;
    }

    public override string Message
    {
      get
      {
        return "ERR_CODE = " + this.code.StringValue + " ERR_DESC = " + this.errDesc + "\n" + this.msg + "\n" + base.Message;
      }
    }

    public virtual string Msg => this.msg;

    public virtual ERR_CODE ErrorCode => this.code;

    public virtual string ErrorDescr => this.errDesc;

    public override string ToString() => this.ErrorCode.StringValue + ": " + this.ErrorDescr;
  }
}
