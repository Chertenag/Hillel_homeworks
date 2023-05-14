using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Hillel_hw_27_server
{
    public delegate void PacketRespondSolver(string message, int sourceId);

    internal class Program
    {
        static void Main(string[] args)
        {
            TCPChatServer chatServer = new();
            chatServer.StartServer(16777);
            Console.ReadLine();
        }
    }


    public class TCPChatServer
    {
        private List<TCPChatServerClient> clients = new();
        private TcpListener tcpListener;

        public void StartServer(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Loopback, port);
            this.tcpListener.Start();
            this.tcpListener.BeginAcceptTcpClient(AcceptTCPClientCallback, null);
            Console.WriteLine("Server started.");
        }

        private void AcceptTCPClientCallback(IAsyncResult asyncResult)
        {
            TCPChatServerClient client = new(this.tcpListener.EndAcceptTcpClient(asyncResult), BroadcastingMessage);
            this.clients.Add(client);

            string newUserMessage = $"New user ID:{client.Id} connected.";
            Console.WriteLine(DateTime.Now.ToString() + ": " + newUserMessage);
            BroadcastingMessage("SERVER : " + newUserMessage, client.Id);

            this.tcpListener.BeginAcceptTcpClient(AcceptTCPClientCallback, null);
        }

        private void BroadcastingMessage(string message, int sourceId)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);

            this.clients.AsParallel()
                .Where(c => c.Id != sourceId)
                .ForAll(x =>
            {
                if (x.Client.Connected)
                {
                    x.Stream.Write(buffer, 0, buffer.Length);
                }
                else
                {
                    x.Close();
                    this.clients.Remove(x);
                }
            });
        }
    }

    public class TCPChatServerClient
    {
        public TcpClient Client;
        public NetworkStream Stream;
        public int Id;
        private byte[] buffer = new byte[1024];
        private PacketRespondSolver respondSolver;
        protected static int nextID;

        public TCPChatServerClient(TcpClient client, PacketRespondSolver packetRespondSolver)
        {
            Id = Interlocked.Increment(ref nextID);
            respondSolver = packetRespondSolver;
            Client = client;
            Stream = client.GetStream();
            Stream.BeginRead(this.buffer, 0, this.buffer.Length, ClientRecieveCallback, null);
        }

        private void ClientRecieveCallback(IAsyncResult asyncResult)
        {
            try
            {
                var bytesReaded = Stream.EndRead(asyncResult);
                if (bytesReaded > 0)
                {
                    byte[] message = new byte[bytesReaded];
                    Array.Copy(this.buffer, message, bytesReaded);
                    var str = "ID (" + this.Id.ToString("00") + "): " + Encoding.UTF8.GetString(message);

                    respondSolver(str, this.Id);
                }
                Stream.BeginRead(this.buffer, 0, this.buffer.Length, ClientRecieveCallback, null);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Close()
        {
            if (Stream != null)
            {
                Stream.Close();
                Stream.Dispose();
            }
            if (Client != null)
            {
                Client.Close();
                Client.Dispose();
            }
        }
    }
}