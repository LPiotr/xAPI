namespace xAPI.Commands
{
    public class AllSymbolsCommand : BaseCommand
    {
        public AllSymbolsCommand(bool prettyPrint)
          : base(new bool?(prettyPrint))
        {
        }

        public override string CommandName => "getAllSymbols";

        public override string[] RequiredArguments => [];
    }
}
