using MazeLib;
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

        private string playerPos;
        private int playerCol;
        private int playerRow;

        public MazeBoard()
        {

            InitializeComponent();

        }





        private void myCanvas_Loaded(Object sender, EventArgs e)
        {


            string m = Maze.Replace(",", "");

            Rectangle rect;
            for (int i = 0; i < Rows; i++)
            {

                for (int j = 0; j < Cols; j++)
                {
                    if (m[i * Rows + j] == '1')
                    {
                        rect = new System.Windows.Shapes.Rectangle();
                        rect.Width = myCanvas.Width / Rows;
                        rect.Height = myCanvas.Height / Rows;
                        rect.Stroke = new SolidColorBrush(Colors.Black);
                        rect.Fill = new SolidColorBrush(Colors.Black);
                        Canvas.SetTop(rect, i * rect.Height);
                        Canvas.SetLeft(rect, j * rect.Width);
                        myCanvas.Children.Add(rect);
                    }

                    else if (m[i * Rows + j] == '0')
                    {
                        rect = new System.Windows.Shapes.Rectangle();
                        rect.Width = myCanvas.Width / Rows;
                        rect.Height = myCanvas.Height / Rows;
                        rect.Stroke = new SolidColorBrush(Colors.White);
                        rect.Fill = new SolidColorBrush(Colors.White);
                        Canvas.SetTop(rect, i * rect.Height);
                        Canvas.SetLeft(rect, j * rect.Width);
                        myCanvas.Children.Add(rect);
                    }


                    else if (m[i * Rows + j] == ' ')
                    {
                        continue;
                    }
                    else if (m[i * Rows + j] == '#')
                    {
                        rect = new System.Windows.Shapes.Rectangle();
                        rect.Width = myCanvas.Width / Rows;
                        rect.Height = myCanvas.Height / Rows;
                        rect.Stroke = new SolidColorBrush(Colors.Red);
                        rect.Fill = new SolidColorBrush(Colors.Red);
                        Canvas.SetTop(rect, i * rect.Height);
                        Canvas.SetLeft(rect, j * rect.Width);
                        myCanvas.Children.Add(rect);
                    }
                    else
                    {
                        //PlayerPos = j + "," + i;
                        playerCol = i;
                        playerRow = j;
                        rect = new System.Windows.Shapes.Rectangle();
                        rect.Width = myCanvas.Width / Rows;
                        rect.Height = myCanvas.Height / Rows;
                        rect.Stroke = new SolidColorBrush(Colors.Yellow);
                        rect.Fill = new SolidColorBrush(Colors.Yellow);
                        Canvas.SetTop(rect, i * rect.Height);
                        Canvas.SetLeft(rect, j * rect.Width);
                        myCanvas.Children.Add(rect);
                    }
                }
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


        public string PlayerPos
        {
            get
            {
                return (string)GetValue(PlayerPosProperty);
                
            }

            set
            {
                SetValue(PlayerPosProperty, value);
                
                string[] s = playerPos.Split(',');

                int preRow = playerRow;
                int prevCol = playerCol;

                playerRow = Int32.Parse(s[0]);
                playerCol = Int32.Parse(s[1]);

                ChangePlayerPosition(preRow, prevCol, playerRow, playerCol);
            }
        }

        private void ChangePlayerPosition(int prow, int pcol, int row, int col)
        {
            Rectangle rect = CellAtPosition(prow, pcol);
            rect.Stroke = new SolidColorBrush(Colors.White);
            rect.Fill = new SolidColorBrush(Colors.White);

            rect = CellAtPosition(row, col);
            rect.Stroke = new SolidColorBrush(Colors.Yellow);
            rect.Fill = new SolidColorBrush(Colors.Yellow);
        }


        public static readonly DependencyProperty GoalPosProperty =
        DependencyProperty.Register("GoalPos", typeof(string), typeof(V.MazeBoard), new
        PropertyMetadata("2,2"));


        public static readonly DependencyProperty InitialPosProperty =
        DependencyProperty.Register("InitialPos", typeof(string), typeof(V.MazeBoard), new
        PropertyMetadata("0,0"));


        // Using a DependencyProperty as the backing store for Maze representation. This enables animation, styling,
        public static readonly DependencyProperty MazeProperty =
        DependencyProperty.Register("Maze", typeof(string), typeof(MazeBoard));


        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling,
        public static readonly DependencyProperty RowsProperty =
        DependencyProperty.Register("Rows", typeof(int), typeof(V.MazeBoard), new
        PropertyMetadata(0));


        // Using a DependencyProperty as the backing store for Cols. This enables animation, styling,
        public static readonly DependencyProperty ColsProperty =
        DependencyProperty.Register("Cols", typeof(int), typeof(V.MazeBoard), new
        PropertyMetadata(0));


        // Using a DependencyProperty as the backing store for Cols. This enables animation, styling,
        public static readonly DependencyProperty PlayerPosProperty =
        DependencyProperty.Register("PlayerPos", typeof(Position), typeof(MazeBoard));




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



        /**
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

            else if (e.Key == Key.Up)
            {
                int newCol = playercol;
                int newRow = playerRow - 1;

                Rectangle rect = CellAtPosition(playerRow, playercol);
                rect.Stroke = new SolidColorBrush(Colors.White);
                rect.Fill = new SolidColorBrush(Colors.White);

                rect = CellAtPosition(newRow, newCol);
                rect.Stroke = new SolidColorBrush(Colors.Yellow);
                rect.Fill = new SolidColorBrush(Colors.Yellow);

                playercol = newCol;
                playerRow = newRow;
            }

            else if (e.Key == Key.Right)
            {
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
            }

            else if (e.Key == Key.Left)
            {
                // Right
                int newCol = playercol - 1;
                int newRow = playerRow;

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
    */

    }
}
