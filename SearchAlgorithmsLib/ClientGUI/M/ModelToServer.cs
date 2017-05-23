using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace ClientGUI.M
{
    class ModelToServer
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
        private Model model; 

        public ModelToServer(int port, Model model)
        {
            this.model = model;
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

                    answer = reader.ReadLine();

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

                    //Console.WriteLine(answer);
                    this.model.getCommandFromServer(answer);
                }
                // Server closed the connection.
                catch
                {
                    this.connectionActive = false;
                    client.Close();
                }
            }
        }

        public void Connect(String command)
        {
            this.endPonit = new IPEndPoint(IPAddress.Parse("127.0.0.1"), this.port);
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

    }



}
