using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
  public class TradesHistoryCommand : BaseCommand
  {
    public TradesHistoryCommand(JObject arguments, bool prettyPrint)
      : base(arguments, new bool?(prettyPrint))
    {
    }

    public override string CommandName => "getTradesHistory";

    public override string[] RequiredArguments
    {
      get => new string[2]{ "start", "end" };
    }
  }
}
