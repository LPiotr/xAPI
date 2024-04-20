using Newtonsoft.Json.Linq;
using System;

namespace xAPI.Commands
{
    public class AllSymbolGroupsCommand : BaseCommand
    {
        [Obsolete("Not available in API any more")]
        public AllSymbolGroupsCommand(bool? prettyPrint)
          : base(new JObject(), prettyPrint)
        {
        }

        public override string CommandName => "getAllSymbolGroups";
        public override string[] RequiredArguments => [];
    }
}
