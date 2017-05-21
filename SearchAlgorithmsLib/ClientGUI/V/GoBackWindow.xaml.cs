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
    /// Interaction logic for GoBackWindow.xaml
    /// </summary>
    public partial class GoBackWindow : Window
    {
        private int flag = 0;

        public GoBackWindow()
        {
            InitializeComponent();
        }

        private void nobutton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.flag = 0;
        }

        private void yesbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.flag = 1;
        }

        public int getYesNoFlag()
        {
            return this.flag;
        }
    }
}
