namespace AreaLibrary.Figures
{
    public class Circle : Figure
    {
        /// <summary>
        /// Радиус круга
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Круг
        /// </summary>
        /// <param name="radius">радиус.</param>
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Радиус должен быть положительным", nameof(radius));
            }

            Radius = radius;
            FigureType = FigureType.Circle;
        }

        /// <inheritdoc />
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
