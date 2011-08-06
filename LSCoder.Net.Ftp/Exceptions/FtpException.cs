using System;

namespace LSCoder.Net.Ftp.Exceptions
{
    public class FtpException : ApplicationException
    {
        #region Constructors

        public FtpException()
        {
        }

        public FtpException(string message)
            : base(message)
        {
        }

        public FtpException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}
