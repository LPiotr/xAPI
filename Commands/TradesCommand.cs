using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class TradesCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "getTrades";

        public override string[] RequiredArguments
        {
            get => ["openedOnly"];
        }
    }
}
