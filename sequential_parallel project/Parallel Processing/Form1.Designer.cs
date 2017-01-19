namespace Parallel_Processing
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.End_radioButton = new System.Windows.Forms.RadioButton();
            this.Box_radioButton = new System.Windows.Forms.RadioButton();
            this.Start_radioButton = new System.Windows.Forms.RadioButton();
            this.maze_ground = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Solve";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Solve_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.End_radioButton);
            this.groupBox1.Controls.Add(this.Box_radioButton);
            this.groupBox1.Controls.Add(this.Start_radioButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(114, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 131);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maze Edit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Timer:00.00";
            // 
            // End_radioButton
            // 
            this.End_radioButton.AutoSize = true;
            this.End_radioButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.End_radioButton.Location = new System.Drawing.Point(6, 65);
            this.End_radioButton.Name = "End_radioButton";
            this.End_radioButton.Size = new System.Drawing.Size(47, 20);
            this.End_radioButton.TabIndex = 4;
            this.End_radioButton.Text = "End";
            this.End_radioButton.UseVisualStyleBackColor = true;
            // 
            // Box_radioButton
            // 
            this.Box_radioButton.AutoSize = true;
            this.Box_radioButton.Checked = true;
            this.Box_radioButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Box_radioButton.Location = new System.Drawing.Point(6, 17);
            this.Box_radioButton.Name = "Box_radioButton";
            this.Box_radioButton.Size = new System.Drawing.Size(46, 20);
            this.Box_radioButton.TabIndex = 2;
            this.Box_radioButton.TabStop = true;
            this.Box_radioButton.Text = "Box";
            this.Box_radioButton.UseVisualStyleBackColor = true;
            this.Box_radioButton.CheckedChanged += new System.EventHandler(this.Box_radioButton_CheckedChanged);
            // 
            // Start_radioButton
            // 
            this.Start_radioButton.AutoSize = true;
            this.Start_radioButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_radioButton.Location = new System.Drawing.Point(6, 41);
            this.Start_radioButton.Name = "Start_radioButton";
            this.Start_radioButton.Size = new System.Drawing.Size(54, 20);
            this.Start_radioButton.TabIndex = 3;
            this.Start_radioButton.Text = "Start";
            this.Start_radioButton.UseVisualStyleBackColor = true;
            // 
            // maze_ground
            // 
            this.maze_ground.BackgroundImage = global::Parallel_Processing.Properties.Resources.empty;
            this.maze_ground.Location = new System.Drawing.Point(10, 10);
            this.maze_ground.Name = "maze_ground";
            this.maze_ground.Size = new System.Drawing.Size(90, 90);
            this.maze_ground.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 131);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.maze_ground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Maze";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel maze_ground;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Box_radioButton;
        private System.Windows.Forms.RadioButton End_radioButton;
        private System.Windows.Forms.RadioButton Start_radioButton;
        private System.Windows.Forms.Label label1;
    }
}

