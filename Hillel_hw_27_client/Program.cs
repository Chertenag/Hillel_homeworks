using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace Hillel_hw_27_client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TCPChatClient chatClient = new(16777);

            while (true)
            {
                string message = Console.ReadLine();
                if (String.IsNullOrEmpty(message))
                {
                    continue;
                }
                chatClient.SendMessage(message);
            }
            Console.ReadLine();
        }
    }

    public class TCPChatClient
    {
        private TcpClient client;
        private NetworkStream stream;
        private byte[] buffer = new byte[1024];

        public TCPChatClient(int port)
        {
            this.client = new TcpClient();
            this.client.Connect(IPAddress.Loopback, port);
            this.stream = this.client.GetStream();
            this.stream.BeginRead(this.buffer, 0, this.buffer.Length, ClientRecieveCallback, null);
        }

        private void ClientRecieveCallback(IAsyncResult asyncResult)
        {
            try
            {
                var bytesReaded = stream.EndRead(asyncResult);
                if (bytesReaded > 0)
                {
                    String str = DateTime.Now + ". " + Encoding.UTF8.GetString(this.buffer, 0, bytesReaded);
                    Console.WriteLine(str);
                }
                buffer = new byte[1024];
                this.stream.BeginRead(this.buffer, 0, this.buffer.Length, ClientRecieveCallback, null);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void SendMessage(string message)
        {
            this.stream.Write(Encoding.UTF8.GetBytes(message));
        }

        public void Close()
        {
            if (this.stream != null)
            {
                this.stream.Close();
                this.stream.Dispose();
            }
            if (this.client != null)
            {
                this.client.Close();
                this.client.Dispose();
            }
        }

    }

}