using System.Drawing;
using System.Windows.Forms;
using FPPaint.Forms;

namespace FPPaint.Classes
{
    class PaletteHelper
    {
        //private Color[] ColorList = new[]{Color.Black, Color.White ,Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Magenta, Color.Gray, Color.CornflowerBlue};
        
        //public void CreatePalette(MainWindow MainWindow)
        //{
        //    for (int i = 0; i < ColorList.GetLength(0); i++)
        //    {
        //        var ToAdd = new Button();
        //        ToAdd.BackColor = ColorList[i];
        //        ToAdd.Size = new Size(20, 20);
        //        ToAdd.Location = new Point(20, 275 + 25*i);
        //        ToAdd.MouseUp += (sender, args) =>
        //                             {
        //                                 if (args.Button == MouseButtons.Left)
        //                                 {
        //                                     MainWindow.PrimaryColor.BackColor =
        //                                         PaintingManager.CurrentTool.PrimaryColor = ((Button) sender).BackColor;
        //                                     return;
        //                                 }
        //                                 if (args.Button == MouseButtons.Right)
        //                                 {
        //                                     MainWindow.SecondaryColor.BackColor =
        //                                         PaintingManager.CurrentTool.SecondaryColor = ((Button) sender).BackColor;
        //                                 }
        //                             };
        //        MainWindow.ToolsAndColors.Controls.Add(ToAdd);
        //    }
        //}
    }
}
