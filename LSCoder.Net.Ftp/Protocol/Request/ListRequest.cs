using System.Collections.Generic;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Extension;
using LSCoder.Net.Ftp.Helper;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp.Protocol.Request
{
    internal class ListRequest : FtpRequest<ListResponse>
    {
        #region Public Properties

        public ListRequest()
        {
        }

        #endregion

        #region Public Methods

        public override ListResponse Execute(ref Socket socket, IList<IFtpResponse> responseList)
        {
            var dataSocket = CreateDataSocket(responseList);
            var commandText = string.Format("NLST -a\n");

            TraceHelper.Write(commandText);
            socket.Send(commandText);

            var directoryEntries = FtpHelper.GetDirecoryEntries(dataSocket);

            return new ListResponse(socket, directoryEntries);
        }

        #endregion
    }
}
