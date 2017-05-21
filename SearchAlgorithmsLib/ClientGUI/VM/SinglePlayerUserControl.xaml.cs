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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for SinglePlayerWindow.xaml
    /// </summary>
    public partial class SinglePlayerUserControl : UserControl
    {


        private int row;
        private int col;
        private String json;
        private Label[,] maze;
        public SinglePlayerUserControl(int row, int col, String json)
        {
            this.row = row;
            this.col = col;
            maze = new Label[row, col];



            Grid myGrid = new Grid();
            myGrid.ShowGridLines = true;
            for (int i=0; i<row; i++)
            {
                myGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < col; i++)
            {
                myGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }


            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Label label = new Label();
                    maze[i, j] = label;
                    Grid.SetColumn(label, j);
                    Grid.SetRow(label, i);
                }
            }

            this.Content = myGrid;
            InitializeComponent();
            
        }


    }
}
