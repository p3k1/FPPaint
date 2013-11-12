using System.Drawing;
using System.Windows.Forms;
using FPPaint.Forms;

namespace FPPaint.Classes
{
    static class PaletteHelper
    {
        private static readonly Color[] ColorList = new[] { Color.Black, Color.White, Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Magenta, Color.Gray, Color.CornflowerBlue };

        public static void CreatePalette(MainWindow MainWindow)
        {
         
            for (int i = 0; i < ColorList.GetLength(0); i++)
            {
                var ToAdd = new Button();
                ToAdd.BackColor = ColorList[i];
                ToAdd.Size = new Size(35, 35);
                ToAdd.Location = new Point(20 + (i % 2) * 40, 275 + 30 * (i - (i % 2)));
                ToAdd.MouseUp += (sender, args) =>
                {
                    if (args.Button == MouseButtons.Left)
                    {
                        MainWindow.PrimaryColorProp.BackColor = MainWindow.PaintingManager.CurrentTool.PrimaryColor = ((Button)sender).BackColor;
                        return;
                    }
                    if (args.Button == MouseButtons.Right)
                    {
                        MainWindow.SecondaryColorProp.BackColor = MainWindow.PaintingManager.CurrentTool.SecondaryColor = ((Button)sender).BackColor;
                    }
                };
                MainWindow.ToolsAndColorsProp.Controls.Add(ToAdd);

            }
        }
    }
}
