using System;

namespace ComplexMath
{
    public class ComplexNumber
    {
        private double _real;
        private double _imaginary;

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public double Real
        {
            get => _real;
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                    throw new ArgumentException("Invalid value for Real part.");
                }

                _real = value;
            }
        }

        public double Imaginary
        {
            get => _imaginary;
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                    throw new ArgumentException("Invalid value for Imaginary part.");
                }

                _imaginary = value;
            }
        }

        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(
                c1.Real * c2.Real - c1.Imaginary * c2.Imaginary,
                c1.Real * c2.Imaginary + c1.Imaginary * c2.Real
            );
        }

        public static ComplexNumber operator /(ComplexNumber c1, ComplexNumber c2)
        {
            double denom = c2.Real * c2.Real + c2.Imaginary * c2.Imaginary;

            if (denom == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }

            return new ComplexNumber(
                (c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / denom,
                (c1.Imaginary * c2.Real - c1.Real * c2.Imaginary) / denom
            );
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }
    }
}