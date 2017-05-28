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
        private int preRow;
        private int prevCol;
        public Position playerPos;
        private int playerCol;
        private int playerRow;

        private Rectangle[,] rectangles;

        public MazeBoard()
        {

            InitializeComponent();
            
        }





        private void myCanvas_Loaded(Object sender, EventArgs e)
        {

            string m = Maze.Replace(",", "");
            rectangles = new Rectangle[Rows, Cols];
            Rectangle rect;
            for (int i = 0; i < Rows; i++)
            {

                for (int j = 0; j < Cols; j++)
                {
                    if (m[i * Cols + j] == '1')
                    {
                        rect = new System.Windows.Shapes.Rectangle();
                        rect.Width = myCanvas.Width / Cols;
                        rect.Height = myCanvas.Height / Rows;
                        rect.Stroke = new SolidColorBrush(Colors.Black);
                        rect.Fill = new SolidColorBrush(Colors.Black);
                        Canvas.SetTop(rect, i * rect.Height);
                        Canvas.SetLeft(rect, j * rect.Width);
                        myCanvas.Children.Add(rect);
                        //for debugging
                        rect.Tag = i.ToString() + ", " + j.ToString();
                        
                    }

                    else if (m[i * Cols + j] == '0')
                    {
                        rect = new System.Windows.Shapes.Rectangle();
                        rect.Width = myCanvas.Width / Cols;
                        rect.Height = myCanvas.Height / Rows;
                        rect.Stroke = new SolidColorBrush(Colors.White);
                        rect.Fill = new SolidColorBrush(Colors.White);
                        Canvas.SetTop(rect, i * rect.Height);
                        Canvas.SetLeft(rect, j * rect.Width);
                        myCanvas.Children.Add(rect);
                        
                    }


                    else if (m[i * Cols + j] == ' ')
                    {
                        continue;
                    }
                    else if (m[i * Cols + j] == '#')
                    {
                        rect = new System.Windows.Shapes.Rectangle();
                        rect.Width = myCanvas.Width / Cols;
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
                        playerCol = j;
                        playerRow = i;
                        preRow = i;
                        prevCol = j;
                        rect = new System.Windows.Shapes.Rectangle();
                        rect.Width = myCanvas.Width / Cols;
                        rect.Height = myCanvas.Height / Rows;
                        rect.Stroke = new SolidColorBrush(Colors.Yellow);
                        rect.Fill = new SolidColorBrush(Colors.Yellow);
                        Canvas.SetTop(rect, i * rect.Height);
                        Canvas.SetLeft(rect, j * rect.Width);
                        myCanvas.Children.Add(rect);
                        
                    }
                    if (rect != null)
                        rectangles[i, j] = rect;
                    rect = null;
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
                MessageBox.Show("maze beeing set");
                SetValue(MazeProperty, value);
            }
        }



        public string InitialPos
        {

            get { return (string)GetValue(InitialPosProperty); }
            set
            {
                SetValue(InitialPosProperty, value);
                //string[] s = playerPos.ToString().Split(',');

                //this.preRow = Int32.Parse(s[0]);
                //this.prevCol = Int32.Parse(s[1]);

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


        public Position PlayerPos
        {
            get
            {
                return (Position)GetValue(PlayerPosProperty);
               
            }
            set
            {
                SetValue(PlayerPosProperty, value);

                //this.playerPos = value.ToString();
                string[] s = playerPos.ToString().Split(',');

                this.preRow = playerRow;
                this.prevCol = playerCol;

                playerRow = Int32.Parse(s[0]);
                playerCol = Int32.Parse(s[1]);

                //ChangePlayerPosition(preRow, prevCol, playerRow, playerCol);
            }
        }

        private void ChangePlayerPosition()
        {


            Rectangle rect = CellAtPosition(this.preRow, this.prevCol);
            if(rect!=null)
            {
                rect.Stroke = new SolidColorBrush(Colors.White);
                rect.Fill = new SolidColorBrush(Colors.White);

                rect = CellAtPosition(PlayerPos.Row, PlayerPos.Col);
                rect.Stroke = new SolidColorBrush(Colors.Yellow);
                rect.Fill = new SolidColorBrush(Colors.Yellow);

                this.preRow = PlayerPos.Row;
                this.prevCol = PlayerPos.Col;
                this.playerRow = PlayerPos.Row;
                this.playerCol = PlayerPos.Col;
            }

        }

        private static void onPlayerPosPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeBoard mazeBoard = (MazeBoard)d;
            mazeBoard.ChangePlayerPosition();
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


        // Using a DependencyProperty as the backing store for Cols. This enables animation, stylsing,
        public static readonly DependencyProperty ColsProperty =
        DependencyProperty.Register("Cols", typeof(int), typeof(V.MazeBoard), new
        PropertyMetadata(0));


        // Using a DependencyProperty as the backing store for position. This enables animation, styling,
        public static readonly DependencyProperty PlayerPosProperty =
        DependencyProperty.Register("PlayerPos", typeof(Position), typeof(MazeBoard), new PropertyMetadata(new Position(0,0), onPlayerPosPropertyChanged));




        private Rectangle CellAtPosition(int i, int j)
        {
            /*
            IEnumerable<Rectangle> rectangles = myCanvas.Children.OfType<Rectangle>();
            int count = 0;
            foreach (var rect in rectangles)
            {
                if (count == i * cols + j)
                {
                    return rect;
                }
                count++;
            }
            return null;
            */
            if (rectangles != null && i < rectangles.GetLength(0) && i >=0 && j >= 0 && j < rectangles.GetLength(1))
                return rectangles[i, j];
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