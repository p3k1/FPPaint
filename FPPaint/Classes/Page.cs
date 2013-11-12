using System;
using System.Collections.Generic;
using System.Drawing;

namespace FPPaint.Classes
{
    /// <summary>
    /// A class responsible for handling bitmap and undo/redo stacks.
    /// </summary>
    public class Page : IDisposable
    {
        #region Fields

        private readonly Stack<Bitmap> _undoStack = new Stack<Bitmap>();
        private readonly Stack<Bitmap> _redoStack = new Stack<Bitmap>();
        public Bitmap Picture = null;
        private bool _disposed;

        #endregion

        #region Properties

        public bool UndoStackEmpty
        {
            get { return _undoStack.Count == 0; }
        }

        public bool RedoStackEmpty
        {
            get { return _redoStack.Count == 0; }
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
        /// <param name="path">Path to the File.</param>
        public void LoadPicture(String path)
        {
            if (!String.IsNullOrEmpty(path))
                using (var bmp = Image.FromFile(path))
                    Picture = new Bitmap(bmp);
        }

        /// <summary>
        /// Used before every painting.
        /// </summary>
        public void PrepareToPaint()
        {
            _undoStack.Push((Bitmap)Picture.Clone());
        }

        /// <summary>
        /// Undo operation.
        /// </summary>
        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                _redoStack.Push((Bitmap)Picture.Clone());
                Picture = _undoStack.Pop();
            }
        }

        /// <summary>
        /// Redo operation.
        /// </summary>
        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                _undoStack.Push((Bitmap)Picture.Clone());
                Picture = _redoStack.Pop();
            }
        }

        /// <summary>
        /// Rotates the picture.
        /// </summary>
        /// <param name="type">Rotate type.</param>
        public void Rotate(RotateFlipType type)
        {
            Picture.RotateFlip(type);
        }

        #endregion

        #region IDisposable implementation
        //According to http://msdn.microsoft.com/en-us/library/ms244737.aspx

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Picture.Dispose();
                }
                _disposed = true;
            }
        }

        public ~Page()
        {
            Dispose(false);
        }

        #endregion
    }
}
