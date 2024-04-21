using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class NewsCommand(JObject body, bool prettyPrint) : BaseCommand(body, new bool?(prettyPrint))
    {
        public override string CommandName => "getNews";

        public override string[] RequiredArguments
        {
            get => new string[2] { "start", "end" };
        }
    }
}
