using CustomerReader.Classes;
using CustomerReader.Interfaces;
using System;
using System.Linq;
namespace CustomerReader
{
    class Program
    {
        static void Main(string[] args)
        {

            Bootstrap.logger.Info("Started");
            Bootstrap.IocContainer();
            var customers = CustomerListFactory.Get().ToList();
            IReader reader = Bootstrap.Resolve<CSVReader>("CSV");
            customers.AddRange(reader.readCustomers("..\\..\\..\\doc\\customers.csv"));
            reader = (IReader)Bootstrap.container.Resolve(typeof(XMLReader), "XML");
            customers.AddRange(reader.readCustomers("..\\..\\..\\doc\\customers.xml"));
            reader = (IReader)Bootstrap.container.Resolve(typeof(JSONReader), "JSON");
            customers.AddRange(reader.readCustomers("..\\..\\..\\doc\\customers.json"));
            Console.WriteLine("Added this many customers (CSV) {0}", customers.Count);
            foreach(Customer c in customers) { c.DisplayCustomer(); }
            Bootstrap.logger.Info("Stopped");
           
            Console.ReadLine();
        }


        public Program()
        {
        }


    }
}
