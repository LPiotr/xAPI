namespace xAPI.Utils
{
    internal abstract class CustomTag
    {
        private static int lastTag = 0;
        private static int maxTag = 1000000;
        private static object locker = new();

        public static string Next()
        {
            lock (locker)
            {
                lastTag = ++lastTag % maxTag;
                return lastTag.ToString();
            }
        }
    }
}
