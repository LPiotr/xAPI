using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
    public class CalendarCommand(bool prettyPrint) : BaseCommand([], new bool?(prettyPrint))
    {
        public override string CommandName => "getCalendar";

        public override string[] RequiredArguments => [];
    }
}
