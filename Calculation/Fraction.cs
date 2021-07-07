using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrigCalc2.Calculation
{
    public class Fraction
    {
        public double numerator;
        public double denominator;

        public Fraction(double numerator, double denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public Fraction Add(Fraction other)
        {
            double _denominator = this.denominator * other.denominator;
            double _numerator = this.numerator * other.denominator + other.numerator * this.denominator;

            Fraction result = new Fraction(_numerator, _denominator);
            result.Reduce();

            return result;
        }

        public Fraction Subtract(Fraction other)
        {
            other.numerator = -other.numerator;

            return Add(other);
        }

        public Fraction Multiply(Fraction other)
        {
            double _numerator = this.numerator * other.numerator;
            double _denominator = this.denominator * other.denominator;
            
            Fraction result = new Fraction(_numerator, _denominator);
            result.Reduce();

            return result;
        }

        public Fraction Divide(Fraction other)
        {
            double _numerator = other.numerator;
            other.numerator = other.denominator;
            other.denominator = _numerator;

            return Multiply(other);
        }

        public void Reduce()
        {
            for (double i = denominator * numerator; i >= 1; i--)
            {
                if ((denominator % i == 0) && (numerator % i == 0))
                {
                    denominator /= i;
                    numerator   /= i;
                }
            }
        }


        public override string ToString()
        {
            return numerator + "/" + denominator;
        }
    }
}
