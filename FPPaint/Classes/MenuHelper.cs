using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FPPaint.Classes.Tools;
using FPPaint.Forms;

namespace FPPaint.Classes
{
    static class MenuHelper
    {
        public static void ExitActions(MainWindow mainWindow)
        {
            if (PaintingManager.File.IsModified)
            {
                DialogResult result = MessageBox.Show("File was changed. Do you want to save it?", "Question", MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.Yes)
                    if (!PaintingManager.File.SaveFile(PaintingManager.Page.Picture))
                        return;

            }
            mainWindow.Close();
            Application.Exit();
        }

    }
}
