using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            House house = new HouseBuilder()
                            .SetBalcony(true)
                            .SetGarden(Garden.Vegetable)
                            .SetWall(Wall.Wooden)
                            .SetWindow(Window.Glass)
                            .SetPentHouse(true)
                            .Build();

            Console.WriteLine("House created with Garden: {0}, Window: {1}, Wall: {2}, Balcony: {3}, Penthouse: {4}",
                house.Garden, house.Window, house.Wall, house.Balcony, house.PentHouse);

            House newHouse = new HouseBuilder()
                .SetBalcony(false)
                .SetWall(Wall.Wooden)
                .SetWindow(Window.Glass)
                .Build();

            Console.WriteLine("House created with Garden: {0}, Window: {1}, Wall: {2}, Balcony: {3}, Penthouse: {4}",
                newHouse.Garden, newHouse.Window, newHouse.Wall, newHouse.Balcony, newHouse.PentHouse);
        }
    }

    public class HouseBuilder
    {
        private readonly House _house = new House();

        public HouseBuilder SetGarden(Garden garden)
        {
            _house.Garden = garden;
            return this;
        }

        public HouseBuilder SetWall(Wall wall)
        {
            _house.Wall = wall;
            return this;
        }

        public HouseBuilder SetWindow(Window window)
        {
            _house.Window = window;
            return this;
        }

        public HouseBuilder SetBalcony(bool balcony)
        {
            _house.Balcony = balcony;
            return this;
        }

        public HouseBuilder SetPentHouse(bool pentHouse)
        {
            _house.PentHouse = pentHouse;
            return this;
        }

        public House Build()
        {
            return _house;
        }
    }

    public class House
    {
        public Garden Garden { get; set; }
        public Wall Wall { get; set; }
        public Window Window { get; set; }
        public bool Balcony { get; set; }
        public bool PentHouse { get; set; }
    }

    public enum Garden
    {
        Flower,
        Vegetable
    }

    public enum Window
    {
        Glass,
        Net,
        Wooden
    }

    public enum Wall
    {
        Wooden,
        Cemented
    }
}
