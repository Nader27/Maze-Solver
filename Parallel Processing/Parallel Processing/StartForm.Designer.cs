namespace Parallel_Processing
{
    partial class StartForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Y_textBox = new System.Windows.Forms.TextBox();
            this.X_textBox = new System.Windows.Forms.TextBox();
            this.go_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Maze Size :";
            // 
            // Y_textBox
            // 
            this.Y_textBox.Location = new System.Drawing.Point(106, 32);
            this.Y_textBox.Name = "Y_textBox";
            this.Y_textBox.Size = new System.Drawing.Size(34, 20);
            this.Y_textBox.TabIndex = 1;
            this.Y_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // X_textBox
            // 
            this.X_textBox.Location = new System.Drawing.Point(153, 32);
            this.X_textBox.Name = "X_textBox";
            this.X_textBox.Size = new System.Drawing.Size(34, 20);
            this.X_textBox.TabIndex = 2;
            this.X_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // go_button
            // 
            this.go_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.go_button.Location = new System.Drawing.Point(65, 61);
            this.go_button.Name = "go_button";
            this.go_button.Size = new System.Drawing.Size(75, 33);
            this.go_button.TabIndex = 3;
            this.go_button.Text = "Go";
            this.go_button.UseVisualStyleBackColor = true;
            this.go_button.Click += new System.EventHandler(this.go_button_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 96);
            this.Controls.Add(this.go_button);
            this.Controls.Add(this.X_textBox);
            this.Controls.Add(this.Y_textBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StartForm";
            this.Text = "Maze Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Y_textBox;
        private System.Windows.Forms.TextBox X_textBox;
        private System.Windows.Forms.Button go_button;
    }
}