using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class TradeTransactionCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "tradeTransaction";

        public override string[] RequiredArguments
        {
            get => ["tradeTransInfo"];
        }
    }
}
