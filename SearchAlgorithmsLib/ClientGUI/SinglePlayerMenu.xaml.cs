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

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for SinglePlayerMenu.xaml
    /// </summary>
    public partial class SinglePlayerMenu : Window
    {
        public SinglePlayerMenu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //String gameName = txtMazeName.Text.ToString();
            this.Close();
            //SinglePlayerWindow game = new SinglePlayerWindow();
            //game.ShowDialog();


            //SinglePlayerMenu menu = new SinglePlayerMenu();
            Window win = new Window();
            win.Content = new SinglePlayerMenu();
            win.ShowDialog();
        }
    }
}
