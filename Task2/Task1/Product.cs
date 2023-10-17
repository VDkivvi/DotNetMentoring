using System.Diagnostics;

namespace Task1
{
    [DebuggerDisplay("{Name} : {Price}")]
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public bool Equals(Product other)
        {
            if (other == null) return false;
            foreach (var prop in typeof(Product).GetProperties())
            {
                var value1 = prop.GetValue(this);
                var value2 = prop.GetValue(other);
                if ((value1 != null && !value1.Equals(value2)) || (value1 == null && value2 != null))
                    return false;
            }
            return true;
        }
    }
}
