using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class TradesHistoryCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "getTradesHistory";

        public override string[] RequiredArguments
        {
            get => ["start", "end"];
        }
    }
}
