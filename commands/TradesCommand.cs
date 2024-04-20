using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class TradesCommand : BaseCommand
    {
        public TradesCommand(JObject arguments, bool prettyPrint)
          : base(arguments, new bool?(prettyPrint))
        {
        }

        public override string CommandName => "getTrades";

        public override string[] RequiredArguments
        {
            get => ["openedOnly"];
        }
    }
}
