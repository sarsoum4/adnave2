using ClientGUI.VM;
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
    /// Interaction logic for SinglePlayerWindow.xaml
    /// </summary>
    public partial class SinglePlayerWindow : Window
    {

        private SinglePlayerVM vm;
        private string name;
        private int row;
        private int col;





        public SinglePlayerWindow(string name, int row, int col)
        {
            
            InitializeComponent();
            //this.KeyDown += Window_KeyDown;

            this.name = name;
            this.row = row;
            this.col = col;
            int port = Properties.Settings.Default.ServerPort;
            string ip = Properties.Settings.Default.ServerIP;
            vm = new SinglePlayerVM(this.name, this.row, this.col, port, ip);
            vm.GenerateGame(this.name, this.row, this.col);
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

            if(vm.VM_PlayerPosition.Row == vm.VM_EndRow && vm.VM_PlayerPosition.Col == vm.VM_EndCol)
            {
                MessageBox.Show("You Win!");
                this.Close();
            }
        }


        private void restartbutton_Click(object sender, RoutedEventArgs e)
        {
            GoBackWindow action = new GoBackWindow();
            action.ShowDialog();
            if (action.getYesNoFlag() == 1)
            {
                vm.RestartGame();
                
            }
        }

        private void solvebutton_Click(object sender, RoutedEventArgs e)
        {
            vm.SolveMaze(this.name, 0);
            MessageBox.Show("Maze is solved! You can restart the maze");
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