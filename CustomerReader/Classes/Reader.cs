using CustomerReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Classes
{
    public abstract class Reader : IReader
    {
        protected List<Customer> _customers = new List<Customer>();
        public abstract IEnumerable<Customer> readCustomers(string fileName);
    }
}
