using System;
namespace learning1
{
	public class Product
	{
		private String _Description;
		public float Price { get; set;}
		public float Wight { get; set;}

		public Product(String Description, float Price=0, float Wight=0)
		{
			this._Description = Description;
			this.Price = Price;
			this.Wight = Wight;

	}

		public String Description {
			get{ return this._Description; }
		}
		
	}
}

