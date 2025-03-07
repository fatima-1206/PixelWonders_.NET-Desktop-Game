using System.Windows.Forms;

namespace PixelWonders
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(239, 182, 200);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(211, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(381, 327);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(139, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(111, 52);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(168, 136, 181);
            button3.Font = new Font("Pixelify Sans", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(64, 0, 64);
            button3.Location = new Point(152, 252);
            button3.Name = "button3";
            button3.Size = new Size(87, 33);
            button3.TabIndex = 3;
            button3.Text = "Login";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(168, 136, 181);
            button2.Font = new Font("Pixelify Sans", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(64, 0, 64);
            button2.Location = new Point(106, 176);
            button2.Name = "button2";
            button2.Size = new Size(179, 34);
            button2.TabIndex = 2;
            button2.Text = "Password";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(168, 136, 181);
            button1.Font = new Font("Pixelify Sans", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(64, 0, 64);
            button1.Location = new Point(106, 104);
            button1.Name = "button1";
            button1.Size = new Size(179, 38);
            button1.TabIndex = 1;
            button1.Text = "Username";
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Pixelify Sans", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 0, 64);
            label1.Location = new Point(152, 17);
            label1.Name = "label1";
            label1.Size = new Size(87, 35);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(168, 136, 181);
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Login";
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Button button1;
        private Label label1;
        private Button button3;
        private PictureBox pictureBox1;
    }
}