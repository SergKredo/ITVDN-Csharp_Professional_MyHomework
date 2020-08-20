using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /*Выучите описание шаблона Template method (Шаблонный метод). Обратите внимание на
применимость шаблона, а также на состав его участников и связи отношения между ними.
Напишите небольшую программу на языке C#, представляющую собой абстрактную
реализацию данного шаблона.*/
    abstract class Shape   // Объявляем абстрактный класс Shape. Класс реализует возможность расчета периметра и площади фигуры
    {
        public class Point   // Объявляем nested класс Point. Класс определяет точки (заданные пользователем) в декартовой системе координат.
        {
            public double X { get; }   // Автосвойство определяет точку X
            public double Y { get; }   // Автосвойство определяет точку Y
            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }
        }
        double Radius { get; }   // Автосвойство определяет радиус круга
        public double Length  // Свойство определяет длину окружности или периметр полигона (многоугольника)
        {
            get
            {
                return CalculateLength(); 
            }
        }
        public double Area  // Свойство определяет площадь фигуры
        {
            get
            {
                return CalculateArea();
            }
        }
        public abstract double CalculateLength();  // Абстрактный метод определяет возможность расчета длины окружности или периметра полигона
        public abstract double CalculateArea();    // Абстрактный метод определяет возможность расчета площади фигуры
    }

    class Circle : Shape   // Объявляем класс Circle. Класс наследуется от абстрактного базового класса Shape
    {
        double Radius { get; }  // Поле определяет радиус окружности
        public Circle(double radius)  // Потльзовательский конструктор для инициализации полей
        {
            this.Radius = radius;
        }

        public override double CalculateLength()  // Переопределяем базовый метод. Метод позволяет расчитать длину окружности
        {
            return 2 * Math.PI * Radius;   // Формула для расчета длины окружности: L = 2*pi*R, где pi = 3.14, R - радиус окружности, L - длина окружности
        }
        public override double CalculateArea()  // Переопределяем базовый метод. Метод позволяет расчитать площадь окружности
        {
            return Math.PI * Math.Pow(Radius, 2);  // Формула для расчета площади окружности: S = pi*R^2, где pi = 3.14, R - радиус окружности, S - площадь окружности
        }
    }

    class Polygon : Shape  // Объявляем класс Polygon. Класс наследуется от абстрактного базового класса Shape
    {
        List<Shape.Point> Points { get; }  // Автосвойство определяет коллекцию точек полигона
       
        public Polygon(List<Shape.Point> listPoints)  // Пользовательский конструктор для инициализации полей класса
        {
            this.Points = listPoints;
        }
        public override double CalculateLength()   // Переопределяем базовый метод. Метод позволяет расчитать периметр полигона
        {
            double sum = 0;  // Сумма всех значений итераций возвращаемого значения метода GetLength
            this.Points.Aggregate((p1, p2) =>   // Вызов агрегатной функции применяется к последовательности значений.
            //Указанное начальное значение служит исходным значением для агрегатной операции, а указанная функция используется для выбора результирующего значения.
            {
                sum += GetLength(p1, p2);
                return p2;
            });
            sum += GetLength(this.Points.First(), this.Points.Last());
            return sum;
        }
        public override double CalculateArea()  // Переопределяем базовый метод. Метод позволяет расчитать площадь полигона
        {
            double sum = 0;
            this.Points.Aggregate((p1, p2) =>  // Вызов агрегатной функции применяется к последовательности значений.
            {
                sum += GetSumAreaCross(p1, p2);
                return p2;
            });
            sum += GetSumAreaCross(this.Points.Last(), this.Points.First());
            return Math.Abs(sum)/2;
        }
        double GetLength(Shape.Point p1, Shape.Point p2) 
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));  // Формула для частичного расчета периметра полигона
        }
        double GetSumAreaCross(Shape.Point p1, Shape.Point p2)
        {
            return p1.X * p2.Y - p1.Y * p2.X;   // Формула для частичного расчета площади полигона. Используется формула площади Гаусса(алгоритм шнурования)
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Circle:\n- Radius: ");
            string circleRadius = Console.ReadLine();
            Shape circle = new Circle(Convert.ToDouble(circleRadius));  // UpCast параметров типа (вторая форма полиморфизма). Приведение к базовому типу
            Console.WriteLine("- Length: {0};\n- Area: {1};", circle.Length, circle.Area);
            Console.WriteLine(new string('-', 100));

            Console.Write("Polygon:\n- Number of point: ");
            string points = Console.ReadLine();
            List<Shape.Point> listPoints = new List<Shape.Point>();
            for (int i = 0; i < Convert.ToInt32(points); i++)
            {
                Console.Write("- Point{0}: X(", i + 1);
                string x = Console.ReadLine();
                Console.CursorTop = 7 + i;
                Console.CursorLeft = 12 + x.Length;
                Console.Write("); Y(");
                string y = Console.ReadLine();
                Console.CursorTop = 7 + i;
                Console.CursorLeft = 17 + x.Length + y.Length;
                Console.WriteLine(");");
                listPoints.Add(new Shape.Point(Convert.ToDouble(x), Convert.ToDouble(y)));
            }
            Shape polygon = new Polygon(listPoints);  // UpCast параметров типа (вторая форма полиморфизма). Приведение к базовому типу
            Console.WriteLine("- Length: {0};\n- Area: {1};", polygon.Length, polygon.Area);
            Console.WriteLine(new string('-', 100));

            Console.ReadKey();
        }
    }
}

/*
 Results:
-----------------------------------------------------------------------------------------------------------------------------------
Circle:
- Radius: 5,25
- Length: 32,9867228626928;
- Area: 86,5901475145687;
----------------------------------------------------------------------------------------------------
Polygon:
- Number of point: 3
- Point1: X(2); Y(1);
- Point2: X(4); Y(5);
- Point3: X(7); Y(8);
- Length: 17,3171019091615;
- Area: 3;
----------------------------------------------------------------------------------------------------
Circle:
- Radius: 10
- Length: 62,8318530717959;
- Area: 314,159265358979;
----------------------------------------------------------------------------------------------------
Polygon:
- Number of point: 5
- Point1: X(3); Y(4);
- Point2: X(5); Y(11);
- Point3: X(12); Y(8);
- Point4: X(9); Y(5);
- Point5: X(5); Y(6);
- Length: 26,0900564326276;
- Area: 30;
----------------------------------------------------------------------------------------------------
Circle:
- Radius: 2
- Length: 12,5663706143592;
- Area: 12,5663706143592;
----------------------------------------------------------------------------------------------------
Polygon:
- Number of point: 4
- Point1: X(0); Y(0);
- Point2: X(0); Y(1);
- Point3: X(1); Y(1);
- Point4: X(1); Y(0);
- Length: 4;
- Area: 1;
----------------------------------------------------------------------------------------------------

 */
