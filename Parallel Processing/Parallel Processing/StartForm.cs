using System;
using System.Windows.Forms;

namespace Parallel_Processing
{
    public partial class StartForm : Form
    {
        Form1 form;
        public StartForm()
        {
            InitializeComponent();
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void go_button_Click(object sender, EventArgs e)
        {
            int x = int.Parse(X_textBox.Text);
            int y = int.Parse(Y_textBox.Text);
            if (x > 1 && y > 1 && x < 50 && y < 50)
            {
                Hide();
                form = new Form1(x, y);
                form.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("1 < Size <= 50", "Wrong",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
