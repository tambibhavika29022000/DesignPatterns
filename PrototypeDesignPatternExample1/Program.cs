using System;

/*
🎨 Use Case:
You're building a graphic design application (like Photoshop or Figma) where users can create and manage shapes such as:
Circles
Rectangles
Lines
Text boxes
Each shape has many properties: position, color, border, shadow, font, etc.

❓ The Problem:
Users want to:
Duplicate existing shapes with all their settings.
Quickly copy styles without going through manual property re-configuration.
But creating a new shape from scratch every time (and setting all its properties again) is repetitive and inefficient.
*/


namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape circle = new Circle(3, 4, "White", 10);
            circle.Draw();

            Circle clonedCircle = (Circle)circle.Clone();
            clonedCircle.Radius = 20;
            clonedCircle.Color = "Blue";
            clonedCircle.Draw();

            Console.WriteLine();

            IShape rectangle = new Rectangle(5, 6, "Green", 40, 25);
            rectangle.Draw();

            Rectangle clonedRectangle = (Rectangle)rectangle.Clone();
            clonedRectangle.Width = 100;
            clonedRectangle.Draw();
        }
    }

    // Prototype Interface
    public interface IShape
    {
        IShape Clone();
        void Draw();
    }

    // Circle Class
    public class Circle : IShape
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string Color { get; set; }
        public int Radius { get; set; }

        public Circle(int x, int y, string color, int radius)
        {
            PositionX = x;
            PositionY = y;
            Color = color;
            Radius = radius;
        }

        public IShape Clone()
        {
            return new Circle(PositionX, PositionY, Color, Radius);
        }

        public void Draw()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Circle [X: {PositionX}, Y: {PositionY}, Color: {Color}, Radius: {Radius}]";
        }
    }

    // Rectangle Class
    public class Rectangle : IShape
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string Color { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int x, int y, string color, int width, int height)
        {
            PositionX = x;
            PositionY = y;
            Color = color;
            Width = width;
            Height = height;
        }

        public IShape Clone()
        {
            return new Rectangle(PositionX, PositionY, Color, Width, Height);
        }

        public void Draw()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Rectangle [X: {PositionX}, Y: {PositionY}, Color: {Color}, Width: {Width}, Height: {Height}]";
        }
    }
}