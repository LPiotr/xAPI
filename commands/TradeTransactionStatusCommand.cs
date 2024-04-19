using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
  public class TradeTransactionStatusCommand : BaseCommand
  {
    public TradeTransactionStatusCommand(JObject arguments, bool prettyPrint)
      : base(arguments, new bool?(prettyPrint))
    {
    }

    public override string CommandName => "tradeTransactionStatus";

    public override string[] RequiredArguments
    {
      get => ["order"];
    }
  }
}
