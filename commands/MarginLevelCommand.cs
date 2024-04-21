using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class MarginLevelCommand(bool? prettyPrint) : BaseCommand([], prettyPrint)
    {
        public override string CommandName => "getMarginLevel";

        public override string[] RequiredArguments => [];
    }
}
