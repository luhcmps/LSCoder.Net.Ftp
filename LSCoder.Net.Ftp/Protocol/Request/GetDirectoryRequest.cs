using System;
using System.Collections.Generic;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Extension;
using LSCoder.Net.Ftp.Helper;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp.Protocol.Request
{
    internal class GetDirectoryRequest : FtpRequest<GetDirectoryResponse>
    {
        #region Public Properties

        public GetDirectoryRequest()
        {
        }

        #endregion

        #region Public Methods

        public override GetDirectoryResponse Execute(ref Socket socket, IList<IFtpResponse> responseList)
        {
            var commandText = string.Format("PWD\n");

            TraceHelper.Write(commandText);

            socket.Send(commandText);
            return new GetDirectoryResponse(socket);
        }

        #endregion
    }
}
