// Decompiled with JetBrains decompiler
// Type: xAPI.Utils.CustomTag
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll


namespace xAPI.Utils
{
  internal abstract class CustomTag
  {
    private static int lastTag = 0;
    private static int maxTag = 1000000;
    private static object locker = new object();

    public static string Next()
    {
      lock (CustomTag.locker)
      {
        CustomTag.lastTag = ++CustomTag.lastTag % CustomTag.maxTag;
        return CustomTag.lastTag.ToString();
      }
    }
  }
}
