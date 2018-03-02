using System;
using static System.Console;

namespace BuilderBattern.FluentBuilderInheritance
{
    public class Person
    {
        public string Name;
        public string Position;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person _person = new Person();

        public Person Build()
        {
            return _person;
        }
    }

    //self is only allowed when its inherited
    //class Foo : Bar<Foo>
    public class PersonInfoBuilder<SELF>:PersonBuilder 
        where SELF:PersonInfoBuilder<SELF>
    {
        //we take this out and add it to the abstract PersonBuilder class
        //protected Person _person = new Person(); //protected because we are using inheritance
        
        //fluent method to specify names
        //replacing the PersonInfoBuilder with {} so that we can do the inheritance
        public SELF called(string name)
        {
            _person.Name = name;
            //manually casting as self because VS/Resharper don't think its allowed
            return (SELF) this; //no problems with the code at this point as long as we dont start to inherit from it
        }
    }

    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
    where SELF:PersonJobBuilder<SELF>
    {
        //we replace the PersonJobBuilder with {} so that we can do the inheritance and bring the PersonInfo
        //info builder into awareness of this method.
        public SELF Person WorksAsA(string position)
        {
            _person.Position = position;
            return (SELF) this;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new PersonJobBuilder();
            
            //with the different types of PersonInfoBuilder and PersonJobBuilder
            //they are not aware of each other and we cant use fluent call to WorksAsA()
            //builder.called("bryan").WorksAsA
            
            
        }
    }
}