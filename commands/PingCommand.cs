using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class PingCommand : BaseCommand
    {
        public PingCommand(bool? prettyPrint)
          : base(new JObject(), prettyPrint)
        {
        }

        public override string CommandName => "ping";

        public override string[] RequiredArguments => new string[0];
    }
}
