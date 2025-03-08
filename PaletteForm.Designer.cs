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
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            addButton = new Panel();
            header = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            panel1 = new Panel();
            panel4 = new Panel();
            panel2.SuspendLayout();
            header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Location = new Point(0, 101);
            flowLayoutPanel1.Margin = new Padding(4, 4, 4, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(12, 19, 12, 6);
            flowLayoutPanel1.Size = new Size(1421, 549);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(addButton);
            panel2.Controls.Add(header);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(0, 1);
            panel2.Margin = new Padding(4, 4, 4, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1416, 100);
            panel2.TabIndex = 2;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addButton.BackgroundImageLayout = ImageLayout.Center;
            addButton.Cursor = Cursors.Hand;
            addButton.Location = new Point(1275, 4);
            addButton.Margin = new Padding(4, 4, 4, 4);
            addButton.Name = "addButton";
            addButton.Padding = new Padding(19, 19, 19, 19);
            addButton.Size = new Size(136, 92);
            addButton.TabIndex = 2;
            addButton.Tag = "";
            // 
            // header
            // 
            header.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            header.Controls.Add(label1);
            header.Location = new Point(204, 4);
            header.Margin = new Padding(4, 4, 4, 4);
            header.Name = "header";
            header.Size = new Size(1071, 92);
            header.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoEllipsis = true;
            label1.AutoSize = true;
            label1.Font = new Font("Pixelify Sans", 34F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(168, 136, 181);
            label1.Location = new Point(215, 6);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(526, 83);
            label1.TabIndex = 0;
            label1.Text = "Color Palettes";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = Properties.Resources.WhatsApp_Image_2025_03_07_at_1_43_31_PM;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(4, 4, 4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(196, 100);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.AutoSize = true;
            panel3.BackgroundImageLayout = ImageLayout.Zoom;
            panel3.Location = new Point(256, 39);
            panel3.Margin = new Padding(4, 4, 4, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1155, 45);
            panel3.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 658);
            panel1.Margin = new Padding(6, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(6, 6, 6, 6);
            panel1.Size = new Size(1421, 106);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // panel4
            // 
            panel4.Location = new Point(0, 39);
            panel4.Margin = new Padding(4, 4, 4, 4);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(6, 6, 6, 6);
            panel4.Size = new Size(249, 45);
            panel4.TabIndex = 1;
            // 
            // PaletteForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1421, 764);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "PaletteForm";
            Text = "PaletteForm";
            panel2.ResumeLayout(false);
            header.ResumeLayout(false);
            header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel1;
        private Panel panel4;
        private PictureBox pictureBox1;
        private Panel header;
        private Label label1;
        private Panel addButton;
    }
}