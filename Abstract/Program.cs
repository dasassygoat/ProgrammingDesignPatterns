using System;
using System.Collections.Generic;
using static System.Console;

namespace Abstract
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This tea is nice but I'd prefer it with milk");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine("Great coffee");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory: IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Put in a tea bag, boil water, pour {amount} ml, add lemon, enjoy");
            return new Tea();
        }
    }

    internal class CoffeeFactory: IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Put coffee, boil water, pour {amount} ml, and wait");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableDrink
        {
            Tea,Coffee
        }
        
        private Dictionary<AvailableDrink, IHotDrinkFactory> factories = 
            new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IHotDrinkFactory) Activator.CreateInstance(
                    Type.GetType("Abstract." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory")
                    );
                factories.Add(drink,factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            HotDrinkMachine hdm = new HotDrinkMachine();
            var drink = hdm.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 10);
            drink.Consume();
        }
    }
}