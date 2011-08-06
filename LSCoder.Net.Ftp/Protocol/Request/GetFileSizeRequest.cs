using System.Collections.Generic;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Extension;
using LSCoder.Net.Ftp.Helper;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp.Protocol.Request
{
    internal class GetFileSizeRequest : FtpRequest<GetFileSizeResponse>
    {
        #region Public Properties

        public GetFileSizeRequest(string fileName)
        {
            FileName = fileName;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Nome do arquivo a ser consultado o tamanho
        /// </summary>
        public string FileName { get; private set; }

        #endregion

        #region Public Methods

        public override GetFileSizeResponse Execute(ref Socket socket, IList<IFtpResponse> responseList)
        {
            var commandText = string.Format("SIZE {0}\n", FileName);

            TraceHelper.Write(commandText);

            socket.Send(commandText);
            return new GetFileSizeResponse(socket);
        }

        #endregion
    }
}
