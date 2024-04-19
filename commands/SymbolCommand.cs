using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
  public class SymbolCommand : BaseCommand
  {
    public SymbolCommand(JObject arguments, bool prettyPrint)
      : base(arguments, new bool?(prettyPrint))
    {
    }

    public override string CommandName => "getSymbol";

    public override string[] RequiredArguments
    {
      get => new string[1]{ "symbol" };
    }
  }
}
