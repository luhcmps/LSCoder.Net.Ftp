using System.Collections.Generic;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Extension;
using LSCoder.Net.Ftp.Helper;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp.Protocol.Request
{
    internal class RemoveDirectoryRequest : FtpRequest<RemoveDirectoryResponse>
    {
        #region Constructor

        public RemoveDirectoryRequest(string directoryName)
        {
            DirectoryName = directoryName;
        }

        #endregion

        #region Public Properties

        public string DirectoryName { get; private set; }

        #endregion

        #region Public Methods

        public override RemoveDirectoryResponse Execute(ref Socket socket, IList<IFtpResponse> responseList)
        {
            var commandText = string.Format("RMD {0}\n", DirectoryName);

            TraceHelper.Write(commandText);

            socket.Send(commandText);
            return new RemoveDirectoryResponse(socket);
        }

        #endregion
    }
}
