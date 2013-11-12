using System;
using System.Drawing;
using System.Windows.Forms;

namespace FPPaint.Classes.Tools
{
    public class Pencil : MultiPointTool
    {
        public Pencil(Color primaryColor, Color secondaryColor)
            : base(primaryColor, secondaryColor)
        {
        }

        public override void Paint(Graphics graphics, int size, bool isRightClicked)
        {
            try
            {
                if (graphics == null)
                {
                    MessageBox.Show("Null graphics!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                for (int i = 1; i < PointsToDraw.Count; i++)
                {
                    graphics.DrawLine(new Pen(isRightClicked ? SecondaryColor: PrimaryColor, size), PointsToDraw[i - 1].X, PointsToDraw[i - 1].Y,
                                      PointsToDraw[i].X, PointsToDraw[i].Y);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
