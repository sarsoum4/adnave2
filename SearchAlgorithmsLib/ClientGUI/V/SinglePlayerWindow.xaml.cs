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
            this.name = name;
            this.row = row;
            this.col = col;
            int port = Properties.Settings.Default.ServerPort;
            string ip = Properties.Settings.Default.ServerIP;
            vm = new SinglePlayerVM(this.name, this.row, this.col, port, ip);
            vm.startGame(this.name, this.row, this.col);
           

    }


        private void restartbutton_Click(object sender, RoutedEventArgs e)
        {
            GoBackWindow action = new GoBackWindow();
            action.ShowDialog();
            if (action.getYesNoFlag() == 1)
            {
                
            }
        }

        private void solvebutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mainbutton_Click(object sender, RoutedEventArgs e)
        {
            GoBackWindow action = new GoBackWindow();
            action.ShowDialog();
            if(action.getYesNoFlag() == 1)
            {
                this.Close();
            }

        }
    }
}
