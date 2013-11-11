using System;
using System.Drawing;
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
            Color[] ColorList = new Color[]{Color.Black, Color.White ,Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Magenta, Color.Gray, Color.CornflowerBlue};

            for (int i = 0; i < ColorList.GetLength(0); i++)
            {
                var ToAdd = new Button();
                ToAdd.BackColor = ColorList[i];
                ToAdd.Size = new Size(20,20);
                ToAdd.Location = new Point(20, 275 + 25*i);
                ToAdd.MouseUp += (sender, args) =>
                                   {
                                       if (((MouseEventArgs)args).Button == MouseButtons.Left)
                                       {
                                           PrimaryColor.BackColor = PaintingManager.CurrentTool.PrimaryColor = ((Button)sender).BackColor;  
                                           return;
                                       }
                                       if (((MouseEventArgs)args).Button == MouseButtons.Right)
                                       {
                                           SecondaryColor.BackColor = PaintingManager.CurrentTool.SecondaryColor = ((Button)sender).BackColor;
                                       }
                                   };
                ToolsAndColors.Controls.Add(ToAdd);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            const int width = 800;
            const int height = 600;
            Picture.Width = width;
            Picture.Height = height;
            PaintingManager.Page = new Page(width, height);
            Picture.Image = PaintingManager.Page.Picture;
            using (Graphics g = Graphics.FromImage(PaintingManager.Page.Picture))
                g.Clear(Color.White);
            Picture.Refresh();
        }

        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PaintingManager.File.IsModified)
            {
                DialogResult result = MessageBox.Show("File was changed. Do you want to save it?", "Question", MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.Yes)
                    if (!PaintingManager.File.SaveFile(PaintingManager.Page.Picture))
                        return;

            }
            Close();
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PaintingManager.File.IsModified)
            {
                DialogResult result = MessageBox.Show("File was changed. Do you want to save it?", "Question",
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.Yes)
                    PaintingManager.File.SaveFile(PaintingManager.Page.Picture);
            }

            var newItem = new NewItemForm();
            if (newItem.ShowDialog() == DialogResult.OK)
            {
                Picture.Width = newItem.width;
                Picture.Height = newItem.height;
                PaintingManager.Page = new Page(newItem.width, newItem.height);
                Picture.Image = PaintingManager.Page.Picture;
                using (Graphics g = Graphics.FromImage(PaintingManager.Page.Picture))
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
                    Picture.Height = PaintingManager.Page.Picture.Height;
                    Picture.Width = PaintingManager.Page.Picture.Width;
                    Picture.Image = PaintingManager.Page.Picture;
                    PaintingManager.File.Path = OpenFile.FileName;
                    Picture.Refresh();
                }
            }
        }

        private void PrimaryColor_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                PaintingManager.CurrentTool.PrimaryColor = c.Color;
                PrimaryColor.BackColor = c.Color;
            }
        }

        private void SecondaryColor_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                PaintingManager.CurrentTool.SecondaryColor = c.Color;
                SecondaryColor.BackColor = c.Color;
            }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if ((PaintingManager.CurrentTool is TwoPointTool) && !PaintingManager.CurrentTool.InUse)
                {
                    ((TwoPointTool)PaintingManager.CurrentTool).StartPainting(e.Location);
                    PaintingManager.File.IsModified = true;
                }
                InstantTool currentTool = PaintingManager.CurrentTool as InstantTool;
                if (currentTool != null)
                {
                    currentTool.Paint(PaintingManager.Page.Picture, e.Location.X, e.Location.Y, PaintingManager.CurrentTool.PrimaryColor, PaintingManager.Page.Picture.GetPixel(e.Location.X, e.Location.Y));
                }
                MultiPointTool multiPointTool = PaintingManager.CurrentTool as MultiPointTool;
                if (multiPointTool != null)
                {
                    multiPointTool.PointsToDraw.Add(e.Location);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            PaintingManager.Page.PrepareToPaint();
            try
            {
                TwoPointTool twoPointTool = PaintingManager.CurrentTool as TwoPointTool;
                if (twoPointTool != null)
                {
                    using (Graphics g = Graphics.FromImage(PaintingManager.Page.Picture))
                        twoPointTool.Paint(e.Location, g);
                    Picture.Refresh();
                    PaintingManager.File.IsModified = true;
                    PaintingManager.CurrentTool.InUse = false;
                }

                InstantTool currentTool = PaintingManager.CurrentTool as InstantTool;
                if (currentTool != null)
                {
                    currentTool.Paint(PaintingManager.Page.Picture, e.Location.X,
                                                                     e.Location.Y,
                                                                     PaintingManager.CurrentTool.PrimaryColor,
                                                                     PaintingManager.Page.Picture.GetPixel(
                                                                         e.Location.X, e.Location.Y));
                    Picture.Invalidate();
                }

                MultiPointTool multiPointTool = PaintingManager.CurrentTool as MultiPointTool;
                if (multiPointTool != null)
                {
                    multiPointTool.PointsToDraw.Clear();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Picture_Paint(object sender, PaintEventArgs e)
        {
            if (PaintingManager.CurrentTool is TwoPointTool && PaintingManager.CurrentTool.InUse)
            {
                TwoPointTool tool = PaintingManager.CurrentTool as TwoPointTool;
                tool.Paint(tool.Temp, e.Graphics);
                ((PictureBox)sender).Invalidate();
                PaintingManager.File.IsModified = true;
            }

            var multiPointTool = PaintingManager.CurrentTool as MultiPointTool;
            if (multiPointTool != null)
            {
                using (Graphics g = Graphics.FromImage(PaintingManager.Page.Picture))
                {
                    multiPointTool.Paint(g, (int)Size.Value);
                }
            }
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (PaintingManager.CurrentTool is TwoPointTool && e.Button == MouseButtons.Left)
            {
                ((TwoPointTool) PaintingManager.CurrentTool).Temp = e.Location;
            }
            if (PaintingManager.CurrentTool is MultiPointTool && e.Button == MouseButtons.Left)
            {
                ((MultiPointTool)PaintingManager.CurrentTool).PointsToDraw.Add(e.Location);
                Picture.Invalidate();
            }
            if (PaintingManager.CurrentTool.InUse && e.Button == MouseButtons.Left)
            {
                Picture.Invalidate();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = !PaintingManager.Page.UndoStackEmpty;
            redoToolStripMenuItem.Enabled = !PaintingManager.Page.RedoStackEmpty;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.Page.Undo();
            Picture.Width = PaintingManager.Page.Picture.Width;
            Picture.Height = PaintingManager.Page.Picture.Height;
            Picture.Image = PaintingManager.Page.Picture;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.Page.Redo();
            Picture.Width = PaintingManager.Page.Picture.Width;
            Picture.Height = PaintingManager.Page.Picture.Height;
            Picture.Image = PaintingManager.Page.Picture;
        }

        private void SetLine_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Line(PaintingManager.CurrentTool.PrimaryColor, PaintingManager.CurrentTool.SecondaryColor, (int)Size.Value));
            Picture.Cursor = Cursors.Cross;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Ellipse(PaintingManager.CurrentTool.PrimaryColor, PaintingManager.CurrentTool.SecondaryColor, (int)Size.Value));
            Picture.Cursor = Cursors.Cross;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.File.SaveFile(PaintingManager.Page.Picture);
        }

        private void SetRubber_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Rubber(PaintingManager.CurrentTool.PrimaryColor, PaintingManager.CurrentTool.SecondaryColor));
        }

        private void SetFill_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Fill(PaintingManager.CurrentTool.PrimaryColor, PaintingManager.CurrentTool.SecondaryColor));
        }

        private void Picture_Click(object sender, EventArgs e)
        {
           
        }

        private void rotate90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.Page.PrepareToPaint();
            int tmpWidth = Picture.Width;
            Picture.Width = Picture.Height;
            Picture.Height = tmpWidth;
            PaintingManager.Page.Rotate(RotateFlipType.Rotate270FlipNone);
            Picture.Refresh();
        }

        private void SetRectangle_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Classes.Tools.Rectangle(PaintingManager.CurrentTool.PrimaryColor, PaintingManager.CurrentTool.SecondaryColor, (int)Size.Value));
            Picture.Cursor = Cursors.Cross;
        }

        private void Pencil_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Pencil(PaintingManager.CurrentTool.PrimaryColor, PaintingManager.CurrentTool.SecondaryColor));
            Picture.Cursor = Cursors.Cross;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void rotate180ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.Page.PrepareToPaint();
            PaintingManager.Page.Rotate(RotateFlipType.Rotate180FlipNone);
            Picture.Refresh();
        }

        private void rotate90RightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.Page.PrepareToPaint();
            int tmpWidth = Picture.Width;
            Picture.Width = Picture.Height;
            Picture.Height = tmpWidth;
            PaintingManager.Page.Rotate(RotateFlipType.Rotate90FlipNone);
            Picture.Refresh();
        }
    }
}
