namespace AreaLibrary.Figures
{
    //Под вопросом на сколько удобно пользователю будет создавать отдельные объекты,
    //возможно имеет смысл сделать метод-фабрику, с помощью которого можно будет создавать фигуры с помощью единого метода, просто передавая тип фигуры
    //и массив параметров например
    public abstract class Figure
    {
        //Тип фигуры сделан "на вырост", если логика будет как то расширяться.

        /// <summary>
        /// Тип фигуры.
        /// </summary>
        protected FigureType FigureType { get; set; }

        /// <summary>
        /// Рассчитать площадь фигуры.
        /// </summary>
        /// <returns>площадь фигуры.</returns>
        public abstract double CalculateArea();
    }
}
