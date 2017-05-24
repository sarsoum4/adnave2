using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGUI.M
{
    interface IModel :  INotifyPropertyChanged
    {


        // maze fields
        string Json { set; get; }


        // connection to the server
        void connect(string ip, int port);
        void disconnect();
        void Recieve();
        void start();
        void send(string s);

        // activate actuators
        void generateNewMaze (string name, int rows, int cols);
        void getGamesList();
        void movePlayer(string move);
    }
}
