using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
  public class TickPricesCommand : BaseCommand
  {
    public TickPricesCommand(JObject arguments, bool prettyPrint)
      : base(arguments, new bool?(prettyPrint))
    {
    }

    public override string CommandName => "getTickPrices";

    public override string[] RequiredArguments
    {
      get => new string[2]{ "symbols", "timestamp" };
    }
  }
}
