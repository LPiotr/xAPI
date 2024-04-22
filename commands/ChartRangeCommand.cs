using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class ChartRangeCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "getChartRangeRequest";

        public override string[] RequiredArguments
        {
            get => ["info"];
        }
    }
}
