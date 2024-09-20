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
        private double a; // Реальная часть комплексного числа
        private double b; // Мнимая часть комплексного числа
        private double radius; // Радиус числа в полярной форме
        private double angle; // Угол числа в полярной форме

        /// <summary>
        /// Конструктор, инициализирующий комплексное число через его декартовы координаты (реальная и мнимая части).
        /// </summary>
        /// <param name="a">Реальная часть комплексного числа.</param>
        /// <param name="b">Мнимая часть комплексного числа.</param>
        public ComplexNumbers(double a, double b)
        {
            this.a = a; // Инициализация реальной части
            this.b = b; // Инициализация мнимой части

            radius = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            angle = Math.Atan2(b, a);
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
            a = radius * Math.Cos(angle); // Вычисление реальной части
            b = radius * Math.Sin(angle); // Вычисление мнимой части
        }
        /// <summary>
        /// Пустой конструктор для ситуаций, в которых инициализация параметров на этапе создания объекта не требуется или невозможна
        /// </summary>
        public ComplexNumbers()
        {
            a = 1;
            b = 1;
            angle = Math.Atan2(b, a);
            radius = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }

        /// <summary>
        /// Сложение двух комплексных чисел в экспоненциальной форме
        /// </summary>
        /// <param name="z2">Второе комплексное число</param>
        /// <returns>Результат сложения комплексных чисел</returns>
        public ComplexNumbers Add(ComplexNumbers z2)
        {
            double realPart = this.a + z2.a;
            double imaginaryPart = this.b + z2.b;
            return new ComplexNumbers(realPart, imaginaryPart);
        }

        /// <summary>
        /// Вычитание комплексных чисел
        /// </summary>
        /// <param name="z2">Второе комплексное число</param>
        /// <returns>Результат вычитания комплексных чисел</returns>
        public ComplexNumbers Subtract(ComplexNumbers z2)
        {
            double realPart = this.a - z2.a;
            double imaginaryPart = this.b - z2.b;
            return new ComplexNumbers(realPart, imaginaryPart);
        }

        /// <summary>
        /// Умножение двух комплексных чисел
        /// </summary>
        /// <param name="z2">Второе комплексное число</param>
        /// <returns>Результат умножения комплексных чисел</returns>
        public ComplexNumbers Multiply(ComplexNumbers z2)
        {
            double newRadius = this.radius * z2.radius;
            double newAngle = this.angle + z2.angle;
            return new ComplexNumbers(newRadius, newAngle, true);
        }


        /// <summary>
        /// Деление двух комплексных чисел в экспоненциальной форме
        /// </summary>
        /// <param name="z2">Второе комплексное число</param>
        /// <returns>Результат деления комплексных чисел</returns>
        public ComplexNumbers Divide(ComplexNumbers z2)
        {
            double newRadius = this.radius / z2.radius;
            double newAngle = this.angle - z2.angle;
            return new ComplexNumbers(newRadius, newAngle, true);
        }

        /// <summary>
        /// Метод для возведения комплексного числа в степень
        /// </summary>
        /// <param name="z">Комплексное число</param>
        /// <param name="exponent">Целая степень для возведения</param>
        /// <returns>Результат возведения комплексного числа в степень</returns>

        public static ComplexNumbers Pow(ComplexNumbers z, int exponent)
        {
            double newRadius = Math.Pow(z.radius, exponent);
            double newAngle = z.angle * exponent;
            return new ComplexNumbers(newRadius, newAngle, true);
        }

        /// <summary>
        /// Метод для возведения одного комплексного числа в степень другого комплексного числа
        /// </summary>
        /// <param name="z1">Основание (комплексное число)</param>
        /// <param name="z2">Показатель степени (комплексное число)</param>
        /// <returns>Результат возведения в степень</returns>
        public static ComplexNumbers Pow(ComplexNumbers z1, ComplexNumbers z2)
        {
            // Вычисляем логарифм от z1 (ln(z1))
            double lnRadius = Math.Log(z1.radius);
            double angleLn = z1.angle;

            // Умножаем z2 на логарифм z1
            double realPart = z2.a * lnRadius - z2.b * angleLn; // Реальная часть произведения
            double imaginaryPart = z2.a * angleLn + z2.b * lnRadius; // Мнимая часть произведения

            // Преобразуем результат в экспоненциальную форму
            double newRadius = Math.Exp(realPart); // Радиус новой комплексной экспоненты
            double newAngle = imaginaryPart; // Угол новой комплексной экспоненты

            return new ComplexNumbers(newRadius, newAngle, true);
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
            return z1.Add(z2); 
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
            return z1.Subtract(z2);
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
            return z1.Multiply(z2);
        }

        /// <summary>
        /// Перегрузка оператора деления (/)
        /// Деление двух комплексных чисел в экспоненциальной форме
        /// </summary>
        /// <param name="z1">Первое комплексное число</param>
        /// <param name="z2">Второе комплексное число</param>
        /// <returns>Результат деления комплексных чисел</returns>
        public static ComplexNumbers operator /(ComplexNumbers z1, ComplexNumbers z2)
        {
            return z1.Divide(z2);
        }

        /// <summary>
        /// Перегрузка оператора возведения в степень (^)
        /// Возведение комплексного числа в степень вещественного числа
        /// </summary>
        /// <param name="z">Комплексное число</param>
        /// <param name="exponent">Степень в виде вещественного числа</param>
        /// <returns>Результат возведения комплексного числа в степень вещественного числа</returns>
        public static ComplexNumbers operator ^(ComplexNumbers z, int exponent)
        {
            return Pow(z, exponent);
        }

        /// <summary>
        /// Перегрузка оператора возведения в степень (^)
        /// Возведение комплексного числа в степень указанного комплексного числа
        /// </summary>
        /// <param name="z1">Первое комплексное число</param>
        /// <param name="z2">Второе комплексное число</param>
        /// <returns>Результат возведения комплексного числа в указанного степень комплексного числа</returns>
        public static ComplexNumbers operator ^(ComplexNumbers z1, ComplexNumbers z2)
        {
            return Pow(z1, z2);
        }


        /// <summary>
        /// Возвращает реальную часть комплексного числа
        /// </summary>
        /// <returns>Реальная часть комплексного числа</returns>
        public double getRealPart()
        {
            return a;
        }

        /// <summary>
        /// Возвращает мнимую часть комплексного числа
        /// </summary>
        /// <returns>Мнимая часть комплексного числа</returns>
        public double getImaginaryPart()
        {
            return b;
        }

        /// <summary>
        /// Возвращает модуль комплексного числа
        /// </summary>
        /// <returns>Модуль комплексного числа</returns>
        public double getRadius()
        {
            return radius;
        }

        /// <summary>
        /// Возвращает угол комплексного числа
        /// </summary>
        /// <returns>Угол комплексного числа</returns>
        public double getAngle()
        {
            return angle;
        }

        /// <summary>
        /// Переопределяет метод ToString для представления комплексного числа в виде строки
        /// </summary>
        /// <returns>Метод Display, возвращающий комплексное число в виде строки в декартовой форме</returns>
        public override string ToString()
        {
            return Display();
        }

        /// <summary>
        /// Возвращает комплексное число в виде строки в декартовой форме.
        /// </summary>
        public string Display()
        {
            double realPart = Math.Round(a, 3);
            double imaginaryPart = Math.Round(b, 3);
            if (b < 0)
                return $"{realPart} - {Math.Abs(imaginaryPart)}i";
            else if (b == 0)
                return $"{realPart}";
            else if (a == 0)
                return $"{imaginaryPart}i";
            return $"{realPart} + {imaginaryPart}i"; // Выводит комплексное число на консоль
        }

        /// <summary>
        /// Возвращает комплексное число в виде строки в полярной форме.
        /// </summary>
        public string Display(bool isInRadians, bool isExp)
        {
            double r = radius;
            double phi = angle;
            string result = "";
            if (!isInRadians)
                phi = phi * (180 / Math.PI);

            if (!isExp)
                result = $"{Math.Round(r, 3)}r * (cos({Math.Round(phi, 3)}) + i * sin(({Math.Round(phi, 3)}))";
            else
                result = $"{Math.Round(r, 3)} * e ^ (i * {Math.Round(phi, 3)})";
            return result;
        }


        /// <summary>
        /// Переопределяет метод Equals для сравнения двух комплексных чисел
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>true - если данное комплексное число равно переданному объекту, в противном случае false</returns>
        public override bool Equals(object obj)
        {
            // Проверка на null и правильный тип объекта
            if (obj == null || !(obj is ComplexNumbers))
                return false;

            ComplexNumbers num2 = obj as ComplexNumbers;

            // Проверяем на равенство реальных и мнимых частей
            if (this.a == num2.getRealPart() && this.b == num2.getImaginaryPart())
                return true;

            return false;
        }

    }
}

