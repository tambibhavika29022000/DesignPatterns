using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            IPizza pizza = new FreshFarmPizza();
            Console.WriteLine($"{pizza.GetType().Name} cost is {pizza.Cost()}");

            pizza = new CheeseTopping(pizza);
            pizza = new PaneerTopping(pizza);

            Console.WriteLine($"Final cost with toppings: {pizza.Cost()}");
        }
    }

    // Component
    public interface IPizza
    {
        int Cost();
    }

    // Concrete Component
    public class FreshFarmPizza : IPizza
    {
        public int Cost()
        {
            return 100;
        }
    }

    public class FreshMushroomPizza : IPizza
    {
        public int Cost()
        {
            return 120;
        }
    }

    // Decorator
    public abstract class ToppingDecorator : IPizza
    {
        protected IPizza pizza;

        public ToppingDecorator(IPizza pizza)
        {
            this.pizza = pizza;
        }

        public abstract int Cost();
    }

    // Concrete Decorators
    public class CheeseTopping : ToppingDecorator
    {
        public CheeseTopping(IPizza pizza) : base(pizza) { }

        public override int Cost()
        {
            return pizza.Cost() + 10;
        }
    }

    public class PaneerTopping : ToppingDecorator
    {
        public PaneerTopping(IPizza pizza) : base(pizza) { }

        public override int Cost()
        {
            return pizza.Cost() + 25;
        }
    }
}
