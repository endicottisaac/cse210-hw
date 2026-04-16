using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Red", 4);
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea());

        Rectangle rectangle = new Rectangle("Blue", 3, 5);
        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.GetArea());

        Circle circle = new Circle("Green", 2.5);
        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.GetArea());

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);
        shapes.Add(new Square("Yellow", 6));

        Console.WriteLine();
        Console.WriteLine("Shape List:");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()} - {shape.GetArea():F2}");
        }
    }
}
