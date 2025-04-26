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
            
            components = new System.ComponentModel.Container();
            close = new Panel();
            headerContainer = new Panel();
            label1 = new Label();
            pictureBoxLogo = new PictureBox();
            livesPanel = new Panel();
            crossOptionContainer = new Panel();
            crossOption = new Panel();
            fillOptionContainer = new Panel();
            fillOption = new Panel();
            animalPanel = new PictureBox();
            imageChangeTimer = new System.Windows.Forms.Timer(components);
            platform = new Panel();
            walkTimer = new System.Windows.Forms.Timer(components);
            rowCluesPanel = new FlowLayoutPanel();
            colCluesPanel = new FlowLayoutPanel();
            gridContainer = new FlowLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            headerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            crossOptionContainer.SuspendLayout();
            fillOptionContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)animalPanel).BeginInit();
            SuspendLayout();
            // 
            // close
            // 
            close.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            close.BackColor = Color.FromArgb(222, 183, 219);
            close.BackgroundImage = Properties.Resources.cross_removebg_preview;
            close.BackgroundImageLayout = ImageLayout.None;
            close.Cursor = Cursors.Hand;
            close.Location = new Point(955, 0);
            close.Margin = new Padding(2);
            close.Name = "close";
            close.Size = new Size(46, 24);
            close.TabIndex = 6;
            close.Click += close_Click;
            close.Paint += close_Paint;
            // 
            // headerContainer
            // 
            headerContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerContainer.BackColor = Color.FromArgb(168, 136, 181);
            headerContainer.BorderStyle = BorderStyle.FixedSingle;
            headerContainer.Controls.Add(label1);
            headerContainer.Controls.Add(pictureBoxLogo);
            headerContainer.Location = new Point(-3, 24);
            headerContainer.Margin = new Padding(3, 2, 3, 2);
            headerContainer.Name = "headerContainer";
            headerContainer.Size = new Size(1003, 60);
            headerContainer.TabIndex = 5;
            headerContainer.Paint += headerContainer_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(168, 136, 181);
            label1.Font = new Font("Pixelify Sans", 34F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(83, 54, 89);
            label1.Location = new Point(350, 4);
            label1.Name = "label1";
            label1.Size = new Size(256, 55);
            label1.TabIndex = 0;
            label1.Text = "Nonogram";
            label1.Click += label1_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.White;
            pictureBoxLogo.Cursor = Cursors.Hand;
            pictureBoxLogo.Image = Properties.Resources.logo3;
            pictureBoxLogo.Location = new Point(2, -1);
            pictureBoxLogo.Margin = new Padding(2);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(110, 61);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 

            // livesPanel
            // 
            livesPanel.BorderStyle = BorderStyle.FixedSingle;
            livesPanel.Location = new Point(669, 154);
            livesPanel.Margin = new Padding(3, 2, 3, 2);
            livesPanel.Name = "livesPanel";
            livesPanel.Padding = new Padding(4, 2, 4, 2);
            livesPanel.Size = new Size(240, 35);
            livesPanel.TabIndex = 9;
            // 
            // crossOptionContainer
            // 
            crossOptionContainer.BorderStyle = BorderStyle.FixedSingle;
            crossOptionContainer.Controls.Add(crossOption);
            crossOptionContainer.Location = new Point(814, 236);
            crossOptionContainer.Margin = new Padding(3, 2, 3, 2);
            crossOptionContainer.Name = "crossOptionContainer";
            crossOptionContainer.Size = new Size(96, 61);
            crossOptionContainer.TabIndex = 11;
            // 
            // crossOption
            // 
            crossOption.BackgroundImage = Properties.Resources.close;
            crossOption.BackgroundImageLayout = ImageLayout.Zoom;
            crossOption.Location = new Point(23, 11);
            crossOption.Margin = new Padding(3, 2, 3, 2);
            crossOption.Name = "crossOption";
            crossOption.Size = new Size(50, 39);
            crossOption.TabIndex = 0;
            // 
            // fillOptionContainer
            // 
            fillOptionContainer.BorderStyle = BorderStyle.FixedSingle;
            fillOptionContainer.Controls.Add(fillOption);
            fillOptionContainer.Location = new Point(677, 236);
            fillOptionContainer.Margin = new Padding(3, 2, 3, 2);
            fillOptionContainer.Name = "fillOptionContainer";
            fillOptionContainer.Size = new Size(96, 61);
            fillOptionContainer.TabIndex = 12;
            // 
            // fillOption
            // 
            fillOption.BackColor = Color.FromArgb(179, 143, 189);
            fillOption.BackgroundImageLayout = ImageLayout.Zoom;

            fillOption.Location = new Point(24, 15);
            fillOption.Name = "fillOption";
            fillOption.Size = new Size(50, 39);
            fillOption.TabIndex = 0;
            // 
            // animalPanel
            // 
            animalPanel.Image = Properties.Resources.white_with_ball_8fps4;
            animalPanel.Location = new Point(669, 422);
            animalPanel.Margin = new Padding(3, 2, 3, 2);
            animalPanel.Name = "animalPanel";
            animalPanel.Size = new Size(52, 45);
            animalPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            animalPanel.TabIndex = 13;
            animalPanel.TabStop = false;
            animalPanel.Click += animalPanel_Click;
            animalPanel.MouseHover += animalPanel_MouseHover;
            // 
            // imageChangeTimer
            // 
            imageChangeTimer.Enabled = true;
            imageChangeTimer.Interval = 10000;
            imageChangeTimer.Tick += imageChangeTimer_Tick;
            // 
            // platform
            // 
            platform.BorderStyle = BorderStyle.FixedSingle;
            platform.Location = new Point(669, 466);
            platform.Margin = new Padding(0);
            platform.Name = "platform";
            platform.Size = new Size(240, 1);
            platform.TabIndex = 14;
            // 
            // walkTimer
            // 
            walkTimer.Enabled = true;
            walkTimer.Interval = 150;
            walkTimer.Tick += timer1_Tick;
            // 
            // rowCluesPanel
            // 
            rowCluesPanel.BackColor = Color.FromArgb(231, 207, 221);
            rowCluesPanel.Location = new Point(117, 215);
            rowCluesPanel.Margin = new Padding(0);
            rowCluesPanel.Name = "rowCluesPanel";
            rowCluesPanel.Size = new Size(75, 475);
            rowCluesPanel.TabIndex = 15;
            // 
            // colCluesPanel
            // 
            colCluesPanel.BackColor = Color.FromArgb(231, 207, 221);
            colCluesPanel.Location = new Point(192, 141);
            colCluesPanel.Margin = new Padding(0);
            colCluesPanel.Name = "colCluesPanel";
            colCluesPanel.Size = new Size(475, 75);
            colCluesPanel.TabIndex = 16;
            // 
            // gridContainer
            // 
            gridContainer.BackColor = Color.FromArgb(83, 54, 89);
            gridContainer.Location = new Point(192, 215);
            gridContainer.Margin = new Padding(0);
            gridContainer.Name = "gridContainer";
            gridContainer.Size = new Size(475, 475);
            gridContainer.TabIndex = 7;
            gridContainer.Paint += gridContainer_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(231, 207, 221);
            flowLayoutPanel1.Location = new Point(117, 141);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(75, 75);
            flowLayoutPanel1.TabIndex = 17;
            // 
            // Nonogram
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 217, 231);

            ClientSize = new Size(1143, 750);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(gridContainer);
            Controls.Add(colCluesPanel);
            Controls.Add(rowCluesPanel);
            Controls.Add(platform);
            Controls.Add(animalPanel);
            Controls.Add(fillOptionContainer);
            Controls.Add(crossOptionContainer);
            Controls.Add(livesPanel);
            Controls.Add(close);
            Controls.Add(headerContainer);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Nonogram";
            Text = "Nonogram";
            headerContainer.ResumeLayout(false);
            headerContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            crossOptionContainer.ResumeLayout(false);
            fillOptionContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)animalPanel).EndInit();
            ResumeLayout(false);
        }

        private void AnimalPanel_MouseHover(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel close;
        private Panel headerContainer;
        private Label label1;
        private PictureBox pictureBoxLogo;
        private Panel livesPanel;
        private Panel crossOptionContainer;
        private Panel crossOption;
        private Panel fillOptionContainer;
        private Panel fillOption;
        private PictureBox animalPanel;
        private System.Windows.Forms.Timer imageChangeTimer;
        private Panel platform;
        private System.Windows.Forms.Timer walkTimer;
        private FlowLayoutPanel rowCluesPanel;
        private FlowLayoutPanel colCluesPanel;
        private FlowLayoutPanel gridContainer;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}