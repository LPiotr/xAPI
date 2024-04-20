using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class TradingHoursCommand : BaseCommand
    {
        public TradingHoursCommand(JObject arguments, bool prettyPrint)
          : base(arguments, new bool?(prettyPrint))
        {
        }

        public override string CommandName => "getTradingHours";

        public override string[] RequiredArguments
        {
            get => ["symbols"];
        }
    }
}
