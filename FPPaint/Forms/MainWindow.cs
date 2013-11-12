using System;
using System.Drawing;
using System.Windows.Forms;
using FPPaint.Classes;
using FPPaint.Classes.Tools;

namespace FPPaint.Forms
{
    public partial class MainWindow : Form
    {
        public static PaintingManager PaintingManager = PaintingManager.Instance(new File(""), new Page(800, 600),
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
            MenuHelper.Undo(this);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuHelper.Redo(this);
        }

        private void rotate90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuHelper.Rotate(this, RotateFlipType.Rotate270FlipNone);
        }

        private void rotate180ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuHelper.Rotate(this, RotateFlipType.Rotate180FlipNone);
        }

        private void rotate90RightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuHelper.Rotate(this, RotateFlipType.Rotate90FlipNone);
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
            MenuHelper.Rotate(this, RotateFlipType.RotateNoneFlipY);
        }

        private void flipVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuHelper.Rotate(this, RotateFlipType.RotateNoneFlipX);
        }
    }
}
