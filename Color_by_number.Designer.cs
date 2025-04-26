namespace PixelWonders
{
    partial class Color_by_number
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label1 = new Label();
            pictureBoxLogo = new PictureBox();
            gridContainer = new Panel();
            animalPanel = new PictureBox();
            platform = new Panel();
            imageChangeTimer = new System.Windows.Forms.Timer(components);
            walkTimer = new System.Windows.Forms.Timer(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)animalPanel).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(168, 136, 181);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBoxLogo);
            panel1.Location = new Point(-3, 24);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(804, 65);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AccessibleRole = AccessibleRole.None;
            label1.AutoSize = true;
            label1.Font = new Font("Pixelify Sans", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(83, 54, 89);
            label1.Location = new Point(256, 5);
            label1.Name = "label1";
            label1.Size = new Size(398, 58);
            label1.TabIndex = 2;
            label1.Text = "Color By Number";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.White;
            pictureBoxLogo.Cursor = Cursors.Hand;
            pictureBoxLogo.Image = Properties.Resources.logo3;
            pictureBoxLogo.Location = new Point(2, 2);
            pictureBoxLogo.Margin = new Padding(2);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(110, 61);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 1;
            pictureBoxLogo.TabStop = false;
            // 
            // gridContainer
            // 
            gridContainer.BackColor = Color.Thistle;
           gridContainer.Location = new Point(35, 29);
            gridContainer.Name = "gridContainer";
           gridContainer.Size = new Size(470, 318);
            gridContainer.TabIndex = 1;
            // 
            // animalPanel
            // 
            animalPanel.Image = Properties.Resources.black_walk_8fps;
            animalPanel.Location = new Point(674, 314);
            animalPanel.Margin = new Padding(3, 2, 3, 2);
            animalPanel.Name = "animalPanel";
            animalPanel.Size = new Size(52, 45);
            animalPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            animalPanel.TabIndex = 13;
            animalPanel.TabStop = false;
            animalPanel.Click += animalPanel_Click;
            animalPanel.MouseHover += animalPanel_MouseHover;
            // 
            // platform
            // 
            platform.BorderStyle = BorderStyle.FixedSingle;
            platform.Location = new Point(672, 361);
            platform.Margin = new Padding(0);
            platform.Name = "platform";
            platform.Size = new Size(240, 1);
            platform.TabIndex = 15;
            // 
            // imageChangeTimer
            // 
            imageChangeTimer.Enabled = true;
            imageChangeTimer.Interval = 1000;
            imageChangeTimer.Tick += imageChangeTimer_Tick;
            // 
            // walkTimer
            // 
            walkTimer.Enabled = true;
            walkTimer.Interval = 150;
            walkTimer.Tick += timer1_Tick;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(168, 136, 181);
            panel2.Controls.Add(gridContainer);
            panel2.Location = new Point(61, 174);
            panel2.Name = "panel2";
            panel2.Size = new Size(539, 371);
            panel2.TabIndex = 16;
            // 
            // Color_by_number
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 207, 221);
            ClientSize = new Size(1127, 711);
            Controls.Add(panel2);
            Controls.Add(platform);
            Controls.Add(animalPanel);
            Controls.Add(panel1);
            Name = "Color_by_number";
            Text = "Color_by_number";
            Load += Color_by_number_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)animalPanel).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void AnimalPanel_MouseHover(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBoxLogo;
        private Panel gridContainer;
        private PictureBox animalPanel;
        private Panel platform;
        private System.Windows.Forms.Timer imageChangeTimer;
        private System.Windows.Forms.Timer walkTimer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panel2;
    }
}