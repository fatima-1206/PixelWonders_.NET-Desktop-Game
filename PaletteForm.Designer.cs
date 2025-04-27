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
            header = new Panel();
            label1 = new Label();
            addButton = new Panel();
            panel3 = new Panel();
            panel1 = new Panel();
            done = new Panel();
            panel4 = new Panel();
            promptLabel = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            colorDialog = new ColorDialog();
            button4 = new Button();
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
            flowLayoutPanel1.Location = new Point(0, 195);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10, 14, 10, 4);
            flowLayoutPanel1.Size = new Size(1716, 1428);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(addButton);
            panel2.Controls.Add(header);
            panel2.Location = new Point(14, 36);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1701, 90);
            panel2.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(239, 182, 200);
            pictureBox2.Image = Properties.Resources.logo3;
            pictureBox2.Location = new Point(40, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(165, 81);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // header
            // 
            header.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            header.Controls.Add(label1);
            header.Location = new Point(174, 6);
            header.Name = "header";
            header.Size = new Size(1376, 78);
            header.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoEllipsis = true;
            label1.AutoSize = true;
            label1.Font = new Font("Pixelify Sans", 34F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(168, 136, 181);
            label1.Location = new Point(267, -6);
            label1.Name = "label1";
            label1.Size = new Size(526, 83);
            label1.TabIndex = 0;
            label1.Text = "Color Palettes";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addButton.BackgroundImage = Properties.Resources.add1;
            addButton.BackgroundImageLayout = ImageLayout.Zoom;
            addButton.Cursor = Cursors.Hand;
            addButton.Location = new Point(1405, 0);
            addButton.Name = "addButton";
            addButton.Padding = new Padding(20, 16, 20, 16);
            addButton.Size = new Size(142, 81);
            addButton.TabIndex = 2;
            addButton.Tag = "";
            addButton.Click += addButton_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel3.AutoSize = true;
            panel3.BackgroundImageLayout = ImageLayout.Zoom;
            panel3.Location = new Point(300, 28);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1035, 56);
            panel3.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(done);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 822);
            panel1.Margin = new Padding(27, 4, 6, 9);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(6, 4, 6, 4);
            panel1.Size = new Size(1664, 123);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // done
            // 
            done.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            done.BackgroundImage = Properties.Resources.play__2_;
            done.BackgroundImageLayout = ImageLayout.Zoom;
            done.Cursor = Cursors.Hand;
            done.Location = new Point(1472, 0);
            done.Name = "done";
            done.Padding = new Padding(20, 16, 20, 16);
            done.Size = new Size(154, 96);
            done.TabIndex = 3;
            done.Tag = "";
            done.Click += DonePanel_Click;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Location = new Point(48, 48);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(6, 4, 6, 4);
            panel4.Size = new Size(171, 36);
            panel4.TabIndex = 1;
            // 
            // promptLabel
            // 
            promptLabel.AutoSize = true;
            promptLabel.Font = new Font("Pixelify Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            promptLabel.Location = new Point(8, 152);
            promptLabel.Margin = new Padding(10, 4, 6, 4);
            promptLabel.Name = "promptLabel";
            promptLabel.Padding = new Padding(6, 4, 6, 4);
            promptLabel.Size = new Size(473, 37);
            promptLabel.TabIndex = 0;
            promptLabel.Text = "Select a color palette for your design!";
            promptLabel.UseWaitCursor = true;
            // 
            // button4
            // 
            button4.BackColor = Color.Thistle;
            button4.Font = new Font("Pixelify Sans", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(1569, -8);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(95, 42);
            button4.TabIndex = 19;
            button4.Text = "X";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // PaletteForm
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1664, 945);
            Controls.Add(button4);
            Controls.Add(promptLabel);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
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
        private Panel done;
        private ColorDialog colorDialog;
        private Button button4;
    }
}