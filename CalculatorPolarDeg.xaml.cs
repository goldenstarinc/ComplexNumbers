﻿using System;
using System.Windows;
using System.Windows.Controls;
using ComplexNumbersLib;

namespace Complex_Interface_WPF
{
    /// <summary>
    /// Класс для реализации страницы калькулятора, работающего с полярными координатами в градусах.
    /// </summary>
    public partial class CalculatorPolarDeg : Page
    {
        /// <summary>
        /// Конструктор класса. Инициализирует компоненты и задает обработчики событий для кнопок.
        /// </summary>
        public CalculatorPolarDeg()
        {
            InitializeComponent(); // Инициализирует компоненты страницы (элементы управления и т.д.)
            // Устанавливает обработчики кликов для кнопок
            AddPolarDeg.Click += PerformCalculation2; // Кнопка сложения
            SubPolarDeg.Click += PerformCalculation2; // Кнопка вычитания
            MultPolarDeg.Click += PerformCalculation2; // Кнопка умножения
            DivPolarDeg.Click += PerformCalculation2; // Кнопка деления
            RestartPolarDeg.Click += ClearFields2; // Кнопка очистки полей ввода
        }

        /// <summary>
        /// Обрабатывает нажатия на кнопки для выполнения вычислений.
        /// </summary>
        /// <param name="sender">Объект, вызвавший это событие (например, кнопка).</param>
        /// <param name="e">Аргументы события.</param>
        private void PerformCalculation2(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение значений из текстовых полей
                double r1 = double.Parse(Num1_RDeg_TB.Text); // Радиус первого числа
                double theta1 = double.Parse(Num1_CosDeg_TB.Text); // Угол первого числа в градусах
                double r2 = double.Parse(Num2_RDeg_TB.Text); // Радиус второго числа
                double theta2 = double.Parse(Num2_CosDeg_TB.Text); // Угол второго числа в градусах

                // Преобразование полярных координат в комплексные числа
                ComplexNumbers z1 = new ComplexNumbers(r1, theta1, false);
                ComplexNumbers z2 = new ComplexNumbers(r2, theta2, false);

                ComplexNumbers result = null; // Переменная для хранения результата

                // Выполнение математической операции в зависимости от нажатой кнопки
                if (sender == AddPolarDeg)
                {
                    result = z1.Add(z2); // Выполнение сложения двух комплексных чисел
                }
                else if (sender == SubPolarDeg)
                {
                    result = z1.Subtract(z2); // Выполнение вычитания второго числа из первого
                }
                else if (sender == MultPolarDeg)
                {
                    result = z1.Multiply(z2); // Выполнение умножения двух комплексных чисел
                }
                else if (sender == DivPolarDeg)
                {
                    result = z1.Divide(z2); // Выполнение деления первого числа на второе
                }

                // Отображение результата в текстовом поле
                ResultPolarDeg_TB.Text = result.Display();
            }
            catch (Exception ex)
            {
                // Обработка исключений и отображение сообщения об ошибке
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Очищает все текстовые поля на странице.
        /// </summary>
        /// <param name="sender">Объект, вызвавший это событие (например, кнопка).</param>
        /// <param name="e">Аргументы события.</param>
        private void ClearFields2(object sender, RoutedEventArgs e)
        {
            // Очистка текстовых полей ввода
            Num1_RDeg_TB.Text = ""; // Радиус первого числа
            Num1_CosDeg_TB.Text = ""; // Угол первого числа в градусах
            Num2_RDeg_TB.Text = ""; // Радиус второго числа
            Num2_CosDeg_TB.Text = ""; // Угол второго числа в градусах
            ResultPolarDeg_TB.Text = ""; // Очистка текстового поля результата
        }
    }
}

