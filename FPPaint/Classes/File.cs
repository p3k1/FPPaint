using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace FPPaint.Classes.Tools
{
    /// <summary>
    /// Class responsible for actions on files.
    /// </summary>
    public class File
    {
        #region Fields

        private bool IsFileNew;
        private bool IsModified = false;
        private string Path = string.Empty;

        #endregion

        #region Properties

        public string Path1
        {
            get { return Path; }
            set { Path = value; }
        }

        public bool IsFileNew1
        {
            get { return IsFileNew; }
            set { IsFileNew = value; }
        }

        public bool IsModified1
        {
            get { return IsModified; }
            set { IsModified = value; }
        }

        public string Name
        {
            get
            {
                if (IsFileNew)
                    return "New File";
                else
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
            if (IsFileNew1 || IsModified1)
            {
                try
                {
                    if (string.IsNullOrEmpty(Path1))
                    {
                        var saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "BMP | *.BMP";
                        if (DialogResult.OK == saveFileDialog.ShowDialog())
                        {
                            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                                Path1 = saveFileDialog.FileName;
                        }
                        else
                            return false;
                    }

                    using (MemoryStream memory = new MemoryStream())
                    using (FileStream fs = new FileStream(Path1, FileMode.Create, FileAccess.ReadWrite, FileShare.Delete))
                    {
                        picture.Save(memory, ImageFormat.Bmp);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    
                    IsModified1 = false;
                    IsFileNew1 = false;
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        #endregion
    }
}
