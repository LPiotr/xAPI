﻿namespace xAPI.Errors
{
    public class ERR_CODE(string code)
    {
        public static readonly ERR_CODE INVALID_PRICE = new("BE001");
        public static readonly ERR_CODE INVALID_SL_TP = new("BE002");
        public static readonly ERR_CODE INVALID_VOLUME = new("BE003");
        public static readonly ERR_CODE LOGIN_DISABLED = new("BE004");
        public static readonly ERR_CODE LOGIN_NOT_FOUND = new("BE005");
        public static readonly ERR_CODE MARKET_IS_CLOSED = new("BE006");
        public static readonly ERR_CODE MISMATCHED_PARAMETERS = new("BE007");
        public static readonly ERR_CODE MODIFICATION_DENIED = new("BE008");
        public static readonly ERR_CODE NOT_ENOUGH_MONEY = new("BE009");
        public static readonly ERR_CODE QUOTES_ARE_OFF = new("BE010");
        public static readonly ERR_CODE OPPOSITE_POSITIONS_PROHIBITED = new("BE011");
        public static readonly ERR_CODE SHORT_POSITIONS_PROHIBITED = new("BE012");
        public static readonly ERR_CODE PRICE_HAS_CHANGED = new("BE013");
        public static readonly ERR_CODE REQUESTS_TOO_FREQUENT = new("BE014");
        public static readonly ERR_CODE REQUOTE = new("BE015");
        public static readonly ERR_CODE TOO_MANY_TRADE_REQUESTS = new("BE016");
        public static readonly ERR_CODE TRADE_IS_DISABLED = new("BE018");
        public static readonly ERR_CODE TRADE_TIMEOUT = new("BE019");
        public static readonly ERR_CODE SYMBOL_NOT_EXIST_FOR_ACCOUNT = new("BE094");
        public static readonly ERR_CODE CANNOT_TRADE_ON_SYMBOL = new("BE095");
        public static readonly ERR_CODE CANNOT_CLOSE_PENDING = new("BE096");
        public static readonly ERR_CODE CANNOT_CLOSE_ALREADY_CLOSED_ORDER = new("BE097");
        public static readonly ERR_CODE NO_SUCH_TRANSACTION = new("BE098");
        public static readonly ERR_CODE UNKNOWN_SYMBOL = new("BE101");
        public static readonly ERR_CODE UNKNOWN_TRANSACTION_TYPE = new("BE102");
        public static readonly ERR_CODE USER_NOT_LOGGED = new("BE103");
        public static readonly ERR_CODE COMMAND_NOT_EXIST = new("BE104");
        public static readonly ERR_CODE INTERNAL_ERROR = new("EX001");
        public static readonly ERR_CODE OTHER_ERROR = new("BE099");
        private readonly string stringCode = code;

        public virtual string StringValue => stringCode == null ? "" : stringCode;

        public static string getErrorDescription(string errorCode)
        {
            return new ERR_CODE(errorCode).getDescription();
        }

        public string getDescription()
        {
            if (stringCode.Equals(""))
                return "";
            if (stringCode.Equals(ERR_CODE.INVALID_PRICE.StringValue))
                return "Invalid price.";
            if (stringCode.Equals(ERR_CODE.INVALID_SL_TP.StringValue))
                return "Invalid SL/TP.";
            if (stringCode.Equals(ERR_CODE.INVALID_VOLUME.StringValue))
                return "Invalid volume.";
            if (stringCode.Equals(ERR_CODE.LOGIN_DISABLED.StringValue))
                return "Login disabled.";
            if (stringCode.Equals(ERR_CODE.LOGIN_NOT_FOUND.StringValue))
                return "Login not found.";
            if (stringCode.Equals(ERR_CODE.MARKET_IS_CLOSED.StringValue))
                return "Market is closed!";
            if (stringCode.Equals(ERR_CODE.MISMATCHED_PARAMETERS.StringValue))
                return "Mismatched parameters.";
            if (stringCode.Equals(ERR_CODE.MODIFICATION_DENIED.StringValue))
                return "Modification denied.";
            if (stringCode.Equals(ERR_CODE.NOT_ENOUGH_MONEY.StringValue))
                return "Not enough money!";
            if (stringCode.Equals(ERR_CODE.QUOTES_ARE_OFF.StringValue))
                return "Quotes are off!";
            if (stringCode.Equals(ERR_CODE.OPPOSITE_POSITIONS_PROHIBITED.StringValue))
                return "Opposite positions prohibited!";
            if (stringCode.Equals(ERR_CODE.SHORT_POSITIONS_PROHIBITED.StringValue))
                return "Short positions prohibited!";
            if (stringCode.Equals(ERR_CODE.PRICE_HAS_CHANGED.StringValue))
                return "Price has changed..";
            if (stringCode.Equals(ERR_CODE.REQUESTS_TOO_FREQUENT.StringValue))
                return "Requests too frequent!";
            if (stringCode.Equals(ERR_CODE.REQUOTE.StringValue))
                return "Requote..";
            if (stringCode.Equals(ERR_CODE.TOO_MANY_TRADE_REQUESTS.StringValue))
                return "Too many trade requests!";
            if (stringCode.Equals(ERR_CODE.TRADE_IS_DISABLED.StringValue))
                return "Trade is disabled.";
            if (stringCode.Equals(ERR_CODE.TRADE_TIMEOUT.StringValue))
                return "Trade timeout..";
            if (stringCode.Equals(ERR_CODE.SYMBOL_NOT_EXIST_FOR_ACCOUNT.StringValue))
                return "Symbol not existent for account.";
            if (stringCode.Equals(ERR_CODE.CANNOT_TRADE_ON_SYMBOL.StringValue))
                return "Cannot trade on symbol.";
            if (stringCode.Equals(ERR_CODE.CANNOT_CLOSE_PENDING.StringValue))
                return "Cannot close pending.";
            if (stringCode.Equals(ERR_CODE.CANNOT_CLOSE_ALREADY_CLOSED_ORDER.StringValue))
                return "Cannot close - order already closed.";
            if (stringCode.Equals(ERR_CODE.NO_SUCH_TRANSACTION.StringValue))
                return "No such transaction.";
            if (stringCode.Equals(ERR_CODE.UNKNOWN_SYMBOL.StringValue))
                return "Unknown symbol.";
            if (stringCode.Equals(ERR_CODE.UNKNOWN_TRANSACTION_TYPE.StringValue))
                return "Unknown transaction type.";
            if (stringCode.Equals(ERR_CODE.USER_NOT_LOGGED.StringValue))
                return "User not logged.";
            if (stringCode.Equals(ERR_CODE.COMMAND_NOT_EXIST.StringValue))
                return "Command does not exist.";
            if (stringCode.Equals(ERR_CODE.INTERNAL_ERROR.StringValue))
                return "Internal error.";
            return stringCode.Equals(ERR_CODE.OTHER_ERROR.StringValue) ? "Internal error (2)." : "Unknown error";
        }
    }
}
