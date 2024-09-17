using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using ComplexNumbersLib;
namespace Complex_Interface_WPF
{
    public partial class Page3 : Page
    {
        //Конструктор класса, инициализирующий компонент и привязывающий событие нажатия кнопки
        public Page3()
        {
            InitializeComponent();
            // Привязываем событие нажатия кнопки "Do" к обработчику события
            Do.Click += Do_Click;
        }

        // Обработчик события выбора Декартовой системы координат
        //private void FromDescartes_RB_Checked(object sender, RoutedEventArgs e)
        //{
        //    // Навигация к странице ввода для Декартовой системы координат
        //    InputFrame.Navigate(new InputDescart());
        //}

        //// Обработчик события выбора Полярной системы координат в градусах
        //private void FromPolarDeg_RB_Checked(object sender, RoutedEventArgs e)
        //{
        //    // Навигация к странице ввода для Полярной системы координат (градусы)
        //    InputFrame.Navigate(new InputPolarDeg());
        //}

        //// Обработчик события выбора Полярной системы координат в радианах
        //private void FromPolarRad_RB_Checked(object sender, RoutedEventArgs e)
        //{
        //    // Навигация к странице ввода для Полярной системы координат (радианы)
        //    InputFrame.Navigate(new InputPolarRad());
        //}

        // Обработчик нажатия на кнопку "Do" для выполнения преобразования
        private void Do_Click(object sender, RoutedEventArgs e)
        {
            //    try
            //    {
            //        // Определяем систему координат, из которой происходит ввод
            //        var fromSystem = GetSelectedFromSystem();
            //        // Определяем целевую систему координат для преобразования
            //        var toSystem = GetSelectedToSystem();

            //        if (fromSystem == toSystem)
            //        {
            //            throw new Exception("Выбраны две одинаковые системы!");
            //        }
            //        // Получаем введенное комплексное число на основе выбранной системы координат
            //        var complexNumber = GetComplexNumber(fromSystem);

            //        Output_TB.Text = ConvertComplexNumber(complexNumber, toSystem);

            //    }
            //    catch (Exception ex)
            //    {
            //        // В случае ошибки показываем сообщение с текстом ошибки
            //        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
        }

        // Метод для определения выбранной системы координат для ввода
        //private string GetSelectedFromSystem()
        //{
        //    // Проверяем, какая система координат выбрана для ввода и возвращаем её название
        //    if (FromDescartes_RB.IsChecked == true) return "Descartes";
        //    if (FromPolarDeg_RB.IsChecked == true) return "PolarDegrees";
        //    if (FromPolarRad_RB.IsChecked == true) return "PolarRadians";
        //    // Если ни одна система не выбрана, выбрасываем исключение
        //    throw new Exception("Выберите систему координат для ввода.");
        //}

        //// Метод для определения целевой системы координат
        //private string GetSelectedToSystem()
        //{
        //    // Проверяем, какая система координат выбрана для преобразования и возвращаем её название
        //    if (ToDescartes_RB.IsChecked == true) return "Descartes";
        //    if (ToPolarDeg_RB.IsChecked == true) return "PolarDegrees";
        //    if (ToPolarRad_RB.IsChecked == true) return "PolarRadians";
        //    // Если ни одна система не выбрана, выбрасываем исключение
        //    throw new Exception("Выберите систему координат для вывода.");
        //}

        // Метод для получения комплексного числа на основе выбранной системы координат
        //private ComplexNumbers GetComplexNumber(string system)
        //{
        //    // Обработка для Декартовой системы координат
        //    if (system == "Descartes")
        //    {
        //        // Получаем данные из страницы ввода Декартовой системы
        //        var inputDescart = InputFrame.Content as InputDescart;
        //        if (inputDescart == null) throw new Exception("Пожалуйста, введите значения для Декартовой системы.");

        //        // Извлекаем действительную и мнимую части комплексного числа
        //        double real = double.Parse(inputDescart.Input_Re_TB.Text, CultureInfo.InvariantCulture);
        //        double imaginary = double.Parse(inputDescart.Input_Im_TB.Text, CultureInfo.InvariantCulture);
        //        return new ComplexNumbers(real, imaginary);
        //    }

        //    // Обработка для Полярной системы координат в градусах
        //    if (system == "PolarDegrees")
        //    {
        //        // Получаем данные из страницы ввода Полярной системы (градусы)
        //        var inputPolarDeg = InputFrame.Content as InputPolarDeg;
        //        if (inputPolarDeg == null) throw new Exception("Пожалуйста, введите значения для Полярной системы (градусы).");

        //        // Извлекаем радиус и угол в градусах
        //        double radius = double.Parse(inputPolarDeg.Input_RDeg_TB.Text, CultureInfo.InvariantCulture);
        //        double angleDegrees = double.Parse(inputPolarDeg.Input_CosDeg_TB.Text, CultureInfo.InvariantCulture);

        //        return new ComplexNumbers(radius, angleDegrees, false);
        //    }

        //    // Обработка для Полярной системы координат в радианах
        //    if (system == "PolarRadians")
        //    {
        //        // Получаем данные из страницы ввода Полярной системы (радианы)
        //        var inputPolarRad = InputFrame.Content as InputPolarRad;
        //        if (inputPolarRad == null) throw new Exception("Пожалуйста, введите значения для Полярной системы (радианы).");

        //        // Извлекаем радиус и угол в радианах
        //        double radius = double.Parse(inputPolarRad.Input_RRad_TB.Text, CultureInfo.InvariantCulture);
        //        double angleRadians = double.Parse(inputPolarRad.Input_CosRad_TB.Text, CultureInfo.InvariantCulture);
        //        return new ComplexNumbers(radius, angleRadians, true);
        //    }

        //    // Если система координат не определена, выбрасываем исключение
        //    throw new Exception("Не удалось определить систему координат.");
        //}

        //// Метод для преобразования комплексного числа в целевую систему координат и возврат результата в виде строки
        //private string ConvertComplexNumber(ComplexNumbers complexNumber, string toSystem)
        //{
        //    double a = complexNumber.a; // Действительная часть
        //    double b = complexNumber.b; // Мнимая часть

        //    // Преобразование в Декартову систему координат
        //    if (toSystem == "Descartes")
        //    {
        //        return complexNumber.Display();
        //    }
        //    // Преобразование в Полярную систему координат
        //    else if (toSystem == "PolarDegrees" || toSystem == "PolarRadians")
        //    {
        //        // Вычисляем радиус и угол
        //        double radius = complexNumber.radius;
        //        double angle = complexNumber.angle;

        //        if (toSystem == "PolarDegrees")
        //        {
        //            angle = angle * (180 / Math.PI);
        //        }
        //        return $"r = {radius}; angle = {angle}";
        //    }
        //    else
        //    {
        //        // Если целевая система координат не определена, выбрасываем исключение
        //        throw new Exception("Неизвестная целевая система координат.");
        //    }

        //}

        private void Do_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}


