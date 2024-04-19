// Decompiled with JetBrains decompiler
// Type: xAPI.Errors.APICommunicationException
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using System;


namespace xAPI.Errors
{
  public class APICommunicationException : Exception
  {
    public APICommunicationException()
    {
    }

    public APICommunicationException(string msg)
      : base(msg)
    {
    }
  }
}
