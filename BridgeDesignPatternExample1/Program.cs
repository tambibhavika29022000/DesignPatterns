using System;
using System.Threading.Channels;

namespace DesignPatterns
{
    /* Bridge Pattern Example:
       You’re designing a graphics system that draws different shapes
       (Circle, Polygon, Triangle) in different colors (Red, Green, Blue).
       Shapes and Colors vary independently.
    */

    class Program
    {
        static void Main(string[] args)
        {
            IColor color = new Red(new Circle());
            color.AddColor();

            IColor color2 = new Blue(new Circle());
            color2.AddColor();
        }

        public interface IShape
        {
            public void Draw();
        }

        public class Circle : IShape
        {
            public void Draw()
            {
                Console.WriteLine("Drawing Circle");
            }
        }

        public class Polygon : IShape
        {
            public void Draw()
            {
                Console.WriteLine("Drawing Polygon");
            }
        }

        public class Triangle : IShape
        {
            public void Draw()
            {
                Console.WriteLine("Drawing Triangle");
            }
        }

        public interface IColor
        {
            public void AddColor();
        }

        public class Red :IColor
        {
            public IShape shape;

            public Red(IShape shape)
            {
                this.shape = shape;
            }
            public void AddColor()
            {
                Console.WriteLine("Drawing {0} of Red Color",this.shape.GetType().Name);
            }
        }

        public class Green : IColor
        {
            public IShape shape;
            public Green(IShape shape)
            {
                this.shape = shape;
            }
            public void AddColor()
            {
                Console.WriteLine("Drawing {0} of Green Color", this.shape.GetType().Name);
            }
        }

        public class Blue : IColor
        {
            public IShape shape;
            public Blue(IShape shape)
            {
                this.shape = shape;
            }
            public void AddColor()
            {
                Console.WriteLine("Drawing {0} of Blue Color", this.shape.GetType().Name);
            }
        }
    }
}
