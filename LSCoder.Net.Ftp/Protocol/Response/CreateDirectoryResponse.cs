using System.Net.Sockets;

namespace LSCoder.Net.Ftp.Protocol.Response
{
    internal class CreateDirectoryResponse : FtpResponse
    {
        public CreateDirectoryResponse(Socket socket) 
            : base(socket, new[] { 257 })
        {
        }
    }
}
