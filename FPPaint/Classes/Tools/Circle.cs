using System;
using System.Drawing;
using System.Windows.Forms;

namespace FPPaint.Classes.Tools
{
    /// <summary>
    /// Class representing Circle tool.
    /// </summary>
    class Circle : TwoPointTool
    {
        public Circle(Color primaryColor, Color secondaryColor, int size)
            : base(primaryColor, secondaryColor, size)
        {
        }

        public override void Paint(Point endPoint, Graphics graphics, bool isRightClicked)
        {
            try
            {
                if (graphics == null)
                {
                    MessageBox.Show("Null graphics!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               .. graphics.DrawEllipse(new Pen(isRightClicked ? SecondaryColor: PrimaryColor , Size), StartingPoint.Value.X, StartingPoint.Value.Y, Math.Min(endPoint.X, endPoint.Y), Math.Min(endPoint.X, endPoint.Y));
                if (StartingPoint.Value.X > endPoint.X && StartingPoint.Value.Y > endPoint.Y)
                {
                    graphics.DrawEllipse(new Pen(isRightClicked ? SecondaryColor : PrimaryColor, Size), new System.Drawing.Rectangle(endPoint.X, endPoint.Y, Math.Min((StartingPoint.Value.X - endPoint.X), (StartingPoint.Value.Y - endPoint.Y)), Math.Min((StartingPoint.Value.X - endPoint.X), (StartingPoint.Value.Y - endPoint.Y))));
                    return;
                }
                if (StartingPoint.Value.X < endPoint.X && StartingPoint.Value.Y > endPoint.Y)
                {
                    graphics.DrawEllipse(new Pen(isRightClicked ? SecondaryColor : PrimaryColor, Size), new System.Drawing.Rectangle(StartingPoint.Value.X, endPoint.Y, Math.Min((endPoint.X - StartingPoint.Value.X), (StartingPoint.Value.Y - endPoint.Y)), Math.Min((endPoint.X - StartingPoint.Value.X), (StartingPoint.Value.Y - endPoint.Y))));
                    return;
                }
                if (StartingPoint.Value.X > endPoint.X && StartingPoint.Value.Y < endPoint.Y)
                {
                    graphics.DrawEllipse(new Pen(isRightClicked ? SecondaryColor : PrimaryColor, Size), new System.Drawing.Rectangle(endPoint.X, StartingPoint.Value.Y, Math.Min((StartingPoint.Value.X - endPoint.X), (endPoint.Y - StartingPoint.Value.Y)),Math.Min((StartingPoint.Value.X - endPoint.X), (endPoint.Y - StartingPoint.Value.Y))));
                }
                else
                {
                    graphics.DrawEllipse(new Pen(isRightClicked ? SecondaryColor : PrimaryColor, Size), new System.Drawing.Rectangle(StartingPoint.Value.X, StartingPoint.Value.Y, Math.Min((endPoint.X - StartingPoint.Value.X), (endPoint.Y - StartingPoint.Value.Y)), Math.Min((endPoint.X - StartingPoint.Value.X), (endPoint.Y - StartingPoint.Value.Y))));
                }
            
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Invalid operation!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
