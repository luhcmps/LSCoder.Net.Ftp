using System.Collections.Generic;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Entities;
using LSCoder.Net.Ftp.Exceptions;

namespace LSCoder.Net.Ftp.Protocol.Response
{
    internal class ListResponse : FtpResponse
    {

        #region Constructors

        public ListResponse(Socket socket, IList<DirectoryEntry> directoryEntries)
            : base(socket, new[] { 0 })
        {
            DirectoryEntries = directoryEntries;
        }

        #endregion

        #region Public Properties

        public IList<DirectoryEntry> DirectoryEntries { get; private set; }

        #endregion

        #region Protected Methods

        protected override void ReadResponse(Socket socket)
        {
            base.ReadResponse(socket);

            // Ex.: Entering Passive Mode (255,255,255,255,100,101).
            //var responseText = ResponseLines[0];

            if (!Success)
            {
                throw new FtpException("Não foi possível efetuar a listagem dos arquivos");
            }

            //var pasvData = responseText.Substring(responseText.IndexOf('(') + 1);
            //pasvData = pasvData.Substring(0, pasvData.IndexOf(')'));

            //var pasvDataParts = pasvData.Split(',');

            //RemoteEndPoint = new IPEndPoint(
            //    new IPAddress(
            //        new[]
            //            {
            //                Convert.ToByte(pasvDataParts[0]),
            //                Convert.ToByte(pasvDataParts[1]),
            //                Convert.ToByte(pasvDataParts[2]),
            //                Convert.ToByte(pasvDataParts[3])
            //            }),
            //    (Int32.Parse(pasvDataParts[4])*256) + Int32.Parse(pasvDataParts[5]));
        }

        #endregion
    }
}
