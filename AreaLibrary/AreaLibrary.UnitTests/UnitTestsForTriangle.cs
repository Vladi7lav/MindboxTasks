using AreaLibrary.Figures;

namespace AreaLibrary.UnitTests
{
    public class UnitTestsForTriangle
    {
        //В целом при большом количестве типов фигур можно привязать проверку к типу фигуры FigureType,
        //предварительно написав формулы рассчёта площади для разных типов фигур

        private static readonly double[] LengthsWithNegativeValue = { -2, 3, -2.4 };
        private static readonly double[] LengthsWithZeroValue = { -2, 3, -2.4 };
        private static readonly double[] LengthsImpossibleTriangle = { 1, 2, 3 };
        private static readonly double[] LengthsNotRightTriangle = { 2, 3, 4 };
        private static readonly double[] LengthsRightTriangle = { 3, 4, 5 };

        #region Проверки для класса Triangle

        [Fact]
        public void CreateTriangleWithNegativeLength()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(LengthsWithNegativeValue[0], LengthsWithNegativeValue[1], LengthsWithNegativeValue[2]));
        }

        [Fact]
        public void CreateTriangleWithZeroLength()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(LengthsWithZeroValue[0], LengthsWithZeroValue[1], LengthsWithZeroValue[2]));
        }

        [Fact]
        public void CreateImpossibleTriangle()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(LengthsImpossibleTriangle[0], LengthsImpossibleTriangle[1], LengthsImpossibleTriangle[2]));
        }

        [Fact]
        public void CalculateTriangleArea()
        {
            var semiPerimeter = LengthsNotRightTriangle.Sum() / 2;
            
            var expectedArea = Math.Sqrt(semiPerimeter * (semiPerimeter - LengthsNotRightTriangle[0]) * (semiPerimeter - LengthsNotRightTriangle[1]) * (semiPerimeter - LengthsNotRightTriangle[2]));
            var libraryArea = new Triangle(LengthsNotRightTriangle[0], LengthsNotRightTriangle[1], LengthsNotRightTriangle[2]).CalculateArea();

            Assert.Equal(expectedArea, libraryArea);
        }

        [Fact]
        public void CheckRightTriangle()
        {
            Assert.False(new Triangle(LengthsNotRightTriangle[0], LengthsNotRightTriangle[1], LengthsNotRightTriangle[2]).TriangleIsRight());
            Assert.True(new Triangle(LengthsRightTriangle[0], LengthsRightTriangle[1], LengthsRightTriangle[2]).TriangleIsRight());
        }

        #endregion

        #region Проверки для статичных методов AreaCalculator

        [Fact]
        public void AreaCalculatorTriangleWithNegativeLength()
        {
            Assert.Throws<ArgumentException>(() => AreaCalculator.CalculateTriangleArea(LengthsWithNegativeValue[0], LengthsWithNegativeValue[1], LengthsWithNegativeValue[2]));
            Assert.Throws<ArgumentException>(() => AreaCalculator.CalculateTriangleArea(LengthsWithNegativeValue));
        }

        [Fact]
        public void AreaCalculatorTriangleWithZeroLength()
        {
            Assert.Throws<ArgumentException>(() => AreaCalculator.CalculateTriangleArea(LengthsWithZeroValue[0], LengthsWithZeroValue[1], LengthsWithZeroValue[2]));
            Assert.Throws<ArgumentException>(() => AreaCalculator.CalculateTriangleArea(LengthsWithZeroValue));
        }

        [Fact]
        public void AreaCalculatorImpossibleTriangle()
        {
            Assert.Throws<ArgumentException>(() => AreaCalculator.CalculateTriangleArea(LengthsImpossibleTriangle[0], LengthsImpossibleTriangle[1], LengthsImpossibleTriangle[2]));
            Assert.Throws<ArgumentException>(() => AreaCalculator.CalculateTriangleArea(LengthsImpossibleTriangle));
        }

        [Fact]
        public void AreaCalculatorCalculateTriangleArea()
        {
            var semiPerimeter = LengthsNotRightTriangle.Sum() / 2;

            var expectedArea = Math.Sqrt(semiPerimeter * (semiPerimeter - LengthsNotRightTriangle[0]) * (semiPerimeter - LengthsNotRightTriangle[1]) * (semiPerimeter - LengthsNotRightTriangle[2]));
            var firstMethodCalculatedArea = AreaCalculator.CalculateTriangleArea(LengthsNotRightTriangle[0], LengthsNotRightTriangle[1], LengthsNotRightTriangle[2]).Area;
            var secondMethodCalculatedArea = AreaCalculator.CalculateTriangleArea(LengthsNotRightTriangle).Area;

            Assert.Equal(expectedArea, firstMethodCalculatedArea);
            Assert.Equal(expectedArea, secondMethodCalculatedArea);
        }

        [Fact]
        public void AreaCalculatorCheckRightTriangle()
        {
            var firstMethodCalculatedAreaNotRight = AreaCalculator.CalculateTriangleArea(LengthsNotRightTriangle[0], LengthsNotRightTriangle[1], LengthsNotRightTriangle[2]).IsRight;
            var secondMethodCalculatedAreaNotRight = AreaCalculator.CalculateTriangleArea(LengthsNotRightTriangle).IsRight;

            Assert.False(firstMethodCalculatedAreaNotRight);
            Assert.False(secondMethodCalculatedAreaNotRight);

            var firstMethodCalculatedAreaRight = AreaCalculator.CalculateTriangleArea(LengthsRightTriangle[0], LengthsRightTriangle[1], LengthsRightTriangle[2]).IsRight;
            var secondMethodCalculatedAreaRight = AreaCalculator.CalculateTriangleArea(LengthsRightTriangle).IsRight;
            
            Assert.True(firstMethodCalculatedAreaRight);
            Assert.True(secondMethodCalculatedAreaRight);
        }

        #endregion
    }
}
