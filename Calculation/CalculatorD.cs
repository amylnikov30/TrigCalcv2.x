using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrigCalc2.Calculation
{
    public class CalculatorD : ICalculator
    {

        
        public double _a { get; private set; }
        public double _b { get; private set; }
        public double _c { get; private set; }
        public double _A { get; private set; }
        public double _B { get; private set; }
        public double _C { get; private set; }

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

        
        private bool _enoughInfo;

        public bool enoughInfo { get { return _enoughInfo; } set { enoughInfo = value; } }


        public CalculatorD(double a=0, double b=0, double c=0, double A=0, double B=0, double C=0)
        {
            this._a = a;
            this._b = b;
            this._c = c;

            this._A = A;
            this._B = B;
            this._C = C;

            this.sides = new double[3] { a, b, c };
            this.angles = new double[3] { A, B, C };

            CheckInfo();
        }

        private void CheckInfo()
        {
            List<double> existingSides = ExistingElems(sides);
            List<double> existingAngles = ExistingElems(angles);

            if (existingSides.Count >= 3)
            {
                _enoughInfo = true;
            }
            else if (existingSides.Count >= 2 && existingAngles.Count >= 1)
            {
                _enoughInfo = true;
            }
            else if (existingSides.Count >= 1 && existingAngles.Count >= 2)
            {
                _enoughInfo = true;
            }
            else
                _enoughInfo = false;
        }


        private double CompleteAnlges(double angle1, double angle2)
        {
            double angle3 = 180 - (angle1 + angle2);

            return angle3;
        }

        private void UpdateArrays()
        {
            sides = new double[3] { _a, _b, _c };
            angles = new double[3] { _A, _B, _C };
        }

        private void UpdateVars()
        {
            _a = sides[0];
            _b = sides[1];
            _c = sides[2];
            _A = angles[0];
            _B = angles[1];
            _C = angles[2];

            sA = Math.Round(_A, 3).ToString();
            sB = Math.Round(_B, 3).ToString();
            sC = Math.Round(_C, 3).ToString();

            Console.WriteLine("sA: " + sA);
            Console.WriteLine("_sA: " + _sA);
        }

        public static double Degrees(double radians) => radians * (180 / Math.PI);

        public static double Radians(double degrees) => degrees * (Math.PI / 180);

        public static Point Midpoint(Point p1, Point p2) => new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);

        private void RevCosLaw()
        {
            double numerator = (_a * _a + _b * _b) - _c * _c;
            double denominator = 2 * _a * _b;

            _C = Degrees(Math.Acos(numerator / denominator));

            numerator = (_a * _a + _c * _c) - _b * _b;
            denominator = 2 * _a * _c;

            _B = Degrees(Math.Acos(numerator / denominator));

            numerator = (_b * _b + _c * _c) - _a * _a;
            denominator = 2 * _b * _c;

            _A = Degrees(Math.Acos(numerator / denominator));

            UpdateArrays();
            UpdateVars();
        }

        private void CosLaw()
        {
            List<double> existingSides = new List<double>();
            double existingAngle = 0;

            foreach (double side in sides)
            {
                if (side != 0)
                    existingSides.Add(side);
            }

            foreach (double angle in angles)
            {
                if (angle != 0)
                    existingAngle = angle;
            }

            double finalSide = Math.Sqrt(Math.Pow(existingSides[0], 2) + Math.Pow(existingSides[1], 2)
                               - 2 * existingSides[0] * existingSides[1] * Math.Cos(existingAngle));
            
            for (int i = 0; i<sides.Length; i++)
            {
                if (sides[i] == 0)
                    sides[i] = finalSide;
            }

        }
        private bool IsBetween()
        {
            if (_a != 0 && _b != 0 && _C != 0)
                return true;
            else if (_a != 0 && _c != 0 && _B != 0)
                return true;
            else if (_b != 0 && _c != 0 && _A != 0)
                return true;

            return false;
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

        private void SinLaw()
        {
            List<double> exSides = ExistingElems(sides);
            List<double> exAngles = ExistingElems(angles);

            if (exSides.Count >= 2 && exAngles.Count >= 1)
            {
                double ratio = 0;


                // find ratio
                for (int i = 0; i < sides.Length; i++)
                {
                    if (sides[i] != 0 && angles[i] != 0)
                    {
                        ratio = sides[i] / Math.Sin(Radians(angles[i]));
                        break;
                    }
                }

                // find second angle and append to exAngles
                for (int i = 0; i < sides.Length; i++)
                {
                    if (sides[i] != 0 && angles[i] == 0)
                    {
                        angles[i] = Degrees(Math.Asin(sides[i] / ratio));
                        exAngles.Add(angles[i]);
                        break;
                    }
                }

                double finalAngle = CompleteAnlges(exAngles[0], exAngles[1]);

                for (int i = 0; i < angles.Length; i++)
                {
                    if (angles[i] == 0)
                    {
                        angles[i] = finalAngle;
                        break;
                    }
                }

                for (int i = 0; i < sides.Length; i++)
                {
                    if (sides[i] == 0)
                    {
                        sides[i] = Math.Sin(Radians(angles[i])) * ratio;
                        break;
                    }
                }

                UpdateVars();
            }

            else if (exSides.Count >= 1 && exAngles.Count >= 2)
            {
                double ratio = 0;

                exAngles.Add(CompleteAnlges(exAngles[0], exAngles[1]));

                for (int i = 0; i<angles.Length; i++)
                {
                    if (angles[i] == 0)
                    {
                        angles[i] = CompleteAnlges(exAngles[0], exAngles[1]);
                        exAngles.Add(angles[i]);
                    }
                }

                // finding ratio
                for (int i = 0; i < sides.Length; i++)
                {
                    if (sides[i] != 0)
                    {
                        ratio = sides[i] / Math.Sin(Radians(sides[i]));
                        break;
                    }
                }

                for (int i = 0; i<sides.Length; i++)
                {
                    if (sides[i] == 0)
                        sides[i] = Math.Sin(Radians(angles[i])) * ratio;
                }

                UpdateVars();
            }

        }

        public void Calculate()
        {
            List<double> existingSides = ExistingElems(sides);
            List<double> existingAngles = ExistingElems(angles);

            if (existingSides.Count >= 3)
            {
                RevCosLaw();
                _enoughInfo = true;
                
                //UpdateArrays();
                //UpdateVars();
            }
            else if (existingSides.Count >= 2 && existingAngles.Count >= 1)
            {
                if (IsBetween())
                {
                    CosLaw();
                    SinLaw();
                }
                else
                    SinLaw();
                _enoughInfo = true;
                
                //UpdateArrays();
                //UpdateVars();
            }
            else if (existingAngles.Count >= 1 && existingAngles.Count >= 2)
            {
                SinLaw();
                _enoughInfo = true;
               
                //UpdateArrays();
                //UpdateVars();
            }
            else
                _enoughInfo = false;
        }

    }
}
