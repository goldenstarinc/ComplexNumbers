using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Program
    {
        static void Main(string[] args)
        {

            ComplexNumbers num1 = new ComplexNumbers(3, 4);
            ComplexNumbers num2 = new ComplexNumbers(1, 2);

            ComplexNumbers sum = num1.Add(num2);
            sum.Display();

            ComplexNumbers diff = num1.Subtract(num2);
            diff.Display();

            ComplexNumbers prod = num1.Multiply(num2);
            prod.Display();

            ComplexNumbers quotient = num1.Divide(num2);
            quotient.Display();

            Console.ReadKey();
        }
    }
}
