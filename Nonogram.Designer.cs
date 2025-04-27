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

            // 
            // headerContainer
            // 
            headerContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerContainer.BackColor = Color.FromArgb(168, 136, 181);
            headerContainer.BorderStyle = BorderStyle.FixedSingle;
            headerContainer.Controls.Add(label1);
            headerContainer.Controls.Add(pictureBoxLogo);

            headerContainer.Location = new Point(-2, 38);
            headerContainer.Margin = new Padding(2);
            headerContainer.Name = "headerContainer";
            headerContainer.Size = new Size(1717, 96);
            headerContainer.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(168, 136, 181);
            label1.Font = new Font("Pixelify Sans", 34F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(83, 54, 89);

            label1.Location = new Point(661, 11);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(366, 83);
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

            pictureBoxLogo.Size = new Size(151, 97);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // livesPanel
            // 
            livesPanel.BorderStyle = BorderStyle.FixedSingle;

            livesPanel.Location = new Point(1133, 346);
            livesPanel.Margin = new Padding(2);
            livesPanel.Name = "livesPanel";
            livesPanel.Padding = new Padding(6, 2, 6, 2);
            livesPanel.Size = new Size(328, 55);
            livesPanel.TabIndex = 9;
            // 
            // crossOptionContainer
            // 
            crossOptionContainer.BackColor = Color.FromArgb(241, 217, 231);
            crossOptionContainer.BorderStyle = BorderStyle.FixedSingle;
            crossOptionContainer.Controls.Add(crossOption);

            crossOptionContainer.Location = new Point(1331, 478);
            crossOptionContainer.Margin = new Padding(2);
            crossOptionContainer.Name = "crossOptionContainer";
            crossOptionContainer.Size = new Size(132, 97);
            crossOptionContainer.TabIndex = 11;
            crossOptionContainer.Click += crossOption_Click;
            // 
            // crossOption
            // 
            crossOption.BackgroundImage = Properties.Resources.close_1_;
            crossOption.BackgroundImageLayout = ImageLayout.Zoom;

            crossOption.Location = new Point(31, 18);
            crossOption.Margin = new Padding(2);
            crossOption.Name = "crossOption";
            crossOption.Size = new Size(70, 62);
            crossOption.TabIndex = 0;
            crossOption.Click += crossOption_Click;
            // 
            // fillOptionContainer
            // 
            fillOptionContainer.BackColor = Color.FromArgb(240, 230, 236);
            fillOptionContainer.BorderStyle = BorderStyle.FixedSingle;
            fillOptionContainer.Controls.Add(fillOption);

            fillOptionContainer.Location = new Point(1142, 478);
            fillOptionContainer.Margin = new Padding(2);
            fillOptionContainer.Name = "fillOptionContainer";
            fillOptionContainer.Size = new Size(132, 97);
            fillOptionContainer.TabIndex = 12;
            fillOptionContainer.Click += fillOption_Click;
            fillOptionContainer.Paint += fillOptionContainer_Paint;
            // 
            // fillOption
            // 
            fillOption.BackColor = Color.FromArgb(179, 143, 189);
            fillOption.BackgroundImageLayout = ImageLayout.Zoom;

            fillOption.Location = new Point(34, 22);
            fillOption.Margin = new Padding(2, 5, 2, 5);
            fillOption.Name = "fillOption";
            fillOption.Size = new Size(60, 60);
            fillOption.TabIndex = 0;
            fillOption.Click += fillOption_Click;
            // 
            // animalPanel
            // 
            animalPanel.Image = Properties.Resources.white_with_ball_8fps4;

            animalPanel.Location = new Point(1133, 902);
            animalPanel.Margin = new Padding(2);
            animalPanel.Name = "animalPanel";
            animalPanel.Size = new Size(106, 91);
            animalPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            animalPanel.TabIndex = 13;
            animalPanel.TabStop = false;
            animalPanel.Click += animalPanel_Click;
            animalPanel.MouseHover += animalPanel_MouseHover;
            // 
            // imageChangeTimer
            // 
            imageChangeTimer.Enabled = true;
            imageChangeTimer.Interval = 1;
            imageChangeTimer.Tick += imageChangeTimer_Tick;
            // 
            // platform
            // 
            platform.BorderStyle = BorderStyle.FixedSingle;

            platform.Location = new Point(1133, 991);
            platform.Margin = new Padding(0);
            platform.Name = "platform";
            platform.Size = new Size(328, 1);
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

            rowCluesPanel.Location = new Point(173, 346);
            rowCluesPanel.Margin = new Padding(0);
            rowCluesPanel.Name = "rowCluesPanel";
            rowCluesPanel.Size = new Size(90, 648);
            rowCluesPanel.TabIndex = 15;
            // 
            // colCluesPanel
            // 
            colCluesPanel.BackColor = Color.FromArgb(231, 207, 221);

            colCluesPanel.Location = new Point(263, 254);
            colCluesPanel.Margin = new Padding(0);
            colCluesPanel.Name = "colCluesPanel";
            colCluesPanel.Size = new Size(648, 90);
            colCluesPanel.TabIndex = 16;
            // 
            // gridContainer
            // 
            gridContainer.BackColor = Color.FromArgb(83, 54, 89);

            gridContainer.Location = new Point(263, 346);
            gridContainer.Margin = new Padding(0);
            gridContainer.Name = "gridContainer";
            gridContainer.Size = new Size(648, 648);
            gridContainer.TabIndex = 7;
            gridContainer.Paint += gridContainer_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(231, 207, 221);

            flowLayoutPanel1.Location = new Point(173, 254);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(90, 89);
            flowLayoutPanel1.TabIndex = 17;
            // 
            // Nonogram
            // 

            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(241, 217, 231);
            ClientSize = new Size(1715, 1106);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(gridContainer);
            Controls.Add(colCluesPanel);
            Controls.Add(rowCluesPanel);
            Controls.Add(platform);
            Controls.Add(animalPanel);
            Controls.Add(fillOptionContainer);
            Controls.Add(crossOptionContainer);
            Controls.Add(livesPanel);
            Controls.Add(headerContainer);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "Nonogram";
            Text = "Nonogram";
            Load += Nonogram_Load;
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