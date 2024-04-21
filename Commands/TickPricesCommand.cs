using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class TickPricesCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "getTickPrices";

        public override string[] RequiredArguments
        {
            get => ["symbols", "timestamp"];
        }
    }
}
