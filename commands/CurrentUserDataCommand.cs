using Newtonsoft.Json.Linq;


namespace xAPI.Commands
{
  public class CurrentUserDataCommand : BaseCommand
  {
    public CurrentUserDataCommand(bool prettyPrint)
      : base(new JObject(), new bool?(prettyPrint))
    {
    }

    public override string CommandName => "getCurrentUserData";

    public override string[] RequiredArguments => new string[0];
  }
}
