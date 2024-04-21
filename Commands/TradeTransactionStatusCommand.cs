using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class TradeTransactionStatusCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "tradeTransactionStatus";

        public override string[] RequiredArguments
        {
            get => ["order"];
        }
    }
}
