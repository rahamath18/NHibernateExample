using FluentNHibernate.Mapping;

namespace NHibernateExample
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual int Phone { get; set; }
        public virtual Address Address { get; set; }

        public override string ToString()
        {
            string BeanValue;
            BeanValue = "Customer[Id:" + Id + " | " +
                    "FirstName:" + FirstName + " | " +
                    "LastName:" + LastName + " | " +
                    "Email:" + Email + " | " +
                    "Phone:" + Phone;
            if (Address != null)
                BeanValue = BeanValue + " | " + "Address:" + Address.Id + "]";
            else
                BeanValue = BeanValue + "]";
            return BeanValue;
        }
    }

    class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {             
            //LazyLoad();
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email).Not.Nullable().Length(50);
            Map(x => x.Phone);
            //References(c => c.Address);
            //References<Address>(x => x.CustomerAddresstID).Column("CustomerAddresstID").ForeignKey("AddressID");
            References(x => x.Address).Column("AddressID").LazyLoad();            
            Table("Customer");
        }
    }
}
