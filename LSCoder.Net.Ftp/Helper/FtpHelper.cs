using System.Collections.Generic;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Entities;

namespace LSCoder.Net.Ftp.Helper
{
    public class FtpHelper
    {
        #region Public Methods

        public static IList<DirectoryEntry> GetDirecoryEntries(Socket socket)
        {
            return new List<DirectoryEntry> {};
        }

        #endregion
    }
}
