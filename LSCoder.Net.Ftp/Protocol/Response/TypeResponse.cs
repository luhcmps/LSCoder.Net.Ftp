using System;
using System.Net.Sockets;

namespace LSCoder.Net.Ftp.Protocol.Response
{
    internal class ConnectResponse : FtpResponse
    {
        #region Constructors

        public ConnectResponse(Socket socket) : base(socket, new[] { 220 })
        {
        }

        #endregion

        #region Protected Methods

        protected override void ReadResponse(Socket socket)
        {
            base.ReadResponse(socket);

            if (!Success)
            {
                throw new ApplicationException(string.Join("\n", ResponseLines));
            }
        }

        #endregion
    }
}
