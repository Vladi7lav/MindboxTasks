namespace AreaLibrary
{
    public static class AreaCalculator
    {
        //Если пользователь не захочет создавать фигуры, может пользоваться статичными методами,
        //по сути они не требуют от библиотеки знания типа фигуры, так как метод вызывается явно

        /// <summary>
        /// Рассчитать площадь круга
        /// </summary>
        /// <param name="radius">радиус</param>
        /// <returns>площадь круга</returns>
        public static double CalculateCircleArea(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Радиус должен быть положительным");
            }

            return Math.PI * radius * radius;
        }

        /// <summary>
        /// Рассчитать площадь треугольника
        /// </summary>
        /// <param name="a">длина первой стороны</param>
        /// <param name="b">длина второй стороны</param>
        /// <param name="c">длина третьей стороны</param>
        /// <returns>площадь треугольника и признак, является ли он прямоугольным</returns>
        public static (double Area, bool IsRight) CalculateTriangleArea(double a, double b, double c)
        {
            return CalculateTriangleArea(new[] { a, b, c });
        }

        /// <summary>
        /// Рассчитать площадь треугольника
        /// </summary>
        /// <param name="lengths">массив содержащий длины трёхз сторон треугольника</param>
        /// <returns>площадь треугольника и признак, является ли он прямоугольным</returns>
        public static (double Area, bool IsRight) CalculateTriangleArea(double[] lengths)
        {
            if (lengths == null || lengths.Length != 3)
            {
                throw new ArgumentException("Количество длин в массиве для рассчёта площади треугольника должно быть равно 3", nameof(lengths));
            }

            if (lengths.Any(l => l <= 0))
            {
                //По необходимости имеет смысл выводить какие именно длины сторон не удовлетворяют условию
                throw new ArgumentException("Длины сторон должны быть положительными");
            }

            //Сортировка по возрастанию
            Array.Sort(lengths);

            if (lengths[2] >= lengths[0] + lengths[1])
            {
                throw new ArgumentException($"Треугольник со сторонами {String.Join(',', lengths)} не может существовать");
            }

            //Если сумма квадратов катетов равна квадрату гипотенузы, то треугольник прямоугольный
            if (lengths[0]*lengths[0] + lengths[1]*lengths[1] == lengths[2]*lengths[2])
            {
                return (lengths[0] * lengths[1] / 2, true);
            }

            var semiPerimeter = lengths.Sum() / 2;

            return (Math.Sqrt(semiPerimeter * (semiPerimeter - lengths[0]) * (semiPerimeter - lengths[1]) * (semiPerimeter - lengths[2])), false);
        }
    }
}