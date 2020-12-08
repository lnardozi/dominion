using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Classes
{
    public static class CustomerDisplay
    {
        public static void DisplayCustomer(this Customer customer)
        {
            String customerString = "";
            customerString += "Email: " + customer.email.ToEmail() + "\n";
            customerString += "First Name: " + customer.fn.ToName() + "\n";
            customerString += "Last Name: " + customer.ln.ToName() + "\n";
            customerString += "Full Name: " + customer.fn.ToName()+" "+ customer.ln.ToName() + "\n";
            customerString += "Street Address: " + customer.streetAddress.ToStreetAddress() + "\n";
            customerString += "City: " + customer.city.ToCity() + "\n";
            customerString += "State: " + customer.state.ToState() + "\n";
            customerString += "Zip Code: " + customer.zipCode + "\n";

            Console.WriteLine(customerString);

        }
    }
}
