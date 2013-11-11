using System.Drawing;

namespace FPPaint.Classes.Tools
{
    /// <summary>
    /// An abstract class which is a base for every two point tool e.g.: circle, rectangle, line.
    /// </summary>
    abstract class TwoPointTool : Tool
    {
        #region Fields

        public int Size { get; set; }

        protected Point? StartingPoint = null;

        public Point Temp;

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor. 
        /// </summary>
        /// <param name="primaryColor">Primary color of the tool.</param>
        /// <param name="secondaryColor">Secondary color of the tool.</param>
        /// <param name="size">Tool size.</param>
        protected TwoPointTool(Color primaryColor, Color secondaryColor, int size)
            : base(primaryColor, secondaryColor)
        {
            Size = size;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method which should be ivoked via MouseDown event.
        /// </summary>
        /// <param name="startingPoint"></param>
        public void StartPainting(Point startingPoint)
        {
            StartingPoint = startingPoint;
            InUse = true;
        }

        public abstract void Paint(Point endPoint, Graphics graphics);

        #endregion
    }
}
