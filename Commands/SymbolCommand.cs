using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class SymbolCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "getSymbol";

        public override string[] RequiredArguments
        {
            get => ["symbol"];
        }
    }
}
