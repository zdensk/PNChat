using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PNChat
{
    public class ChatServer
    {
        private TcpListener listener;
        private bool running;

        public event Action<string>? MessageReceived = delegate { };

        public ChatServer(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
            Start();
        }

        public void Start()
        {
            running = true;
            listener.Start();
            Task.Run(async () =>
            {
                while (running)
                {
                    try
                    {
                        var tcpClient = await listener.AcceptTcpClientAsync();
                        _ = HandleClientAsync(tcpClient);
                    }
                    catch
                    {
                        // Hibakezelés, pl. log
                    }
                }
            });
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            try
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    MessageReceived?.Invoke(message);
                }
            }
            catch
            {
                // Hibakezelés
            }
            finally
            {
                client.Close();
            }
        }

        public void Stop()
        {
            running = false;
            listener.Stop();
        }
    }
}
