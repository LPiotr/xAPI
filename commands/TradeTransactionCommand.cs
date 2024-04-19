using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
  public class TradeTransactionCommand : BaseCommand
  {
    public TradeTransactionCommand(JObject arguments, bool prettyPrint)
      : base(arguments, new bool?(prettyPrint))
    {
    }

    public override string CommandName => "tradeTransaction";

    public override string[] RequiredArguments
    {
      get => ["tradeTransInfo"];
    }
  }
}
