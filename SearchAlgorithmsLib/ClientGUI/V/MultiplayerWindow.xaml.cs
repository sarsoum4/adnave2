using ClientGUI.VM;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientGUI.V
{
    /// <summary>
    /// Interaction logic for MultiplayerWindow.xaml
    /// </summary>
    public partial class MultiplayerWindow : Window
    {



        private MultiplayerVM vm;
        private string name;
        private int row;
        private int col;
        private Position myPosition;
        private Position otherPosition;


        public MultiplayerWindow(string name, int row, int col)
        {
            InitializeComponent();

            this.name = name;
            this.row = row;
            this.col = col;
            myPosition = new Position(0, 0);
            otherPosition = new Position(0, 0);

            int port = Properties.Settings.Default.ServerPort;
            string ip = Properties.Settings.Default.ServerIP;
            vm = new MultiplayerVM(this.name, this.row, this.col, port, ip);
            DataContext = vm;
        }

        public MultiplayerWindow(string gameName)
        {
            InitializeComponent();
            myPosition = new Position(0, 0);
            otherPosition = new Position(0, 0);
            this.name= gameName;
            this.waitlabel.Content = "";
        }

        private void restartbutton_Click(object sender, RoutedEventArgs e)
        {
            GoBackWindow action = new GoBackWindow();
            action.ShowDialog();
            if (action.getYesNoFlag() == 1)
            {
                action.Close();
            }
        }

        private void solvebutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mainbutton_Click(object sender, RoutedEventArgs e)
        {
            GoBackWindow action = new GoBackWindow();
            action.ShowDialog();
            if (action.getYesNoFlag() == 1)
            {
                this.Close();
            }

        }




    }
}
