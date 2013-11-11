using System.Drawing;

namespace FPPaint.Classes.Tools
{
    /// <summary>
    /// An abstract class which is a base for all tools.
    /// </summary>
    public abstract class Tool
    {
        #region Properties

        public bool InUse { get; set; }
        public Color PrimaryColor { get; set; }
        public Color SecondaryColor { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="primaryColor">Primary color of the tool.</param>
        /// <param name="secondaryColor">Secondary color of the tool.</param>
        protected Tool(Color primaryColor, Color secondaryColor)
        {
            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
        }

        #endregion
    }
}
