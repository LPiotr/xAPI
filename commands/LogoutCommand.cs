using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class LogoutCommand : BaseCommand
    {
        public LogoutCommand()
          : base([], new bool?(false))
        {
        }

        public override string ToJSONString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) commandName
        }
      }.ToString();
        }

        public override string CommandName => "logout";

        public override string[] RequiredArguments => new string[0];
    }
}
