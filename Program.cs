using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace udp_logger
{
    class Program
    {
        static int port = 8889;

        static void Main(string[] args) {
            Console.WriteLine("Listening on Port: {0}", port);

            //Creates a UdpClient for reading incoming data.
            UdpClient receivingUdpClient = new UdpClient(port); 
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            try {

                while (true) {
                    Byte[] receiveBytes = receivingUdpClient.Receive(ref RemoteIpEndPoint);
                    string returnData = Encoding.UTF8.GetString(receiveBytes);
                    Console.WriteLine(returnData.ToString());
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
