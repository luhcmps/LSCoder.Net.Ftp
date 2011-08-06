using System.Collections.Generic;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp.Protocol.Request
{
    internal interface IFtpRequest<out TResponse> where TResponse : FtpResponse
    {
        #region Methods

        TResponse Execute(ref Socket socket);

        TResponse Execute(ref Socket socket, IList<IFtpResponse> responseList);

        #endregion
    }
}
