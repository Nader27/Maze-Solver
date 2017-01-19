using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

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
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}
