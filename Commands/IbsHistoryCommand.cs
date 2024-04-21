using Newtonsoft.Json.Linq;


namespace xAPI.Commands
{
    public class IbsHistoryCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "getIbsHistory";

        public override string[] RequiredArguments
        {
            get => ["start", "end"];
        }
    }
}
