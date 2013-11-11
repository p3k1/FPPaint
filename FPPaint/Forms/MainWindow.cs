using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FPPaint.Classes;
using FPPaint.Classes.Tools;

namespace FPPaint.Forms
{
    public partial class MainWindow : Form
    {
        public PaintingManager PaintingManager = PaintingManager.GetInstance(new File(""), new Page(800, 600), new Pencil(Color.Black, Color.White));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            int width = 800;
            int height = 600;
            Picture.Width = width;
            Picture.Height = height;
            PaintingManager.page = new Page(width, height);
            Picture.Image = PaintingManager.page.Picture;
            using (Graphics g = Graphics.FromImage(PaintingManager.page.Picture))
                g.Clear(Color.White);
            Picture.Refresh();
        }

        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PaintingManager.file.IsModified1)
            {
                DialogResult result = MessageBox.Show("File was changed. Do you want to save it?", "Question", MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.Yes)
                    if (!PaintingManager.file.SaveFile(PaintingManager.page.Picture))
                        return;

            }
            this.Close();
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PaintingManager.file.IsModified1)
            {
                DialogResult result = MessageBox.Show("File was changed. Do you want to save it?", "Question",
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.Yes)
                    PaintingManager.file.SaveFile(PaintingManager.page.Picture);
            }

            var newItem = new NewItemForm();
            if (newItem.ShowDialog() == DialogResult.OK)
            {
                Picture.Width = newItem.width;
                Picture.Height = newItem.height;
                PaintingManager.page = new Page(newItem.width, newItem.height);
                Picture.Image = PaintingManager.page.Picture;
                using (Graphics g = Graphics.FromImage(PaintingManager.page.Picture))
                    g.Clear(Color.White);
                Picture.Refresh();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var OpenFile = new OpenFileDialog())
            {
                OpenFile.Multiselect = false;
                OpenFile.Filter = "Bitmaps (*.BMP)|*.bmp";
                if (OpenFile.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(OpenFile.FileName))
                {
                    PaintingManager.CreateNewPicture(OpenFile.FileName);
                    Picture.Height = PaintingManager.page.Picture.Height;
                    Picture.Width = PaintingManager.page.Picture.Width;
                    Picture.Image = PaintingManager.page.Picture;
                    PaintingManager.file.Path1 = OpenFile.FileName;
                    Picture.Refresh();
                }
            }
        }

        private void PrimaryColor_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                this.PaintingManager.currentTool.PrimaryColor = c.Color;
                PrimaryColor.BackColor = c.Color;
            }
        }

        private void SecondaryColor_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                this.PaintingManager.currentTool.SecondaryColor = c.Color;
                SecondaryColor.BackColor = c.Color;
            }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if ((PaintingManager.currentTool is TwoPointTool) && !PaintingManager.currentTool.InUse)
                {
                    ((TwoPointTool)PaintingManager.currentTool).StartPainting(e.Location);
                    PaintingManager.file.IsModified1 = true;
                }
                if (PaintingManager.currentTool is InstantTool)
                {
                    ((InstantTool)PaintingManager.currentTool).Paint(PaintingManager.page.Picture, e.Location.X, e.Location.Y, PaintingManager.currentTool.PrimaryColor, PaintingManager.page.Picture.GetPixel(e.Location.X, e.Location.Y));
                }
                if (PaintingManager.currentTool is MultiPointTool)
                {
                    ((MultiPointTool)PaintingManager.currentTool).PointsToDraw.Add(e.Location);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            PaintingManager.page.PrepareToPaint();
            try
            {
                if (PaintingManager.currentTool is TwoPointTool)
                {
                    using (Graphics g = Graphics.FromImage(PaintingManager.page.Picture))
                        ((TwoPointTool)PaintingManager.currentTool).Paint(e.Location, g);
                    Picture.Refresh();
                    PaintingManager.file.IsModified1 = true;
                    PaintingManager.currentTool.InUse = false;
                }

                if (PaintingManager.currentTool is InstantTool)
                {
                    ((InstantTool)PaintingManager.currentTool).Paint(PaintingManager.page.Picture, e.Location.X,
                                                                      e.Location.Y,
                                                                      PaintingManager.currentTool.PrimaryColor,
                                                                      PaintingManager.page.Picture.GetPixel(
                                                                          e.Location.X, e.Location.Y));
                    Picture.Invalidate();
                }

                if (PaintingManager.currentTool is MultiPointTool)
                {
                    ((MultiPointTool)PaintingManager.currentTool).PointsToDraw.Clear();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Picture_Paint(object sender, PaintEventArgs e)
        {
            if (PaintingManager.currentTool is TwoPointTool && PaintingManager.currentTool.InUse)
            {
                TwoPointTool tool = PaintingManager.currentTool as TwoPointTool;
                tool.Paint(tool.Temp, e.Graphics);
                ((PictureBox)sender).Invalidate();
                PaintingManager.file.IsModified1 = true;
            }

            if (PaintingManager.currentTool is MultiPointTool)
            {
                using (Graphics g = Graphics.FromImage(PaintingManager.page.Picture))
                {
                    ((MultiPointTool)PaintingManager.currentTool).Paint(g, (int)Size.Value);
                }
            }
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (PaintingManager.currentTool is TwoPointTool && e.Button == MouseButtons.Left)
            {
                ((TwoPointTool) PaintingManager.currentTool).Temp = e.Location;
            }
            if (PaintingManager.currentTool is MultiPointTool && e.Button == MouseButtons.Left)
            {
                ((MultiPointTool)PaintingManager.currentTool).PointsToDraw.Add(e.Location);
                Picture.Invalidate();
            }
            if (PaintingManager.currentTool.InUse && e.Button == MouseButtons.Left)
            {
                Picture.Invalidate();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PaintingManager.page.UndoStackEmpty)
            {
                undoToolStripMenuItem.Enabled = false;
            }
            else
            {
                undoToolStripMenuItem.Enabled = true;
            }

            if (PaintingManager.page.RedoStackEmpty)
            {
                redoToolStripMenuItem.Enabled = false;
            }
            else
            {
                redoToolStripMenuItem.Enabled = true;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.page.Undo();
            this.Picture.Image = PaintingManager.page.Picture;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.page.Redo();
            this.Picture.Image = PaintingManager.page.Picture;
        }

        private void SetLine_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Line(PaintingManager.currentTool.PrimaryColor, PaintingManager.currentTool.SecondaryColor, (int)Size.Value));
            Picture.Cursor = Cursors.Cross;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Ellipse(PaintingManager.currentTool.PrimaryColor, PaintingManager.currentTool.SecondaryColor, (int)Size.Value));
            Picture.Cursor = Cursors.Cross;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.file.SaveFile(PaintingManager.page.Picture);
        }

        private void SetRubber_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Rubber(PaintingManager.currentTool.PrimaryColor, PaintingManager.currentTool.SecondaryColor));
        }

        private void SetFill_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Fill(PaintingManager.currentTool.PrimaryColor, PaintingManager.currentTool.SecondaryColor));
        }

        private void Picture_Click(object sender, EventArgs e)
        {
           
        }

        private void rotate90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tmpWidth = Picture.Width;
            Picture.Width = Picture.Height;
            Picture.Height = tmpWidth;
            PaintingManager.page.Rotate(RotateFlipType.Rotate270FlipNone);
            Picture.Refresh();
        }

        private void SetRectangle_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new FPPaint.Classes.Tools.Rectangle(PaintingManager.currentTool.PrimaryColor, PaintingManager.currentTool.SecondaryColor, (int)Size.Value));
            Picture.Cursor = Cursors.Cross;
        }

        private void Pencil_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Pencil(PaintingManager.currentTool.PrimaryColor, PaintingManager.currentTool.SecondaryColor));
            Picture.Cursor = Cursors.Cross;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void rotate180ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.page.Rotate(RotateFlipType.Rotate180FlipNone);
            Picture.Refresh();
        }

        private void rotate90RightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tmpWidth = Picture.Width;
            Picture.Width = Picture.Height;
            Picture.Height = tmpWidth;
            PaintingManager.page.Rotate(RotateFlipType.Rotate90FlipNone);
            Picture.Refresh();
        }
    }
}
