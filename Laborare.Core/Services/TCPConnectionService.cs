namespace Laborare.Core.Services
{
    using Laborare.Core.Models;

    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;

    class TCPConnectionService : IConnectionService
    {
        private string _IpAddress;
        private int _Port;
        private TcpClient client;

        public TCPConnectionService(string ip_address, int port)
        {
            client = new TcpClient();
            _IpAddress = ip_address;
            _Port = port;
            Connect();
        }

        public async void Connect()
        {
            try
            {
                await client.ConnectAsync(_IpAddress, _Port);
            }
            catch (Exception er)
            {
                //MessageBox.Show(er.ToString());
            }
        }

        public string ReceiveMessage()
        {
            var buf = new byte[4096]; // do we want to lower the amount of bytes to lower network latency?
            var stream = client.GetStream();
            stream.Read(buf, 0, buf.Length);
            return System.Text.Encoding.ASCII.GetString(buf); 
        }

        public void Send(string msg)
        {
            var stream = client.GetStream();
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            writer.WriteLine(msg + "\r");
            Thread.Sleep(50);
        }
        
        public void Disconnect()
        {
            client.Close();
        }
    }
}
