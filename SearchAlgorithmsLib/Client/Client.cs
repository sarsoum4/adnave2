using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {

        private int port;
        private bool connectionActive = false;
        private IPEndPoint endPonit = null;
        private TcpClient client = null;
        private NetworkStream stream = null;
        private StreamReader reader = null;
        private StreamWriter writer = null;


        public Client(int port)
        {
            this.port = port;
            this.connectionActive = false;
            this.endPonit = null;
            this.client = null;
            this.stream = null;
            this.reader = null;
            this.writer = null;
         }


        private void Recieve()
        {
            bool flag = true;
            while (flag)
            {
                try
                {
                    
                    string answer = reader.ReadLine();

                    if (answer == null)
                    {
                        flag = false;
                    }

                    else if (answer.Equals("close"))
                    {
                        // Close the connection.
                        writer.WriteLine("close");
                        writer.Flush();
                        this.connectionActive = false;
                        client.Close();
                        break;
                    }
                   
                    else if (answer.Equals("-1"))
                    {
                        this.connectionActive = false;
                        client.Close();
                        break;
                    }


                    else
                    {
                        Console.WriteLine(answer);
                    }
                }
                // Server closed the connection.
                catch
                {
                    this.connectionActive = false;
                    client.Close();
                }
            }
        }


        public void Connect()
        {
            this.endPonit = new IPEndPoint(IPAddress.Parse("127.0.0.1"), this.port);
            Task send = new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Welcome Player !");
                        String userCommand = Console.ReadLine();

                        if (!connectionActive)
                        {
                            connectionActive = true;
                            client = new TcpClient();
                            client.Connect(endPonit);
                            stream = client.GetStream();
                            writer = new StreamWriter(stream);
                            reader = new StreamReader(stream);

                            // Run the receiving task.
                            Task recv = new Task(() =>
                            {
                                Recieve();

                            });
                            recv.Start();

                        }
                        writer.WriteLine(userCommand);
                        writer.Flush();

                    }

                    catch
                    {
                        connectionActive = false;
                        client.Close();
                    }
                }
            }); send.Start();
            send.Wait();
        }






    }
}