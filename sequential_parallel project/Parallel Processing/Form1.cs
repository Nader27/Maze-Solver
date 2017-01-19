using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parallel_Processing
{
    public struct Node
    {

        public Node(Point Point, int dir, int path)
        {
            this.Point = Point;
            this.dir = dir;
            this.path = path;
        }
        public Point Point;
        public int dir;
        public int path;
    };
    public partial class Form1 : Form
    {
        int[] dx = { 0, 1, 0, -1 };
        int[] dy = { -1, 0, 1, 0 };
        int SIZEX;
        int SIZEY;
        PictureBox[,] Box;
        bool[,] boolBox;
        Dictionary<Tuple<Point, int>, Node> par;
        List<Tuple<Point, int>> visited;
        List<Point> Blocked;
        Point startBox;
        Point endBox;
        Node node;
        Queue<Node> queue;
        private Stopwatch sw;
        private TimeSpan ts;

        public Form1(int x, int y)
        {
            SIZEX = x;
            SIZEY = y;
            Box = new PictureBox[x, y];
            boolBox = new bool[x, y];
            startBox = new Point(-1, -1);
            endBox = new Point(-1, -1);
            Blocked = new List<Point>();
            sw = new Stopwatch();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    boolBox[i, j] = false;
                    Box[i, j] = new PictureBox();
                    ((System.ComponentModel.ISupportInitialize)(Box[i, j])).BeginInit();
                }
            }
            InitializeComponent();
            if (x > 3)
                Width = x * 30 + 100 + 40;
            if (y > 3)
                Height = y * 30 + 60;
            maze_ground.Size = new Size(30 * x, 30 * y);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {

                    Box[i, j].BackColor = System.Drawing.Color.Transparent;
                    Box[i, j].Size = new System.Drawing.Size(30, 30);
                    Box[i, j].Location = new System.Drawing.Point(30 * i, 30 * j);
                    Box[i, j].Name = "Box" + i+"-" + j;
                    Box[i, j].TabIndex = 0;
                    Box[i, j].TabStop = false;
                    Box[i, j].Click += new EventHandler(Box_Click);
                    maze_ground.Controls.Add(Box[i, j]);
                    ((System.ComponentModel.ISupportInitialize)(Box[i, j])).EndInit();
                }
            }
        }

        public bool valid(Point Point)  //check valid position and valid cell
        {
            if (Blocked.Contains(Point) || Point.X >= SIZEX || Point.Y >= SIZEY || Point.X < 0 || Point.Y < 0)
                return false;
            return true;
        }

        private void Box_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            string bs = pictureBox.Name.Substring(3);
            int BoxX = int.Parse(bs.Split('-').ElementAt(0));
            int BoxY = int.Parse(bs.Split('-').ElementAt(1));
            if (Box_radioButton.Checked)
            {
                if (startBox == new Point(BoxX, BoxY) || endBox == new Point(BoxX, BoxY)) ;
                else if (!boolBox[BoxX, BoxY])
                {
                    pictureBox.Image = Properties.Resources.filled;
                    boolBox[BoxX, BoxY] = true;
                    Blocked.Add(new Point(BoxX, BoxY));
                }
                else
                {
                    pictureBox.Image = null;
                    boolBox[BoxX, BoxY] = false;
                    Blocked.Remove(new Point(BoxX, BoxY));
                }

            }
            else if (Start_radioButton.Checked)
            {
                if (startBox == new Point(-1, -1))
                {
                    pictureBox.Image = Properties.Resources.car;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    startBox = new Point(BoxX, BoxY);
                }
                else if (startBox == new Point(BoxX, BoxY))
                {
                    pictureBox.Image = null;
                    startBox = new Point(-1, -1);
                }
                else
                {
                    Box[startBox.X, startBox.Y].Image = null;
                    pictureBox.Image = Properties.Resources.car;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    startBox = new Point(BoxX, BoxY);
                }
            }
            else if (End_radioButton.Checked)
            {
                if (endBox == new Point(-1, -1))
                {
                    pictureBox.Image = Properties.Resources.exit;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    endBox = new Point(BoxX, BoxY);
                }
                else if (endBox == new Point(BoxX, BoxY))
                {
                    pictureBox.Image = null;
                    endBox = new Point(-1, -1);
                }
                else
                {
                    Box[endBox.X, endBox.Y].Image = null;
                    pictureBox.Image = Properties.Resources.exit;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    endBox = new Point(BoxX, BoxY);
                }
            }
        }

        private void Box_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Box_radioButton.Checked)
            {
                for (int i = 0; i < SIZEX; i++)
                {
                    for (int j = 0; j < SIZEY; j++)
                    {
                        Box[i, j].Enabled = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < SIZEX; i++)
                {
                    for (int j = 0; j < SIZEY; j++)
                    {
                        if (boolBox[i, j])
                            Box[i, j].Enabled = false;
                    }
                }
            }
        }

        private void Solve_Click(object sender, EventArgs e)
        {
            sw.Reset();
            sw.Start();
            if (startBox == new Point(-1,-1) || endBox == new Point (-1,-1))
            {
                MessageBox.Show("Start Point and End Point Required", "Hey !!",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
            else if (BFS(startBox))
            {
                List<Node> PATH = new List<Node>();
                PATH.Add(node);
                while (node.path != 0)
                {
                    Tuple<Point, int> tuple = new Tuple<Point, int>(node.Point, node.dir);
                    node = par[tuple];
                    PATH.Add(node);
                }
                ts = sw.Elapsed;
                Console.WriteLine(ts.ToString());
                label1.Text = string.Format("Timer:{0,2}.{1,2}", ts.Seconds, ts.Milliseconds);
                sw.Stop();
                ResultForm ResultForm = new ResultForm(SIZEX, SIZEY, startBox, endBox, Blocked, PATH);
                ResultForm.ShowDialog();
            }
            else
                MessageBox.Show("No Path Found", "Sorry",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private bool BFS(Point point) //O(m*n)
        {
            queue = new Queue<Node>();
            node = new Node(point, 0, 0);
            par = new Dictionary<Tuple<Point, int>, Node>();
            visited = new List<Tuple<Point, int>>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                if (node.Point == endBox)
                    return true;
                for (int i = 0; i < 2; ++i)
                {
                    int new_dir = (node.dir + i) % 4;
                    Point new_point = new Point(node.Point.X + dx[new_dir], node.Point.Y + dy[new_dir]);
                    Tuple<Point, int> tuple = new Tuple<Point, int>(new_point, new_dir);
                    if (valid(new_point) && !visited.Contains(tuple))
                    {
                        queue.Enqueue(new Node(new_point, new_dir, node.path + 1));
                        par[tuple] = new Node(node.Point, node.dir, node.path);
                        visited.Add(tuple);
                    }
                }
            }
            return false;
        }
    }
}
