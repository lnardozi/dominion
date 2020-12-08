using CustomerReader.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Interfaces
{
    public interface IReader
    {
        IEnumerable<Customer> readCustomers(string fileName);

    }
}
