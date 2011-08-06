using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Protocol.Request;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp
{
    public class FtpClient
    {
        #region Fields

        private Socket _socket;

        #endregion

        #region Constructors

        public FtpClient(string remoteHost, int remotePort, string userName, string password)
        {
            RemoteHost = remoteHost;
            RemotePort = remotePort;
            UserName = userName;
            Password = password;

            _socket = null;
        }

        #endregion

        #region Private Properties

        private bool Connected
        {
            get
            {
                return (_socket != null) && (_socket.Connected);
            }
        }

        #endregion

        #region Public Properties

        protected string RemoteHost { get; private set; }

        protected int RemotePort { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        #endregion

        private IFtpResponse ExecuteRequests(IEnumerable<IFtpRequest<FtpResponse>> requests)
        {
            IFtpResponse lastResponse = null;
            var responses = new List<IFtpResponse>();
            foreach (var request in requests)
            {
                lastResponse = request.Execute(ref _socket, responses);

                if (!lastResponse.Success)
                    return lastResponse;

                responses.Add(lastResponse);
            }

            return lastResponse;
        }

        #region Public Methods

        public bool Connect()
        {
            if (Connected)
                return true;

            return ExecuteRequests(new IFtpRequest<FtpResponse>[]
                                       {
                                           new ConnectRequest(RemoteHost, RemotePort),
                                           new UserRequest(UserName),
                                           new PasswordRequest(Password)
                                       }).Success;
        }

        public void Close()
        {
            if (_socket == null)
                return;

            if(_socket.Connected)
                _socket.Disconnect(false);

            _socket.Dispose();
        }

        public string GetCurrentDirectory()
        {
            Connect();
            return (new GetDirectoryRequest()).Execute(ref _socket).CurrentDirectory;
        }

        public bool ChangeDirectory(string pathName)
        {
            Connect();
            return (new ChangeDirectoryRequest(pathName)).Execute(ref _socket).Success;
        }

        public bool ChangeToParentDirectory()
        {
            Connect();
            return (new ChangeToParentDirectoryRequest()).Execute(ref _socket).Success;
        }

        public bool CreateDirectory(string directoryName)
        {
            Connect();
            return (new CreateDirectoryRequest(directoryName)).Execute(ref _socket).Success;
        }

        public bool RemoveDirectory(string directoryName)
        {
            Connect();
            return (new RemoveDirectoryRequest(directoryName)).Execute(ref _socket).Success;
        }

        public int GetFileSize(string fileName)
        {
            Connect();
            return (new GetFileSizeRequest(fileName)).Execute(ref _socket).FileSize;
        }

        public bool SetType(TransferTypes type)
        {
            Connect();
            return (new TypeRequest(type)).Execute(ref _socket).Success;
        }

        public bool List()
        {
            Connect();
            return ExecuteRequests(new IFtpRequest<FtpResponse>[]
                                       {
                                           new TypeRequest(TransferTypes.Ascii),
                                           new PassiveRequest(),
                                           new ListRequest()
                                       }).Success;
        }

        #endregion
    }
}
