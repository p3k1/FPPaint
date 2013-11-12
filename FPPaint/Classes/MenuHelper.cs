using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FPPaint.Classes.Tools;
using FPPaint.Forms;

namespace FPPaint.Classes
{
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
                mainWindow.PictureProp.Image = PaintingManager.Page.Picture;
                using (Graphics g = Graphics.FromImage(PaintingManager.Page.Picture))
                    g.Clear(Color.White);
                mainWindow.PictureProp.Refresh();
            }
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
        }
    }
}
