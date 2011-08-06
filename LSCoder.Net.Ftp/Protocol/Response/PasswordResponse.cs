using System.Net.Sockets;

namespace LSCoder.Net.Ftp.Protocol.Response
{
    internal class PasswordResponse : FtpResponse
    {

        #region Constructors

        public PasswordResponse(Socket socket)
            : base(socket, new[] { 230 })
        {
        }

        #endregion
    }
}
