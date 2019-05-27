using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace NHibernateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ISession session = NHibernateSessionUtil.GetSession();

            var Address = new Address
            {
                Line1 = "Building 100",
                Line2 = "Beach Road",
                Line3 = "USA"
            };
            session.Save(Address);

            var customer_1 = new Customer
            {
                FirstName = "Rahamath S" ,
                LastName = "S",
                Email = "rahamath18@yahoo.com",
                Phone = 1234567890,
                Address = Address
            };
            session.Save(customer_1);

            var customer_2 = new Customer
            {
                FirstName = "John M",
                LastName = "M",
                Email = "johnm@info.com",
                Phone = 1876543210,
                Address = Address
            };
            session.Save(customer_2);

            IQuery query = session.CreateQuery("from Address");
            IList<Address> AddressList = new List<Address>();
            AddressList = query.List<Address>();
            if (AddressList != null)
            {
                System.Diagnostics.Debug.WriteLine(" Address Count: " + AddressList.Count);
                foreach (Address A in AddressList)
                {
                    System.Diagnostics.Debug.WriteLine(" Address : " + A);
                }
            }
        }
    }
}
