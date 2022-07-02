using System;
namespace task8ex3
{
    public class Product : IComparable
    {
        public string name
        {
            get;
            set;
        }
        public Decimal price { get; set; }
        public Decimal weight { get; set; }


        public Product(string name, Decimal price = 1)
        {
            this.name = name;
            this.price = price;
            CorrectName();

        }

        private void CorrectName()
        {
            if (name.Length > 1)
            {
                name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            }
            else
            {
                if (name.Length == 1)
                { name = name.ToUpper(); }
            }
            name = name.Replace(" ","_");

        }
        public virtual void IncrisePrice(int percent)
        {
            if (percent > -1 & percent <= 100)
            {
                price = Math.Round(price * (100 + percent) / 100, 2);
            }
        }

        
        public override string ToString()
        {
            return name + " " + price.ToString();
        }

        public int CompareTo(Object obj)
        {
            if (obj is Product)
            {
                return this.name.CompareTo((obj as Product).name);
            }
            else
            {
                return -1;
            }

        }

        public static bool operator ==(Product a, Product b)
        {
            return a.name == b.name;
        }

        public static bool operator !=(Product a, Product b)
        {
            return a.name != b.name;
        }

        public bool Equals(Product b)
        {
            return (name == b.name);
        }

        public override bool Equals(object obj) => Equals(obj as Product);

        public override int GetHashCode()
        {
            return this.name.GetHashCode();

        }
    }
}

