namespace xAPI.Commands
{
    public class CurrentUserDataCommand(bool prettyPrint) : BaseCommand([], new bool?(prettyPrint))
    {
        public override string CommandName => "getCurrentUserData";

        public override string[] RequiredArguments => [];
    }
}
