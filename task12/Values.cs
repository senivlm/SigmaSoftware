using System;
namespace task12
{
	public class Values
	{
		public Values()
		{
		}

		public static int PersentOfGrade(Grade Grade)
		{
			return (int)Grade;

		}

		public static int PersentOfMeatType(MeatType meatType)
		{
			switch (meatType)
			{
				case MeatType.Beef:
					return 5;

				case MeatType.Pork:
					return 4;

				case MeatType.Mutton:
					return 3;
					
				case MeatType.Chicken:
					return 2;
			}
			return 1;

		}

		public static int PersentOfTerm(Term term)
		{
			switch (term)
			{
				case Term.Year:
					return 5;
				case Term.Month:
					return 4;
				case Term.Weak:
					return 3;
			}
			return 1;

		}

		public static Product GetProductFromString(string str)
		{
			Product result;
			string[] arr = str.Split(' ');

			if (arr.Length == 4)
				result = new Meat(arr[0], decimal.Parse(arr[1]), (Grade)Enum.Parse(typeof(Grade), arr[2]), (MeatType)Enum.Parse(typeof(MeatType), arr[3]));
			else
			{
				if (arr.Length == 3)
				{
					result = new DailyProduct(arr[0], decimal.Parse(arr[1]), (Term)Enum.Parse(typeof(Term), arr[2]));
				}
				else
				{
					if (arr.Length == 2)
					{
						result = new Product(arr[0], decimal.Parse(arr[1]));
					}
					else
					{
						throw new ArgumentException("Bad string format");
					}
				}
			}
			return result;
				
		}


	}
}

