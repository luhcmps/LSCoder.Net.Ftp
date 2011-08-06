using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp.Protocol.Request
{
    internal abstract class FtpRequest<TResponse> : IFtpRequest<TResponse> where TResponse : FtpResponse
    {
        #region Protected Methods

        protected Socket CreateSocket(string remoteHost, int remotePort)
        {
            var remoteEndPoint = new IPEndPoint(Dns.GetHostEntry(remoteHost).AddressList[0], remotePort);
            return CreateSocket(remoteEndPoint);
        }

        protected Socket CreateSocket(IPEndPoint remoteEndPoint)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(remoteEndPoint);

            return socket;
        }

        protected Socket CreateDataSocket(IList<IFtpResponse> responseList)
        {
            var pasvResponse = (PassiveResponse) GetLastResponseByType(responseList, typeof (PassiveResponse));

            if(pasvResponse == null)
            {
                throw new ApplicationException("Execute o comando PASV antes de entrar no modo de transferência de dados");
            }

            return CreateSocket(pasvResponse.RemoteEndPoint);
        }

        protected IFtpResponse GetLastResponseByType(IList<IFtpResponse> responseList, Type type)
        {
            for(var i = responseList.Count - 1; i >= 0; i--)
            {
                if (responseList[i].GetType().Equals(type))
                    return responseList[i];
            }

            return null;
        }

        #endregion

        #region Public Methods

        public TResponse Execute(ref Socket socket)
        {
            return Execute(ref socket, null);
        }

        public abstract TResponse Execute(ref Socket socket, IList<IFtpResponse> responseList);

        #endregion
    }
}
