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
        public string initialPos;
        public string goalPos;


        private int playercol;
        private int playerRow;

        public MazeBoard()
        {

            InitializeComponent();

            


        }





        private void myCanvas_Loaded(Object sender, EventArgs e)
        {
            rows = 5;
            cols = 5;
            Maze = "1,0,1,0,1,0,1,0,1,1,1,1,1,0,0,1,0,*,0,1,1,0,1,1,#";
            playercol = 2 ;
            playerRow = 3;


            

    }






        private void myCanvas_KeyUp(Object sender, KeyEventArgs e)
        {
            
            MessageBox.Show("5555555");
            IEnumerable<Rectangle> rectangles = myCanvas.Children.OfType<Rectangle>();
            int count = 0;
            foreach (var rect in rectangles)
            {
                if(count == rows * playercol + playerRow)
                {
                    rect.Stroke = new SolidColorBrush(Colors.Yellow);
                    rect.Fill = new SolidColorBrush(Colors.Yellow);
                }
                count++;
            }
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
                for (int i = 0; i < rows; i++)
                {

                    for (int j = 0; j < cols; j++)
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

                        else if (m[i * 5 + j] == '0')
                        {
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Width = myCanvas.Width / 5;
                            rect.Height = myCanvas.Height / 5;
                            rect.Stroke = new SolidColorBrush(Colors.White);
                            rect.Fill = new SolidColorBrush(Colors.White);
                            Canvas.SetTop(rect, i * rect.Height);
                            Canvas.SetLeft(rect, j * rect.Width);
                            myCanvas.Children.Add(rect);
                        }


                        else if (m[i * 5 + j] == ' ')
                        {
                            continue;
                        }
                        else if(m[i * 5 + j] == '#')
                        {
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Width = myCanvas.Width / 5;
                            rect.Height = myCanvas.Height / 5;
                            rect.Stroke = new SolidColorBrush(Colors.Red);
                            rect.Fill = new SolidColorBrush(Colors.Red);
                            Canvas.SetTop(rect, i * rect.Height);
                            Canvas.SetLeft(rect, j * rect.Width);
                            myCanvas.Children.Add(rect);
                        }
                        else
                        {
                            playercol = i;
                            playerRow = j;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Width = myCanvas.Width / 5;
                            rect.Height = myCanvas.Height / 5;
                            rect.Stroke = new SolidColorBrush(Colors.Yellow);
                            rect.Fill = new SolidColorBrush(Colors.Yellow);
                            Canvas.SetTop(rect, i * rect.Height);
                            Canvas.SetLeft(rect, j * rect.Width);
                            myCanvas.Children.Add(rect);
                        }
                    }
                }
            }
        }



        public string InitialPos
        {

            get { return (string)GetValue(InitialPosProperty); }
            set
            {
                SetValue(InitialPosProperty, value);
            }
        }


        public string GoalPos
        {
            get { return (string)GetValue(GoalPosProperty); }
            set
            {
                SetValue(GoalPosProperty, value);
            }
        }



        public static readonly DependencyProperty GoalPosProperty =
        DependencyProperty.Register("GoalPos", typeof(string), typeof(V.MazeBoard), new
        PropertyMetadata("2,2"));


        public static readonly DependencyProperty InitialPosProperty =
        DependencyProperty.Register("InitialPos", typeof(string), typeof(V.MazeBoard), new
        PropertyMetadata("0,0"));


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









            /**
                        // Right
                        int newCol = playercol + 1;
                        int newRow = playerRow;

                        Rectangle rect = CellAtPosition(playerRow, playercol);
                        rect.Stroke = new SolidColorBrush(Colors.White);
                        rect.Fill = new SolidColorBrush(Colors.White);

                        rect = CellAtPosition(newRow, newCol);
                        rect.Stroke = new SolidColorBrush(Colors.Yellow);
                        rect.Fill = new SolidColorBrush(Colors.Yellow);

                        playercol = newCol;
                        playerRow = newRow;
            *
*/


        private Rectangle CellAtPosition(int i, int j)
        {
            IEnumerable<Rectangle> rectangles = myCanvas.Children.OfType<Rectangle>();
            int count = 0;
            foreach (var rect in rectangles)
            {
                if (count == i * rows + j)
                {
                    return rect;
                }
                count++;
            }
            return null;
        }

        public void UserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Down)
            {
                int newCol = playercol;
                int newRow = playerRow + 1;

                Rectangle rect = CellAtPosition(playerRow, playercol);
                rect.Stroke = new SolidColorBrush(Colors.White);
                rect.Fill = new SolidColorBrush(Colors.White);

                rect = CellAtPosition(newRow, newCol);
                rect.Stroke = new SolidColorBrush(Colors.Yellow);
                rect.Fill = new SolidColorBrush(Colors.Yellow);

                playercol = newCol;
                playerRow = newRow;
            }

            if (e.Key == Key.Down)
            {
                int newCol = playercol;
                int newRow = playerRow + 1;

                Rectangle rect = CellAtPosition(playerRow, playercol);
                rect.Stroke = new SolidColorBrush(Colors.White);
                rect.Fill = new SolidColorBrush(Colors.White);

                rect = CellAtPosition(newRow, newCol);
                rect.Stroke = new SolidColorBrush(Colors.Yellow);
                rect.Fill = new SolidColorBrush(Colors.Yellow);

                playercol = newCol;
                playerRow = newRow;
            }
        }
    }
}
