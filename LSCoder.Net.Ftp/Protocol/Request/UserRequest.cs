using System.Collections.Generic;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Extension;
using LSCoder.Net.Ftp.Helper;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp.Protocol.Request
{
    internal class UserRequest : FtpRequest<UserResponse>
    {
        #region Public Properties

        public UserRequest(string userName)
        {
            UserName = userName;
        }

        #endregion

        #region Public Properties

        public string UserName { get; private set; }

        #endregion

        #region Public Methods

        public override UserResponse Execute(ref Socket socket, IList<IFtpResponse> responseList)
        {
            var commandText = string.Format("USER {0}\n", UserName);

            TraceHelper.Write(commandText);

            socket.Send(commandText);
            return new UserResponse(socket);
        }

        #endregion
    }
}
