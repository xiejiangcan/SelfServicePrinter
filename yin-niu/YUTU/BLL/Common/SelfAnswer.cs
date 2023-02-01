using System;
using System.Net;
using System.Net.Sockets;

namespace YUTU.BLL.Common
{
    public class SelfAnswer
    {
        public bool IsSkip = false;
        public void SetTimeOut(double interval, Action action)
        {
            System.Timers.Timer timer = new System.Timers.Timer(interval);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(delegate (object sender, System.Timers.ElapsedEventArgs e)
            {
                timer.Enabled = false;
                if (!IsSkip)
                {
                    action();
                }
            });
            timer.AutoReset = false;
            timer.Enabled = true;
        }

        public void SetTimeOut(double interval, int port)
        {
            System.Timers.Timer timer = new System.Timers.Timer(interval);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(delegate (object sender, System.Timers.ElapsedEventArgs e)
            {
                timer.Enabled = false;
                if (!IsSkip)
                {
                    SendData(port);
                }
            });
            timer.AutoReset = false;
            timer.Enabled = true;
        }

        public void SendData(int port)
        {
            SendData("127.0.0.1", port);
        }
        public void SendData(string ip, int port)
        {
            byte[] buffer = new byte[] { 0xFF, 0xFF, 0xFF };
            IPAddress remoteIp = IPAddress.Parse(ip);
            IPEndPoint remotePoint = new IPEndPoint(remoteIp, port);

            UdpClient udpClient = new UdpClient();
            udpClient.Send(buffer, buffer.Length, remotePoint);
        }
    }
}