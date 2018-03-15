using System;

namespace FactoryExerciseOne
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        private int personId = 0;
        
        public Person CreatePerson(string name)
        {
            return new Person{Id = personId++, Name = name};
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            PersonFactory pf = new PersonFactory();
            var j = pf.CreatePerson("john");
            Console.WriteLine($"Id: {j.Id} Name:{j.Name}");
            var r = pf.CreatePerson("rudy");
            Console.WriteLine($"Id: {r.Id} Name:{r.Name}");
        }
    }
}