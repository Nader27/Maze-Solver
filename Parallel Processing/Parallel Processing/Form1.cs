using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace Parallel_Processing
{
    public partial class Form1 : Form
    {
        int[] dx = { 0, 1, 0, -1 };
        int[] dy = { -1, 0, 1, 0 };
        int SIZEX;
        int SIZEY;
        PictureBox[,] Box;
        bool[,] boolBox;
        List<Point> Blocked;
        Point startBox;
        Point endBox;
        List<Task> Tasks;
        CancellationTokenSource cts = new CancellationTokenSource();
        private readonly Mutex m_lock = new Mutex();
        ResultForm ResultForm;
        TimeSpan ts;
        Stopwatch sw;
        bool finish;
        private List<Node> Resultnodes;

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
                    Box[i, j].Name = "Box" + i + "-" + j;
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
                    pictureBox.Image = Properties.Resources.car0;
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
                    pictureBox.Image = Properties.Resources.car0;
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

        private async void Solve_Click(object sender, EventArgs e)
        {
            if (startBox == new Point(-1, -1) || endBox == new Point(-1, -1))
            {
                MessageBox.Show("Start Point and End Point Required", "Hey !!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                (sender as Button).Enabled = false;
                bool tsk = await Operation();
                if (!tsk)
                {
                    ts = sw.Elapsed;
                    label1.Text = string.Format("Timer:{0,2}.{1,2}", ts.Seconds, ts.Milliseconds);
                    sw.Stop();
                    MessageBox.Show("No Path", "Soory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ts = sw.Elapsed;
                    label1.Text = string.Format("Timer:{0,2}.{1,2}", ts.Seconds, ts.Milliseconds);
                    sw.Stop();
                    ResultForm = new ResultForm(SIZEX, SIZEY, startBox, endBox, Blocked, Resultnodes);
                    ResultForm.ShowDialog();
                }
                (sender as Button).Enabled = true;
            }
        }

        private async Task<bool> Operation()
        {
            try
            {
                sw.Reset();
                sw.Start();
                cts = new CancellationTokenSource();
                List<Node> Lis = new List<Node>();
                Tasks = new List<Task>();
                Lis.Add(new Node(startBox, 0, 0));
                this.finish = false;
                Task task = Task.Run(() => ThreadFun(Lis, cts.Token));
                Tasks.Add(task);
                await Task.WhenAny(Tasks);
                if (this.finish)
                    return true;
                else return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }

        }

        private void ThreadFun(List<Node> nodes, CancellationToken cts)
        {
            //Debugger.Break();
            List<Node> ls = new List<Node>();
            Node node = nodes.Last();
            m_lock.WaitOne();
            if (cts.IsCancellationRequested)
            {
                m_lock.ReleaseMutex();
                return;
            }
            if (node.Point == endBox)
            {
                this.cts.Cancel();
                Resultnodes = nodes;
                this.finish = true;
                m_lock.ReleaseMutex();
                return;
            }
            m_lock.ReleaseMutex();
            for (int i = 0; i < 2; ++i)
            {
                int new_dir = (node.dir + i) % 4;
                Point new_point = new Point(node.Point.X + dx[new_dir], node.Point.Y + dy[new_dir]);
                if (valid(new_point) && !nodes.Exists(n => n.Point == new_point && n.dir == new_dir))
                    ls.Add(new Node(new_point, new_dir, node.path + 1));
            }
            if (ls.Count == 2)
            {

                List<Node> rnode = new List<Node>(nodes);
                List<Node> lnode = new List<Node>(nodes);
                rnode.Add(ls.Last());
                lnode.Add(ls.First());
                Task task = Task.Run(() => ThreadFun(rnode, cts));
                Tasks.Add(task);
                ThreadFun(lnode, cts);
            }
            else if (ls.Count == 1)
            {
                nodes.Add(ls.Last());
                ThreadFun(nodes, cts);
            }
            return;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sw.IsRunning)
            {
                ts = sw.Elapsed;
                label1.Text = string.Format("Timer:{0,2}.{1,2}", ts.Seconds, ts.Milliseconds);
            }
        }
    }
}
