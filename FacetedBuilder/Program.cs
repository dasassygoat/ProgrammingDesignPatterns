using System;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace FacetedBuilder
{

    public class Person
    {
        public string StreetAddress, PostCode, City;

        public string CompanyName, Position;
        public int AnnualIncome;


        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(PostCode)}: {PostCode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class PersonBuilder //facade
    {
        //reference not a value
        protected Person person = new Person();

        public PersonJobBuilder works()
        {
            return new PersonJobBuilder(person);
        }

        public PersonAddressBuilder lives()
        {
            return new PersonAddressBuilder(person);
        }

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person; 
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string street)
        {
            person.StreetAddress = street;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postalCode)
        {
            person.PostCode = postalCode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }
    //
    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            //can't use the var here
            Person person = pb.works().At("Fabrikam").AsA("Engineer").Earning(123000).lives().At("123 St. St").WithPostCode("12345").In("Dublin");
            
            WriteLine(person);
        }
    }
}