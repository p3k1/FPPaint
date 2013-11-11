using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPPaint.Classes.Tools
{
    public class Pencil : MultiPointTool
    {
        public Pencil(Color primaryColor, Color secondaryColor)
            : base(primaryColor, secondaryColor)
        {
        }

        public override void Paint(Graphics grahpics, int size)
        {
            try
            {
                if (grahpics == null)
                {
                    throw new ArgumentNullException();
                }
                for (int i = 1; i < PointsToDraw.Count; i++)
                {
                    grahpics.DrawLine(new Pen(PrimaryColor, size), PointsToDraw[i - 1].X, PointsToDraw[i - 1].Y,
                                      PointsToDraw[i].X, PointsToDraw[i].Y);
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Null graphics!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
