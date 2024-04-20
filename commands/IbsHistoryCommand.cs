using Newtonsoft.Json.Linq;


namespace xAPI.Commands
{
    public class IbsHistoryCommand : BaseCommand
    {
        public IbsHistoryCommand(JObject arguments, bool prettyPrint)
          : base(arguments, new bool?(prettyPrint))
        {
        }

        public override string CommandName => "getIbsHistory";

        public override string[] RequiredArguments
        {
            get => ["start", "end"];
        }
    }
}
