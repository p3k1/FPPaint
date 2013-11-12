using System;
using System.Drawing;
using System.Windows.Forms;

namespace FPPaint.Classes.Tools
{
    /// <summary>
    /// Class representing Line tool.
    /// </summary>
    class Line : TwoPointTool
    {
        #region Constructor

        public Line(Color primaryColor, Color secondaryColor, int size)
            : base(primaryColor, secondaryColor, size)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Paints the line.
        /// </summary>
        /// <param name="endPoint">Point ending the line.</param>
        /// <param name="graphics">Graphics object.</param>
        public override void Paint(Point endPoint, Graphics graphics, bool isRightClicked)
        {
            try
            {
                if (graphics == null)
                {
                    MessageBox.Show("Null graphics!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                graphics.DrawLine(new Pen(isRightClicked ? SecondaryColor : PrimaryColor, Size), (PointF)StartingPoint, endPoint);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Invalid operation!" + ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
