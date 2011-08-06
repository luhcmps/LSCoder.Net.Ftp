using System.Net.Sockets;

namespace LSCoder.Net.Ftp.Protocol.Response
{
    internal class ChangeDirectoryResponse : FtpResponse
    {
        public ChangeDirectoryResponse(Socket socket) 
            : base(socket, new[] { 250 })
        {
        }
    }
}
