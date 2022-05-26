using System;
namespace test2
{
	public class Storage
	{
        Product[] data;
        public Storage()
        {
            data = new Product[5];
        }

        public Product this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        public void PrintMeat()
        {
            foreach (Product product in data)
            {
                if (product != null)
                {
                    if (product.GetType() == typeof(Meat))
                    {
                        Console.WriteLine(product.ToString());
                    }
                }
            }
        }

        public void Printall()
        {
            foreach (Product product in data)
            {
                if (product != null)
                {
                        Console.WriteLine(product.ToString());

                }
            }
        }

        public void  IncrisePrice(int Percent)
        {
            foreach (Product product in data)
            {
                if (product != null)
                {
                    product.IncrisePrice(Percent);

                }
            }
        }
    }
}

