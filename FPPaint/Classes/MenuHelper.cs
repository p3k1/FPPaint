using System;
using System.Drawing;
using System.Windows.Forms;
using FPPaint.Classes;
using FPPaint.Forms;

namespace FPPaint.Forms
{
    /// <summary>
    /// Contains helper methods to reduce MainWindow.cs size.
    /// </summary>
    static class MenuHelper
    {
        public static void ExitActions(MainWindow mainWindow)
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
            mainWindow.Close();
            Application.Exit();
        }

        public static void NewFileActions(MainWindow mainWindow)
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
                mainWindow.PictureProp.Width = newItem.width;
                mainWindow.PictureProp.Height = newItem.height;
                PaintingManager.Page = new Page(newItem.width, newItem.height);
                PaintingManager.File = new File("");
                mainWindow.PictureProp.Image = PaintingManager.Page.Picture;
                using (Graphics g = Graphics.FromImage(PaintingManager.Page.Picture))
                    g.Clear(Color.White);
                mainWindow.PictureProp.Refresh();
            }
            mainWindow.Text = "FP Paint - " + PaintingManager.File.Name;
        }

        public static void OpenActions(MainWindow mainWindow)
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

            using (var OpenFile = new OpenFileDialog())
            {
                OpenFile.Multiselect = false;
                OpenFile.Filter = "Bitmaps (*.BMP)|*.bmp";
                if (OpenFile.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(OpenFile.FileName))
                {
                    PaintingManager.CreateNewPicture(OpenFile.FileName);
                    mainWindow.PictureProp.Height = PaintingManager.Page.Picture.Height;
                    mainWindow.PictureProp.Width = PaintingManager.Page.Picture.Width;
                    mainWindow.PictureProp.Image = PaintingManager.Page.Picture;
                    PaintingManager.File.Path = OpenFile.FileName;
                    mainWindow.PictureProp.Refresh();
                }
            }
            mainWindow.Text = "FP Paint - " + PaintingManager.File.Name;
        }

        public static void Undo(MainWindow mainWindow)
        {
            PaintingManager.Page.Undo();
            mainWindow.PictureProp.Width = PaintingManager.Page.Picture.Width;
            mainWindow.PictureProp.Height = PaintingManager.Page.Picture.Height;
            mainWindow.PictureProp.Image = PaintingManager.Page.Picture;
        }

        public static void Redo(MainWindow mainWindow)
        {
            PaintingManager.Page.Redo();
            mainWindow.PictureProp.Width = PaintingManager.Page.Picture.Width;
            mainWindow.PictureProp.Height = PaintingManager.Page.Picture.Height;
            mainWindow.PictureProp.Image = PaintingManager.Page.Picture;
        }

        public static void Rotate(MainWindow mainWindow, RotateFlipType type)
        {
            PaintingManager.Page.PrepareToPaint();
            PaintingManager.Page.Rotate(type);
            //int tmpWidth = mainWindow.PictureProp.Width;
            mainWindow.PictureProp.Width = PaintingManager.Page.Picture.Width;
            mainWindow.PictureProp.Height = PaintingManager.Page.Picture.Height;
            mainWindow.PictureProp.Refresh();
        }
    }
}
