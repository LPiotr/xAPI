using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class ServerTimeCommand : BaseCommand
    {
        public ServerTimeCommand(bool? prettyPrint)
          : base(new JObject(), prettyPrint)
        {
        }

        public override string CommandName => "getServerTime";

        public override string[] RequiredArguments => new string[0];
    }
}
