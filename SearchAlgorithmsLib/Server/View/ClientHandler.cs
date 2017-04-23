using Server.Controler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.View
{
    public class ClientHandler : IView
    {

        private IController controller;

        public ClientHandler(IController controller)
        {
            this.controller = controller;
        }


        public void HandleClient(TcpClient client)
        {
            new Task(() => 
            {
                //bool flag = true;
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                while (true)
                {

                        string commandLine = reader.ReadLine();
                        Console.WriteLine("Got command: {0}", commandLine);

                        string result = controller.ExecuteCommand(commandLine, client);
                        if (result.Equals("-1"))
                        {
                            client.Close();
                            break;
                        }
                        Console.WriteLine(result);
                        writer.Write("");
                        writer.Flush();
                        writer.Write(result);
                        writer.Flush();
                }

                
                
            }).Start();
        }


    }
}
