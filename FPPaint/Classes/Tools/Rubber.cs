using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FPPaint.Classes.Tools
{
    /// <summary>
    /// Class representing Rubber tool.
    /// </summary>
    class Rubber : MultiPointTool
    {
        public Rubber(Color primaryColor, Color secondaryColor)
            : base(primaryColor, secondaryColor)
        {
        }

        public override void Paint(Graphics grahpics, int size)
        {
            if (grahpics == null)
            {
                throw new ArgumentNullException();
            }
            for (int i = 1; i < PointsToDraw.Count; i++)
            {
                grahpics.DrawLine(new Pen(SecondaryColor, size), PointsToDraw[i - 1].X, PointsToDraw[i - 1].Y,
                                  PointsToDraw[i].X, PointsToDraw[i].Y);
            }
        }
    }
}
