using System;
using System.Collections.Generic;
using System.Drawing;

namespace FPPaint.Classes
{
    /// <summary>
    /// A class responsible for handling bitmap and undo/redo stacks.
    /// </summary>
    public class Page
    {
        #region Fields

        private Stack<Bitmap> UndoStack = new Stack<Bitmap>();
        private Stack<Bitmap> RedoStack = new Stack<Bitmap>();
        public Bitmap Picture = null;

        #endregion

        #region Properties

        public bool UndoStackEmpty
        {
            get { return UndoStack.Count == 0; }
        }

        public bool RedoStackEmpty
        {
            get { return RedoStack.Count == 0; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="width">Bitmap width.</param>
        /// <param name="height">Bitmap height.</param>
        public Page(int width, int height)
        {
            Picture = new Bitmap(width, height);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads a picture.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        public void LoadPicture(String path)
        {
            if (!String.IsNullOrEmpty(path))
                using (var bmp = Bitmap.FromFile(path))
                    Picture = new Bitmap(bmp);
        }

        /// <summary>
        /// Used before every painting.
        /// </summary>
        public void PrepareToPaint()
        {
            UndoStack.Push((Bitmap)Picture.Clone());
        }

        /// <summary>
        /// Undo operation.
        /// </summary>
        public void Undo()
        {
            if (UndoStack.Count > 0)
            {
                RedoStack.Push((Bitmap)Picture.Clone());
                Picture = UndoStack.Pop();
            }
        }

        /// <summary>
        /// Redo operation.
        /// </summary>
        public void Redo()
        {
            if (RedoStack.Count > 0)
            {
                UndoStack.Push((Bitmap)Picture.Clone());
                Picture = RedoStack.Pop();
            }
        }

        public void Rotate(RotateFlipType type)
        {
            Picture.RotateFlip(type);
        }

        #endregion
    }
}
