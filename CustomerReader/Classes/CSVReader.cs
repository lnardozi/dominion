using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Classes
{
    public class CSVReader : Reader
    {
        public CSVReader():base()
        {
        }

        public override IEnumerable<Customer> readCustomers(string fileName)
        {
            try
            {
                StreamReader br = new StreamReader(File.Open(fileName, FileMode.Open));
                String line = br.ReadLine();

                var columnNumbers = ColumnNumbers(line);
                line = br.ReadLine();

                while (line != null)
                {
                    //String[] attributes = line.split(" , ");
                    String[] attributes = line.Split(',');

                    Customer customer = Bootstrap.Resolve<Customer>();
                    customer.email = attributes[columnNumbers["email"]];
                    customer.fn = attributes[columnNumbers["firstName"]];
                    customer.ln = attributes[columnNumbers["lastName"]];
                    customer.phone = attributes[columnNumbers["phoneNumber"]];
                    customer.streetAddress = attributes[columnNumbers["streetAddress"]];
                    customer.city = attributes[columnNumbers["city"]];
                    customer.state = attributes[columnNumbers["state"]];
                    customer.zipCode = attributes[columnNumbers["zipCode"]];

                    _customers.Add(customer);
                    line = br.ReadLine();
                }
            }
            catch (IOException ex)
            {
                Bootstrap.logger.Error(ex);
            }
            return _customers.AsEnumerable();
        }
        private static Dictionary<string, int> ColumnNumbers(string line)
        {
            Dictionary<string, int> ColumnNumbers = new Dictionary<string, int>();
            var columns = line.Split(',');
            for (int i = 0; i < columns.Length; i++)
            {
                ColumnNumbers.Add(columns[i].TrimStart(), i);
            }
            return ColumnNumbers;
        }

    }
}
