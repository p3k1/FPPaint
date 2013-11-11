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

        public File file;
        public Page page { get; set; }
        public Tool currentTool { get; private set; }
        private static PaintingManager PM = null;

        #endregion

        #region Constructor

        private PaintingManager(File file, Page page, Tool currentTool)
        {
            this.file = file;
            this.page = page;
            this.currentTool = currentTool;
        }

        #endregion

        #region Methods

        public static PaintingManager GetInstance(File file, Page page, Tool currentTool)
        {
            if (PM == null)
            {
                PM = new PaintingManager(file, page, currentTool);
            }
            return PM;
        }

        public void SetCurrentTool(Tool NewTool)
        {
            currentTool = NewTool;
        }

        public void CreateNewPicture(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                file = new File(path);
                page.LoadPicture(path);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        
        #endregion
    }
}

