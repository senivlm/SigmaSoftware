using System;
using System.Collections;
using System.Collections.Generic;

namespace task8ex3
{
    public class Storage:List<Product>
    {
        public Storage()
        {
          
        }

        public Storage(List<Product> products) : base(products)
        {
            
        }


        public List<Product> Products
        {
            get { return this;}
        }

        
        public List<Product> GetMeat()
        {
            return GetProductsByType(typeof(Meat));
        }

        private List<Product> GetProductsByType(Type type)
        {
            List<Product> result = new List<Product>();
            

            foreach (Product product in this)
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


        public void  IncrisePrice(int Percent)
        {
            foreach (Product product in this)
            {
                if (product != null)
                {
                    product.IncrisePrice(Percent);

                }
            }
        }

        

    }
}

