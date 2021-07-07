using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrigCalc2.Utilities
{
    public enum ColorTheme
    {
        dark,
        light
    }

    public enum CalculationType
    {
        radians,
        degrees
    }

    public struct Settings
    {
        public ColorTheme theme;
        public CalculationType calculationType;
    }
}
