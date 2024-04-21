namespace xAPI.Commands
{
    public class AllSymbolsCommand(bool prettyPrint) : BaseCommand(new bool?(prettyPrint))
    {
        public override string CommandName => "getAllSymbols";

        public override string[] RequiredArguments => [];
    }
}
