using ComplexNumbersLib;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Complex_Interface_WPF
{
    public partial class ExpDescartes : Page
    {
        public ExpDescartes()
        {
            InitializeComponent();
        }

        private void R_Set_Checked(object sender, RoutedEventArgs e)
        {
            DescFrame.Navigate(new RealInput_Exponentiation());
        }

        private void C_Set_Checked(object sender, RoutedEventArgs e)
        {
            DescFrame.Navigate(new ComplexInput_Exponentiation());
        }

        private void C_Set_PolarDeg_Checked(object sender, RoutedEventArgs e)
        {
            DescFrame.Navigate(new ComplexPolarDegInput_Exponentiation());
        }

        private void C_Set_PolarRad_Checked(object sender, RoutedEventArgs e)
        {
            DescFrame.Navigate(new ComplexPolarRadInput_Exponentiation());
        }

        private void Do_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                // Пытаемся прочитать реальную и мнимую части из текстбоксов
                if (!double.TryParse(Num_Re_TB.Text, out double realPart) ||
                    !double.TryParse(Num_Im_TB.Text, out double imaginaryPart))
                {
                    ResultExpDesc_TB.Text = "Ошибка: Введите корректные числовые значения.";
                    return; // Прерываем выполнение метода при некорректном вводе
                }

                ComplexNumbers z = new ComplexNumbers(realPart, imaginaryPart); // Создаем комплексное число z
                ComplexNumbers exponent = null;

                if (R_Set.IsChecked == true)
                {
                    var input = DescFrame.Content as RealInput_Exponentiation;
                    // Реальная степень
                    double realPart2 = double.Parse(input.Real_TB.Text);
                    exponent = new ComplexNumbers(realPart2, 0, true);
                }
                else if (C_Set.IsChecked == true)
                {
                    var input = DescFrame.Content as ComplexInput_Exponentiation;
                    // Комплексное число (декартова форма)
                    double realPart2 = double.Parse(input.Num_Re_TB.Text);
                    double imaginaryPart2 = double.Parse(input.Num_Im_TB.Text);
                    exponent = new ComplexNumbers(realPart2, imaginaryPart2);
                }
                else if (C_Set_PolarDeg.IsChecked == true)
                {
                    var input = DescFrame.Content as ComplexPolarDegInput_Exponentiation;
                    // Комплексное число (полярная форма в градусах)
                    double radius = double.Parse(input.RPolarDeg_TB.Text);
                    double angle = double.Parse(input.AnglePolarDeg_TB.Text);
                    exponent = new ComplexNumbers(radius, angle, false);
                }
                else if (C_Set_PolarRad.IsChecked == true)
                {
                    var input = DescFrame.Content as ComplexPolarRadInput_Exponentiation;
                    // Комплексное число (полярная форма в радианах)
                    double radius = double.Parse(input.RPolarRad_TB.Text);
                    double angle = double.Parse(input.AnglePolarRad_TB.Text);
                    exponent = new ComplexNumbers(radius, angle, true);
                }

                // Возведение в степень
                if (exponent != null)
                {
                    ComplexNumbers powResult = z ^ exponent;
                    ResultExpDesc_TB.Text = powResult.Display(); // Используем метод Display для отображения результата
                }
            }
            catch (Exception ex)
            {
                ResultExpDesc_TB.Text = $"Ошибка: {ex.Message}";
            }
        }
        private void DelExpDesc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelDescartes_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем все TextBox в текущем Page
            Num_Re_TB.Text = string.Empty;
            Num_Im_TB.Text = string.Empty;
            ResultExpDesc_TB.Text = string.Empty;
        }
    }
}


