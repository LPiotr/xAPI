using Newtonsoft.Json.Linq;
using System;

namespace xAPI.Commands
{
    [method: Obsolete("Not available in API any more")]
    public class AllSymbolGroupsCommand(bool? prettyPrint) : BaseCommand([], prettyPrint)
    {
        public override string CommandName => "getAllSymbolGroups";
        public override string[] RequiredArguments => [];
    }
}
