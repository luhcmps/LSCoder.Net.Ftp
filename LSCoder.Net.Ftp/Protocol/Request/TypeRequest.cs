using System.Collections.Generic;
using System.Net.Sockets;
using LSCoder.Net.Ftp.Extension;
using LSCoder.Net.Ftp.Helper;
using LSCoder.Net.Ftp.Protocol.Response;

namespace LSCoder.Net.Ftp.Protocol.Request
{
    internal class TypeRequest : FtpRequest<TypeResponse>
    {
        #region Public Properties

        public TypeRequest(TransferTypes transferType)
        {
            TransferType = transferType;
        }

        #endregion

        #region Public Properties

        public TransferTypes TransferType { get; private set; }

        #endregion

        #region Public Methods

        public override TypeResponse Execute(ref Socket socket, IList<IFtpResponse> responseList)
        {
            var commandText = string.Format("TYPE {0}\n", TransferType.ToString()[0].ToString().ToUpper());

            TraceHelper.Write(commandText);

            socket.Send(commandText);
            return new TypeResponse(socket);
        }

        #endregion
    }
}
