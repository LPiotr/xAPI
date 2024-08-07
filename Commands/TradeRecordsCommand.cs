﻿using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class TradeRecordsCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "getTradeRecords";

        public override string[] RequiredArguments
        {
            get => ["orders"];
        }
    }
}
