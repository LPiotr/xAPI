using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class StepRulesCommand : BaseCommand
    {
        public StepRulesCommand()
          : base([], new bool?(false))
        {
        }

        public override string CommandName => "getStepRules";

        public override string[] RequiredArguments => [];
    }
}
