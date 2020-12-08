using CustomerReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Classes
{
    public class Address : IAddress
    {
        public String streetAddress { get; set; }
        public String city { get; set; }
        public String state { get; set; }
        public String zipCode { get; set; }
    }
}
