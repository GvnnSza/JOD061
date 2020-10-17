using System;
using System.Net;
using System.Net.Sockets;



namespace Server
{
    class Program
    {
        const int porta = 7000;

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any,porta);
            try{

            
            Console.WriteLine("Servidor ta Igual o Pai , online !");
            server.Start();
            }catch(Exception){
                Console.WriteLine("O Servidor ta igual o Pai Neymar, off");
            }
            while(true){
                TcpClient client = server.AcceptTcpClient();  
                Console.WriteLine("Conexao com sucesso!");


                client.Close();
                Console.WriteLine("Conexão interrompida!");
            }
        }
    }
}
