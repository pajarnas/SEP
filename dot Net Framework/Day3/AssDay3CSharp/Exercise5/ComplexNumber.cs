using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    class ComplexNumber
    {
        public int Real { get; set; }
        public int Imaginary { get; set; }

        public int GetReal()
        {
            return Real;
        }

        public void SetReal(int r)
        {
            Real = r;
        }
        public int GetImaginary()
        {
            return Imaginary;
        }

        public void SetImaginary(int i)
        {
            Imaginary = i;
        }


        public ComplexNumber(int r, int i)
        {
            Real = r;
            Imaginary = i;
        }

        public override string ToString()
        {
            return "(" + Real.ToString() + "," + Imaginary.ToString() + "i)";
        }

        public double GetMagnitude()
        {
            return Math.Sqrt(Real*Real+Imaginary*Imaginary);
        }

        public void Add(ComplexNumber a)
        {
            Real += a.Real;
            Imaginary += a.Imaginary;
            
        }
    }
}
