using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JOD061
{
    class Program
    {
        const int porta_ = 7000;
        const string ip = "192.168.0.28";
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
                UdpClient porta = new UdpClient(porta_);

                Console.WriteLine("Para voltar - CTRL + C");
                while (true)
                {
                    byte[] bytesRecebidos = porta.Receive(ref endPoint);
                    Console.WriteLine("Mensagem Enviada com Sucesso: {0}", Encoding.ASCII.GetString(bytesRecebidos));
                    Console.WriteLine("Mensagem enviada com sucesso por {0}:{1}",endPoint.Address.ToString(), endPoint.Port.ToString());
                    
                }
            }
            catch (Exception)
            {
                UdpClient pares = new UdpClient();
                pares.EnableBroadcast = true;

                Console.WriteLine("Envie sua mensagem. Para voltar, Pressione ENTER");
                Console.WriteLine("--> ");
                string mssg = Console.ReadLine();

                while (mssg.Length > 0)
                {
                    byte[] bytesEnviados = Encoding.ASCII.GetBytes(mssg);
                    pares.Send(bytesEnviados, bytesEnviados.Length, ip, porta_);

                    Console.Write("> ");
                    mssg = Console.ReadLine();

                }
                pares.Close();

            }
        }
    }
}