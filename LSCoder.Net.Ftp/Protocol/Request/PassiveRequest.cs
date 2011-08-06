using System.Collections.Generic;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Extension;
using LSCoder.Net.Ftp.Helper;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp.Protocol.Request
{
    internal class PassiveRequest : FtpRequest<PassiveResponse>
    {
        #region Public Properties

        public PassiveRequest()
        {
        }

        #endregion

        #region Public Methods

        public override PassiveResponse Execute(ref Socket socket, IList<IFtpResponse> responseList)
        {
            var commandText = string.Format("PASV\n");

            TraceHelper.Write(commandText);

            socket.Send(commandText);
            return new PassiveResponse(socket);
        }

        #endregion
    }
}
