using System;
using FPPaint.Classes.Tools;

namespace FPPaint.Classes
{
    /// <summary>
    /// Painting Manager. Implements singleton.
    /// </summary>
    public class PaintingManager
    {
        #region Fields

        public static File File;
        public static Page Page { get; set; }
        public Tool CurrentTool { get; private set; }
        private static PaintingManager _pm;

        #endregion

        #region Constructor

        private PaintingManager(File file, Page page, Tool currentTool)
        {
            File = file;
            Page = page;
            CurrentTool = currentTool;
        }

        #endregion

        #region Methods

        public static PaintingManager GetInstance(File file, Page page, Tool currentTool)
        {
            return _pm ?? (_pm = new PaintingManager(file, page, currentTool));
        }

        public void SetCurrentTool(Tool newTool)
        {
            CurrentTool = newTool;
        }

        public void CreateNewPicture(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                File = new File(path);
                Page.LoadPicture(path);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        
        #endregion
    }
}

