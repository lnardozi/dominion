using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CustomerReader.Classes
{
    public class XMLReader : Reader
    {

        public XMLReader():base() { }
        public override IEnumerable<Customer> readCustomers(string fileName)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(fileName);

                XmlNodeList nList = doc.GetElementsByTagName("Customers");

                for (int temp = 0; temp < nList.Count; temp++)
                {
                    XmlNode nNode = nList[temp];
                    Console.WriteLine("\nCurrent Element :" + nNode.Name);
                    if (nNode.NodeType == XmlNodeType.Element)
                    {
                        Customer customer = Bootstrap.Resolve<Customer>();
                        XmlElement eElement = (XmlElement)nNode;

                        customer.email = eElement.GetElementsByTagName("Email").Item(0).InnerText;
                        customer.fn = eElement.GetElementsByTagName("FirstName").Item(0).InnerText;
                        customer.ln = eElement.GetElementsByTagName("LastName").Item(0).InnerText;
                        customer.phone = eElement.GetElementsByTagName("PhoneNumber").Item(0).InnerText;

                        XmlElement aElement = (XmlElement)eElement.GetElementsByTagName("Address").Item(0);

                        customer.streetAddress = aElement.GetElementsByTagName("StreetAddress").Item(0).InnerText;
                        customer.city = aElement.GetElementsByTagName("City").Item(0).InnerText;
                        customer.state = aElement.GetElementsByTagName("State").Item(0).InnerText;
                        customer.zipCode = aElement.GetElementsByTagName("ZipCode").Item(0).InnerText;

                        _customers.Add(customer);
                    }
                }
            }
            catch (Exception e)
            {
                Bootstrap.logger.Error(e);
            }

            return _customers.AsEnumerable();
        }
    }
}
