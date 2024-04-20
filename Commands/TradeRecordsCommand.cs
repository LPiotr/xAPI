using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class TradeRecordsCommand : BaseCommand
    {
        public TradeRecordsCommand(JObject arguments, bool prettyPrint)
          : base(arguments, new bool?(prettyPrint))
        {
        }

        public override string CommandName => "getTradeRecords";

        public override string[] RequiredArguments
        {
            get => ["orders"];
        }
    }
}
