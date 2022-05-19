using System;
namespace learning1
{
	public class Buy
	{
		private Product product;
		private int qty ;

		public Buy(Product product, int qty = 1)
		{
			this.product = product;
			this.qty = qty;
		}

		public int Qty()
		{ return this.qty; }

		public void SetQty(int qty)
		{
			if (qty < 1)
			{
				this.qty = 1;
			} 
			else
			{ this.qty = qty; };
		}

		public double Wight ()
		{
			return product.Wight * qty;
		}

		public string Position()
		{ return product.Description; }


		public double Cost()
		{
			return product.Price * qty;
		}

	}
}

