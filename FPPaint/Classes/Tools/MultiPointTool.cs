﻿using System.Collections.Generic;
using System.Drawing;

namespace FPPaint.Classes.Tools
{
    public abstract class MultiPointTool : Tool
    {
        public List<Point> PointsToDraw = new List<Point>();
        
        protected MultiPointTool(Color primaryColor, Color secondaryColor) : base(primaryColor, secondaryColor)
        {
        }

        public abstract void Paint(Graphics grahpics, int size, bool isRightClicked);
    }
}
