using AreaLibrary.Figures;

namespace AreaLibrary.UnitTests
{
    public class UnitTestsForCircle
    {
        #region Проверки для класса Circle

        [Fact]
        public void CreateCircleWithNegativeRadius()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-13.2));
        }

        [Fact]
        public void CreateCircleWithZeroRadius()
        {
            Assert.Throws<ArgumentException>(() => new Circle(0));
        }

        [Fact]
        public void CalculateCircleArea()
        {
            var radius = 2.0;
            var expectedArea = Math.PI * radius * radius;
            var libraryArea = new Circle(radius).CalculateArea();

            Assert.Equal(expectedArea, libraryArea);
        }

        #endregion

        #region Проверки для статичных методов AreaCalculator

        [Fact]
        public void AreaCalculatorCircleWithNegativeRadius()
        {
            Assert.Throws<ArgumentException>(() => AreaCalculator.CalculateCircleArea(-6.1));
        }

        [Fact]
        public void AreaCalculatorCircleWithZeroRadius()
        {
            Assert.Throws<ArgumentException>(() => AreaCalculator.CalculateCircleArea(0));
        }

        [Fact]
        public void AreaCalculatorCircleCalculateArea()
        {
            var radius = 2.0;
            var expectedArea = Math.PI * radius * radius;
            var libraryArea = AreaCalculator.CalculateCircleArea(radius);

            Assert.Equal(expectedArea, libraryArea);
        }

        #endregion
    }
}