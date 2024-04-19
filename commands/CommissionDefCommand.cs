﻿using Newtonsoft.Json.Linq;

namespace xAPI.Commands
{
  public class CommissionDefCommand : BaseCommand
  {
    public CommissionDefCommand(JObject arguments, bool prettyPrint)
      : base(arguments, new bool?(prettyPrint))
    {
    }

    public override string ToJSONString()
    {
      return new JObject()
      {
        {
          "command",
          (JToken) this.commandName
        },
        {
          "prettyPrint",
          (JToken) this.prettyPrint
        },
        {
          "arguments",
          (JToken) this.arguments
        },
        {
          "extended",
          (JToken) true
        }
      }.ToString();
    }

    public override string CommandName => "getCommissionDef";

    public override string[] RequiredArguments
    {
      get => new string[2]{ "symbol", "volume" };
    }
  }
}
