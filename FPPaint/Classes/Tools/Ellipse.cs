using System;
using System.Drawing;
using System.Windows.Forms;

namespace FPPaint.Classes.Tools
{
    class Ellipse : TwoPointTool
    {
        public Ellipse(Color primaryColor, Color secondaryColor, int size)
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
                graphics.DrawEllipse(new Pen(isRightClicked ? SecondaryColor : PrimaryColor, Size), StartingPoint.Value.X, StartingPoint.Value.Y,
                      (endPoint.X - StartingPoint.Value.X), (endPoint.Y - StartingPoint.Value.Y));
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Invalid operation!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //catch (ArgumentNullException ex)
            //{
            //    MessageBox.Show("Null graphics!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        
    }
}
