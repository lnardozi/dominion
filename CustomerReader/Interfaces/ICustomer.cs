using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Interfaces
{
    public interface ICustomer
    {
        String fn { get; set; }
        String ln { get; set; }
        String email { get; set; }
        String phone { get; set; }
    }
}
