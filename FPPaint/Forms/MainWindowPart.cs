using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FPPaint.Classes;
using FPPaint.Classes.Tools;

namespace FPPaint.Forms
{
    partial class MainWindow
    {
        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            isRightClicked = e.Button == MouseButtons.Right;
            try
            {
                if ((PaintingManager.CurrentTool is TwoPointTool) && !PaintingManager.CurrentTool.InUse)
                {
                    ((TwoPointTool)PaintingManager.CurrentTool).StartPainting(e.Location);
                    PaintingManager.File.IsModified = true;
                }
                InstantTool currentTool = PaintingManager.CurrentTool as InstantTool;
                if (currentTool != null)
                {
                    currentTool.Paint(PaintingManager.Page.Picture, e.Location.X, e.Location.Y,
                        isRightClicked? PaintingManager.CurrentTool.SecondaryColor: PaintingManager.CurrentTool.PrimaryColor,
                                      PaintingManager.Page.Picture.GetPixel(e.Location.X, e.Location.Y));
                }
                MultiPointTool multiPointTool = PaintingManager.CurrentTool as MultiPointTool;
                if (multiPointTool != null)
                {
                    multiPointTool.InUse = true;
                    multiPointTool.PointsToDraw.Add(e.Location);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace, "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            PaintingManager.Page.PrepareToPaint();
            try
            {
                TwoPointTool twoPointTool = PaintingManager.CurrentTool as TwoPointTool;
                if (twoPointTool != null)
                {
                    isRightClicked = e.Button == MouseButtons.Right;
                    using (Graphics g = Graphics.FromImage(PaintingManager.Page.Picture))
                        twoPointTool.Paint(e.Location, g, isRightClicked);
                    Picture.Refresh();
                    PaintingManager.File.IsModified = true;
                    PaintingManager.CurrentTool.InUse = false;
                }

                InstantTool currentTool = PaintingManager.CurrentTool as InstantTool;
                if (currentTool != null)
                {
                    currentTool.Paint(PaintingManager.Page.Picture, e.Location.X,
                                      e.Location.Y,
                                      isRightClicked? PaintingManager.CurrentTool.SecondaryColor: PaintingManager.CurrentTool.PrimaryColor,
                                      PaintingManager.Page.Picture.GetPixel(
                                          e.Location.X, e.Location.Y));
                    Picture.Invalidate();
                    PaintingManager.File.IsModified = true;
                }

                MultiPointTool multiPointTool = PaintingManager.CurrentTool as MultiPointTool;
                if (multiPointTool != null && multiPointTool.InUse)
                {
                    multiPointTool.PointsToDraw.Clear();
                    multiPointTool.InUse = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace, "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            isRightClicked = e.Button == MouseButtons.Right;
            if (PaintingManager.CurrentTool is TwoPointTool &&
                (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
            {
                ((TwoPointTool)PaintingManager.CurrentTool).Temp = e.Location;
            }
            if (PaintingManager.CurrentTool is MultiPointTool &&
                (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
            {
                ((MultiPointTool)PaintingManager.CurrentTool).PointsToDraw.Add(e.Location);
                Picture.Invalidate();
            }
            if (PaintingManager.CurrentTool.InUse && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
            {
                Picture.Invalidate();
            }
        }

        private void Picture_Paint(object sender, PaintEventArgs e)
        {
            if (PaintingManager.CurrentTool is TwoPointTool && PaintingManager.CurrentTool.InUse)
            {
                TwoPointTool tool = PaintingManager.CurrentTool as TwoPointTool;
                tool.Paint(tool.Temp, e.Graphics, isRightClicked);
                ((PictureBox)sender).Invalidate();
                PaintingManager.File.IsModified = true;
            }

            var multiPointTool = PaintingManager.CurrentTool as MultiPointTool;
            if (multiPointTool != null && multiPointTool.InUse)
            {
                using (Graphics g = Graphics.FromImage(PaintingManager.Page.Picture))
                {
                    multiPointTool.Paint(g, (int)Size.Value, isRightClicked);
                    PaintingManager.File.IsModified = true;
                }
            }
        }
    }
}
