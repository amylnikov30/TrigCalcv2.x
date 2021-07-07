using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrigCalc2.Calculation
{
    public interface ICalculator
    {

        public double a { get; }
        public double b { get; }
        public double c { get; }
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public string sA { get; set; }
        public string sB { get; set; }
        public string sC { get; set; }


        public bool enoughInfo { get; set; }

        public void Calculate();
    }
}
