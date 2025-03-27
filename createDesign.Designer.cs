namespace PixelWonders
{
    partial class CreateDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDesign));
            headerContainer = new Panel();
            pictureBoxLogo = new PictureBox();
            headerPanel = new Panel();
            label1 = new Label();
            close = new Panel();
            gridContainer = new FlowLayoutPanel();
            palettePanel = new Panel();
            eraserButton = new PictureBox();
            saveButton = new PictureBox();
            LockButton = new PictureBox();
            headerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)eraserButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LockButton).BeginInit();
            SuspendLayout();
            // 
            // headerContainer
            // 
            headerContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerContainer.Controls.Add(pictureBoxLogo);
            headerContainer.Controls.Add(headerPanel);
            headerContainer.Location = new Point(10, 32);
            headerContainer.Name = "headerContainer";
            headerContainer.Size = new Size(1126, 80);
            headerContainer.TabIndex = 3;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Cursor = Cursors.Hand;
            pictureBoxLogo.Image = Properties.Resources.logo3;
            pictureBoxLogo.Location = new Point(2, 6);
            pictureBoxLogo.Margin = new Padding(2);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(126, 72);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // headerPanel
            // 
            headerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel.Controls.Add(label1);
            headerPanel.Location = new Point(132, 6);
            headerPanel.Margin = new Padding(2);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1811, 69);
            headerPanel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Pixelify Sans", 34F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(168, 136, 181);
            label1.Location = new Point(203, -5);
            label1.Name = "label1";
            label1.Size = new Size(479, 69);
            label1.TabIndex = 0;
            label1.Text = "Create a Design";
            // 
            // close
            // 
            close.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            close.BackgroundImage = Properties.Resources.cross1;
            close.BackgroundImageLayout = ImageLayout.None;
            close.Cursor = Cursors.Hand;
            close.Location = new Point(1091, 0);
            close.Margin = new Padding(2);
            close.Name = "close";
            close.Size = new Size(52, 34);
            close.TabIndex = 4;
            close.Click += close_Click;
            close.Paint += close_Paint;
            // 
            // gridContainer
            // 
            gridContainer.BackColor = Color.FromArgb(83, 54, 89);
            gridContainer.Location = new Point(320, 162);
            gridContainer.Margin = new Padding(0);
            gridContainer.Name = "gridContainer";
            gridContainer.Size = new Size(500, 500);
            gridContainer.TabIndex = 5;
            // 
            // palettePanel
            // 
            palettePanel.Location = new Point(233, 174);
            palettePanel.Name = "palettePanel";
            palettePanel.Size = new Size(49, 469);
            palettePanel.TabIndex = 6;
            palettePanel.Paint += palettePanel_Paint;
            // 
            // eraserButton
            // 
            eraserButton.BackColor = Color.FromArgb(241, 217, 231);
            eraserButton.BorderStyle = BorderStyle.FixedSingle;
            eraserButton.Cursor = Cursors.Hand;
            eraserButton.ErrorImage = Properties.Resources.error;
            eraserButton.Image = Properties.Resources.eraser_1_;
            eraserButton.Location = new Point(884, 223);
            eraserButton.Name = "eraserButton";
            eraserButton.Padding = new Padding(5);
            eraserButton.Size = new Size(125, 62);
            eraserButton.SizeMode = PictureBoxSizeMode.Zoom;
            eraserButton.TabIndex = 8;
            eraserButton.TabStop = false;
            eraserButton.Click += Eraser_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(241, 217, 231);
            saveButton.BorderStyle = BorderStyle.FixedSingle;
            saveButton.Cursor = Cursors.Hand;
            saveButton.ErrorImage = Properties.Resources.error;
            saveButton.Image = Properties.Resources.diskette1;
            saveButton.Location = new Point(884, 468);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(125, 62);
            saveButton.SizeMode = PictureBoxSizeMode.Zoom;
            saveButton.TabIndex = 9;
            saveButton.TabStop = false;
            saveButton.Click += saveButton_Click;
            // 
            // LockButton
            // 
            LockButton.BackColor = Color.FromArgb(241, 217, 231);
            LockButton.BorderStyle = BorderStyle.FixedSingle;
            LockButton.Cursor = Cursors.Hand;
            LockButton.ErrorImage = Properties.Resources.error;
            LockButton.Image = Properties.Resources.unlocked;
            LockButton.Location = new Point(884, 344);
            LockButton.Name = "LockButton";
            LockButton.Size = new Size(125, 62);
            LockButton.SizeMode = PictureBoxSizeMode.Zoom;
            LockButton.TabIndex = 10;
            LockButton.TabStop = false;
            // 
            // CreateDesign
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(LockButton);
            Controls.Add(saveButton);
            Controls.Add(eraserButton);
            Controls.Add(palettePanel);
            Controls.Add(gridContainer);
            Controls.Add(close);
            Controls.Add(headerContainer);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateDesign";
            Text = "CreateDesign";
            Load += CreateDesign_Load;
            headerContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)eraserButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)LockButton).EndInit();
            ResumeLayout(false);
        }

        private void Panel5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel headerContainer;
        private PictureBox pictureBoxLogo;
        private Panel headerPanel;
        private Panel close;
        private FlowLayoutPanel gridContainer;
        private Panel palettePanel;
        private Panel Lock;
        private Panel Save;
        private Label label1;
        private PictureBox eraserButton;
        private PictureBox saveButton;
        private PictureBox LockButton;
        //private PictureBox eraserPic;
        //private PictureBox lockPic;
        //private PictureBox savePicBox;
    }
}