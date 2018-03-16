using System;
using static System.Console;

namespace Prototype
{

    public class Person : ICloneable
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ",Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            return new Person(Names,(Address)Address.Clone());
        }
    }

    public class Address : ICloneable
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var john = new Person(new []{"John","Smith"},new Address("Hobart",123));

            //using the clone this way dosent accomplish anything because the change
            //for Janes house number changes johns as well
            var jane = (Person) john.Clone();
            jane.Address.HouseNumber = 321;
            
            WriteLine(john);
            WriteLine(jane);
        }
    }
}