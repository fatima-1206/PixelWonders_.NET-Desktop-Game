namespace PixelWonders
{
    partial class Nonogram
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
            close = new Panel();
            headerContainer = new Panel();
            label1 = new Label();
            pictureBoxLogo = new PictureBox();
            gridContainer = new FlowLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            livesPanel = new Panel();
            heart = new Panel();
            crossOptionContainer = new Panel();
            crossOption = new Panel();
            fillOptionContainer = new Panel();
            fillOption = new Panel();
            pictureBox1 = new PictureBox();
            headerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            livesPanel.SuspendLayout();
            crossOptionContainer.SuspendLayout();
            fillOptionContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // close
            // 
            close.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            close.BackColor = Color.FromArgb(222, 183, 219);
            close.BackgroundImage = Properties.Resources.cross_removebg_preview;
            close.BackgroundImageLayout = ImageLayout.None;
            close.Cursor = Cursors.Hand;
            close.Location = new Point(1091, 0);
            close.Margin = new Padding(2);
            close.Name = "close";
            close.Size = new Size(52, 32);
            close.TabIndex = 6;
            close.Click += close_Click;
            // 
            // headerContainer
            // 
            headerContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerContainer.BackColor = Color.FromArgb(168, 136, 181);
            headerContainer.BorderStyle = BorderStyle.FixedSingle;
            headerContainer.Controls.Add(label1);
            headerContainer.Controls.Add(pictureBoxLogo);
            headerContainer.Location = new Point(-3, 32);
            headerContainer.Name = "headerContainer";
            headerContainer.Size = new Size(1146, 80);
            headerContainer.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(168, 136, 181);
            label1.Font = new Font("Pixelify Sans", 34F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(83, 54, 89);
            label1.Location = new Point(400, 6);
            label1.Name = "label1";
            label1.Size = new Size(310, 69);
            label1.TabIndex = 0;
            label1.Text = "Nonogram";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.White;
            pictureBoxLogo.Cursor = Cursors.Hand;
            pictureBoxLogo.Image = Properties.Resources.logo3;
            pictureBoxLogo.Location = new Point(2, -1);
            pictureBoxLogo.Margin = new Padding(2);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(126, 81);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // gridContainer
            // 
            gridContainer.BackColor = Color.FromArgb(83, 54, 89);
            gridContainer.Location = new Point(156, 183);
            gridContainer.Margin = new Padding(0);
            gridContainer.Name = "gridContainer";
            gridContainer.Size = new Size(475, 475);
            gridContainer.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ControlLight;
            flowLayoutPanel1.Location = new Point(113, 141);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(575, 575);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // livesPanel
            // 
            livesPanel.BorderStyle = BorderStyle.FixedSingle;
            livesPanel.Controls.Add(heart);
            livesPanel.Location = new Point(765, 196);
            livesPanel.Name = "livesPanel";
            livesPanel.Padding = new Padding(5, 3, 5, 3);
            livesPanel.Size = new Size(274, 64);
            livesPanel.TabIndex = 9;
            // 
            // heart
            // 
            heart.BackgroundImage = Properties.Resources.heart_1_;
            heart.BackgroundImageLayout = ImageLayout.Zoom;
            heart.Location = new Point(3, 5);
            heart.Name = "heart";
            heart.Size = new Size(57, 52);
            heart.TabIndex = 1;
            // 
            // crossOptionContainer
            // 
            crossOptionContainer.BorderStyle = BorderStyle.FixedSingle;
            crossOptionContainer.Controls.Add(crossOption);
            crossOptionContainer.Location = new Point(930, 314);
            crossOptionContainer.Name = "crossOptionContainer";
            crossOptionContainer.Size = new Size(109, 81);
            crossOptionContainer.TabIndex = 11;
            // 
            // crossOption
            // 
            crossOption.BackgroundImage = Properties.Resources.close;
            crossOption.BackgroundImageLayout = ImageLayout.Zoom;
            crossOption.Location = new Point(26, 15);
            crossOption.Name = "crossOption";
            crossOption.Size = new Size(57, 52);
            crossOption.TabIndex = 0;
            // 
            // fillOptionContainer
            // 
            fillOptionContainer.BorderStyle = BorderStyle.FixedSingle;
            fillOptionContainer.Controls.Add(fillOption);
            fillOptionContainer.Location = new Point(774, 314);
            fillOptionContainer.Name = "fillOptionContainer";
            fillOptionContainer.Size = new Size(109, 81);
            fillOptionContainer.TabIndex = 12;
            // 
            // fillOption
            // 
            fillOption.BackColor = Color.FromArgb(83, 54, 89);
            fillOption.BackgroundImageLayout = ImageLayout.Zoom;
            fillOption.Location = new Point(26, 15);
            fillOption.Name = "fillOption";
            fillOption.Size = new Size(57, 52);
            fillOption.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.white_with_ball_8fps4;
            pictureBox1.Location = new Point(954, 128);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(85, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // Nonogram
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 217, 231);
            ClientSize = new Size(1143, 750);
            Controls.Add(pictureBox1);
            Controls.Add(fillOptionContainer);
            Controls.Add(crossOptionContainer);
            Controls.Add(livesPanel);
            Controls.Add(close);
            Controls.Add(headerContainer);
            Controls.Add(gridContainer);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Nonogram";
            Text = "Nonogram";
            headerContainer.ResumeLayout(false);
            headerContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            livesPanel.ResumeLayout(false);
            crossOptionContainer.ResumeLayout(false);
            fillOptionContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel close;
        private Panel headerContainer;
        private Label label1;
        private PictureBox pictureBoxLogo;
        private FlowLayoutPanel gridContainer;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel livesPanel;
        private Panel crossOptionContainer;
        private Panel crossOption;
        private Panel fillOptionContainer;
        private Panel fillOption;
        private Panel heart;
        private PictureBox pictureBox1;
    }
}