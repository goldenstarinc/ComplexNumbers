using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class ComplexNumbers
    {
        public double a;
        public double b;
        public double radius;
        public double angle;

        public ComplexNumbers(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public ComplexNumbers(double radius, double angle, bool isInRadians)
        {
            this.radius = radius;
            this.angle = angle;

            if (!isInRadians)
            {
                angle = angle * (Math.PI / 180);
            }

            this.a = radius * Math.Cos(angle);
            this.b = radius * Math.Sin(angle);
        }

        public ComplexNumbers Add(ComplexNumbers other)
        {
            double realPart = this.a + other.a;
            double imaginaryPart = this.b + other.b;
            return new ComplexNumbers(realPart, imaginaryPart);
        }

        public ComplexNumbers Subtract(ComplexNumbers other)
        {
            double realPart = this.a - other.a;
            double imaginaryPart = this.b - other.b;
            return new ComplexNumbers(realPart, imaginaryPart);
        }

        public ComplexNumbers Multiply(ComplexNumbers other)
        {
            double realPart = this.a * other.a - this.b * other.b;
            double imaginaryPart = this.a * other.b + this.b * other.a;
            return new ComplexNumbers(realPart, imaginaryPart);
        }

        public ComplexNumbers Divide(ComplexNumbers other)
        {
            double denominator = other.a * other.a + other.b * other.b;
            double realPart = (this.a * other.a + this.b * other.b) / denominator;
            double imaginaryPart = (this.b * other.a - this.a * other.b) / denominator;
            return new ComplexNumbers(realPart, imaginaryPart);
        }

        public void Display()
        {
            Console.WriteLine($"Комплексное число: {a} + {b}i");
        }
    }
}
