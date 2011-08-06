using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LSCoder.Net.Ftp.Extension
{
    public static class SocketExtension
    {
        public static int Send(this Socket socket, string text)
        {
            var buffer = Encoding.UTF8.GetBytes(text);
            return socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        public static bool WaitForData(this Socket socket, int timeout)
        {
            var timeoutDate = DateTime.Now.AddMilliseconds(timeout);

            while (socket.Available == 0)
            {
                if (DateTime.Now.CompareTo(timeoutDate) > 0)
                    return false;

                Thread.Sleep(100);
            }

            return true;
        }

        public static int Receive(this Socket socket, byte[] buffer, int offset, int size, int timeout, SocketFlags socketFlags)
        {
            if (!WaitForData(socket, timeout))
                return 0;

            return socket.Receive(buffer, offset, size, socketFlags);
        }

        public static byte ReceiveByte(this Socket socket)
        {
            return socket.ReceiveBytes(1)[0];
        }

        public static byte[] ReceiveBytes(this Socket socket, int size)
        {
            var buffer = new byte[size];
            socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);

            return buffer;
        }

        public static string ReceiveLine(this Socket socket)
        {
            var memoryStream = new MemoryStream();
            do
            {
                var socketByte = socket.ReceiveByte();
                if (socketByte == 13)
                {
                    socketByte = socket.ReceiveByte();

                    if (socketByte == 10)
                        break;

                    memoryStream.Write(new byte[] { 13, socketByte }, 0, 2);
                }
                else
                {
                    memoryStream.WriteByte(socketByte);
                }

            } while (true);

            var buffer = new byte[memoryStream.Length];
            memoryStream.Seek(0, SeekOrigin.Begin);
            memoryStream.Read(buffer, 0, buffer.Length);

            return Encoding.UTF8.GetString(buffer);
        }
    }
}
