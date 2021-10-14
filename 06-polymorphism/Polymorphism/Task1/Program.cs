using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure[] arrayFigures = new Figure[5];
            Line line = new Line(5, 10, 15);
            Circle circle = new Circle(2, 3, 8);
            Rectangle rectangle = new Rectangle(2, 5, 16, 4);
            Round round = new Round(-4, 4, 16);
            Ring ring = new Ring(0, 0, 60, 40);

            arrayFigures[0] = line;
            arrayFigures[1] = circle;
            arrayFigures[2] = rectangle;
            arrayFigures[3] = round;
            arrayFigures[4] = ring;

            foreach (Figure figure in arrayFigures)
            {
                figure.Draw();
            }
        }
    }
}
