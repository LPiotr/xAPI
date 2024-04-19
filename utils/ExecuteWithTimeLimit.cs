// Decompiled with JetBrains decompiler
// Type: SyncAPIConnect.Utils.ExecuteWithTimeLimit
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using System;
using System.Threading.Tasks;


namespace SyncAPIConnect.Utils
{
  internal class ExecuteWithTimeLimit
  {
    public static bool Execute(TimeSpan timeSpan, Action codeBlock)
    {
      try
      {
        Task task = Task.Factory.StartNew((Action) (() => codeBlock()));
        task.Wait(timeSpan);
        return task.IsCompleted;
      }
      catch (AggregateException ex)
      {
        throw ex.InnerExceptions[0];
      }
    }
  }
}
