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
                Task task = Task.Factory.StartNew((Action)(() => codeBlock()));
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
