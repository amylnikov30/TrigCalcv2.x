using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrigCalc2.Calculation
{
    public class CalculatorR : ICalculator
    {

        private CalculatorD calculator;

        
        private bool _enoughInfo;

        public bool enoughInfo { get { return _enoughInfo; } set { enoughInfo = value; } }

        private bool inTermsOfPi;


        private double _a;
        private double _b;
        private double _c;
        private double _A;
        private double _B;
        private double _C;

        public double a { get { return _a; } set { a = value; } }
        public double b { get { return _b; } set { b = value; } }
        public double c { get { return _c; } set { c = value; } }
        public double A { get { return _A; } set { A = value; } }
        public double B { get { return _B; } set { B = value; } }
        public double C { get { return _C; } set { C = value; } }


        private string _sA;
        private string _sB;
        private string _sC;

        public string sA { get { return _sA; } set { _sA = value; } }
        public string sB { get { return _sB; } set { _sB = value; } }
        public string sC { get { return _sC; } set { _sC = value; } }

        private double[] sides;
        private double[] angles;

        public CalculatorR(double a, double b, double c, string A, string B, string C)
        {

            string token = "(pi)";


            if (A.ToLower().Contains(token))
                inTermsOfPi = true;
            if (B.ToLower().Contains(token))
                inTermsOfPi = true;
            if (C.ToLower().Contains(token))
                inTermsOfPi = true;

            double dA = TryParse(A);
            double dB = TryParse(B);
            double dC = TryParse(C);

            if (dA == 0 && dB == 0 && dC == 0)
                inTermsOfPi = true;

            sides  = new double[3] { a,  b,  c  };
            angles = new double[3] { dA, dB, dC };

            calculator = new CalculatorD(a, b, c, dA, dB, dC);

            //foreach (double angle in angles)
            //{
            //    Console.WriteLine(angle);
            //}

            CheckInfo();
        }

        private void CheckInfo()
        {

            List<double> existingSides = ExistingElems(sides);
            List<double> existingAngles = ExistingElems(angles);

            if (existingSides.Count >= 3)
            {
                //Console.WriteLine("existingSides >= 3");
                _enoughInfo = true;
            }
            else if (existingSides.Count >= 2 && existingAngles.Count >= 1)
            {
                //Console.WriteLine("existingSides >= 2 && existingAngles >= 1");
                _enoughInfo = true;
            }
            else if (existingSides.Count >= 1 && existingAngles.Count >= 2)
            {
                //Console.WriteLine("existingSides >= 1 && existingAngles >= 2");
                _enoughInfo = true;
            }
            else
                _enoughInfo = false;
        }

        private List<double> ExistingElems(double[] ls)
        {
            List<double> result = new List<double>();

            foreach (double i in ls)
            {
                if (i != 0)
                    result.Add(i);
            }

            return result;
        }

        public void Calculate()
        {
            calculator.Calculate();

            _a = calculator._a;
            _b = calculator._b;
            _c = calculator._c;
            _A = calculator._A;
            _B = calculator._B;
            _C = calculator._C;

            //Console.WriteLine(_A);

            if (inTermsOfPi)
            {
                Console.WriteLine("In Terms Of PI");
                sA = InTermsOfPI(CalculatorD.Radians(_A));
                sB = InTermsOfPI(CalculatorD.Radians(_B));
                sC = InTermsOfPI(CalculatorD.Radians(_C));
            }
            else
            {
                Console.WriteLine("Decimal Radians");
                sA = Math.Round(CalculatorD.Radians(_A), 3).ToString();
                sB = Math.Round(CalculatorD.Radians(_B), 3).ToString();
                sC = Math.Round(CalculatorD.Radians(_C), 3).ToString();
            }
        }

        private double TryParse(string radians)
        {
            char token = '/';

            if (radians.Contains(token))
            {
                string[] split = radians.Split(token);

                double numerator;

                double.TryParse(split[0].Substring(0, split[0].Length - 4), out numerator);

                double denominator;


                double.TryParse(split[1], out denominator);
                
                //Console.WriteLine(numerator);

                double degrees = CalculatorD.Degrees(numerator * Math.PI / denominator);

                //inTermsOfPi = true;


                return degrees;
            }
            else
            {
                double degrees;
                double.TryParse(radians, out degrees);

                degrees = CalculatorD.Degrees(degrees);

                //inTermsOfPi = false;

                return degrees;

            }
        }


        private string InTermsOfPI(double radians)
        {
            double degrees = CalculatorD.Degrees(radians);

            double numerator   = degrees;
            double denominator = 180.0;

            Fraction result = new Fraction(numerator, denominator);

            result.Reduce();

            Console.WriteLine(result);

            string strNumerator   = Math.Round(result.numerator, 3).ToString();
            string strDenominator = Math.Round(result.denominator, 3).ToString();

            return strNumerator + "(PI)/" + strDenominator;

        }
    }
}
