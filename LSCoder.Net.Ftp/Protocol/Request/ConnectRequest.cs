using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Helper;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp.Protocol.Request
{
    internal class ConnectRequest : FtpRequest<ConnectResponse>
    {
        #region Constructors

        public ConnectRequest(string remoteHost, int remotePort)
        {
            RemoteHost = remoteHost;
            RemotePort = remotePort;
        }

        #endregion

        #region Public Properties

        public string RemoteHost { get; private set; }

        public int RemotePort { get; private set; }

        #endregion

        public override ConnectResponse Execute(ref Socket socket, IList<IFtpResponse> responseList)
        {
            TraceHelper.WriteLine(string.Format("Conectando no servidor {0}:{1}", RemoteHost, RemotePort));

            if (socket != null)
            {
                socket.Dispose();
            }

            socket = CreateSocket(RemoteHost, RemotePort);

            return new ConnectResponse(socket);
        }
    }
}
