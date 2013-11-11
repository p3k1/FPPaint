namespace FPPaint.Forms
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rotate90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90RightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate180ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkingAreaPanel = new System.Windows.Forms.Panel();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.Pencil = new System.Windows.Forms.Button();
            this.SetLine = new System.Windows.Forms.Button();
            this.SetEllipse = new System.Windows.Forms.Button();
            this.SetCircle = new System.Windows.Forms.Button();
            this.SetRectangle = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.ToolsAndColors = new System.Windows.Forms.Panel();
            this.SetRubber = new System.Windows.Forms.Button();
            this.SetFill = new System.Windows.Forms.Button();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.Size = new System.Windows.Forms.NumericUpDown();
            this.PrimaryColor = new System.Windows.Forms.Button();
            this.SecondaryColor = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.WorkingAreaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.ToolsAndColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Size)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1206, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator1,
            this.rotate90ToolStripMenuItem,
            this.rotate90RightToolStripMenuItem,
            this.rotate180ToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // rotate90ToolStripMenuItem
            // 
            this.rotate90ToolStripMenuItem.Name = "rotate90ToolStripMenuItem";
            this.rotate90ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.rotate90ToolStripMenuItem.Text = "Rotate 90° left";
            this.rotate90ToolStripMenuItem.Click += new System.EventHandler(this.rotate90ToolStripMenuItem_Click);
            // 
            // rotate90RightToolStripMenuItem
            // 
            this.rotate90RightToolStripMenuItem.Name = "rotate90RightToolStripMenuItem";
            this.rotate90RightToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.rotate90RightToolStripMenuItem.Text = "Rotate 90° right";
            this.rotate90RightToolStripMenuItem.Click += new System.EventHandler(this.rotate90RightToolStripMenuItem_Click);
            // 
            // rotate180ToolStripMenuItem
            // 
            this.rotate180ToolStripMenuItem.Name = "rotate180ToolStripMenuItem";
            this.rotate180ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.rotate180ToolStripMenuItem.Text = "Rotate 180°";
            this.rotate180ToolStripMenuItem.Click += new System.EventHandler(this.rotate180ToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // WorkingAreaPanel
            // 
            this.WorkingAreaPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkingAreaPanel.AutoScroll = true;
            this.WorkingAreaPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.WorkingAreaPanel.Controls.Add(this.Picture);
            this.WorkingAreaPanel.Location = new System.Drawing.Point(114, 24);
            this.WorkingAreaPanel.Name = "WorkingAreaPanel";
            this.WorkingAreaPanel.Size = new System.Drawing.Size(1092, 663);
            this.WorkingAreaPanel.TabIndex = 1;
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.Color.White;
            this.Picture.Location = new System.Drawing.Point(4, 4);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(1, 1);
            this.Picture.TabIndex = 0;
            this.Picture.TabStop = false;
            this.Picture.Click += new System.EventHandler(this.Picture_Click);
            this.Picture.Paint += new System.Windows.Forms.PaintEventHandler(this.Picture_Paint);
            this.Picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseDown);
            this.Picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseMove);
            this.Picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseUp);
            // 
            // Pencil
            // 
            this.Pencil.Image = ((System.Drawing.Image)(resources.GetObject("Pencil.Image")));
            this.Pencil.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Pencil.Location = new System.Drawing.Point(11, 15);
            this.Pencil.Name = "Pencil";
            this.Pencil.Size = new System.Drawing.Size(45, 45);
            this.Pencil.TabIndex = 0;
            this.Pencil.UseVisualStyleBackColor = true;
            this.Pencil.Click += new System.EventHandler(this.Pencil_Click);
            // 
            // SetLine
            // 
            this.SetLine.Image = ((System.Drawing.Image)(resources.GetObject("SetLine.Image")));
            this.SetLine.Location = new System.Drawing.Point(62, 15);
            this.SetLine.Name = "SetLine";
            this.SetLine.Size = new System.Drawing.Size(45, 45);
            this.SetLine.TabIndex = 3;
            this.SetLine.UseVisualStyleBackColor = true;
            this.SetLine.Click += new System.EventHandler(this.SetLine_Click);
            // 
            // SetEllipse
            // 
            this.SetEllipse.Image = ((System.Drawing.Image)(resources.GetObject("SetEllipse.Image")));
            this.SetEllipse.Location = new System.Drawing.Point(62, 66);
            this.SetEllipse.Margin = new System.Windows.Forms.Padding(0);
            this.SetEllipse.Name = "SetEllipse";
            this.SetEllipse.Size = new System.Drawing.Size(45, 45);
            this.SetEllipse.TabIndex = 5;
            this.SetEllipse.UseVisualStyleBackColor = true;
            this.SetEllipse.Click += new System.EventHandler(this.button3_Click);
            // 
            // SetCircle
            // 
            this.SetCircle.Image = ((System.Drawing.Image)(resources.GetObject("SetCircle.Image")));
            this.SetCircle.Location = new System.Drawing.Point(11, 66);
            this.SetCircle.Name = "SetCircle";
            this.SetCircle.Size = new System.Drawing.Size(45, 45);
            this.SetCircle.TabIndex = 4;
            this.SetCircle.UseVisualStyleBackColor = true;
            // 
            // SetRectangle
            // 
            this.SetRectangle.Image = ((System.Drawing.Image)(resources.GetObject("SetRectangle.Image")));
            this.SetRectangle.Location = new System.Drawing.Point(62, 117);
            this.SetRectangle.Name = "SetRectangle";
            this.SetRectangle.Size = new System.Drawing.Size(45, 45);
            this.SetRectangle.TabIndex = 7;
            this.SetRectangle.UseVisualStyleBackColor = true;
            this.SetRectangle.Click += new System.EventHandler(this.SetRectangle_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(11, 117);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(45, 45);
            this.button6.TabIndex = 6;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // ToolsAndColors
            // 
            this.ToolsAndColors.Controls.Add(this.SetRubber);
            this.ToolsAndColors.Controls.Add(this.SetFill);
            this.ToolsAndColors.Controls.Add(this.SizeLabel);
            this.ToolsAndColors.Controls.Add(this.Size);
            this.ToolsAndColors.Controls.Add(this.PrimaryColor);
            this.ToolsAndColors.Controls.Add(this.SecondaryColor);
            this.ToolsAndColors.Controls.Add(this.SetRectangle);
            this.ToolsAndColors.Controls.Add(this.button6);
            this.ToolsAndColors.Controls.Add(this.SetEllipse);
            this.ToolsAndColors.Controls.Add(this.SetCircle);
            this.ToolsAndColors.Controls.Add(this.SetLine);
            this.ToolsAndColors.Controls.Add(this.Pencil);
            this.ToolsAndColors.Location = new System.Drawing.Point(1, 24);
            this.ToolsAndColors.Name = "ToolsAndColors";
            this.ToolsAndColors.Size = new System.Drawing.Size(114, 663);
            this.ToolsAndColors.TabIndex = 8;
            // 
            // SetRubber
            // 
            this.SetRubber.Image = ((System.Drawing.Image)(resources.GetObject("SetRubber.Image")));
            this.SetRubber.Location = new System.Drawing.Point(61, 168);
            this.SetRubber.Name = "SetRubber";
            this.SetRubber.Size = new System.Drawing.Size(45, 45);
            this.SetRubber.TabIndex = 15;
            this.SetRubber.UseVisualStyleBackColor = true;
            this.SetRubber.Click += new System.EventHandler(this.SetRubber_Click);
            // 
            // SetFill
            // 
            this.SetFill.Image = ((System.Drawing.Image)(resources.GetObject("SetFill.Image")));
            this.SetFill.Location = new System.Drawing.Point(10, 168);
            this.SetFill.Name = "SetFill";
            this.SetFill.Size = new System.Drawing.Size(45, 45);
            this.SetFill.TabIndex = 14;
            this.SetFill.UseVisualStyleBackColor = true;
            this.SetFill.Click += new System.EventHandler(this.SetFill_Click);
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(14, 234);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(27, 13);
            this.SizeLabel.TabIndex = 13;
            this.SizeLabel.Text = "Size";
            // 
            // Size
            // 
            this.Size.Location = new System.Drawing.Point(62, 232);
            this.Size.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(44, 20);
            this.Size.TabIndex = 12;
            this.Size.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // PrimaryColor
            // 
            this.PrimaryColor.BackColor = System.Drawing.Color.Black;
            this.PrimaryColor.CausesValidation = false;
            this.PrimaryColor.Location = new System.Drawing.Point(17, 590);
            this.PrimaryColor.Name = "PrimaryColor";
            this.PrimaryColor.Size = new System.Drawing.Size(43, 43);
            this.PrimaryColor.TabIndex = 10;
            this.PrimaryColor.UseVisualStyleBackColor = false;
            this.PrimaryColor.Click += new System.EventHandler(this.PrimaryColor_Click);
            // 
            // SecondaryColor
            // 
            this.SecondaryColor.BackColor = System.Drawing.Color.White;
            this.SecondaryColor.Location = new System.Drawing.Point(46, 616);
            this.SecondaryColor.Name = "SecondaryColor";
            this.SecondaryColor.Size = new System.Drawing.Size(43, 43);
            this.SecondaryColor.TabIndex = 11;
            this.SecondaryColor.UseVisualStyleBackColor = false;
            this.SecondaryColor.Click += new System.EventHandler(this.SecondaryColor_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1206, 687);
            this.Controls.Add(this.ToolsAndColors);
            this.Controls.Add(this.WorkingAreaPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "FP Paint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResizeEnd += new System.EventHandler(this.MainWindow_ResizeEnd);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.WorkingAreaPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ToolsAndColors.ResumeLayout(false);
            this.ToolsAndColors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Size)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
     
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel WorkingAreaPanel;
        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.Button Pencil;
        private System.Windows.Forms.Button SetLine;
        private System.Windows.Forms.Button SetEllipse;
        private System.Windows.Forms.Button SetCircle;
        private System.Windows.Forms.Button SetRectangle;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel ToolsAndColors;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.NumericUpDown Size;
        private System.Windows.Forms.Button PrimaryColor;
        private System.Windows.Forms.Button SecondaryColor;
        private System.Windows.Forms.Button SetRubber;
        private System.Windows.Forms.Button SetFill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem rotate90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate90RightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate180ToolStripMenuItem;
    }
}

