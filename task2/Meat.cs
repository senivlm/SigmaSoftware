using System;
namespace test2
{
	public class Meat:Product
	{
		private Grade grade;
		private MeatType meatType;

		public Meat() : this(default, default, default, default) { }

		public Meat(String name, decimal price=0, Grade grade = Grade.VS, MeatType meatTypem = MeatType.Beef) : base( name,  price)
		{
			this.grade = grade;
			this.meatType = meatTypem;
		}
		

		public override void IncrisePrice(int Percent)
		{
			 price = Math.Round(price+(100+Percent+Values.PersentOfGrade(grade)+Values.PersentOfMeatType(meatType))/100,2);
		}

        public override string ToString()
        {
            return grade.ToString() + ' ' + meatType.ToString()+' '+base.ToString();
        }
    }
}

