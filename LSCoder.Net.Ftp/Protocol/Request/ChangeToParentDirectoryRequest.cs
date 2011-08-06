using System.Collections.Generic;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Extension;
using LSCoder.Net.Ftp.Helper;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp.Protocol.Request
{
    internal class ChangeToParentDirectoryRequest : FtpRequest<ChangeToParentDirectoryResponse>
    {
        #region Public Properties

        public ChangeToParentDirectoryRequest()
        {
        }

        #endregion

        #region Public Methods

        public override ChangeToParentDirectoryResponse Execute(ref Socket socket, IList<IFtpResponse> responseList)
        {
            var commandText = string.Format("CDUP\n");

            TraceHelper.Write(commandText);

            socket.Send(commandText);
            return new ChangeToParentDirectoryResponse(socket);
        }

        #endregion
    }
}
