using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Runtime.Remoting.Messaging;

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
        /// Пустой конструктор для ситуаций, в которых инициализация параметров на этапе создания объекта не требуется или невозможна
        /// </summary>
        public ComplexNumbers()
        {
            this.a = 0;
            this.b = 0;
            this.radius = 0;
            this.angle = 0;
        }

        /// <summary>
        /// Перегрузка оператора сложения (+)
        /// Сложение двух комплексных чисел в экспоненциальной форме
        /// </summary>
        /// <param name="z1">Первое комплексное число</param>
        /// <param name="z2">Второе комплексное число</param>
        /// <returns>Результат сложения комплексных чисел</returns>
        public static ComplexNumbers operator +(ComplexNumbers z1, ComplexNumbers z2)
        {
            double realPart = z1.a + z2.a;
            double imaginaryPart = z1.b + z2.b;
            return new ComplexNumbers(Math.Round(realPart,4), Math.Round(imaginaryPart,4));
        }

        /// <summary>
        /// Перегрузка оператора вычитания (-)
        /// Сложение двух комплексных чисел в экспоненциальной форме
        /// </summary>
        /// <param name="z1">Первое комплексное число</param>
        /// <param name="z2">Второе комплексное число</param>
        /// <returns>Результат вычитания комплексных чисел</returns>
        public static ComplexNumbers operator -(ComplexNumbers z1, ComplexNumbers z2)
        {
            double realPart = z1.a - z2.a; 
            double imaginaryPart = z1.b - z2.b; 
            return new ComplexNumbers(Math.Round(realPart,4), Math.Round(imaginaryPart,4));
        }

        /// <summary>
        /// Перегрузка оператора умножения (*)
        /// Умножение двух комплексных чисел в экспоненциальной форме
        /// </summary>
        /// <param name="z1">Первое комплексное число</param>
        /// <param name="z2">Второе комплексное число</param>
        /// <returns>Результат умножения комплексных чисел</returns>
        public static ComplexNumbers operator *(ComplexNumbers z1, ComplexNumbers z2)
        {
            double newRadius = z1.radius * z2.radius; 
            double newAngle = z1.angle + z2.angle;
            return new ComplexNumbers(Math.Round(newRadius,4), Math.Round(newAngle,4));
        }


        /// <summary>
        /// Перегрузка оператора деления (/)
        /// Деление двух комплексных чисел в экспоненциальной форме
        /// </summary>
        /// </summary>
        /// <param name="z1">Первое комплексное число</param>
        /// <param name="z2">Второе комплексное число</param>
        /// <returns>Результат деления комплексных чисел</returns>
        public static ComplexNumbers operator /(ComplexNumbers z1, ComplexNumbers z2)
        {
            double newRadius = z1.radius / z2.radius;
            double newAngle = z1.angle - z2.angle;

            return new ComplexNumbers(Math.Round(newRadius,4), Math.Round(newAngle,4));
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

