using System.Net.Sockets;

namespace LSCoder.Net.Ftp.Protocol.Response
{
    internal class RemoveDirectoryResponse : FtpResponse
    {
        public RemoveDirectoryResponse(Socket socket) 
            : base(socket, new[] { 250 })
        {
        }
    }
}
