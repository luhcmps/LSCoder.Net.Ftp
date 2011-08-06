using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using LSCoder.Net.Ftp.Extension;
using LSCoder.Net.Ftp.Helper;

namespace LSCoder.Net.Ftp.Protocol.Response
{
    internal abstract class FtpResponse : IFtpResponse
    {

        #region Constructors

        protected FtpResponse(Socket socket, int[] successCodes, bool readResponse = true)
        {
            ResponseCode = -1;
            SuccessCodes = successCodes;
            ResponseLines = new List<string>();

            if (readResponse)
            {
                ReadResponseCode(socket);
                ReadResponse(socket);
            }
        }

        #endregion

        #region Protected Properties

        protected int[] SuccessCodes { get; private set; }

        protected int ResponseCode { get; private set; }

        protected List<string> ResponseLines { get; private set; }

        protected bool MultiLineResponse { get; private set; }

        #endregion

        #region Public Properties

        public bool Success
        {
            get
            {
                return SuccessCodes.Where(code => code.Equals(ResponseCode)).Count() > 0;
            }
        }

        #endregion

        #region Protected Methods

        protected void ReadResponseCode(Socket socket)
        {
            ResponseCode = Int32.Parse(Encoding.UTF8.GetString(socket.ReceiveBytes(3)));

            // A resposta do servidor pode ser uma ou várias linhas de texto, sendo 
            // que o que diferencia uma tipo de resposta da outra é a presença do 
            // sinal '-' logo após o código de retorno (RFC 959).
            //
            // Single Line Response:
            //     331 Password Required
            //
            // Multi Line Response
            //     230-Prezado cliente, seja bem-vindo a Locaweb.
            //         Os logs de FTP/HTTP do seu dominio estao disponiveis em:
            //         http://dominio/logs (utilize seu usuario e senha de FTP)
            //     230 User lscoder logged in.
            MultiLineResponse = (socket.ReceiveByte() == '-');
        }

        //protected abstract void ReadResponse(Socket socket);
        protected virtual void ReadResponse(Socket socket)
        {
            bool hasMoreLines;
            do
            {
                var line = socket.ReceiveLine();

                hasMoreLines = false;
                if(MultiLineResponse)
                {
                    if(line.StartsWith(string.Format("{0} ", ResponseCode.ToString().PadLeft(3, '0'))))
                    {
                        line = "   " + line.Substring(3);
                    }
                    else
                    {
                        hasMoreLines = true;
                    }
                }

                ResponseLines.Add(line);
            } while (hasMoreLines);

            TraceHelper.WriteLine(string.Join("\n", ResponseLines));
        }

        //protected void ClearSocket(Socket socket, int timeout = 5000)
        //{
        //    var buffer = new byte[socket.ReceiveBufferSize];

        //    int receivedLength;
        //    while ((receivedLength = socket.Receive(buffer, 0, buffer.Length, timeout, SocketFlags.None)) > 0)
        //    {
        //        Trace.Write(Encoding.UTF8.GetString(buffer, 0, receivedLength));
        //    }
        //}

        #endregion
    }
}
