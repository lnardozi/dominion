using CustomerReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Classes
{

    public class Customer : Address, ICustomer
    {
        public String fn { get; set; }
        public String ln { get; set; }
        public String email { get; set; }
        public String phone { get; set; }
    }
}
