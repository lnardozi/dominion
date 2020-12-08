using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Classes
{
    public static class CustomerListFactory
    {
        public static IEnumerable<Customer> Get()
        {
            var customers = new List<Customer>();
            return customers.AsEnumerable();
        }
    }
}
