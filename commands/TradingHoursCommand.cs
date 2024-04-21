using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class TradingHoursCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "getTradingHours";

        public override string[] RequiredArguments
        {
            get => ["symbols"];
        }
    }
}
