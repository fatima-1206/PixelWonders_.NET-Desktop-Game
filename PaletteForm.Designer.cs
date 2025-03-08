using System.Security.Cryptography;

namespace PixelWonders
{
    partial class PaletteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaletteForm));
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            addButton = new Panel();
            header = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            panel1 = new Panel();
            panel4 = new Panel();
            promptLabel = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel5 = new Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            header.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Location = new Point(0, 163);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10, 15, 10, 5);
            flowLayoutPanel1.Size = new Size(1125, 483);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(addButton);
            panel2.Controls.Add(header);
            panel2.Location = new Point(4, 33);
            panel2.Name = "panel2";
            panel2.Size = new Size(1121, 80);
            panel2.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.logo2;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(157, 77);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addButton.BackgroundImage = Properties.Resources.add;
            addButton.BackgroundImageLayout = ImageLayout.Center;
            addButton.Cursor = Cursors.Hand;
            addButton.Location = new Point(1008, 3);
            addButton.Name = "addButton";
            addButton.Padding = new Padding(15);
            addButton.Size = new Size(109, 74);
            addButton.TabIndex = 2;
            addButton.Tag = "";
            // 
            // header
            // 
            header.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            header.Controls.Add(label1);
            header.Location = new Point(205, 3);
            header.Name = "header";
            header.Size = new Size(803, 74);
            header.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoEllipsis = true;
            label1.AutoSize = true;
            label1.Font = new Font("Pixelify Sans", 34F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(168, 136, 181);
            label1.Location = new Point(140, 0);
            label1.Name = "label1";
            label1.Size = new Size(445, 69);
            label1.TabIndex = 0;
            label1.Text = "Color Palettes";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.AutoSize = true;
            panel3.BackgroundImageLayout = ImageLayout.Zoom;
            panel3.Location = new Point(205, 31);
            panel3.Name = "panel3";
            panel3.Size = new Size(912, 36);
            panel3.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 652);
            panel1.Margin = new Padding(25, 5, 5, 10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(1125, 98);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // panel4
            // 
            panel4.Location = new Point(8, 31);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5);
            panel4.Size = new Size(191, 36);
            panel4.TabIndex = 1;
            // 
            // promptLabel
            // 
            promptLabel.AutoSize = true;
            promptLabel.Font = new Font("Pixelify Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            promptLabel.Location = new Point(8, 121);
            promptLabel.Margin = new Padding(10, 5, 5, 5);
            promptLabel.Name = "promptLabel";
            promptLabel.Padding = new Padding(5);
            promptLabel.Size = new Size(402, 34);
            promptLabel.TabIndex = 0;
            promptLabel.Text = "Select a color palette for your design!";
            promptLabel.UseWaitCursor = true;
            promptLabel.Click += label2_Click;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel5.BackgroundImage = Properties.Resources.cross;
            panel5.BackgroundImageLayout = ImageLayout.None;
            panel5.Cursor = Cursors.Hand;
            panel5.Location = new Point(1073, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(52, 34);
            panel5.TabIndex = 3;
            panel5.Click += panel5_Click;
            panel5.Paint += panel5_Paint;
            // 
            // PaletteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1125, 750);
            Controls.Add(panel5);
            Controls.Add(promptLabel);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PaletteForm";
            Text = "PaletteForm";
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            header.ResumeLayout(false);
            header.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel1;
        private Panel panel4;
        private Panel header;
        private Label label1;
        private Panel addButton;
        private Label promptLabel;
        private PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panel5;
    }
}