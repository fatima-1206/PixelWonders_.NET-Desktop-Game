namespace PixelWonders
{
    partial class Menu2
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu2));
            imageList1 = new ImageList(components);
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            button2 = new Button();
            button3 = new Button();
            button1 = new Button();
            panel3 = new Panel();
            label2 = new Label();
            button4 = new Button();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // label1
            // 
            label1.AutoSize = true;

            label1.Location = new Point(531, 200);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 0;
            label1.Click += Label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(239, 182, 200);
            panel1.Controls.Add(panel2);

            panel1.Location = new Point(1013, 229);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(653, 630);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 210, 160);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button1);

            panel2.Location = new Point(24, 22);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(607, 581);
            panel2.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(168, 136, 181);
            button2.Font = new Font("Pixelify Sans", 12F);
            button2.ForeColor = Color.FromArgb(64, 0, 64);

            button2.Location = new Point(134, 227);
            button2.Margin = new Padding(4, 6, 4, 6);
            button2.Name = "button2";
            button2.Size = new Size(336, 94);
            button2.TabIndex = 3;
            button2.Text = "Puzzle";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(239, 182, 200);
            button3.Font = new Font("Pixelify Sans", 12F);
            button3.ForeColor = Color.FromArgb(64, 0, 64);

            button3.Location = new Point(134, 363);
            button3.Margin = new Padding(4, 6, 4, 6);
            button3.Name = "button3";
            button3.Size = new Size(336, 101);
            button3.TabIndex = 2;
            button3.Text = "Color by \r\nnumber";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(239, 182, 200);
            button1.Font = new Font("Pixelify Sans", 12F);
            button1.ForeColor = Color.FromArgb(64, 0, 64);

            button1.Location = new Point(134, 85);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(336, 94);
            button1.TabIndex = 0;
            button1.Text = "Nonogram";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Thistle;
            panel3.Controls.Add(label2);
            panel3.Font = new Font("Pixelify Sans", 12F);

            panel3.Location = new Point(0, 458);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(1716, 166);
            panel3.TabIndex = 2;
            panel3.Text = "Choose your mystery solving level";
            panel3.Paint += Panel3_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Pixelify Sans", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 0, 64);

            label2.Location = new Point(114, 66);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(518, 35);
            label2.TabIndex = 0;
            label2.Text = "Choose your mystery solving level";
            // 
            // button4
            // 
            button4.BackColor = Color.Thistle;
            button4.Font = new Font("Pixelify Sans", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

            button4.Location = new Point(19, 20);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(175, 69);
            button4.TabIndex = 3;
            button4.Text = "       Back";
            button4.UseVisualStyleBackColor = false;
            button4.Click += Button4_Click;
         
            // 
            // Menu2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(168, 136, 181);
            ClientSize = new Size(1715, 1106);
         
            Controls.Add(button4);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "Menu2";
            Text = "Form1";
            Load += Menu2_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ImageList imageList1;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Button button3;
        private Button button1;
        private Button button2;
        private Panel panel3;
        private Label label2;
        private Button button4;
        private PictureBox pictureBox2;
    }
}
