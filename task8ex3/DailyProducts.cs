using System;
namespace task8ex3
{
	public class DailyProduct:Product
	{
		private Term term;

		public DailyProduct() : this(default, default, default) { }

		public DailyProduct(string name, decimal price, Term term):base(name, price)
		{
			this.term = term;

		}


		public override void IncrisePrice(int Percent)
		{
			price = Math.Round(price * (100 + Percent + Values.PersentOfTerm(term))/ 100, 2);
		}

		public override string ToString()
		{
			return base.ToString() + ' ' + term.ToString();
		}

	}
}

