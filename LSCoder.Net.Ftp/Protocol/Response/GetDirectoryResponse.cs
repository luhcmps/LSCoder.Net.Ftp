using System;
using System.Net.Sockets;

namespace LSCoder.Net.Ftp.Protocol.Response
{
    internal class GetDirectoryResponse : FtpResponse
    {

        #region Constructors

        public GetDirectoryResponse(Socket socket)
            : base(socket, new[] { 257 })
        {
        }

        #endregion

        #region Public Properties

        public string CurrentDirectory { get; private set; }

        #endregion

        #region Protected Methods

        protected override void ReadResponse(Socket socket)
        {
            base.ReadResponse(socket);

            // Ex.: "/folder" is current directory
            var responseText = ResponseLines[0];

            if (!Success)
            {
                CurrentDirectory = string.Empty;
                throw new ApplicationException("Não foi possível recuperar o diretório atual");
            }

            var currentDirectory = responseText;
            currentDirectory = currentDirectory.Substring(currentDirectory.IndexOf('"') + 1);
            currentDirectory = currentDirectory.Substring(0, currentDirectory.IndexOf('"'));

            CurrentDirectory = currentDirectory;
        }

        #endregion

    }
}
