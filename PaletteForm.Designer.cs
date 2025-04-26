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
            done = new Panel();
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

            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Location = new Point(0, 130);
            flowLayoutPanel1.Margin = new Padding(2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(7, 9, 7, 3);
            flowLayoutPanel1.Size = new Size(1144, 952);

            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(addButton);
            panel2.Controls.Add(header);

            panel2.Location = new Point(9, 24);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1134, 60);

            panel2.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.logo3;

            pictureBox2.Location = new Point(2, 4);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(110, 54);

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addButton.BackgroundImage = Properties.Resources.add1;
            addButton.BackgroundImageLayout = ImageLayout.Zoom;
            addButton.Cursor = Cursors.Hand;

            addButton.Location = new Point(1036, 4);
            addButton.Margin = new Padding(2);

            addButton.Name = "addButton";
            addButton.Padding = new Padding(13, 11, 13, 11);
            addButton.Size = new Size(95, 54);
            addButton.TabIndex = 2;
            addButton.Tag = "";
            addButton.Paint += addButton_Paint;
            // 
            // header
            // 
            header.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            header.Controls.Add(label1);

            header.Location = new Point(116, 4);
            header.Margin = new Padding(2);
            header.Name = "header";
            header.Size = new Size(917, 52);

            header.TabIndex = 1;
            header.Paint += header_Paint;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoEllipsis = true;
            label1.AutoSize = true;
            label1.Font = new Font("Pixelify Sans", 34F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(168, 136, 181);
            label1.Location = new Point(178, -4);

            label1.Margin = new Padding(2, 0, 2, 0);

            label1.Name = "label1";
            label1.Size = new Size(368, 55);
            label1.TabIndex = 0;
            label1.Text = "Color Palettes";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel3.AutoSize = true;
            panel3.BackgroundImageLayout = ImageLayout.Zoom;
            panel3.Location = new Point(185, 19);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(690, 22);
            panel3.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Bottom;

            panel1.Location = new Point(0, 691);
            panel1.Margin = new Padding(18, 3, 4, 6);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(4, 3, 4, 3);
            panel1.Size = new Size(1143, 58);

            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Location = new Point(32, 26);

            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(4, 3, 4, 3);
            panel4.Size = new Size(148, 24);

            panel4.TabIndex = 1;
            // 
            // done
            // 
            done.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            done.BackgroundImage = Properties.Resources.play__2_;
            done.BackgroundImageLayout = ImageLayout.Zoom;
            done.Cursor = Cursors.Hand;

            done.Location = new Point(1045, 686);
            done.Margin = new Padding(2);

            done.Name = "done";
            done.Padding = new Padding(13, 11, 13, 11);
            done.Size = new Size(74, 46);
            done.TabIndex = 3;
            done.Tag = "";
            done.Click += DonePanel_Click;
            done.Paint += done_Paint;
            // 
            // promptLabel
            // 
            promptLabel.AutoSize = true;
            promptLabel.Font = new Font("Pixelify Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);

            promptLabel.Location = new Point(5, 101);

            promptLabel.Margin = new Padding(7, 3, 4, 3);
            promptLabel.Name = "promptLabel";
            promptLabel.Padding = new Padding(4, 3, 4, 3);
            promptLabel.Size = new Size(313, 26);
            promptLabel.TabIndex = 0;
            promptLabel.Text = "Select a color palette for your design!";
            promptLabel.UseWaitCursor = true;
            promptLabel.Click += promptLabel_Click;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel5.BackgroundImage = Properties.Resources.cross1;
            panel5.BackgroundImageLayout = ImageLayout.None;
            panel5.Cursor = Cursors.Hand;

            panel5.Location = new Point(1098, 0);
            panel5.Margin = new Padding(2);
            panel5.Name = "panel5";
            panel5.Size = new Size(46, 26);

            panel5.TabIndex = 3;
            panel5.Click += panel5_Click;
            panel5.Paint += panel5_Paint;
            // 
            // PaletteForm
            // 

            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1143, 749);

            Controls.Add(done);
            Controls.Add(panel5);
            Controls.Add(promptLabel);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(1);
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
        private Panel done;
    }
}