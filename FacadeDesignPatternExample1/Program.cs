using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerFacade computer = new ComputerFacade();
            computer.Start();

            Console.WriteLine("\n-- Later --\n");

            computer.Shutdown();
        }
    }

    // Subsystem Components
    public class PowerSupply
    {
        public void TurnOn() => Console.WriteLine("Power Supply: ON");
        public void TurnOff() => Console.WriteLine("Power Supply: OFF");
    }

    public class BIOS
    {
        public void ExecutePOST() => Console.WriteLine("BIOS: Running POST checks");
        public void LoadOS() => Console.WriteLine("BIOS: Loading Operating System");
    }

    public class CPU
    {
        public void Freeze() => Console.WriteLine("CPU: Freeze");
        public void Execute() => Console.WriteLine("CPU: Execute");
    }

    public class Memory
    {
        public void Load() => Console.WriteLine("Memory: Loading programs");
    }

    public class HardDrive
    {
        public void ReadData() => Console.WriteLine("Hard Drive: Reading boot sector");
    }

    // Facade
    public class ComputerFacade
    {
        private PowerSupply power = new PowerSupply();
        private BIOS bios = new BIOS();
        private CPU cpu = new CPU();
        private Memory memory = new Memory();
        private HardDrive hdd = new HardDrive();

        public void Start()
        {
            Console.WriteLine("Starting Computer...");
            power.TurnOn();
            cpu.Freeze();
            bios.ExecutePOST();
            memory.Load();
            hdd.ReadData();
            bios.LoadOS();
            cpu.Execute();
        }

        public void Shutdown()
        {
            Console.WriteLine("Shutting down Computer...");
            cpu.Freeze();
            power.TurnOff();
        }
    }
}
