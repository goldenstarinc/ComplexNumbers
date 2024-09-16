using ComplexNumbersLib;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestAdd()
        {
            // Подготовка
            ComplexNumbers num1 = new ComplexNumbers(2, 3);
            ComplexNumbers num2 = new ComplexNumbers(1, 4);

            // Действие
            ComplexNumbers result = num1 + num2;

            // Проверка
            Assert.Equal(3, result.a);
            Assert.Equal(7, result.b);
        }

        [Fact]
        public void TestSubtract()
        {
            // Подготовка
            ComplexNumbers num1 = new ComplexNumbers(2, 3);
            ComplexNumbers num2 = new ComplexNumbers(1, 4);

            // Действие
            ComplexNumbers result = num1 - num2;

            // Проверка
            Assert.Equal(1, result.a);
            Assert.Equal(-1, result.b);
        }

        [Fact]
        public void TestMultiply()
        {
            // Подготовка
            ComplexNumbers num1 = new ComplexNumbers(1, 3);
            ComplexNumbers num2 = new ComplexNumbers(1, 4);

            // Действие
            ComplexNumbers result = num1 * num2;

            // Проверка
            Assert.Equal(-11, result.a, 2);
            Assert.Equal(7, result.b, 2);
        }

        [Fact]
        public void TestDivide()
        {
            // Подготовка
            ComplexNumbers num1 = new ComplexNumbers(2, 3);
            ComplexNumbers num2 = new ComplexNumbers(1, 4);

            // Действие
            ComplexNumbers result = num1 / num2;

            // Проверка
            Assert.Equal(0.82, result.a, 2);
            Assert.Equal(-0.29, result.b, 2);
        }

        [Fact]
        public void TestAdd2()
        {
            // Подготовка данных
            ComplexNumbers num1 = new ComplexNumbers(4538, 6453);
            ComplexNumbers num2 = new ComplexNumbers(498, 7385);

            // Действие
            ComplexNumbers result = num1 + num2;

            // Проверка
            Assert.Equal(5036, result.a);
            Assert.Equal(13838, result.b);
        }

        [Fact]
        public void TestSubtract2()
        {
            // Подготовка
            ComplexNumbers num1 = new ComplexNumbers(4538, 6453);
            ComplexNumbers num2 = new ComplexNumbers(498, 7385);

            // Действие
            ComplexNumbers result = num1 - num2;

            // Проверка
            Assert.Equal(4040, result.a);
            Assert.Equal(-932, result.b);
        }

        [Fact]
        public void TestMultiply2()
        {
            // Подготовка
            ComplexNumbers num1 = new ComplexNumbers(4538, 6453);
            ComplexNumbers num2 = new ComplexNumbers(498, 7385);

            // Действие
            ComplexNumbers result = num1 * num2;

            // Проверка
            Assert.Equal(-45395481, result.a);
            Assert.Equal(36726724, result.b);
        }

        [Fact]
        public void TestDivide2()
        {
            // Подготовка
            ComplexNumbers num1 = new ComplexNumbers(4538, 6453);
            ComplexNumbers num2 = new ComplexNumbers(498, 7385);

            // Действие
            ComplexNumbers result = num1 / num2;

            // Проверка
            Assert.Equal(0.9111, result.a, 4);  // Точность до четвертого знака
            Assert.Equal(-0.5531, result.b, 4);
        }
    }
}
