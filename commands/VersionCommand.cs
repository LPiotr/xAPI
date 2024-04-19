using Newtonsoft.Json.Linq;


namespace xAPI.Commands
{
  public class VersionCommand : BaseCommand
  {
    public VersionCommand(JObject arguments, bool prettyPrint)
      : base(arguments, new bool?(prettyPrint))
    {
    }

    public override string CommandName => "getVersion";

    public override string[] RequiredArguments => new string[0];
  }
}
