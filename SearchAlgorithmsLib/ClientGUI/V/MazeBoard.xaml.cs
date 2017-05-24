using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ClientGUI.V
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class MazeBoard : UserControl
    {

        public int rows;
        public int cols;
        public string maze;
        public int[] initialPos;
        public int[] goalPos;

        public MazeBoard()
        {

            InitializeComponent();

            Maze = "1,0,1,0,0,0,1,0,1,1,1,1,1,0,0,1,0,0,0,1,1,0,1,1,0";


        }



        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        public int Cols
        {
            get { return (int)GetValue(ColsProperty); }
            set { SetValue(ColsProperty, value); }
        }


        public string Maze
        {
            get
            {
                return (string)GetValue(MazeProperty);
            }
            set
            {
                SetValue(MazeProperty, value);
                string m = Maze.Replace(",", "");

               Rectangle rect;
                for (int i = 0; i < 5; i++)
                {

                    for (int j = 0; j < 5; j++)
                    {
                        if (m[i * 5 + j] == '1')
                        {
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Width = myCanvas.Width / 5;
                            rect.Height = myCanvas.Height / 5;
                            rect.Stroke = new SolidColorBrush(Colors.Black);
                            rect.Fill = new SolidColorBrush(Colors.Black);
                            Canvas.SetTop(rect, i * rect.Height);
                            Canvas.SetLeft(rect, j * rect.Width);
                            myCanvas.Children.Add(rect);
                        }
                    }
                }
            }
        }



        public int[] InitialPos
        {

            get { return (int[])GetValue(InitialPosProperty); }
            set
            {
                SetValue(InitialPosProperty, value);
            }
        }


        public int[] GoalPos
        {
            get { return (int[])GetValue(GoalPosProperty); }
            set
            {
                SetValue(GoalPosProperty, value);
            }
        }



        public static readonly DependencyProperty GoalPosProperty =
        DependencyProperty.Register("GoalPos", typeof(int[]), typeof(V.MazeBoard), new
        PropertyMetadata(new int[2, 2]));


        public static readonly DependencyProperty InitialPosProperty =
        DependencyProperty.Register("InitialPos", typeof(int[]), typeof(V.MazeBoard), new
        PropertyMetadata(new int [0, 0]));


        // Using a DependencyProperty as the backing store for Maze representation. This enables animation, styling,
        public static readonly DependencyProperty MazeProperty =
        DependencyProperty.Register("Maze", typeof(string), typeof(V.MazeBoard), new
        PropertyMetadata("11111000001"));


        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling,
        public static readonly DependencyProperty RowsProperty =
        DependencyProperty.Register("Rows", typeof(int), typeof(V.MazeBoard), new
        PropertyMetadata(0));


        // Using a DependencyProperty as the backing store for Cols. This enables animation, styling,
        public static readonly DependencyProperty ColsProperty =
        DependencyProperty.Register("Cols", typeof(int), typeof(V.MazeBoard), new
        PropertyMetadata(0));
    }
}
