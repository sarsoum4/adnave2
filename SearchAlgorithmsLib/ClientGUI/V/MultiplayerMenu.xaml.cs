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
    /// Interaction logic for MultiplayerMenu.xaml
    /// </summary>
    public partial class MultiplayerMenu : Window
    {
        public MultiplayerMenu()
        {
            InitializeComponent();
            this.txtListOfGames.Items.Add("5");
            txtRows.Text = Properties.Settings.Default.MazeRows.ToString();
            txtCols.Text = Properties.Settings.Default.MazeCols.ToString();
        }





        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            String gameName = txtMazeName.Text.ToString();
            int row = Convert.ToInt32(txtRows.Text.ToString());
            int col = Convert.ToInt32(txtCols.Text.ToString());

            this.Close();

            MultiplayerWindow game = new MultiplayerWindow(gameName, row, col);
            game.ShowDialog();

        }

        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {

            string gameName = txtListOfGames.Text.ToString();
            MultiplayerWindow game = new MultiplayerWindow(gameName);
            this.Close();
            game.ShowDialog();

        }







    }
}
