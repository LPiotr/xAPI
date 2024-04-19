using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
  public class ChartRangeCommand : BaseCommand
  {
    public ChartRangeCommand(JObject arguments, bool prettyPrint)
      : base(arguments, new bool?(prettyPrint))
    {
    }

    public override string CommandName => "getChartRangeRequest";

    public override string[] RequiredArguments
    {
      get => new string[1]{ "info" };
    }
  }
}
