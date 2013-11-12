using System;
using System.Drawing;
using System.Windows.Forms;
using FPPaint.Classes;
using FPPaint.Classes.Tools;

namespace FPPaint.Forms
{
    public partial class MainWindow : Form
    {
        public static PaintingManager PaintingManager = PaintingManager.GetInstance(new File(""), new Page(800, 600),
                                                                                    new Pencil(Color.Black, Color.White));

        private bool isRightClicked;

        public Panel ToolsAndColorsProp
        {
            get { return ToolsAndColors; }
            set { ToolsAndColors = value; }
        }

        public Button PrimaryColorProp
        {
            get { return PrimaryColor; }
            set { PrimaryColor = value; }
        }

        public Button SecondaryColorProp
        {
            get { return SecondaryColor; }
            set { SecondaryColor = value; }
        }

        public PictureBox PictureProp
        {
            get { return Picture; }
            set { Picture = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            PaletteHelper.CreatePalette(this);
            Text = "FP Paint - " + PaintingManager.File.Name;
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuHelper.ExitActions(this);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuHelper.NewFileActions(this);
            Text = "FP Paint - " + PaintingManager.File.Name;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuHelper.OpenActions(this);
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

        private void rotate90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.Page.PrepareToPaint();
            int tmpWidth = Picture.Width;
            Picture.Width = Picture.Height;
            Picture.Height = tmpWidth;
            PaintingManager.Page.Rotate(RotateFlipType.Rotate270FlipNone);
            Picture.Refresh();
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.File.SaveFile(PaintingManager.Page.Picture);
            Text = "FP Paint - " + PaintingManager.File.Name;
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
            isRightClicked = e.Button == MouseButtons.Right;
            try
            {
                if ((PaintingManager.CurrentTool is TwoPointTool) && !PaintingManager.CurrentTool.InUse)
                {
                    ((TwoPointTool) PaintingManager.CurrentTool).StartPainting(e.Location);
                    PaintingManager.File.IsModified = true;
                }
                InstantTool currentTool = PaintingManager.CurrentTool as InstantTool;
                if (currentTool != null)
                {
                    currentTool.Paint(PaintingManager.Page.Picture, e.Location.X, e.Location.Y,
                                      PaintingManager.CurrentTool.PrimaryColor,
                                      PaintingManager.Page.Picture.GetPixel(e.Location.X, e.Location.Y));
                }
                MultiPointTool multiPointTool = PaintingManager.CurrentTool as MultiPointTool;
                if (multiPointTool != null)
                {
                    multiPointTool.InUse = true;
                    multiPointTool.PointsToDraw.Add(e.Location);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace, "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
                    isRightClicked = e.Button == MouseButtons.Right;
                    using (Graphics g = Graphics.FromImage(PaintingManager.Page.Picture))
                        twoPointTool.Paint(e.Location, g, isRightClicked);
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
                    PaintingManager.File.IsModified = true;
                }

                MultiPointTool multiPointTool = PaintingManager.CurrentTool as MultiPointTool;
                if (multiPointTool != null && multiPointTool.InUse)
                {
                    multiPointTool.PointsToDraw.Clear();
                    multiPointTool.InUse = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace, "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Picture_Paint(object sender, PaintEventArgs e)
        {
            if (PaintingManager.CurrentTool is TwoPointTool && PaintingManager.CurrentTool.InUse)
            {
                TwoPointTool tool = PaintingManager.CurrentTool as TwoPointTool;
                tool.Paint(tool.Temp, e.Graphics, isRightClicked);
                ((PictureBox) sender).Invalidate();
                PaintingManager.File.IsModified = true;
            }

            var multiPointTool = PaintingManager.CurrentTool as MultiPointTool;
            if (multiPointTool != null && multiPointTool.InUse)
            {
                using (Graphics g = Graphics.FromImage(PaintingManager.Page.Picture))
                {
                    multiPointTool.Paint(g, (int) Size.Value, isRightClicked);
                    PaintingManager.File.IsModified = true;
                }
            }
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            this.isRightClicked = e.Button == MouseButtons.Right;
            if (PaintingManager.CurrentTool is TwoPointTool &&
                (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
            {
                ((TwoPointTool) PaintingManager.CurrentTool).Temp = e.Location;
            }
            if (PaintingManager.CurrentTool is MultiPointTool &&
                (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
            {
                ((MultiPointTool) PaintingManager.CurrentTool).PointsToDraw.Add(e.Location);
                Picture.Invalidate();
            }
            if (PaintingManager.CurrentTool.InUse && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
            {
                Picture.Invalidate();
            }
        }

        private void SetLine_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Line(PaintingManager.CurrentTool.PrimaryColor,
                                                    PaintingManager.CurrentTool.SecondaryColor, (int) Size.Value));
            Picture.Cursor = Cursors.Cross;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Ellipse(PaintingManager.CurrentTool.PrimaryColor,
                                                       PaintingManager.CurrentTool.SecondaryColor, (int) Size.Value));
            Picture.Cursor = Cursors.Cross;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.Show();
        }


        private void SetRubber_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Rubber(PaintingManager.CurrentTool.PrimaryColor,
                                                      PaintingManager.CurrentTool.SecondaryColor));
        }

        private void SetFill_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Fill(PaintingManager.CurrentTool.PrimaryColor,
                                                    PaintingManager.CurrentTool.SecondaryColor));
        }


        private void SetRectangle_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Classes.Tools.Rectangle(PaintingManager.CurrentTool.PrimaryColor,
                                                                       PaintingManager.CurrentTool.SecondaryColor,
                                                                       (int) Size.Value));
            Picture.Cursor = Cursors.Cross;
        }

        private void Pencil_Click(object sender, EventArgs e)
        {
            PaintingManager.SetCurrentTool(new Pencil(PaintingManager.CurrentTool.PrimaryColor,
                                                      PaintingManager.CurrentTool.SecondaryColor));
            Picture.Cursor = Cursors.Cross;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.File.SaveAs(PaintingManager.Page.Picture);

            Text = "FP Paint - " + PaintingManager.File.Name;
        }

        private void flipHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.Page.PrepareToPaint();
            PaintingManager.Page.Rotate(RotateFlipType.RotateNoneFlipY);
            Picture.Refresh();
        }

        private void flipVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingManager.Page.PrepareToPaint();
            PaintingManager.Page.Rotate(RotateFlipType.RotateNoneFlipX);
            Picture.Refresh();
        }

    }
}
