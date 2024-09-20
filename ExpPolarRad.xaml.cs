using ComplexNumbersLib;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Complex_Interface_WPF
{
    public partial class ExpPolarRad : Page
    {
        public ExpPolarRad()
        {
            InitializeComponent();
        }

        private void R_Set_Checked(object sender, RoutedEventArgs e)
        {
            ExpPolarRadFrame.Navigate(new RealInput_Exponentiation());
        }

        private void C_Set_Checked(object sender, RoutedEventArgs e)
        {
            ExpPolarRadFrame.Navigate(new ComplexInput_Exponentiation());
        }

        private void C_Set_PolarDeg_Checked(object sender, RoutedEventArgs e)
        {
            ExpPolarRadFrame.Navigate(new ComplexPolarDegInput_Exponentiation());
        }

        private void C_Set_PolarRad_Checked(object sender, RoutedEventArgs e)
        {
            ExpPolarRadFrame.Navigate(new ComplexPolarRadInput_Exponentiation());
        }

        private void Do_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                // Пытаемся прочитать радиус и угол из текстбоксов
                if (!double.TryParse(Num_RExpPolarRad_TB.Text, out double radius) ||
                    !double.TryParse(Num_AExpPolarRad_TB.Text, out double angle))
                {
                    ResultExpPolarRad_TB.Text = "Ошибка: Введите корректные числовые значения.";
                    return; // Прерываем выполнение метода при некорректном вводе
                }

                ComplexNumbers z = new ComplexNumbers(radius, angle, true); // Создаем комплексное число z
                ComplexNumbers exponent = null;

                if (R_Set.IsChecked == true)
                {
                    var input = ExpPolarRadFrame.Content as RealInput_Exponentiation;
                    // Реальная степень
                    double realPart2 = double.Parse(input.Real_TB.Text);
                    exponent = new ComplexNumbers(realPart2, 0, true);
                }
                else if (C_Set.IsChecked == true)
                {
                    var input = ExpPolarRadFrame.Content as ComplexInput_Exponentiation;
                    // Комплексное число (декартова форма)
                    double realPart2 = double.Parse(input.Num_Re_TB.Text);
                    double imaginaryPart2 = double.Parse(input.Num_Im_TB.Text);
                    exponent = new ComplexNumbers(realPart2, imaginaryPart2);
                }
                else if (C_Set_PolarDeg.IsChecked == true)
                {
                    var input = ExpPolarRadFrame.Content as ComplexPolarDegInput_Exponentiation;
                    // Комплексное число (полярная форма в градусах)
                    double rPolarDeg = double.Parse(input.RPolarDeg_TB.Text);
                    double anglePolarDeg = double.Parse(input.AnglePolarDeg_TB.Text);
                    exponent = new ComplexNumbers(rPolarDeg, anglePolarDeg, false);
                }
                else if (C_Set_PolarRad.IsChecked == true)
                {
                    var input = ExpPolarRadFrame.Content as ComplexPolarRadInput_Exponentiation;
                    // Комплексное число (полярная форма в радианах)
                    double rPolarRad = double.Parse(input.RPolarRad_TB.Text);
                    double anglePolarRad = double.Parse(input.AnglePolarRad_TB.Text);
                    exponent = new ComplexNumbers(rPolarRad, anglePolarRad, true);
                }

                // Возведение в степень
                if (exponent != null)
                {
                    ComplexNumbers powResult = z ^ exponent;
                    ResultExpPolarRad_TB.Text = powResult.Display(); // Используем метод Display для отображения результата
                }
            }
            catch (Exception ex)
            {
                ResultExpPolarRad_TB.Text = $"Ошибка: {ex.Message}";
            }
        }
        private void DelExpPolarRad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelExpPolarRad_Click_1(object sender, RoutedEventArgs e)
        {
            // Очистка текстовых полей
            Num_RExpPolarRad_TB.Text = string.Empty;
            Num_AExpPolarRad_TB.Text = string.Empty;
            ResultExpPolarRad_TB.Text = string.Empty;
        }
    }
}

