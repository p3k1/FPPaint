using System;
using System.Drawing;
using System.Windows.Forms;

namespace FPPaint.Classes.Tools
{
    /// <summary>
    /// Class representing Rectangle tool.
    /// </summary>
    class Rectangle : TwoPointTool
    {
        public Rectangle(Color primaryColor, Color secondaryColor, int size)
            : base(primaryColor, secondaryColor, size)
        {
        }

        /// <summary>
        /// Paints a rectangle.
        /// </summary>
        /// <param name="endPoint">Ending point of a rectangle.</param>
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
                if (StartingPoint.Value.X > endPoint.X && StartingPoint.Value.Y > endPoint.Y)
                {
                    graphics.DrawRectangle(new Pen(isRightClicked ? SecondaryColor: PrimaryColor, Size), endPoint.X, endPoint.Y, (StartingPoint.Value.X - endPoint.X), (StartingPoint.Value.Y - endPoint.Y));
                }
                if (StartingPoint.Value.X < endPoint.X && StartingPoint.Value.Y > endPoint.Y)
                {
                    graphics.DrawRectangle(new Pen(isRightClicked ? SecondaryColor : PrimaryColor, Size), StartingPoint.Value.X, endPoint.Y, (endPoint.X - StartingPoint.Value.X), (StartingPoint.Value.Y - endPoint.Y));
                }
                if (StartingPoint.Value.X > endPoint.X && StartingPoint.Value.Y < endPoint.Y)
                {
                    graphics.DrawRectangle(new Pen(isRightClicked ? SecondaryColor : PrimaryColor, Size), endPoint.X, StartingPoint.Value.Y, (StartingPoint.Value.X - endPoint.X), (endPoint.Y - StartingPoint.Value.Y));
                }
                else
                {
                    graphics.DrawRectangle(new Pen(isRightClicked ? SecondaryColor : PrimaryColor, Size), StartingPoint.Value.X, StartingPoint.Value.Y, (endPoint.X - StartingPoint.Value.X), (endPoint.Y - StartingPoint.Value.Y));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
