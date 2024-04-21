using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class CommissionDefCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string ToJSONString()
        {
            return new JObject()
            {
                {
                    "command",
                    (JToken) commandName
                },
                
                {
                    "prettyPrint",
                    (JToken) prettyPrint
                },
                {
                    "arguments",
                    (JToken) arguments
                },
                {
                    "extended",
                    (JToken) true
                }   
            }.ToString();
        }

        public override string CommandName => "getCommissionDef";

        public override string[] RequiredArguments
        {
            get => ["symbol", "volume"];
        }
    }
}
