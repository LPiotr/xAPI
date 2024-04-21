using System;
using xAPI.Errors;

namespace xAPI.Responses
{
    public class APIErrorResponse(ERR_CODE code, string errDesc, string msg) : Exception(msg)
    {
        private ERR_CODE code = code;
        private string errDesc = errDesc;
        private string msg = msg;

        public override string Message
        {
            get
            {
                return "ERR_CODE = " + code.StringValue + " ERR_DESC = " + errDesc + "\n" + msg + "\n" + base.Message;
            }
        }

        public virtual string Msg => msg;

        public virtual ERR_CODE ErrorCode => code;

        public virtual string ErrorDescr => errDesc;

        public override string ToString() => ErrorCode.StringValue + ": " + ErrorDescr;
    }
}
