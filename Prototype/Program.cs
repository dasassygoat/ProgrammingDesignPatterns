using System;
using static System.Console;

namespace Prototype
{

    public class Person 
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public Person(Person other)
        {
            Names = other.Names;
            Address = new Address(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ",Names)}, {nameof(Address)}: {Address}";
        }

        
    }

    public class Address 
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var john = new Person(new []{"John","Smith"},new Address("Hobart",123));

            //using the clone this way dosent accomplish anything because the change
            //for Janes house number changes johns as well
            var jane = new Person(john);
            jane.Address.HouseNumber = 321;
            
            WriteLine(john);
            WriteLine(jane);
        }
    }
}