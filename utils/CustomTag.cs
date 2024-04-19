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
