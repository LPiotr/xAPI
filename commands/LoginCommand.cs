using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
  public class LoginCommand : BaseCommand
  {
    public LoginCommand(JObject arguments, bool prettyPrint)
      : base(arguments, new bool?(prettyPrint))
    {
    }

    public override string CommandName => "login";

    public override string[] RequiredArguments
    {
      get => new string[2]{ "userId", "password" };
    }
  }
}
