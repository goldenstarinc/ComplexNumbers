using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ComplexNumbersLib
{
    /// <summary>
    /// Класс для работы с комплексными числами, включая операции сложения, вычитания, умножения и деления.
    /// </summary>
    public class ComplexNumbers
    {
        // Поля класса, представляющие реальную и мнимую части числа
        public double a; // Реальная часть комплексного числа
        public double b; // Мнимая часть комплексного числа
        public double radius; // Радиус числа в полярной форме
        public double angle; // Угол числа в полярной форме

        /// <summary>
        /// Конструктор, инициализирующий комплексное число через его декартовы координаты (реальная и мнимая части).
        /// </summary>
        /// <param name="a">Реальная часть комплексного числа.</param>
        /// <param name="b">Мнимая часть комплексного числа.</param>
        public ComplexNumbers(double a, double b)
        {
            this.a = a; // Инициализация реальной части
            this.b = b; // Инициализация мнимой части

            this.radius = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            this.angle = Math.Atan2(b, a);
        }

        /// <summary>
        /// Конструктор, инициализирующий комплексное число через его полярные координаты (радиус и угол).
        /// </summary>
        /// <param name="radius">Радиус (модуль) комплексного числа.</param>
        /// <param name="angle">Угол (аргумент) комплексного числа.</param>
        /// <param name="isInRadians">Флаг, указывающий, задан ли угол в радианах (если false, угол в градусах).</param>
        public ComplexNumbers(double radius, double angle, bool isInRadians)
        {
            // Если угол задан не в радианах, выполняется преобразование из градусов в радианы
            if (!isInRadians)
            {
                angle = angle * (Math.PI / 180); // Преобразование угла из градусов в радианы
            }

            this.radius = radius; // Инициализация радиуса
            this.angle = angle; // Инициализация угла

            // Преобразование из полярной формы в декартовую: 
            // a = r * cos(θ), b = r * sin(θ)
            this.a = radius * Math.Cos(angle); // Вычисление реальной части
            this.b = radius * Math.Sin(angle); // Вычисление мнимой части
        }

        /// <summary>
        /// Метод для сложения двух комплексных чисел.
        /// </summary>
        /// <param name="other">Комплексное число, которое нужно сложить с текущим.</param>
        /// <returns>Новый объект ComplexNumbers, представляющий результат сложения.</returns>
        public ComplexNumbers Add(ComplexNumbers other)
        {
            // Сложение реальных и мнимых частей
            double realPart = this.a + other.a; // Реальная часть суммы
            double imaginaryPart = this.b + other.b; // Мнимая часть суммы
            return new ComplexNumbers(Math.Round(realPart, 4), Math.Round(imaginaryPart, 4)); // Возвращает новое комплексное число
        }

        /// <summary>
        /// Метод для вычитания одного комплексного числа из другого.
        /// </summary>
        /// <param name="other">Комплексное число, которое нужно вычесть из текущего.</param>
        /// <returns>Новый объект ComplexNumbers, представляющий результат вычитания.</returns>
        public ComplexNumbers Subtract(ComplexNumbers other)
        {
            // Вычитание реальных и мнимых частей
            double realPart = this.a - other.a; // Реальная часть разности
            double imaginaryPart = this.b - other.b; // Мнимая часть разности
            return new ComplexNumbers(Math.Round(realPart, 4), Math.Round(imaginaryPart, 4)); // Возвращает новое комплексное число
        }

        /// <summary>
        /// Метод для умножения двух комплексных чисел.
        /// </summary>
        /// <param name="other">Комплексное число, на которое нужно умножить текущее.</param>
        /// <returns>Новый объект ComplexNumbers, представляющий результат умножения.</returns>
        public ComplexNumbers Multiply(ComplexNumbers other)
        {
            // Умножение по формуле: (a + bi) * (c + di) = (ac - bd) + (ad + bc)i
            double realPart = this.a * other.a - this.b * other.b; // Вычисление реальной части произведения
            double imaginaryPart = this.a * other.b + this.b * other.a; // Вычисление мнимой части произведения
            return new ComplexNumbers(Math.Round(realPart, 4), Math.Round(imaginaryPart, 4)); // Возвращает новое комплексное число
        }

        /// <summary>
        /// Метод для деления текущего комплексного числа на другое.
        /// </summary>
        /// <param name="other">Комплексное число, на которое нужно разделить текущее.</param>
        /// <returns>Новый объект ComplexNumbers, представляющий результат деления.</returns>
        public ComplexNumbers Divide(ComplexNumbers other)
        {
            // Деление по формуле: (a + bi) / (c + di) = ((ac + bd) + (bc - ad)i) / (c² + d²)
            double denominator = other.a * other.a + other.b * other.b; // Вычисление знаменателя (c² + d²)
            double realPart = (this.a * other.a + this.b * other.b) / denominator; // Вычисление реальной части частного
            double imaginaryPart = (this.b * other.a - this.a * other.b) / denominator; // Вычисление мнимой части частного
            return new ComplexNumbers(Math.Round(realPart, 4), Math.Round(imaginaryPart, 4)); // Возвращает новое комплексное число
        }

        /// <summary>
        /// Выводит комплексное число на консоль в виде строки.
        /// </summary>
        public string Display()
        {
            if (b < 0)
                return $"{a} - {Math.Abs(b)}i";
            return $"{a} + {b}i"; // Выводит комплексное число на консоль
        }
    }
}

