using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Interfaces
{
    public interface IAddress
    {
        String streetAddress { get; set; }
        String city { get; set; }
        String state { get; set; }
        String zipCode { get; set; }
    }
}
