// Decompiled with JetBrains decompiler
// Type: xAPI.Commands.TradingHoursCommand
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Commands
{
  public class TradingHoursCommand : BaseCommand
  {
    public TradingHoursCommand(JObject arguments, bool prettyPrint)
      : base(arguments, new bool?(prettyPrint))
    {
    }

    public override string CommandName => "getTradingHours";

    public override string[] RequiredArguments
    {
      get => new string[1]{ "symbols" };
    }
  }
}
