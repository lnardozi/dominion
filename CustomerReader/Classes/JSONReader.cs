using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Classes
{
    public class JSONReader : Reader
    {
        public JSONReader():base() { }
        public override IEnumerable<Customer> readCustomers(string fileName)
        {
            JsonTextReader reader = new JsonTextReader(System.IO.File.OpenText(fileName));

            try
            {
                JArray obj = (JArray)JToken.ReadFrom(reader);
                //JArray a = (JArray)reader);
                //

                foreach (JObject o in obj)
                {
                    Customer customer = Bootstrap.Resolve<Customer>();
                    JObject record = (JObject)o;

                    String email = (String)record["Email"];
                    customer.email = email;

                    String firstName = (String)record["FirstName"];
                    customer.fn = firstName;

                    String lastName = (String)record["LastName"];
                    customer.ln = lastName;

                    String phone = (String)record["PhoneNumber"];
                    customer.phone = phone;

                    JObject address = (JObject)record["Address"];

                    String streetAddress = (String)address["StreetAddress"];
                    customer.streetAddress = streetAddress;

                    String city = (String)address["City"];
                    customer.city = city;

                    String state = (String)address["State"];
                    customer.state = state;

                    String zipCode = (String)address["ZipCode"];
                    customer.zipCode = zipCode;

                    _customers.Add(customer);
                }
            }
            catch (FileNotFoundException e)
            {
                Bootstrap.logger.Error(e);
            }
            catch (IOException e)
            {
                Bootstrap.logger.Error(e);
            }
            catch (JsonException e)
            {
                Bootstrap.logger.Error(e);
            }
            return _customers.AsEnumerable();
        }
    }
}
