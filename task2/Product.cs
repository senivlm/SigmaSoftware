using System;
namespace test2
{
	public class Product
	{
        public string name { get; set; }
		public Decimal price { get; set; }
		public Decimal weight { get; set; }


		public Product(string name, Decimal price=1)
		{
			this.name = name;
			this.price = price;
		}

		public virtual void IncrisePrice(int percent)
		{
			if (percent > -1 & percent <= 100)
			{
				price = Math.Round(price * (100 + percent) / 100, 2);
			}
		}

		public void Parse(string str)
		{
			string[] arr = str.Split(' ');
			if (arr.Length > 2)
				weight = int.Parse(arr[2]);
			if (arr.Length > 1)
				price = int.Parse(arr[1]);
			if (arr.Length > 0)
				name = arr[0];

		}
		
        public override string ToString()
        {
            return name+" "+price.ToString();
        }
    }
}

