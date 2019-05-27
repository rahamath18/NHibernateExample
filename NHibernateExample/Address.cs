using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace NHibernateExample
{
    public class Address
    {
        public virtual int Id { get; set; }
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string Line3 { get; set; }
        public virtual IList<Customer> Customers { get; set; }

        public override string ToString() {
            string BeanValue;
            BeanValue = "Address[Id:" + Id + " | " +
                    "Line1:" + Line1 + " | " +
                    "Line2:" + Line2 + " | " +
                    "Line3:" + Line3;
            if (Customers != null)
                BeanValue = BeanValue + " | " + "Customers:" + Customers.Count + "]";
            else
                BeanValue = BeanValue + "]";
            return BeanValue;
        }
    }

    class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            
            Id(x => x.Id);
            Map(x => x.Line1).Not.Nullable().Length(20);
            Map(x => x.Line2);
            Map(x => x.Line3);
            HasMany(x => x.Customers).LazyLoad();            
            Table("Address");
        }
    }
}
