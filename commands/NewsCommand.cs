using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
  public class NewsCommand : BaseCommand
  {
    public NewsCommand(JObject body, bool prettyPrint)
      : base(body, new bool?(prettyPrint))
    {
    }

    public override string CommandName => "getNews";

    public override string[] RequiredArguments
    {
      get => new string[2]{ "start", "end" };
    }
  }
}
