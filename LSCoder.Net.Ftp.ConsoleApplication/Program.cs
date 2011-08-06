using System;
using LSCoder.Net.Ftp.ConsoleApplication.Helper;
using LSCoder.Net.Ftp.Helper;

namespace LSCoder.Net.Ftp.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Código para testar as funcionalidades do FTP
            Console.WriteLine("Informe os dados da conexão\n");

            Console.Write("Servidor ............: ");
            var remoteHost = Console.ReadLine();
            
            Console.Write("Porta (default 21) ..: ");
            var remotePort = Int32.Parse(Console.ReadLine());
            
            Console.Write("Usuário .............: ");
            var userName = Console.ReadLine();

            Console.Write("Senha ...............: ");
            var password = ConsoleHelper.ReadLine(true);

            Console.WriteLine();

            try
            {
                bool success;
                var ftpClient = new FtpClient(remoteHost, remotePort, userName, password);

                if ((success = ftpClient.Connect()) == true)
                {
                    TraceHelper.WriteLine("*** Conectado!");
                    TraceHelper.WriteLine(string.Format("*** Diretório atual: {0}", ftpClient.GetCurrentDirectory()));
                }

                if (success && ((success = ftpClient.ChangeDirectory("web")) == true))
                {
                    TraceHelper.WriteLine("*** Diretório alterado com sucesso!");
                    TraceHelper.WriteLine(string.Format("*** Diretório atual: {0}", ftpClient.GetCurrentDirectory()));
                }

                if (success)
                {
                    var fileSize = ftpClient.GetFileSize("Sun.zip");

                    TraceHelper.WriteLine(string.Format("*** O arquivo Sun.zip tem {0} bytes", fileSize));
                }

                if (success && ((success = ftpClient.CreateDirectory("FtpClientTest")) == true))
                {
                    TraceHelper.WriteLine("*** Diretório [FtpClientTest] criado com sucesso!");
                }

                if (success && ((success = ftpClient.RemoveDirectory("FtpClientTest")) == true))
                {
                    TraceHelper.WriteLine("*** Diretório [FtpClientTest] removido com sucesso!");
                }

                if (success && ((success = ftpClient.ChangeToParentDirectory()) == true))
                {
                    TraceHelper.WriteLine("*** Voltou para o diretório raiz");
                    TraceHelper.WriteLine(string.Format("*** Diretório atual: {0}", ftpClient.GetCurrentDirectory()));
                }

                if (success && ((success = ftpClient.List()) == true))
                {
                    TraceHelper.WriteLine("*** Listagem efetuada com sucesso");
                }
            }
            catch (Exception exception)
            {
                TraceHelper.WriteLine(string.Format("*** Ocorreu o seguinte erro durante a comunicação com o servidor FTP: {0}", exception.Message));
            }

            Console.ReadKey(true);
        }
    }
}
