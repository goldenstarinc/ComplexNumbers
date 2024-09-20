using ComplexNumbersLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Complex_Interface_WPF
{
    /// <summary>
    /// Логика взаимодействия для ExpPolarDeg.xaml
    /// </summary>
    public partial class ExpPolarDeg : Page
    {
        public ExpPolarDeg()
        {
            InitializeComponent();
        }

        private void R_Set_Checked(object sender, RoutedEventArgs e)
        {
            ExpPolarDegFrame.Navigate(new RealInput_Exponentiation());
        }

        private void C_Set_Checked(object sender, RoutedEventArgs e)
        {
            ExpPolarDegFrame.Navigate(new ComplexInput_Exponentiation());
        }

        private void C_Set_PolarDeg_Checked(object sender, RoutedEventArgs e)
        {
            ExpPolarDegFrame.Navigate(new ComplexPolarDegInput_Exponentiation());
        }

        private void C_Set_PolarRad_Checked(object sender, RoutedEventArgs e)
        {
            ExpPolarDegFrame.Navigate(new ComplexPolarRadInput_Exponentiation());
        }

        private void Do_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                // Пытаемся прочитать радиус и угол из текстбоксов
                if (!double.TryParse(Num_RExpPolarDeg_TB.Text, out double radius) ||
                    !double.TryParse(Num_AExpPolarDeg_TB.Text, out double angle))
                {
                    ResultExpPolarDeg_TB.Text = "Ошибка: Введите корректные числовые значения.";
                    return; // Прерываем выполнение метода при некорректном вводе
                }

                ComplexNumbers z = new ComplexNumbers(radius, angle, false); // Создаем комплексное число z
                ComplexNumbers exponent = null;

                if (R_Set.IsChecked == true)
                {
                    var input = ExpPolarDegFrame.Content as RealInput_Exponentiation;
                    // Реальная степень
                    double realPart2 = double.Parse(input.Real_TB.Text);
                    exponent = new ComplexNumbers(realPart2, 0, true);
                }
                else if (C_Set.IsChecked == true)
                {
                    var input = ExpPolarDegFrame.Content as ComplexInput_Exponentiation;
                    // Комплексное число (декартова форма)
                    double realPart2 = double.Parse(input.Num_Re_TB.Text);
                    double imaginaryPart2 = double.Parse(input.Num_Im_TB.Text);
                    exponent = new ComplexNumbers(realPart2, imaginaryPart2);
                }
                else if (C_Set_PolarDeg.IsChecked == true)
                {
                    var input = ExpPolarDegFrame.Content as ComplexPolarDegInput_Exponentiation;
                    // Комплексное число (полярная форма в градусах)
                    double rPolarDeg = double.Parse(input.RPolarDeg_TB.Text);
                    double anglePolarDeg = double.Parse(input.AnglePolarDeg_TB.Text);
                    exponent = new ComplexNumbers(rPolarDeg, anglePolarDeg, false);
                }
                else if (C_Set_PolarRad.IsChecked == true)
                {
                    var input = ExpPolarDegFrame.Content as ComplexPolarRadInput_Exponentiation;
                    // Комплексное число (полярная форма в радианах)
                    double rPolarRad = double.Parse(input.RPolarRad_TB.Text);
                    double anglePolarRad = double.Parse(input.AnglePolarRad_TB.Text);
                    exponent = new ComplexNumbers(rPolarRad, anglePolarRad, true);
                }

                // Возведение в степень
                if (exponent != null)
                {
                    ComplexNumbers powResult = z ^ exponent;
                    ResultExpPolarDeg_TB.Text = powResult.Display(); // Используем метод Display для отображения результата
                }
            }
            catch (Exception ex)
            {
                ResultExpPolarDeg_TB.Text = $"Ошибка: {ex.Message}";
            }
        }
        private void DelExpPolarDeg_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void DelExpPolarDeg_Click_1(object sender, RoutedEventArgs e)
        {
            // Очищаем все TextBox в текущем Page
            Num_RExpPolarDeg_TB.Text = string.Empty;
            Num_AExpPolarDeg_TB.Text = string.Empty;
            ResultExpPolarDeg_TB.Text = string.Empty;
        }
    }
}
