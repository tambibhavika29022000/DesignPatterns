using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            IImage image1 = new ProxyImage("nature.jpg");
            IImage image2 = new ProxyImage("sunset.png");

            Console.WriteLine("Images created, not loaded yet.");

            // Now display one of them
            image1.Display();
            Console.WriteLine();

            // Display again — will not reload
            image1.Display();

            Console.WriteLine();

            // Display another image
            image2.Display();
        }
    }

    // Subject Interface
    public interface IImage
    {
        void Display();
    }

    // Real Subject
    public class RealImage : IImage
    {
        private string _filename;

        public RealImage(string filename)
        {
            _filename = filename;
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            Console.WriteLine($"Loading image from disk: {_filename}");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying image: {_filename}");
        }
    }

    // Proxy
    public class ProxyImage : IImage
    {
        private RealImage _realImage;
        private string _filename;

        public ProxyImage(string filename)
        {
            _filename = filename;
        }

        public void Display()
        {
            if (_realImage == null)
            {
                _realImage = new RealImage(_filename);  // Load only once
            }
            _realImage.Display();
        }
    }
}
