namespace FPPaint.Forms
{
    partial class NewItemForm
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
            this.Width = new System.Windows.Forms.NumericUpDown();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.Height = new System.Windows.Forms.NumericUpDown();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Height)).BeginInit();
            this.SuspendLayout();
            // 
            // Width
            // 
            this.Width.Location = new System.Drawing.Point(101, 61);
            this.Width.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.Width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(75, 20);
            this.Width.TabIndex = 11;
            this.Width.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(44, 61);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(35, 13);
            this.WidthLabel.TabIndex = 10;
            this.WidthLabel.Text = "Width";
            // 
            // Height
            // 
            this.Height.Location = new System.Drawing.Point(101, 23);
            this.Height.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.Height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Height.Name = "Height";
            this.Height.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Height.Size = new System.Drawing.Size(75, 20);
            this.Height.TabIndex = 9;
            this.Height.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(41, 25);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(38, 13);
            this.HeightLabel.TabIndex = 8;
            this.HeightLabel.Text = "Height";
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(110, 144);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 7;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(29, 144);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // NewItemForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(212, 187);
            this.ControlBox = false;
            this.Controls.Add(this.Width);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.Height);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(228, 226);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(228, 226);
            this.Name = "NewItemForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New File";
            this.Load += new System.EventHandler(this.NewItemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Height)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Width;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.NumericUpDown Height;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}