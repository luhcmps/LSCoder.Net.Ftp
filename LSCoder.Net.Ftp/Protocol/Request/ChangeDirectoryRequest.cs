using System.Collections.Generic;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Extension;
using LSCoder.Net.Ftp.Helper;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp.Protocol.Request
{
    internal class ChangeDirectoryRequest : FtpRequest<ChangeDirectoryResponse>
    {
        #region Constructor

        public ChangeDirectoryRequest(string pathName)
        {
            PathName = pathName;
        }

        #endregion

        #region Public Properties

        public string PathName { get; private set; }

        #endregion

        #region Public Methods

        public override ChangeDirectoryResponse Execute(ref Socket socket, IList<IFtpResponse> responseList)
        {
            var commandText = string.Format("CWD {0}\n", PathName);

            TraceHelper.Write(commandText);

            socket.Send(commandText);
            return new ChangeDirectoryResponse(socket);
        }

        #endregion
    }
}
