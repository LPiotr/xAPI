namespace xAPI.Commands
{
    public class PingCommand(bool? prettyPrint) : BaseCommand([], prettyPrint)
    {
        public override string CommandName => "ping";

        public override string[] RequiredArguments => [];
    }
}
