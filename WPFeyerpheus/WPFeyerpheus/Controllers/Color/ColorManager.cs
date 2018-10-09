﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Eyerpheus.Controllers
{
    class ColorManager
    {
        private const int span = -30;

        public Color getHighLightedVersion(Color color)
        {
            int R = color.R + span;
            int G = color.G + span;
            int B = color.B + span;

            return Color.FromRgb((byte)R, (byte)G, (byte)B);
        }
    }
}
