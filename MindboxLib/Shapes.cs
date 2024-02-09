namespace MindboxLib
{
    /// <summary>
    /// Общий интерфейс для всех фигур
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Площадь фигуры
        /// </summary>
        public double Area { get; }
    }



    /// <summary>
    /// Круг
    /// </summary>
    public class Circle : IShape
    {
        /// <summary>
        /// Радиус круга
        /// </summary>
        public double Radius { get; set; }
        /// <summary>
        /// Площадь круга
        /// </summary>
        public double Area => Math.PI * Radius * Radius;

        public Circle(double radius) 
        {
            Radius = radius;
        }

        public override string ToString() => $"Окружность, радиус: {Radius}";
    }



    /// <summary>
    /// Треугольник, определённый по трём сторонам
    /// </summary>
    public class Triangle : IShape
    {
        /// <summary>
        /// Сторона треугольника (для прямоугольного треугольника - меньший катет)
        /// </summary>
        public double SideA { get; set; }
        /// <summary>
        /// Сторона треугольника (для прямоугольного треугольника - больший катет)
        /// </summary>
        public double SideB { get; set; }
        /// <summary>
        /// Сторона треугольника (для прямоугольного треугольника - гипотенуза)
        /// </summary>
        public double SideC { get; set; }

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        public double Area {
            get
            {
                // полупериметр
                double semiperimeter = (SideA + SideB + SideC) * 0.5;
                // формула Герона
                return (IsRight) 
                    ? (semiperimeter - SideA) * (semiperimeter - SideB)
                    : Math.Sqrt(semiperimeter * (semiperimeter - SideA) * (semiperimeter - SideB) * (semiperimeter - SideC));
            }
        }

        /// <summary>
        /// True, если треугольник прямоуголен
        /// </summary>
        public bool IsRight
        {
            // Теорема Пифагора
            get => Validate() && (SideA * SideA + SideB * SideB == SideC * SideC);
        }

        /// <summary>
        /// Используется для проверки существования треугольника с заданными сторонами
        /// </summary>
        /// <returns>true, если треугольник существует; в противном случае выбрасывает исключение</returns>
        /// <exception cref="ShapeException"></exception>
        protected bool Validate()
        {
            if (SideB < SideA || SideC < SideB || SideC < SideA)
                throw new ShapeException(this, "Стороны треугольника определены в неправильном порядке");
            if (SideC > SideA + SideB)
                throw new ShapeException(this, "Треугольник с заданными длинами сторон не существует");
            return true;
        }

        public Triangle(double a, double b, double c)
        {
            // Стороны сортируются по возрастанию длины, чтобы упростить проверки
            double[] temp = [ a, b, c ]; Array.Sort(temp);
            SideA = temp[0]; SideB = temp[1]; SideC = temp[2];
            Validate();
        }

        public override string ToString() => $"Треугольник, стороны: {SideA}, {SideB}, {SideC}";
    }
}
