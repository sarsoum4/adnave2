using System;
using MazeLib;
using MazeGeneratorLib;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;

namespace ClientGUI.M
{
    class Model : IModel
    {


        private String userCommand;
        private String answer;
        private string commandType;

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



        public Model()
        {

            this.connectionActive = false;
            this.endPonit = null;
            this.client = null;
            this.stream = null;
            this.reader = null;
            this.writer = null;
            this.commandType = null;
        }


        public void getCommandFromServer(string command)
        {
           //this.currentCommand = command;
        }

        public String commandToSend()
        {
            return null;
        }

        ///get the maze representation, the
        public void parseMaze()
        {
            MazeGeneratorLib.IMazeGenerator generator = new DFSMazeGenerator();
            Maze maze = generator.Generate(5, 5);
            //this.json = maze.ToJSON();

            //use the FromJson method. then this.maze.row is the rows etc
            //this.maze = Maze.FromJSON(jsonFormatStr);
/**
            JObject ob = JObject.Parse(this.json);
            this.mazeRepresentation = ob.GetValue("Maze").ToString();
            //get the start row
            this.startRep = ob.SelectToken("Start.Row").ToString();
            this.startRow = Int32.Parse(this.startRep);
            //get the start col
            this.startRep = ob.SelectToken("Start.Col").ToString();
            this.startCol = Int32.Parse(this.startRep);
            //get the end row
            this.endRep = ob.GetValue("End.Row").ToString();
            this.endRow = Int32.Parse(this.endRep);
            //get the end col
            this.endRep = ob.GetValue("End.Row").ToString();
            this.endCol = Int32.Parse(this.endRep);
*/
        }

        public void connect(string ip, int port)
        {
            Console.WriteLine(ip);
            Console.WriteLine(port);
            this.endPonit = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6664);
            client = new TcpClient();
            client.Connect("127.0.0.1", 66664);
        }

        public void start()
        {
            Task send = new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        if (!connectionActive)
                        {
                            connectionActive = true;
                            client = new TcpClient();
                            client.Connect(endPonit);
                            stream = client.GetStream();
                            this.writer = new StreamWriter(stream);
                            this.reader = new StreamReader(stream);

                            // Run the receiving task.
                            Task recv = new Task(() =>
                            {
                                Recieve();

                            });
                            recv.Start();
                        }
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

        public void Recieve()
        {
            bool flag = true;
            while (flag)
            {
                try
                {
                    this.answer = reader.ReadLine();

                    if (answer == null)
                    {
                        flag = false;
                    }

                    if(this.commandType.Equals("generate"))
                    {
                        this.Json = answer;
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

                }
                // Server closed the connection.
                catch
                {
                    this.connectionActive = false;
                    client.Close();
                }
            }
        }


        //the command to send to server
        public void send(string s)
        {
            this.userCommand = s;
            
            writer.WriteLine(s);
            writer.Flush();
        }


        public void generateNewMaze(string name, int rows, int cols)
        {
            string s = "generate " + name + " " + rows.ToString() + " " + cols.ToString();
            this.userCommand = s;

            client = new TcpClient();
            client.Connect(endPonit);

            writer = new StreamWriter(s);

            writer.Write(s);
            writer.Flush();
            this.commandType = "generate";

            string answer = reader.ReadLine();
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

    }
}
