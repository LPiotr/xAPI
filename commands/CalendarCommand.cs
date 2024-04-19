using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
  public class CalendarCommand : BaseCommand
  {
    public CalendarCommand(bool prettyPrint)
      : base(new JObject(), new bool?(prettyPrint))
    {
    }

    public override string CommandName => "getCalendar";

    public override string[] RequiredArguments => new string[0];
  }
}
