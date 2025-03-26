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
            headerContainer = new Panel();
            pictureBoxLogo = new PictureBox();
            headerPanel = new Panel();
            labelDesign = new Label();
            close = new Panel();
            gridContainer = new FlowLayoutPanel();
            palettePanel = new Panel();
            Eraser = new Panel();
            Lock = new Panel();
            Save = new Panel();
            headerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            headerPanel.SuspendLayout();
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
            headerPanel.Controls.Add(labelDesign);
            headerPanel.Location = new Point(132, 6);
            headerPanel.Margin = new Padding(2);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1811, 69);
            headerPanel.TabIndex = 1;
            // 
            // labelDesign
            // 
            labelDesign.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelDesign.AutoEllipsis = true;
            labelDesign.AutoSize = true;
            labelDesign.Font = new Font("Pixelify Sans", 34F, FontStyle.Bold);
            labelDesign.ForeColor = Color.FromArgb(168, 136, 181);
            labelDesign.Location = new Point(203, -5);
            labelDesign.Margin = new Padding(2, 0, 2, 0);
            labelDesign.Name = "labelDesign";
            labelDesign.Size = new Size(479, 69);
            labelDesign.TabIndex = 0;
            labelDesign.Text = "Create a Design";
            labelDesign.TextAlign = ContentAlignment.MiddleCenter;
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
            gridContainer.BackColor = Color.FromArgb(218, 186, 231);
            gridContainer.Location = new Point(320, 162);
            gridContainer.Margin = new Padding(0);
            gridContainer.Name = "gridContainer";
            gridContainer.Size = new Size(500, 500);
            gridContainer.TabIndex = 5;
            gridContainer.Paint += gridContainer_Paint;
            // 
            // palettePanel
            // 
            palettePanel.Location = new Point(233, 174);
            palettePanel.Name = "palettePanel";
            palettePanel.Size = new Size(49, 469);
            palettePanel.TabIndex = 6;
            // 
            // Eraser
            // 
            Eraser.Location = new Point(856, 225);
            Eraser.Name = "Eraser";
            Eraser.Size = new Size(186, 66);
            Eraser.TabIndex = 7;
            Eraser.Paint += Eraser_Paint;
            // 
            // Lock
            // 
            Lock.Location = new Point(856, 346);
            Lock.Name = "Lock";
            Lock.Size = new Size(186, 66);
            Lock.TabIndex = 8;
            // 
            // Save
            // 
            Save.Location = new Point(856, 457);
            Save.Name = "Save";
            Save.Size = new Size(186, 66);
            Save.TabIndex = 9;
            // 
            // CreateDesign
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(Save);
            Controls.Add(Lock);
            Controls.Add(Eraser);
            Controls.Add(palettePanel);
            Controls.Add(gridContainer);
            Controls.Add(close);
            Controls.Add(headerContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CreateDesign";
            Text = "CreateDesign";
            Load += CreateDesign_Load;
            headerContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
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
        private Label labelDesign;
        private Panel close;
        private FlowLayoutPanel gridContainer;
        private Panel palettePanel;
        private Panel Eraser;
        private Panel Lock;
        private Panel Save;
    }
}