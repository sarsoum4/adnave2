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
            String gameName = txtMazeName.Text.ToString();
            int row = Convert.ToInt32(txtRows.Text.ToString());
            int col = Convert.ToInt32(txtCols.Text.ToString());

            this.Close();
            SinglePlayerWindow game = new SinglePlayerWindow(Name, row, col);
            game.ShowDialog();



        }
    }
}
