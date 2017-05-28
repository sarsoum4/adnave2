using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientGUI.M
{
    class MultiplayerModel : IModel
    {


        private String userCommand;
        private String answer;

        private int port;
        private bool connectionActive = false;
        private IPEndPoint endPonit = null;
        private TcpClient client = null;
        private NetworkStream stream = null;
        private StreamReader reader = null;
        private StreamWriter writer = null;



        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }





        public MultiplayerModel()
        {

            this.connectionActive = false;
            this.endPonit = null;
            this.client = null;
            this.stream = null;
            this.reader = null;
            this.writer = null;
        }





        public void getCommandFromServer(string command)
        {
            //this.currentCommand = command;
        }

        public String commandToSend()
        {
            return null;
        }






        public void connect(string ip, int port)
        {
            Console.WriteLine(ip);
            Console.WriteLine(port);
            this.endPonit = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6675);

            if (!connectionActive)
            {
                connectionActive = true;
                client = new TcpClient();
                client.Connect(endPonit);
                stream = client.GetStream();
                this.writer = new StreamWriter(stream);
                this.reader = new StreamReader(stream);
            }
        }


        //string
        public string Recieve()
        {

            bool flag = true;
            string current = "";

            while (flag)
            {
                try
                {

                    this.answer = reader.ReadLine();
                    if (answer == "  }")
                    {
                        current += "  }";
                        current += "}";
                        break;
                    }

                    else if (answer.Equals("close"))
                    {
                        // Close the connection.
                        writer.WriteLine("close");
                        writer.Flush();
                        this.connectionActive = false;
                        client.Close();
                        return "Close";
                    }

                    else if (answer.Equals("-1"))
                    {
                        this.connectionActive = false;
                        client.Close();
                        return "-1";
                    }

                }
                // Server closed the connection.
                catch
                {
                    this.connectionActive = false;
                    client.Close();
                }
                current += answer;
            }
            return current;

        }



        //send to server
        public void send(string s)
        {
            this.userCommand = s;
            writer.WriteLine(s);
            writer.Flush();
        }



        public void generateNewMaze(string name, int rows, int cols)
        {
            throw new NotImplementedException();
        }

        public void movePlayer(string move)
        {
            throw new NotImplementedException();
        }

        public void getGamesList()
        {
            //this.currentCommand = "list";
        }

        public void movePlayer()
        {
            throw new NotImplementedException();
        }

        public void disconnect()
        {
            throw new NotImplementedException();
        }

        public void start()
        {
            throw new NotImplementedException();
        }

        public void generateNewMazeMaze(string name, int rows, int cols)
        {
            //this.currentCommand = "generate " + name + row.ToString() + " " + col.ToString();
            //Server.Controler.Controller 
        }



        public string Json
        {
            get
            {
                return answer;
            }

            set
            {
                this.answer = value;
                NotifyPropertyChanged("Json");
            }
        }




    }
}
