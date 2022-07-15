namespace AreaLibrary.Figures
{
    public class Triangle : Figure
    {
        private const string LengthIsNotPositiveNumber = "Длина должна быть положительной величиной";
        private const string TriangleNotExists = "Треугольник с заданными сторонами не может существовать";

        #region Fields

        private double a;
        private double b;
        private double c;

        #endregion

        #region Props

        /// <summary>
        /// Сторона 1
        /// </summary>
        public double A
        {
            get => a;
            init
            {
                if (value < 0)
                {
                    throw new ArgumentException(LengthIsNotPositiveNumber, nameof(A));
                }

                a = value;
            }
        }

        /// <summary>
        /// Сторона 2
        /// </summary>
        public double B
        {
            get => b;
            init
            {
                if (value < 0)
                {
                    throw new ArgumentException(LengthIsNotPositiveNumber, nameof(B));
                }

                b = value;
            }
        }

        /// <summary>
        /// Сторона 3
        /// </summary>
        public double C
        {
            get => c;
            init
            {
                if (value < 0)
                {
                    throw new ArgumentException(LengthIsNotPositiveNumber, nameof(C));
                }

                c = value;
            }
        }

        #endregion

        /// <summary>
        /// Треугольник
        /// </summary>
        /// <param name="a">длина первой стороны</param>
        /// <param name="b">длина второй стороны</param>
        /// <param name="c">длина третьей стороны</param>
        public Triangle(double a, double b, double c)
        {
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException(TriangleNotExists);
            }

            A = a;
            B = b;
            C = c;

            FigureType = FigureType.Triangle;
        }

        /// <inheritdoc />
        public override double CalculateArea()
        {
            var semiPerimeter = (A + B + C) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - A) * (semiPerimeter - B) * (semiPerimeter - C));
        }

        /// <summary>
        /// Метод для проверки, является ли треугольник прямоугольным
        /// </summary>
        /// <returns>результат проверки</returns>
        public bool TriangleIsRight()
        {
            var lengths = new[] { this.a, this.b, this.c };

            //Сортировка по возрастанию
            Array.Sort(lengths);

            return lengths[0] * lengths[0] + lengths[1] * lengths[1] == lengths[2] * lengths[2];
        }
    }
}
