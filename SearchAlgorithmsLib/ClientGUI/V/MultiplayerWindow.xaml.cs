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
            vm.startGame(this.name, this.row, this.col);
            DataContext = vm;
        }



        public MultiplayerWindow(string gameName)
        {
            InitializeComponent();
            myPosition = new Position(0, 0);
            otherPosition = new Position(0, 0);
            this.name= gameName;
            

            int port = Properties.Settings.Default.ServerPort;
            string ip = Properties.Settings.Default.ServerIP;
            vm = new MultiplayerVM(this.name, port, ip);
            vm.Join(gameName);
            DataContext = vm;

        }





        private void Window_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.Key == Key.Down)
            {
                vm.PlayerMoveDown();

            }

            else if (e.Key == Key.Up)
            {
                vm.PlayerMoveUp();
            }

            else if (e.Key == Key.Right)
            {
                vm.PlayerMoveRight();
            }

            else if (e.Key == Key.Left)
            {
                vm.PlayerMoveLeft();
            }

            if (vm.VM_PlayerPosition.Row == vm.VM_EndRow && vm.VM_PlayerPosition.Col == vm.VM_EndCol)
            {
                MessageBox.Show("You Win!");
                this.Close();
            }
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
