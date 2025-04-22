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
            eyePicBox = new PictureBox();
            button1 = new Button();
            label5 = new Label();
            passwordTextBox = new TextBox();
            txtUsername = new TextBox();
            label4 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            label1 = new Label();
            label3 = new Label();
            button2 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)eyePicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(239, 182, 200);
            panel1.Controls.Add(eyePicBox);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(passwordTextBox);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(241, 56);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(435, 497);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // eyePicBox
            // 
            eyePicBox.BackColor = Color.FromArgb(241, 217, 231);
            eyePicBox.Image = Properties.Resources.closeEye;
            eyePicBox.Location = new Point(287, 258);
            eyePicBox.Name = "eyePicBox";
            eyePicBox.Size = new Size(38, 20);
            eyePicBox.SizeMode = PictureBoxSizeMode.Zoom;
            eyePicBox.TabIndex = 14;
            eyePicBox.TabStop = false;
            eyePicBox.Click += eyePicBox_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(168, 136, 181);
            button1.Font = new Font("Pixelify Sans", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(64, 0, 64);
            button1.Location = new Point(287, 428);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(96, 36);
            button1.TabIndex = 10;
            button1.Text = "SignUp";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Pixelify Sans", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(64, 0, 64);
            label5.Location = new Point(121, 226);
            label5.Name = "label5";
            label5.Size = new Size(107, 24);
            label5.TabIndex = 9;
            label5.Text = "Password";
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.FromArgb(241, 217, 231);
            passwordTextBox.BorderStyle = BorderStyle.None;
            passwordTextBox.Location = new Point(121, 258);
            passwordTextBox.Margin = new Padding(3, 4, 3, 4);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.ShortcutsEnabled = false;
            passwordTextBox.Size = new Size(204, 20);
            passwordTextBox.TabIndex = 8;
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.TextChanged += textBox2_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(241, 217, 231);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Location = new Point(121, 176);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(204, 20);
            txtUsername.TabIndex = 7;
            txtUsername.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Pixelify Sans", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(64, 0, 64);
            label4.Location = new Point(121, 146);
            label4.Name = "label4";
            label4.Size = new Size(108, 24);
            label4.TabIndex = 6;
            label4.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Pixelify Sans", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 0, 64);
            label2.Location = new Point(48, 434);
            label2.Name = "label2";
            label2.Size = new Size(217, 23);
            label2.TabIndex = 4;
            label2.Text = "Don't have a account?";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(159, 22);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(127, 70);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(168, 136, 181);
            button3.Font = new Font("Pixelify Sans", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(64, 0, 64);
            button3.Location = new Point(174, 350);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(99, 44);
            button3.TabIndex = 3;
            button3.Text = "Login";
            button3.UseVisualStyleBackColor = false;
            button3.Click += Button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Pixelify Sans", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 0, 64);
            label1.Location = new Point(174, 22);
            label1.Name = "label1";
            label1.Size = new Size(114, 45);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(889, 2);
            label3.Name = "label3";
            label3.Size = new Size(27, 29);
            label3.TabIndex = 1;
            label3.Text = "X";
            label3.Click += Label3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Thistle;
            button2.Font = new Font("Pixelify Sans", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(10, 11);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(94, 46);
            button2.TabIndex = 3;
            button2.Text = ">Back";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(168, 136, 181);
            ClientSize = new Size(914, 600);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)eyePicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button button3;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label4;
        private TextBox passwordTextBox;
        private TextBox txtUsername;
        private Label label5;
        private Button button1;
        private Label label3;
        private Button button2;
        private PictureBox eyePicBox;
    }
}