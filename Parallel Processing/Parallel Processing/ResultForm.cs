using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Parallel_Processing
{
    public partial class ResultForm : Form
    {
        int SIZEX;
        int SIZEY;
        PictureBox[,] Box;
        bool[,] boolBox;
        Point startBox;
        Point endBox;
        private List<Point> blocked;
        private List<Node> pATH;

        public ResultForm(int x, int y, Point startBox, Point endBox, List<Point> blocked, List<Node> pATH)
        {
            this.startBox = startBox;
            this.endBox = endBox;
            this.blocked = blocked;
            this.pATH = pATH;
            this.SIZEX = x;
            this.SIZEY = y;
            Box = new PictureBox[x, y];
            boolBox = new bool[x, y];
            startBox = new Point(-1, -1);
            endBox = new Point(-1, -1);
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
                Width = x * 30 + 40;
            if (y > 3)
                Height = y * 30 + 60;
            maze_ground.Size = new Size(30 * x, 30 * y);
            backgroundWorker1.RunWorkerAsync();
        }
        private void operation(int i, int j)
        {
            Box[i, j].BackColor = System.Drawing.Color.Transparent;
            Box[i, j].Size = new System.Drawing.Size(30, 30);
            Box[i, j].Location = new System.Drawing.Point(30 * i, 30 * j);
            Box[i, j].Name = "Box" + i + j;
            Box[i, j].TabIndex = 0;
            Box[i, j].TabStop = false;
            Box[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
            Point p = new Point(i, j);
            if (p == startBox)
                Box[i, j].Image = Properties.Resources.car0;
            else if (p == endBox)
                Box[i, j].Image = Properties.Resources.exit;

            else if (blocked.Contains(p))
                Box[i, j].Image = Properties.Resources.filled;
            Func<int> start = delegate ()
            {
                maze_ground.Controls.Add(Box[i, j]);
                ((System.ComponentModel.ISupportInitialize)(Box[i, j])).EndInit();
                return 0;
            };
            Invoke(start);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            operation(startBox.X, startBox.Y);
            operation(endBox.X, endBox.Y);
            foreach (Point item in blocked)
                operation(item.X, item.Y);
            foreach (Node item in pATH)
            {
                int i = item.Point.X;
                int j = item.Point.Y;
                Box[i, j].BackColor = System.Drawing.Color.Transparent;
                Box[i, j].Size = new System.Drawing.Size(30, 30);
                Box[i, j].Location = new System.Drawing.Point(30 * i, 30 * j);
                Box[i, j].Name = "Box" + i + j;
                Box[i, j].TabIndex = 0;
                Box[i, j].TabStop = false;
                Box[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                Point p = new Point(i, j);
                Func<int> start = delegate ()
               {
                   switch (item.dir)
                   {
                       case 0:
                           Box[i, j].Image = Properties.Resources.car0;
                           break;
                       case 1:
                           Box[i, j].Image = Properties.Resources.car1;
                           break;
                       case 2:
                           Box[i, j].Image = Properties.Resources.car2;
                           break;
                       case 3:
                           Box[i, j].Image = Properties.Resources.car3;
                           break;
                   }
                   maze_ground.Controls.Add(Box[i, j]);
                   ((System.ComponentModel.ISupportInitialize)(Box[i, j])).EndInit();
                   return 0;
               };
                Invoke(start);
                Thread.Sleep(100);
                Func<int> end = delegate ()
                {
                    Box[i, j].Image = Properties.Resources.path;
                    return 0;
                };
                Invoke(end);
            }
        }
    }
}

