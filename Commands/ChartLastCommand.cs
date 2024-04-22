using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class ChartLastCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "getChartLastRequest";

        public override string[] RequiredArguments
        {
            get => ["info"];
        }
    }
}
