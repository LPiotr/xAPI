using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class LoginCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "login";

        public override string[] RequiredArguments
        {
            get => ["userId", "password"];
        }
    }
}
