using System;
using System.Diagnostics;
using System.Threading;

namespace LSCoder.Net.Ftp.Helper
{
    public static class TraceHelper
    {
        #region Private Methods

        private static string FormatMessage(string message)
        {
            return string.Format("[{0}] [{1}] {2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, message);
        }

        #endregion

        #region Public Methods

        public static void Write(string message)
        {
            Trace.Write(FormatMessage(message));
        }

        public static void WriteLine(string message = "")
        {
            Trace.WriteLine(FormatMessage(message));
        }

        #endregion
    }
}
