using Newtonsoft.Json.Bson;
using System.Diagnostics;

namespace MindboxLib.Tests
{
    [TestClass]
    public class UnitTests
    {
        /// <summary>
        /// Проверка на равенство двух чисел с плавающей точкой в пределах допустимой погрешности
        /// </summary>
        /// <param name="x">Первое число</param>
        /// <param name="y">Второе число</param>
        /// <param name="acceptableVariance">Допустимая погрешность</param>
        /// <returns>true, если числа равны</returns>
        private bool IsApproximatelyEqual(double x, double y, double acceptableVariance)
        {
            double variance = x > y ? x - y : y - x;
            return variance < acceptableVariance;
        }

        /// <summary>
        /// Базовый тест вычисления площади круга
        /// </summary>
        [TestMethod]
        public void BasicCircle()
        {
            // Набор окружностей с известной площадью
            Dictionary<double, double> radiusAreas = new()
            {
                { 1, 3.14 },
                { 2, 12.57 },
                { 5, 78.54 },
                { 8.65, 235.06 },
            };
            foreach (var radiusArea in radiusAreas)
            {
                Circle circle = new(radiusArea.Key);
                Debug.WriteLine($"{circle.Area} ==> {radiusArea.Value}");
                Assert.IsTrue(IsApproximatelyEqual(circle.Area, radiusArea.Value, 0.01));
            }
        }
        
        /// <summary>
        /// Базовый тест построения и вычисления площади треугольника
        /// </summary>
        [TestMethod]
        public void BasicTriangle()
        {
            // Набор длин сторон треугольников с известной площадью
            List<(double a, double b, double c, double area)> triangles = new()
            {
                (3, 4, 5, 6),
                (7, 8, 9, 26.83),
                (8, 14, 21, 32.99)
            };
            foreach(var triSides in triangles)
            {
                Triangle triangle = new(triSides.a, triSides.b, triSides.c);
                Debug.WriteLine($"{triangle.Area} ==> {triSides.area}");
                Assert.IsTrue(IsApproximatelyEqual(triangle.Area, triSides.area, 0.01));
            }
            // Проверка на то, что попытка создать несуществующий треугольник выбрасывает исключение
            Assert.ThrowsException<ShapeException>(() => new Triangle(1, 2, 4));
        }
    }
}