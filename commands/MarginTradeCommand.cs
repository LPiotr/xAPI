using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
  public class MarginTradeCommand : BaseCommand
  {
    public MarginTradeCommand(JObject arguments, bool prettyPrint)
      : base(arguments, new bool?(prettyPrint))
    {
    }

    public override string CommandName => "getMarginTrade";

    public override string[] RequiredArguments
    {
      get => new string[2]{ "symbol", "volume" };
    }
  }
}
