﻿// Decompiled with JetBrains decompiler
// Type: xAPI.Commands.LogoutCommand
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;


namespace xAPI.Commands
{
  public class LogoutCommand : BaseCommand
  {
    public LogoutCommand()
      : base(new JObject(), new bool?(false))
    {
    }

    public override string ToJSONString()
    {
      return new JObject()
      {
        {
          "command",
          (JToken) this.commandName
        }
      }.ToString();
    }

    public override string CommandName => "logout";

    public override string[] RequiredArguments => new string[0];
  }
}
