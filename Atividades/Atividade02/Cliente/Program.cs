using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Clientela
{
    class Program
    {
        const int porta = 7000;
        const string ip = "192.168.0.28";

        static void Main(string[] args)
        {
            TcpClient clientela = new TcpClient();
            Console.Write("Tentando Conectar ao servidor... ");
            try
            {
                clientela.Connect(ip, porta);
                Console.WriteLine("Okay!");
            }
            catch (Exception)
            {
                Console.WriteLine("Nao Deu Certo");
                return;
            }

            byte[] bytes = new byte[1024];
            NetworkStream stream = clientela.GetStream();

            Console.WriteLine("Insira uma Mensagem. Para sair, pressione ENTER.");
            Console.Write("--> ");
            string mssg = Console.ReadLine();

            while (mssg.Length > 0)
            {
                bytes = Encoding.ASCII.GetBytes(mssg);
                stream.Write(bytes, 0, bytes.Length);

                Console.Write("> ");
                mssg = Console.ReadLine();
            }

            stream.Close();
            Console.WriteLine("Desconectado!");
            clientela.Close();
        }
    }
}
