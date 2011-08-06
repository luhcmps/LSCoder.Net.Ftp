using System;
using System.Net.Sockets;

namespace LSCoder.Net.Ftp.Protocol.Response
{
    internal class TypeResponse : FtpResponse
    {
        #region Constructors

        public TypeResponse(Socket socket)
            : base(socket, new[] { 200 })
        {
        }

        #endregion
    }
}
