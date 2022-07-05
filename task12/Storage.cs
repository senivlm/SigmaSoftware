using System;
using System.Collections.Generic;
using System.Linq;

namespace task12
{

    public delegate void DailyProductAddHandler(Product product);

    public class Storage
    {
        List<Product> products;
        public DailyProductAddHandler OnAddDailyProduc;
        public static Term CriticalTermOfStorage = Term.Weak;
        public Storage()
        {
            products = new List<Product>();
        }

        public Product this[int index]
        {
            get
            {
                if (products.Count > index && index >= 0)
                {
                    return products[index];
                }
                throw new ArgumentException("Index out of bounds");
            }
            set
            {
                if (products.Count > index && index >= 0)
                {
                    CheckProductAndInvocOfDayly(value);
                    products[index] = value;
                }
                else
                {
                    throw new ArgumentException("Index out of bounds");
                }
            }
        }

        public List<Product> Products
        {
            get { return products; }
        }

        public void Add(Product product)
        {
            if (product is Product)
            {
                CheckProductAndInvocOfDayly(product);
                products.Add(product);
            }
            else
            {
                throw new ArgumentException("Only products");
            }
        }

        private void CheckProductAndInvocOfDayly(Product product)
        {
            if (product is DailyProduct)
             {
                OnAddDailyProduc.Invoke(product);
             }
        }

        public List<Product> GetMeat()
        {
            return GetProductsByType(typeof(Meat));
        }

        private List<Product> GetProductsByType(Type type)
        {
            List<Product> result = new List<Product>();
            foreach (Product product in products)
            {
                if (product != null)
                {
                    if (product.GetType() == type)
                    {
                        result.Add(product);
                    }
                }
            }
            return result;
        }


        public List<Product> SelectSome(Func<Product, bool> predicate)
        {
            return products.Where(predicate).ToList();
        }


        public void  IncrisePrice(int Percent)
        {
            foreach (Product product in products)
            {
                if (product != null)
                {
                    product.IncrisePrice(Percent);

                }
            }
        }
    }
}

