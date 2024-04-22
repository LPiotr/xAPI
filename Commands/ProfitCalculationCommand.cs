using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class ProfitCalculationCommand(JObject arguments, bool prettyPrint) : BaseCommand(arguments, new bool?(prettyPrint))
    {
        public override string CommandName => "getProfitCalculation";

        public override string[] RequiredArguments
        {
            get
            {
                return
                [
          "cmd",
          "symbol",
          "volume",
          "openPrice",
          "closePrice"
                ];
            }
        }
    }
}
