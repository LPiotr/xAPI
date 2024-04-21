using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class VersionCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "getVersion";

        public override string[] RequiredArguments => [];
    }
}
