using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class ServerTimeCommand(bool? prettyPrint) : BaseCommand([], prettyPrint)
    {
        public override string CommandName => "getServerTime";

        public override string[] RequiredArguments => new string[0];
    }
}
