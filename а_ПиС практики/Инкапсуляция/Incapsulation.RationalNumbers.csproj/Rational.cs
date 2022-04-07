using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.RationalNumbers
{
    public class Rational
    {
        #region Fields
        private int numerator; // числитель
        private int denominator; //знаменатель

        private bool isNan;
        public int Numerator { get { return numerator; } }
        public int Denominator { get { return denominator; } }
        public bool IsNan {
            get
            {
                if (denominator == 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
#endregion

// КОНСТРУКТОР
        public Rational(int numerator, int denominator = 1)
        {
            this.numerator = numerator;
            this.denominator = denominator;

            if (this.denominator < 0)
            {
                this.numerator *= -1;
                this.denominator *= -1;
            }

            if (this.denominator == 0)
                this.isNan = true;
            else
            {
                this.isNan = false;
                if (this.numerator > 0 
                    || this.numerator < 0)
                {
                    var maxCommonDivisor = MaxCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));
                    this.numerator /= maxCommonDivisor;
                    this.denominator /= maxCommonDivisor;
                }
                else
                    this.denominator = 1;
            }
        }

        public Rational(int num) : this(num, 1) { }

        public static int MaxCommonDivisor(int numerator, int denominator)
        {
            if (numerator == 0) return denominator;
            if (numerator == denominator) return numerator;
            //if (numerator > denominator)
            //    return MaxCommonDivisor(numerator - denominator, denominator);
            //return MaxCommonDivisor(denominator - numerator, numerator);
            else
                while (denominator != 0)
                {
                    var x = denominator;
                    denominator = numerator % denominator;
                    numerator = x;
                }
            return numerator;


        }

        private static void ToCommonDenominator(Rational x, Rational y)
        {
            if (x.denominator > y.denominator)
            {
                var commonDenominator = x.denominator * y.denominator;
                var aMultiplier = commonDenominator / x.denominator;
                var bMultiplier = commonDenominator / y.denominator;

                x.denominator = commonDenominator;
                x.numerator *= aMultiplier;

                y.denominator = commonDenominator;
                y.numerator *= bMultiplier;
            }
        }

        // операторы 

        public static Rational operator +(Rational x, Rational y)
        {
            return new Rational(x.numerator * y.denominator + y.numerator * x.denominator, 
                x.denominator * y.denominator);
        }

        public static Rational operator -(Rational x, Rational y)
        {
            return new Rational(x.numerator * y.denominator - y.numerator * x.denominator,
                            x.denominator * y.denominator);
        }

        public static Rational operator *(Rational x, Rational y)
        {
            return new Rational(x.Numerator * y.Numerator, 
                x.Denominator * y.Denominator);
        }

        public static Rational operator /(Rational x, Rational y)
        {
            if (y.IsNan)
                return new Rational(0, 0);
            else
                return new Rational((x.numerator * y.denominator), x.denominator * y.numerator);
        }


        public static explicit operator int(Rational a)
        {
            var result = (double)a.numerator / (double)a.denominator;
            var division = (int)result;
            if (result - division == 0)
                return (int)division;
            else
                throw new ArgumentException();
        }

        public static implicit operator double(Rational x)
        {
            if (x.isNan) return double.NaN;
            return (double)x.numerator / x.denominator;
        }


        public static implicit operator Rational(int a)
        {
            return new Rational(a);
        }
    }
}
