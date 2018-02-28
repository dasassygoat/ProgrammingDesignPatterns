using System;
using System.Reflection.Metadata;
using static System.Console;

namespace InterfaceSegregation
{
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }

        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPrinter
    {
        void Print(Document d);
      
    }

    public interface IScanner
    {
        void Scan(Document d);
        
    }

    public interface IFax
    {
        void Fax(Document d);
        
    }
    
    public class Photocopier: IPrinter, IScanner
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMultiFunctionDevice : IScanner, IPrinter
    {
        
    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}