using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGUI.M
{
    interface IModel : INotifyPropertyChanged
    {
        // connection to the server
        void connect(string ip, int port);
        void disconnect();
        void start();

        // maze fields
        string mazeName { set; get; }
        int startRow { set; get; }
        int startCol { set; get; }
        int endRow { set; get; }
        int endCol { set; get; }
        int rows { set; get; }
        int cols { set; get; }

        // activate actuators
        void generateNewMazeMaze(string name, int rows, int cols);
        void getGamesList();
        void movePlayer();
    }
}