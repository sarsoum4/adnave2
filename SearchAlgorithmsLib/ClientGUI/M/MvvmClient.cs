using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientGUI.M
{
    class MvvmClient : IMvvmClient
    {
        private int port;
        private bool connectionActive = false;
        private IPEndPoint endPonit = null;
        private TcpClient client = null;
        private NetworkStream stream = null;
        private StreamReader reader = null;
        private StreamWriter writer = null;
        private String userCommand;
        private String answer;

        public MvvmClient()
        {
            this.connectionActive = false;
            this.endPonit = null;
            this.client = null;
            this.stream = null;
            this.reader = null;
            this.writer = null;
        }


        public void connect(string command, string ip, int port)
        {
            this.endPonit = new IPEndPoint(IPAddress.Parse(ip), this.port);
            //this.endPonit = new IPEndPoint(IPAddress.Parse("127.0.0.1"), this.port);

            Task send = new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        userCommand = command;

                        if (!connectionActive)
                        {
                            connectionActive = true;
                            client = new TcpClient();
                            client.Connect(endPonit);

                            // Run the receiving task.
                            Task recv = new Task(() =>
                            {
                                Recieve();

                            });
                            recv.Start();
                        }
                        //TODO: check what will be the message to return?
                        model.commandToSend();
                        //writer.WriteLine(userCommand);
                        //writer.Flush();
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

        public void disconnect()
        {
            throw new NotImplementedException();
        }

        public string read()
        {
            throw new NotImplementedException();
        }

        public void write(string command)
        {
            throw new NotImplementedException();
        }

        public void connect(string ip, int port)
        {
            throw new NotImplementedException();
        }
    }
}