using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PNChat
{
    public class ChatClient
    {
        private int port;

        public ChatClient(int port)
        {
            this.port = port;
        }

        public async Task SendMessage(string ip, string msg)
        {
            using (var client = new TcpClient())
            {
                await client.ConnectAsync(ip, port);
                var stream = client.GetStream();
                byte[] data = Encoding.UTF8.GetBytes(msg);
                await stream.WriteAsync(data, 0, data.Length);
            }
        }

        public async Task SendFile(string ip, string path)
        {
            using (var client = new TcpClient())
            {
                await client.ConnectAsync(ip, port);
                var stream = client.GetStream();
                byte[] fileData = File.ReadAllBytes(path);
                await stream.WriteAsync(fileData, 0, fileData.Length);
            }
        }
    }
}
