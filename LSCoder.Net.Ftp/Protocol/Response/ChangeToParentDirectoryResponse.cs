using System.Net.Sockets;

namespace LSCoder.Net.Ftp.Protocol.Response
{
    internal class ChangeToParentDirectoryResponse : FtpResponse
    {
        public ChangeToParentDirectoryResponse(Socket socket) 
            : base(socket, new[] { 250 })
        {
        }
    }
}
