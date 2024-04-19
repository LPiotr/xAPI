using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
  public class MarginLevelCommand : BaseCommand
  {
    public MarginLevelCommand(bool? prettyPrint)
      : base(new JObject(), prettyPrint)
    {
    }

    public override string CommandName => "getMarginLevel";

    public override string[] RequiredArguments => new string[0];
  }
}
