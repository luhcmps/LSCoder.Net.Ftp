using System.Collections.Generic;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Extension;
using LSCoder.Net.Ftp.Helper;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp.Protocol.Request
{
    internal class PasswordRequest : FtpRequest<PasswordResponse>
    {
        #region Public Properties

        public PasswordRequest(string password)
        {
            Password = password;
        }

        #endregion

        #region Public Properties

        public string Password { get; private set; }

        #endregion

        #region Public Methods

        public override PasswordResponse Execute(ref Socket socket, IList<IFtpResponse> responseList)
        {
            TraceHelper.Write(string.Format("PASS *****\n"));

            socket.Send(string.Format("PASS {0}\n", Password));
            return new PasswordResponse(socket);
        }

        #endregion
    }
}
