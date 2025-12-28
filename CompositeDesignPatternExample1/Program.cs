using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    class Program
    {
        /*The Composite Design Pattern is a structural design pattern that allows 
         you to compose objects into tree-like structures to represent part-whole hierarchies. 
        It lets clients treat individual objects (leaves) and compositions of objects (composites) uniformly.*/
        static void Main(string[] args)
        {
            FileSystemItems File1 = new File("Aadhar.pdf");
            FileSystemItems File2 = new File("PAN.pdf");
            FileSystemItems File3 = new File("DrivingLicence.pdf");
            FileSystemItems File4 = new File("Photo.JPG");

            Folder Folder = new Folder("Documents");
            Folder.Add(File1);
            Folder.Add(File2);
            Folder.Add(File3);

            Folder root = new Folder("Root");
            root.Add(File4);
            root.Add(Folder);
            root.Display();

        }
    }

    public abstract class FileSystemItems
    {
        public string Name { get; set; }

        public FileSystemItems(string name)
        {
            this.Name = name;
        }
        public virtual void Display()
        {
            Console.WriteLine("\tFile name is {0}", this.Name);
        }
    }

    public class File : FileSystemItems
    {
        public File(string name) : base(name) { }
    }

    public class Folder : FileSystemItems
    {
        List<FileSystemItems> items = new List<FileSystemItems>();
        public Folder(string name) : base(name) { }

        public void Add(FileSystemItems item)
        {
            items.Add(item);
        }

        public override void Display()
        {
            Console.WriteLine("Folder Name is {0}", this.Name);
            foreach (FileSystemItems item in items) 
            {
                Console.Write("\t");
                item.Display();
            }
        }
    }
}
