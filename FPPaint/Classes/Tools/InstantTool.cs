using System.Drawing;
using System.Windows.Forms;

namespace FPPaint.Classes.Tools
{
    /// <summary>
    /// Abstract class representing Instant tool (need only one click to paint).
    /// </summary>
    public abstract class InstantTool : Tool
    {
        #region Constructor

        protected InstantTool(Color primaryColor, Color secondaryColor)
            : base(primaryColor, secondaryColor)
        { }

        #endregion

        #region Methods

        public abstract void Paint(Bitmap bitmap, int x, int y, Color color, Color currentColor);

        #endregion

    }
}

