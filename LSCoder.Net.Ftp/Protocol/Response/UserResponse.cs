using System.Net.Sockets;

namespace LSCoder.Net.Ftp.Protocol.Response
{
    internal class UserResponse : FtpResponse
    {

        #region Constructors

        public UserResponse(Socket socket) : base(socket, new[] { 331 })
        {
        }

        #endregion
    }
}
