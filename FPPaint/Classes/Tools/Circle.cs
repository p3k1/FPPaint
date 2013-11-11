﻿using System;
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

        public override void Paint(Point _endPoint, Graphics graphics)
        {
            try
            {
                if (graphics == null)
                { 
                    MessageBox.Show("Null graphics!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;    
                }
                    graphics.DrawEllipse(new Pen(PrimaryColor, Size), StartingPoint.Value.X, StartingPoint.Value.Y, Math.Min(_endPoint.X, _endPoint.Y), Math.Min(_endPoint.X, _endPoint.Y));
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Invalid operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //catch (ArgumentNullException ex)
            //{
            //    MessageBox.Show("Null graphics!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
    }
}
