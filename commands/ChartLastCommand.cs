using Newtonsoft.Json.Linq;


namespace xAPI.Commands
{
  public class ChartLastCommand : BaseCommand
  {
    public ChartLastCommand(JObject arguments, bool prettyPrint)
      : base(arguments, new bool?(prettyPrint))
    {
    }

    public override string CommandName => "getChartLastRequest";

    public override string[] RequiredArguments
    {
      get => new string[1]{ "info" };
    }
  }
}
