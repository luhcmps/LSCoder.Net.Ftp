using System;
using System.Net.Sockets;

namespace LSCoder.Net.Ftp.Protocol.Response
{
    internal class GetFileSizeResponse : FtpResponse
    {

        #region Constructors

        public GetFileSizeResponse(Socket socket)
            : base(socket, new[] { 213 })
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Tamanho do arquivo (bytes)
        /// </summary>
        public int FileSize { get; private set; }

        #endregion

        #region Protected Methods

        protected override void ReadResponse(Socket socket)
        {
            base.ReadResponse(socket);

            if (!Success)
                return;

            FileSize = Int32.Parse(ResponseLines[0].Trim());
        }

        #endregion

    }
}
