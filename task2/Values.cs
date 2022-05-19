using System;
namespace test2
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

	}
}

