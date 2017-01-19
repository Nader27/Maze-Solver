using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Box[i, j].BackColor = System.Drawing.Color.Transparent;
                    Box[i, j].Size = new System.Drawing.Size(30, 30);
                    Box[i, j].Location = new System.Drawing.Point(30 * i, 30 * j);
                    Box[i, j].Name = "Box" + i + j;
                    Box[i, j].TabIndex = 0;
                    Box[i, j].TabStop = false;
                    Point p = new Point(i, j);
                    if (p == startBox)
                        Box[i, j].Image = Properties.Resources.car;
                    else if (p == endBox)
                        Box[i, j].Image = Properties.Resources.exit;
                    else if (pATH.Exists(n => n.Point == p))
                        Box[i, j].Image = Properties.Resources.path;
                    else if (blocked.Contains(p))
                        Box[i, j].Image = Properties.Resources.filled;
                    maze_ground.Controls.Add(Box[i, j]);
                    ((System.ComponentModel.ISupportInitialize)(Box[i, j])).EndInit();
                }
            }
        }
    }
}
