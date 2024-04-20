using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class ProfitCalculationCommand : BaseCommand
    {
        public ProfitCalculationCommand(JObject arguments, bool prettyPrint)
          : base(arguments, new bool?(prettyPrint))
        {
        }

        public override string CommandName => "getProfitCalculation";

        public override string[] RequiredArguments
        {
            get
            {
                return new string[5]
                {
          "cmd",
          "symbol",
          "volume",
          "openPrice",
          "closePrice"
                };
            }
        }
    }
}
