using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace FPPaint.Classes
{
    /// <summary>
    /// Class responsible for actions on files.
    /// </summary>
    public class File
    {
        #region Fields

        public bool IsFileNew;
        public bool IsModified = false;
        public string Path = string.Empty;

        #endregion

        #region Properties

        public string Name
        {
            get
            {
                if (IsFileNew)
                    return "New File";
                return Path;
            }
            set
            {
                Path = value;
                IsFileNew = false;
            }
        }

        #endregion

        #region Constructor

        public File(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                Path = string.Empty;
                IsFileNew = true;
            }
            else
            {
                Path = path;
                IsFileNew = false;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Saves a picture.
        /// </summary>
        /// <param name="picture">Picture to save.</param>
        public bool SaveFile(Bitmap picture)
        {
            if (IsFileNew || IsModified)
            {
                try
                {
                    if (string.IsNullOrEmpty(Path))
                    {
                        var saveFileDialog = new SaveFileDialog {Filter = "BMP bitmap| *.BMP"};
                        if (DialogResult.OK == saveFileDialog.ShowDialog())
                        {
                            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                                Path = saveFileDialog.FileName;
                        }
                        else
                            return false;
                    }

                    using (var memory = new MemoryStream())
                    using (var fs = new FileStream(Path, FileMode.Create, FileAccess.ReadWrite, FileShare.Delete))
                    {
                        picture.Save(memory, ImageFormat.Bmp);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    
                    IsModified = false;
                    IsFileNew = false;
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        public void SaveAs(Bitmap picture)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog { Filter = "BMP bitmap| *.BMP" };
                if (DialogResult.OK == saveFileDialog.ShowDialog())
                {
                    if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                        Path = saveFileDialog.FileName;
                }
                else
                    return;

                using (var memory = new MemoryStream())
                using (var fs = new FileStream(Path, FileMode.Create, FileAccess.ReadWrite, FileShare.Delete))
                {
                    picture.Save(memory, ImageFormat.Bmp);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }

                IsModified = false;
                IsFileNew = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
