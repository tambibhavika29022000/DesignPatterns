using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            OSType os = OSType.Mac;
            var factory = UIFactory.GetFactory(os);
            factory.Checkbox().render(); // I am mac checkbox
            factory.Button().render(); // I am mac button
            factory.TextBox().render(); // I am mac textbox
        }
    }

    public static class UIFactory
    {
        public static IOSFactory GetFactory(OSType os)
        {
            if (os == OSType.Windows)
            {
                return new WindowsFactory();
            }

            if (os == OSType.Linux)
            {
                return new LinuxFactory();
            }

            return new MacFactory();
        }
    }

    public interface IOSFactory
    {
        IElement Checkbox();
        IElement Button();
        IElement TextBox();
    }

    public class WindowsFactory : IOSFactory
    {
        public IElement Checkbox() => new WindowsCheckBox();
        public IElement Button() => new WindowsButton();
        public IElement TextBox() => new WindowsTextBox();
    }

    public class LinuxFactory : IOSFactory
    {
        public IElement Checkbox() => new LinuxCheckBox();
        public IElement Button() => new LinuxButton();
        public IElement TextBox() => new LinuxTextBox();
    }

    public class MacFactory : IOSFactory
    {
        public IElement Checkbox() => new MacCheckBox();
        public IElement Button() => new MacButton();
        public IElement TextBox() => new MacTextBox();
    }


    public enum OSType
    {
        Windows,
        Linux,
        Mac
    }

    public interface IElement
    {
        void render();
    }

    public interface ICheckBox : IElement { }
    public interface IButton : IElement { }
    public interface ITextBox : IElement { }

    public class WindowsCheckBox : ICheckBox
    {
        public void render()
        {
            Console.WriteLine("This is checkbox of OS Window");
        }
    }

    public class WindowsTextBox : ITextBox
    {
        public void render()
        {
            Console.WriteLine("This is TextBox of OS Window");
        }
    }

    public class WindowsButton : IButton
    {
        public void render()
        {
            Console.WriteLine("This is Button of OS Window");
        }
    }

    public class LinuxCheckBox : ICheckBox
    {
        public void render()
        {
            Console.WriteLine("This is checkbox of OS Linux");
        }
    }

    public class LinuxTextBox : ITextBox
    {
        public void render()
        {
            Console.WriteLine("This is TextBox of OS Linux");
        }
    }

    public class LinuxButton : IButton
    {
        public void render()
        {
            Console.WriteLine("This is Button of OS Linux");
        }
    }

    public class MacCheckBox : ICheckBox
    {
        public void render()
        {
            Console.WriteLine("This is checkbox of OS Mac");
        }
    }

    public class MacTextBox : ITextBox
    {
        public void render()
        {
            Console.WriteLine("This is TextBox of OS Mac");
        }
    }

    public class MacButton : IButton
    {
        public void render()
        {
            Console.WriteLine("This is Button of OS Mac");
        }
    }
}